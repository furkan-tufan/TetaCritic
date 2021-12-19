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
        [Display(Name = "Yönetmen")]
        public string Yonetmen { get; set; }
        [Display(Name = "Özet")]
        public string Ozet { get; set; }
       // [DataType(DataType.Date)]
        [Display(Name = "Vizyon Tarihi")]
        public int VizyonTarihi { get; set; }
        [Display(Name = "Oyuncu Kadrosu")]
        public List<string> Oyuncular = new List<string>();
        [Display(Name = "Kategori")]
        public Kategori Ktg { get; set; }
        public int KategoriId{ get; set; }

    }
}
