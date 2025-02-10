using kurs_matematyki.Core.DTO;

namespace kurs_matematyki.Core.Entities
{
    public class UserManagerResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public AuthenticationResponse AuthenticationResponse { get; set; }
    }
}
