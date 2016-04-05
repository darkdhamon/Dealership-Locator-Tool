namespace DealershipModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModAddressUnqueContraint : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Addresses", "FullAddress");
            CreateIndex("dbo.Addresses", new[] { "StreetAddress", "ZipCode" }, unique: true, name: "FullAddress");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Addresses", "FullAddress");
            CreateIndex("dbo.Addresses", new[] { "StreetAddress", "City", "State", "ZipCode" }, unique: true, name: "FullAddress");
        }
    }
}
