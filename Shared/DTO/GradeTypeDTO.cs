using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOOR.Shared.DTO
{
    public class GradeTypeDTO
    {
        public int SchoolId { get; set; }
        [StringLength(2)]
        public string GradeTypeCode { get; set; } = null!;
        [StringLength(50)]
        public string Description { get; set; } = null!;
        [StringLength(30)]
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        [StringLength(30)]
        public string ModifiedBy { get; set; } = null!;

        public DateTime ModifiedDate { get; set; }
    }
}


