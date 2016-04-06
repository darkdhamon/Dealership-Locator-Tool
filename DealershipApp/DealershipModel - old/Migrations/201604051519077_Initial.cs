using System.Data.Entity.Migrations;

namespace DealershipModel.Migrations
{
   public partial class Initial : DbMigration
   {
      public override void Up()
      {
         CreateTable(
            "dbo.Addresses",
            c => new
            {
               Id = c.Int(false, true),
               StreetAddress = c.String(false, 250),
               City = c.String(maxLength: 50),
               State = c.String(maxLength: 2),
               ZipCode = c.String(maxLength: 10),
               Latitude = c.Double(),
               Longitude = c.Double()
            })
            .PrimaryKey(t => t.Id)
            .Index(t => new {t.StreetAddress, t.City, t.State, t.ZipCode}, unique: true, name: "FullAddress");

         CreateTable(
            "dbo.Dealerships",
            c => new
            {
               Id = c.Int(false, true),
               Manager = c.String(),
               Phone = c.String(),
               Address_Id = c.Int()
            })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Addresses", t => t.Address_Id)
            .Index(t => t.Address_Id);

         CreateTable(
            "dbo.Vehicles",
            c => new
            {
               Id = c.Int(false, true),
               Make = c.String(),
               Model = c.String(),
               Year = c.String(),
               ImgURL = c.String(false),
               Dealership_Id = c.Int()
            })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Dealerships", t => t.Dealership_Id)
            .Index(t => t.Dealership_Id);
      }

      public override void Down()
      {
         DropForeignKey("dbo.Vehicles", "Dealership_Id", "dbo.Dealerships");
         DropForeignKey("dbo.Dealerships", "Address_Id", "dbo.Addresses");
         DropIndex("dbo.Vehicles", new[] {"Dealership_Id"});
         DropIndex("dbo.Dealerships", new[] {"Address_Id"});
         DropIndex("dbo.Addresses", "FullAddress");
         DropTable("dbo.Vehicles");
         DropTable("dbo.Dealerships");
         DropTable("dbo.Addresses");
      }
   }
}