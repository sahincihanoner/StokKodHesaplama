namespace StokKodHesaplama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fatih2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StockCodes", "Desi", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.StockCodes", "Fiyat", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.StockCodes", "KomisyonTutari", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.StockCodes", "BirimKargoUcreti", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.StockCodes", "UrunMaliyeti", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.StockCodes", "Tarih", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StockCodes", "Tarih", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.StockCodes", "UrunMaliyeti", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.StockCodes", "BirimKargoUcreti", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.StockCodes", "KomisyonTutari", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.StockCodes", "Fiyat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.StockCodes", "Desi", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
