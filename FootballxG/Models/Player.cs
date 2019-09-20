using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballxG.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public int TeamID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PlayerName { get; set; }
        public int? No { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Position { get; set; }
        public int? Matches { get; set; }
        public int? Minutes { get; set; }
        public int? Goals { get; set; }
        public int? Passes { get; set; }
        public int? Spots { get; set; }
        public int? CardYellow { get; set; }
        public int? CardRed { get; set; }
        public double? Xg { get; set; }
        public double? XgP { get; set; }
        public double? Xa { get; set; }
        public double? XaP { get; set; }
        public double? Xg90 { get; set; }
        public double? Xa90 { get; set; }

      
    }
}
