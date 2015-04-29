namespace GuitarMate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuitarPlayers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        Location = c.String(),
                        Instrument = c.String(),
                        AdDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuitarPlayers");
        }
    }
}
