using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        [Display(Name = "Film Adı")]
        public string FilmAdi { get; set; }
        [Display(Name = "Yönetmen")]
        public string Yonetmen { get; set; }
        [Display(Name = "Özet")]
        public string Ozet { get; set; }
        [Display(Name = "Çıkış Yılı")]
        public int VizyonTarihi { get; set; }
        [Display(Name = "Afiş")]
        public string Afis { get; set; }
        [Display(Name = "Oyuncu Kadrosu")]
        public ICollection<Oyuncu> Oyuncular { get; set; }
        [Display(Name = "Kategori")]
        public Kategori Ktg { get; set; }
        public int KategoriId{ get; set; }

        public Film()
        {
            this.Oyuncular = new Collection<Oyuncu>();
        }
    }
}
