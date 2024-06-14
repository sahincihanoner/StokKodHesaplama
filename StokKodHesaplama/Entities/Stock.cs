using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokKodHesaplama.Entities
{
    public class Stock
    {
        public int ID { get; set; }
        public string StokKodu { get; set; }
        public int? Adet { get; set; }

        public decimal? Desi { get; set; }
        public decimal? Fiyat { get; set; }
        public decimal? Komisyon { get; set; }
        public decimal? BirimKargoUcreti { get; set; }
        public decimal? ToplamKargoUcreti { get; set; }
        public decimal? Maliyet { get; set; }
        public decimal? Kar { get; set; }

        public DateTime? Tarih { get; set; }

    }

}
