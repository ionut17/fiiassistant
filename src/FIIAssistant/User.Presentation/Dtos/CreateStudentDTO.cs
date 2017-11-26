using System.ComponentModel.DataAnnotations;

namespace User.Presentation.Dtos
{
    public class CreateStudentDto
    {
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(3)]
        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        [Range(1,3)]
        public int Year { get; set; }
        
        [MaxLength(3)]
        public string Group { get; set; }
    }
}
