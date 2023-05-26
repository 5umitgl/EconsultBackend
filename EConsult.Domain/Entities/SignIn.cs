using System.ComponentModel.DataAnnotations;

namespace Econsult.Domain.Entities
{
    public class SignIn
    {
        public class SignInRequest
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }
        public class SignInResponse
        {
            public bool ISuccess { get; set; }
            public string Message { get; set; }
            public string role{ get; set; }
            public string nametag { get; set; }
            public int id { get; set; }
            public int? isApproved { get; set; }
        }
    }
}
