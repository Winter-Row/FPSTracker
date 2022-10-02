using System.ComponentModel.DataAnnotations;
namespace FPSTracker.Models
{
    public class UserName
    {
        public int UserNameId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
        public List<Game>? Games { get; set; }

    }
}
