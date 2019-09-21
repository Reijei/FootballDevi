using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballxG.Models
{
    public class Practise
    {
        [Key]
        public int? PractiseID { get; set; }
        public DateTime? DateTime { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TeamName { get; set; }
        public int? Goals { get; set; }
        public int? Corners { get; set; }
        public int? Side { get; set; }
        public int? Free { get; set; }
        public int? Total { get; set; }
        public float? Xg { get; set; }
    }
}
