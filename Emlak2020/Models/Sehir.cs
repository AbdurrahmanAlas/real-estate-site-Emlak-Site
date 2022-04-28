using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emlak2020.Models
{
    public class Sehir
    {

        [Key]
        public int SehirId { get; set; }
        public string SehirAd { get; set; }
        public List<Semt>Semts { get; set; }

    }
}