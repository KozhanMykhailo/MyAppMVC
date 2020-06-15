using MyAppMVC.Models;
using System;
using System.Collections.Generic;
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
			}
		}

		internal static void CreateRow(Team newTeam)
		{
			if(newTeam == null)
			{
				return;
			}
			if(TeamsCollection == null)
			{
				TeamsCollection = new List<Team>();
				TeamsCollection.Add(newTeam);
			}
			else
			{
				TeamsCollection.Add(newTeam);
			}
		}

		public static void DeleteRow(int id)
		{
			var delRow = GetTeamFromCollection(id);
			if (delRow != null)
			{
				TeamsCollection.Remove(delRow);
			}
		}
	}
}