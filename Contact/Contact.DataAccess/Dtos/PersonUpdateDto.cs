using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Contact.DataAccess.Dtos
{
    public class PersonUpdateDto : IDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Surname { get; set; }
        [MaxLength(300)]
        public string Company { get; set; }
    }
}
