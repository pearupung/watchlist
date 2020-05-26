using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace WebApp.ViewModels
{
    public class HomeIndexDTO
    {
        [Required]
        [MinLength(1)]
        public string InstructorName { get; set; }

        public List<InstructorDTO> Instructors { get; set; }
    }
}