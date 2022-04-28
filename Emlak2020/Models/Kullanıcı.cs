using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emlak2020.Models
{
    public class Kullanıcı
    {
        [Key]
        public int vatId { get; set; }
        //[StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsin")]
        //[Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]
        public string vatEmail { get; set; }
        //[StringLength(30)]
        //[Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string vatParola { get; set; }
        //[StringLength(30)]
        //[Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string TelefonNo { get; set; }
        public string Role { get; set; }
    }
}