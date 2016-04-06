using System.Data.Entity.Migrations;

namespace DealershipModel.Migrations
{
   public partial class ModAddressUnqueContraint : DbMigration
   {
      public override void Up()
      {
         DropIndex("dbo.Addresses", "FullAddress");
         CreateIndex("dbo.Addresses", new[] {"StreetAddress", "ZipCode"}, true, "FullAddress");
      }

      public override void Down()
      {
         DropIndex("dbo.Addresses", "FullAddress");
         CreateIndex("dbo.Addresses", new[] {"StreetAddress", "City", "State", "ZipCode"}, true, "FullAddress");
      }
   }
}