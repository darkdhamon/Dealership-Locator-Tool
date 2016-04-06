using System.Data.Entity.Migrations;

namespace DealershipModel.Migrations
{
   public partial class RemoveAddressContraints : DbMigration
   {
      public override void Up()
      {
         DropIndex("dbo.Addresses", "FullAddress");
         AlterColumn("dbo.Addresses", "StreetAddress", c => c.String(false));
         AlterColumn("dbo.Addresses", "City", c => c.String());
         AlterColumn("dbo.Addresses", "State", c => c.String());
         AlterColumn("dbo.Addresses", "ZipCode", c => c.String());
      }

      public override void Down()
      {
         AlterColumn("dbo.Addresses", "ZipCode", c => c.String(maxLength: 10));
         AlterColumn("dbo.Addresses", "State", c => c.String(maxLength: 2));
         AlterColumn("dbo.Addresses", "City", c => c.String(maxLength: 50));
         AlterColumn("dbo.Addresses", "StreetAddress", c => c.String(false, 250));
         CreateIndex("dbo.Addresses", new[] {"StreetAddress", "ZipCode"}, true, "FullAddress");
      }
   }
}