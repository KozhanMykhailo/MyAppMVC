using MyAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MyAppMVC.Repository
{
	public static class TeamsRepositipy
	{
		public static IList<Team> TeamsCollection { get; set; }
		public static IList<Team> GetTeamsCollection()
		{
			if (TeamsCollection == null)
			{
				TeamsCollection = new List<Team>();
				using (MatchesContext db = new MatchesContext())
				{
					foreach (var item in db.Teams)
					{
						TeamsCollection.Add(new Team() { TeamName = item.TeamName, City = item.City, Id = item.Id });
					}
				}
				return TeamsCollection;
			}
			else
				return TeamsCollection;
		}
		public static Team GetTeamFromCollection(int id)
		{
			if (TeamsCollection.Where(w => w.Id == id).Any())
				return TeamsCollection.Where(w => w.Id == id).FirstOrDefault();
			else
				return new Team() { Id = 0, City = "Error", TeamName = "Error" };
		}
		public static void UpdateDataTeam(Team updTeam)
		{
			var team = TeamsCollection.Where(w => w.Id == updTeam.Id).FirstOrDefault();
			if (team != null)
			{
				team.TeamName = updTeam.TeamName;
				team.City = updTeam.City;
				team.Id = updTeam.Id;
				SaveChangesInDB(updTeam, EntityState.Modified);
			}
		}

		internal static bool CreateRow(Team newTeam)
		{
			if (newTeam == null)
			{
				return false;
			}
			if (newTeam.Id == 0)
			{
				newTeam.Id = TeamsCollection.Max(m => m.Id) + 1;
			}
			if (SaveChangesInDB(newTeam, EntityState.Added))
			{
				if (TeamsCollection == null)
				{
					TeamsCollection = new List<Team>();
				}
				TeamsCollection.Add(newTeam);
				return true;
			}
			else
			{
				return false;
			}

		}

		public static void DeleteRow(int id)
		{
			var delRow = GetTeamFromCollection(id);
			if (delRow != null)
			{
				if(SaveChangesInDB(delRow, EntityState.Deleted))
				TeamsCollection.Remove(delRow);
			}
		}
		private static bool SaveChangesInDB(Team team, EntityState entityState)
		{
			using (MatchesContext db = new MatchesContext())
			{
				switch (entityState)
				{
					case EntityState.Added:
						db.Entry<Team>(team).State = EntityState.Added;
						break;
					case EntityState.Modified:
						db.Entry<Team>(team).State = EntityState.Modified;
						break;
					case EntityState.Deleted:
						db.Entry<Team>(team).State = EntityState.Deleted;
						break;
					default: return false;
				}
				if (db.SaveChanges() > 0)
					return true;
				else
					return false;
			}
		}
	}
}