using System.ComponentModel.DataAnnotations;
namespace FPSTracker.Models
{
    public class Match
    {
        public int MatchId { get; set; }

        [Required]
        [MaxLength(4)]
        //checking that input is only the word win o loss
        //found here https://www.geeksforgeeks.org/what-is-regular-expression-in-c-sharp/#:~:text=In%20C%23%2C%20Regular%20Expression%20is,that%20allows%20the%20pattern%20matching.
        [RegularExpression("Win|Loss|win|loss", ErrorMessage = "Must Enter Win or Loss")]
        public string? WinOrLoss { get; set; }

        [Range(0, 10, ErrorMessage = "Enter a number between 0 - 10")]
        [DisplayFormat(DataFormatString ="{0:0.00}")]//always displaying 2 decimal places found here https://stackoverflow.com/questions/3923242/showing-number-in-2-decimal-places-in-gridview
        public decimal? Ratio { get; set; }

        [Range(0, 10000, ErrorMessage = "Enter a number between 0 - 10,000")]
        public int? TeamScore { get; set; }

        [Range(0, 10000, ErrorMessage = "Enter a number between 0 - 10,000")]
        public int? OpponentScore { get; set; }

        //FK for reference
        public int? GameId { get; set; }
        public Game? Game { get; set; }

        //FK for reference
        public int UserNameId { get; set; }
        public UserName? UserName { get; set; }
    }
}
