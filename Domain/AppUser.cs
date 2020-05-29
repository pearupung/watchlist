using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser<int> 
    {
        public bool IsInstructor { get; set; }

        public Pupil Pupil { get; set; }
        public Instructor Instructor { get; set; }
    }
}