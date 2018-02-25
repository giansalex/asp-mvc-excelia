namespace ExceliaMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Direction",
                c => new
                    {
                        DirectionId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                        Latitud = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitud = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserCreated = c.String(nullable: false, maxLength: 16),
                        Created = c.DateTime(nullable: false),
                        UserUpdated = c.String(maxLength: 16),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.DirectionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Direction");
        }
    }
}
