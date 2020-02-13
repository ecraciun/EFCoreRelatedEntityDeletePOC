namespace EF6PossibleBug.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ZLast2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiddleId = c.Int(),
                        Bar = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Middles", t => t.MiddleId)
                .Index(t => t.MiddleId);
            
            CreateTable(
                "dbo.Middles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Foo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ZFirst3s",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiddleId = c.Int(),
                        Bar = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Middles", t => t.MiddleId)
                .Index(t => t.MiddleId);
            
            CreateTable(
                "dbo.Firsts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiddleId = c.Int(),
                        Bar = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Middles", t => t.MiddleId)
                .Index(t => t.MiddleId);
            
            CreateTable(
                "dbo.First2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiddleId = c.Int(),
                        Bar = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Middles", t => t.MiddleId)
                .Index(t => t.MiddleId);
            
            CreateTable(
                "dbo.AZLast3s",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiddleId = c.Int(),
                        Bar = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Middles", t => t.MiddleId)
                .Index(t => t.MiddleId);
            
            CreateTable(
                "dbo.ZLasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiddleId = c.Int(),
                        Bar = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Middles", t => t.MiddleId)
                .Index(t => t.MiddleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZLasts", "MiddleId", "dbo.Middles");
            DropForeignKey("dbo.AZLast3s", "MiddleId", "dbo.Middles");
            DropForeignKey("dbo.First2", "MiddleId", "dbo.Middles");
            DropForeignKey("dbo.Firsts", "MiddleId", "dbo.Middles");
            DropForeignKey("dbo.ZFirst3s", "MiddleId", "dbo.Middles");
            DropForeignKey("dbo.ZLast2", "MiddleId", "dbo.Middles");
            DropIndex("dbo.ZLasts", new[] { "MiddleId" });
            DropIndex("dbo.AZLast3s", new[] { "MiddleId" });
            DropIndex("dbo.First2", new[] { "MiddleId" });
            DropIndex("dbo.Firsts", new[] { "MiddleId" });
            DropIndex("dbo.ZFirst3s", new[] { "MiddleId" });
            DropIndex("dbo.ZLast2", new[] { "MiddleId" });
            DropTable("dbo.ZLasts");
            DropTable("dbo.AZLast3s");
            DropTable("dbo.First2");
            DropTable("dbo.Firsts");
            DropTable("dbo.ZFirst3s");
            DropTable("dbo.Middles");
            DropTable("dbo.ZLast2");
        }
    }
}
