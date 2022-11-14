using System.ComponentModel.DataAnnotations;

namespace FPSTracker.Models
{
    public class Game
    {
        public int GameId { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Game Name")]
        public string? GameName { get; set; }
        public string? Rating { get; set; }

        [DisplayFormat(DataFormatString = "{0:0GB}")]
        [Display(Name = "Game Size")]
        public int? GameSize { get; set; }
        public List<UserName>? Usernames { get; set; }


    }
}
