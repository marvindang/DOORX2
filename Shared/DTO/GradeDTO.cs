using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DOOR.Shared.DTO
{
	public class GradeDTO
	{
        [Key]
        [Precision(8)]
        public int SchoolId { get; set; }
        [Key]
        [Precision(8)]
        public int StudentId { get; set; }
        [Key]
        [Precision(8)]
        public int SectionId { get; set; }
        [Key]
        [StringLength(2)]
        [Unicode(false)]
        public string GradeTypeCode { get; set; } = null!;
        [Key]
        [Precision(3)]
        public byte GradeCodeOccurrence { get; set; }
        public decimal NumericGrade { get; set; }
        public string? Comments { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string ModifiedBy { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }
    }
}

