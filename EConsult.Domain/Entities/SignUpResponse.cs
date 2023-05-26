using System.ComponentModel.DataAnnotations;

namespace Econsult.Domain.Entities
{
    public class SignUpResponse
    {
        public bool ISuccess { get;set; }
        public string Message { get;set; }
    }
}
