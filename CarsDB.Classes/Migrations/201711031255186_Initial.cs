namespace CarsDB.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Colour = c.String(),
                        Model = c.String(),
                        CarType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarTypes", t => t.CarType_ID)
                .Index(t => t.CarType_ID);
            
            CreateTable(
                "dbo.CarTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Descr = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarType_ID", "dbo.CarTypes");
            DropIndex("dbo.Cars", new[] { "CarType_ID" });
            DropTable("dbo.CarTypes");
            DropTable("dbo.Cars");
        }
    }
}
