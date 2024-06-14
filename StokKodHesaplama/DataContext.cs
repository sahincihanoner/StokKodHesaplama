using StokKodHesaplama.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokKodHesaplama
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class DataContext:DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockCode> StockCode { get; set; }


    }
}
