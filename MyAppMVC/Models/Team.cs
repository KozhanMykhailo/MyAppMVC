using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyAppMVC.Models
{
	public class Team
	{
		[Display(Name = "ExampleId")]
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }
		[Required]
		public string TeamName { get; set; }
		public string City { get; set; }
	}
}