using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TetaCritic.Models
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string Yonetmen { get; set; }
        public string Ozet { get; set; }
        public int VizyonTarihi { get; set; }
        public List<string> Oyuncular = new List<string>();

        public int KategoriId{ get; set; }
        Kategori Ktg;

}
}
