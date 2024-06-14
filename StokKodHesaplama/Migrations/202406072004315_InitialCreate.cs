namespace StokKodHesaplama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StokKodu = c.String(unicode: false),
                        SatisAdeti = c.Int(nullable: false),
                        SatisFiyati = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamSatisFiyati = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KomisyonTutari = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BirimKargoUcreti = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamKargoUcreti = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunMaliyeti = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kazanc = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stocks");
        }
    }
}
