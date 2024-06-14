using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokKodHesaplama.Entities
{
    public class StockCode
    {
        public int ID { get; set; }
        public string StokKodu { get; set; }
        public decimal? Desi { get; set; }
        public decimal? Fiyat { get; set; }
        public decimal? KomisyonTutari { get; set; }
        public decimal? BirimKargoUcreti { get; set; }
        public decimal? UrunMaliyeti { get; set; }
        public DateTime? Tarih { get; set; }
    }
}
