using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballxG.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int? Wins { get; set; }
        public int? Loses { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Serie { get; set; }
        public int? Position { get; set; }



    }
}
