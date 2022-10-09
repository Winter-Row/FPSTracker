using System.ComponentModel.DataAnnotations;
namespace FPSTracker.Models
{
    public class UserName
    {
        public int UserNameId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }

    }
}
