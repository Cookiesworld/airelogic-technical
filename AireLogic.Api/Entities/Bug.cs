using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AireLogic.Api.Entities
{
    public class Bug
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public BugState BugState { get; set; }

        [ForeignKey("PersonId")]
        public Person AssignedPerson { get; set; }

        public Guid PersonId { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}
