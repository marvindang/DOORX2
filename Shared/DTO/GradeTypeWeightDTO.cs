using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOOR.Shared.DTO
{
	public class GradeTypeWeightDTO
	{
        [Key]
        [Precision(8)]
        public int SchoolId { get; set; }
        [Key]
        [Precision(8)]
        public int SectionId { get; set; }
        [Key]
        [StringLength(2)]
        [Unicode(false)]
        public string GradeTypeCode { get; set; } = null!;
        [Precision(3)]
        public byte NumberPerSection { get; set; }
        [Precision(3)]
        public byte PercentOfFinalGrade { get; set; }
        [Precision(1)]
        public bool DropLowest { get; set; }
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

