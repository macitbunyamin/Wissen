using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wissen.Models
{
    public class DenemeForm
    {  
        [Required(ErrorMessage ="{0} alanı çok  gereklidir")]
        [MaxLength(50,ErrorMessage ="{0}alanı en fazla {1} karakter uzunlugunda olabilir")]
        [Display(Name ="ad")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "{0} alanı  cok ama cok gereklidir")]
        [MaxLength(50, ErrorMessage = "{0}alanı en fazla {1} karakter uzunlugunda olabilir")]
        [Display(Name = "soyad")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        [Display(Name = "email")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [MaxLength(50)]
        [Display(Name = "telefon")]
        public string Phone { get; set; }

    }
}