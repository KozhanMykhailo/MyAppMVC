using System.Collections.Generic;

namespace MyAppMVC.Models
{
	public class Team
	{
		public int Id { get; set; }
		public string TeamName { get; set; }
		public string City { get; set; }
		public ICollection<Match> Matches { get; set; }
	}
}