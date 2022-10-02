using System.ComponentModel.DataAnnotations;
namespace FPSTracker.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        [Required]
        [MaxLength(4)]
        public string? WinOrLoss { get; set; }
        public float? Ratio { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }
    }
}
