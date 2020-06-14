using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class HomeInstructorDTO
    {
        [Required]
        [MinLength(4)]
        public string EntryCode { get; set; }
    }
}