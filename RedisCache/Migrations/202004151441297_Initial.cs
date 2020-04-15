namespace RedisCache.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CountryMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StateMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateName = c.String(nullable: false, maxLength: 50),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryMasters", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StateMasters", "CountryId", "dbo.CountryMasters");
            DropIndex("dbo.StateMasters", new[] { "CountryId" });
            DropTable("dbo.StateMasters");
            DropTable("dbo.CountryMasters");
        }
    }
}
