namespace MyAppMVC.Models
{
	public class Match
	{
        public int Id { get; set; }
        public string Stadium { get; set; }
        public int TeamA { get; set; }
        public int TeamB { get; set; }
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}