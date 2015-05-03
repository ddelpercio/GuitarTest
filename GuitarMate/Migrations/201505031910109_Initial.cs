namespace GuitarMate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuitarPlayers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(unicode: false),
                        Location = c.String(unicode: false),
                        Instrument = c.String(unicode: false),
                        AdDescription = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuitarPlayers");
        }
    }
}
