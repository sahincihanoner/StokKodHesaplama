namespace StokKodHesaplama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fatih : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockCodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StokKodu = c.String(unicode: false),
                        Desi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KomisyonTutari = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BirimKargoUcreti = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunMaliyeti = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tarih = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockCodes");
        }
    }
}
