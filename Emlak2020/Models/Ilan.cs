using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emlak2020.Models
{
    public class Ilan
    {

        public int IlanId { get; set; }
        public string Açıklama { get; set; }
        public double Fiyat { get; set; }
        public int OdaSayısı { get; set; }
        public int BanyoSayısı { get; set; }
        public bool Kredi { get; set; }
        public int Alan { get; set; }
        public string Kat { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        //public DateTime  { get; set; }
        public string Telefon { get; set; }
        public bool Sitede { get; set; }
        public int Aidat { get; set; }
        public bool Takas { get; set; }
        public string Adres { get; set; }
        public string UserName { get; set; }
        public int SehirId { get; set; }
        public int SemtId { get; set; }
        public int DurumId { get; set; }
        //public Durum Durum { get; set; }

        public int MahalleId { get; set; }
        public Mahalle Mahalle { get; set; }

        public int TipId { get; set; }
        public Tip Tip { get; set; }

        public List<Resim> Resims { get; set; }

    }
}