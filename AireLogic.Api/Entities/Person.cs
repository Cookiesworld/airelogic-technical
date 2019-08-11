using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AireLogic.Api.Entities
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public ICollection<Bug> Bugs { get; set; } = new List<Bug>();
    }
}
