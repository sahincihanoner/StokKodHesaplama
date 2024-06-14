namespace StokKodHesaplama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fatih3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "Adet", c => c.Int());
            AddColumn("dbo.Stocks", "Desi", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "Fiyat", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "Komisyon", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "Maliyet", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "Kar", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "Tarih", c => c.DateTime(precision: 0));
            AlterColumn("dbo.Stocks", "BirimKargoUcreti", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Stocks", "ToplamKargoUcreti", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Stocks", "SatisAdeti");
            DropColumn("dbo.Stocks", "SatisFiyati");
            DropColumn("dbo.Stocks", "ToplamSatisFiyati");
            DropColumn("dbo.Stocks", "KomisyonTutari");
            DropColumn("dbo.Stocks", "UrunMaliyeti");
            DropColumn("dbo.Stocks", "Kazanc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "Kazanc", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "UrunMaliyeti", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "KomisyonTutari", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "ToplamSatisFiyati", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "SatisFiyati", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "SatisAdeti", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "ToplamKargoUcreti", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stocks", "BirimKargoUcreti", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Stocks", "Tarih");
            DropColumn("dbo.Stocks", "Kar");
            DropColumn("dbo.Stocks", "Maliyet");
            DropColumn("dbo.Stocks", "Komisyon");
            DropColumn("dbo.Stocks", "Fiyat");
            DropColumn("dbo.Stocks", "Desi");
            DropColumn("dbo.Stocks", "Adet");
        }
    }
}
