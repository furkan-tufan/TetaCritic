using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TetaCritic.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre girilmesi zorunludur!")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Mailinizi yanlış girdiniz")]
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "E-Posta girilmesi zorunludur!")]
        public string Email { get; set; }

        public string Nick { get; set; } //Adminlerin kullanıcı adı, emailidir.
    }
}
