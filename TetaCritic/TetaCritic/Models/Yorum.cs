using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TetaCritic.Models
{
    public class Yorum
    {
        [Key]
        public int YorumId { get; set; }

        public string Icerik { get; set; }

        public DateTime? Zaman { get; set; }

        public int FilmId { get; set; }

        public int? Derece { get; set; }
    }
}