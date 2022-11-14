using System.ComponentModel.DataAnnotations;
namespace FPSTracker.Models
{
    public class Match
    {
        public int MatchId { get; set; }

        [Required]
        [Display(Name = "Win Or Loss")]
        public string? WinOrLoss { get; set; }

        [Range(0, 10, ErrorMessage = "Enter a number between 0 - 10")]
        [DisplayFormat(DataFormatString ="{0:0.00}")]//always displaying 2 decimal places found here https://stackoverflow.com/questions/3923242/showing-number-in-2-decimal-places-in-gridview
        public decimal? Ratio { get; set; }

        [Range(0, 10000, ErrorMessage = "Enter a number between 0 - 10,000")]
        [Display(Name = "Team Score")]
        public int? TeamScore { get; set; }

        [Range(0, 10000, ErrorMessage = "Enter a number between 0 - 10,000")]
        [Display(Name = "Oppeonent Score")]
        public int? OpponentScore { get; set; }

        //FK for reference
        [Display(Name = "Game")]
        public int? GameId { get; set; }
        public Game? Game { get; set; }

        //FK for reference
        [Display(Name = "User Name")]
        public int UserNameId { get; set; }
        public UserName? UserName { get; set; }
    }
}
