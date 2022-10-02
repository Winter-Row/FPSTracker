using System.ComponentModel.DataAnnotations;

namespace FPSTracker.Models
{
    public class Game
    {
        public int GameId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? GameName { get; set; }

        //FK for ref to UserNames
        public int UserNameId { get; set; }

        public UserName? UserName { get; set; }

    }
}
