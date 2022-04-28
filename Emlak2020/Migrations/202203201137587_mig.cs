namespace Emlak2020.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Durums",
                c => new
                    {
                        DurumId = c.Int(nullable: false, identity: true),
                        DurumAd = c.String(),
                    })
                .PrimaryKey(t => t.DurumId);
            
            CreateTable(
                "dbo.Tips",
                c => new
                    {
                        TipId = c.Int(nullable: false, identity: true),
                        TipAd = c.String(),
                        DurumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipId)
                .ForeignKey("dbo.Durums", t => t.DurumId, cascadeDelete: true)
                .Index(t => t.DurumId);
            
            CreateTable(
                "dbo.Ilans",
                c => new
                    {
                        IlanId = c.Int(nullable: false, identity: true),
                        Açıklama = c.String(),
                        Fiyat = c.Double(nullable: false),
                        OdaSayısı = c.Int(nullable: false),
                        BanyoSayısı = c.Int(nullable: false),
                        Kredi = c.Boolean(nullable: false),
                        Alan = c.Int(nullable: false),
                        Kat = c.String(),
                        Tarih = c.DateTime(),
                        Telefon = c.String(),
                        Sitede = c.Boolean(nullable: false),
                        Aidat = c.Int(nullable: false),
                        Takas = c.Boolean(nullable: false),
                        Adres = c.String(),
                        UserName = c.String(),
                        SehirId = c.Int(nullable: false),
                        SemtId = c.Int(nullable: false),
                        DurumId = c.Int(nullable: false),
                        MahalleId = c.Int(nullable: false),
                        TipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IlanId)
                .ForeignKey("dbo.Mahalles", t => t.MahalleId, cascadeDelete: true)
                .ForeignKey("dbo.Tips", t => t.TipId, cascadeDelete: true)
                .Index(t => t.MahalleId)
                .Index(t => t.TipId);
            
            CreateTable(
                "dbo.Mahalles",
                c => new
                    {
                        MahalleId = c.Int(nullable: false, identity: true),
                        MahalleAd = c.String(),
                        SemtId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MahalleId)
                .ForeignKey("dbo.Semts", t => t.SemtId, cascadeDelete: true)
                .Index(t => t.SemtId);
            
            CreateTable(
                "dbo.Semts",
                c => new
                    {
                        SemtId = c.Int(nullable: false, identity: true),
                        SemtAd = c.String(),
                        SehirId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SemtId)
                .ForeignKey("dbo.Sehirs", t => t.SehirId, cascadeDelete: true)
                .Index(t => t.SehirId);
            
            CreateTable(
                "dbo.Sehirs",
                c => new
                    {
                        SehirId = c.Int(nullable: false, identity: true),
                        SehirAd = c.String(),
                    })
                .PrimaryKey(t => t.SehirId);
            
            CreateTable(
                "dbo.Resims",
                c => new
                    {
                        ResimId = c.Int(nullable: false, identity: true),
                        ResimAd = c.String(),
                        IlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResimId)
                .ForeignKey("dbo.Ilans", t => t.IlanId, cascadeDelete: true)
                .Index(t => t.IlanId);
            
            CreateTable(
                "dbo.Kullanıcı",
                c => new
                    {
                        vatId = c.Int(nullable: false, identity: true),
                        vatEmail = c.String(),
                        vatParola = c.String(),
                        TelefonNo = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.vatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ilans", "TipId", "dbo.Tips");
            DropForeignKey("dbo.Resims", "IlanId", "dbo.Ilans");
            DropForeignKey("dbo.Ilans", "MahalleId", "dbo.Mahalles");
            DropForeignKey("dbo.Semts", "SehirId", "dbo.Sehirs");
            DropForeignKey("dbo.Mahalles", "SemtId", "dbo.Semts");
            DropForeignKey("dbo.Tips", "DurumId", "dbo.Durums");
            DropIndex("dbo.Resims", new[] { "IlanId" });
            DropIndex("dbo.Semts", new[] { "SehirId" });
            DropIndex("dbo.Mahalles", new[] { "SemtId" });
            DropIndex("dbo.Ilans", new[] { "TipId" });
            DropIndex("dbo.Ilans", new[] { "MahalleId" });
            DropIndex("dbo.Tips", new[] { "DurumId" });
            DropTable("dbo.Kullanıcı");
            DropTable("dbo.Resims");
            DropTable("dbo.Sehirs");
            DropTable("dbo.Semts");
            DropTable("dbo.Mahalles");
            DropTable("dbo.Ilans");
            DropTable("dbo.Tips");
            DropTable("dbo.Durums");
        }
    }
}
