using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOOR.Shared.DTO
{
	public class EnrollmentDTO
	{
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        public DateTime EnrollDate { get; set; }
        public byte? FinalGrade { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        [StringLength(30)]
        public string ModifiedBy { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }
        public int SchoolId { get; set; }
    }
}

