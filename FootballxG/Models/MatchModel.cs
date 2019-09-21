using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballxG.Models
{
    public class MatchModel
    {
        [Key]
        public int? MatchID { get; set; }
        public DateTime? DateTime { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string HomeName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string AwayName { get; set; }
        public int? HomeGoals { get; set; }
        public int? AwayGoals { get; set; }
        public int? HomeCorners { get; set; }
        public int? AwayCorners { get; set; }
        public int? HomeSide { get; set; }
        public int? AwaySide { get; set; }
        public int? HomeFree { get; set; }
        public int? AwayFree { get; set; }
        public int? HomeTotal { get; set; }
        public int? AwayTotal { get; set; }
        public float? HomeXg { get; set; }
        public float? AwayXg { get; set; }

        public List<ShotModel> ShotModel { get; set; }

    }
}
