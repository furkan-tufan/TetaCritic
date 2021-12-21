using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TetaCritic.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Display(Name = "Kategori Adı")]
        public string KategoriAdi { get; set; }
        [Display(Name = "Film Listesi")]
        public virtual ICollection<Film> FilmListesi { get; set; }

        public Kategori()
        {
            this.FilmListesi = new Collection<Film>();
        }
    }
}
