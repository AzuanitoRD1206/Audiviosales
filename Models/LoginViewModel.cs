// LoginViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace CrudAudiovisuales.Models
{
    public class LoginViewModel
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
