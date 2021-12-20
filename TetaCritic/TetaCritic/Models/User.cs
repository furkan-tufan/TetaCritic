using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TetaCritic.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(20, ErrorMessage = "Kullanıcı adı maksimum 20 karakter olmalı!")]
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı girilmesi zorunludur!")]
        public string Nick { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre girilmesi zorunludur!")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Mailinizi yanlış girdiniz")]
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "E-Posta girilmesi zorunludur!")]
        public string Email { get; set; }
    }
}
