using System.ComponentModel.DataAnnotations;

namespace Econsult.Domain.Entities
{
    public class NewUser
    {
        [Key]  public int UserId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

       
    }
}
