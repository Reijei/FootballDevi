using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballxG.Models
{
    public class Shot
    {
        [Key]
        public int? ShotID { get; set; }
        [Column(TypeName = "nvarchar(12)")]
        public DateTime? DateTime { get; set; }
        public int? Time { get; set; }
        public int? Half { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ShooterName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TeamName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Opponent { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Assist { get; set; }
        public double? PositionX { get; set; }
        public double? PositionY { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string BodyPart { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Result { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Breakway { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Pattern { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string BigChange { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string NoChange { get; set; }
        public int? Defenders { get; set; }
        public float? Xg { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Comments { get; set; }


        public int? MatchID { get; set; }
        public int? PractiseID { get; set; }

        public Match Match { get; set; }




    }
}
