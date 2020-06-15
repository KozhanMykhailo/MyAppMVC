using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAppMVC.Models
{
	public class GemaPlayer
	{
		[Key]
		[Column(Order = 0)]
		public int PlayerId { get; set; }
		[Key]
		[Column(Order =1)]
		public int MatchId { get; set; }
	}
}