using System.ComponentModel.DataAnnotations;

namespace MyAppMVC.Models
{
	public class GemaPlayer
	{
		[Key]
		public int PlayerId { get; set; }
		public int Match { get; set; }//original - MatchId 
	}
}