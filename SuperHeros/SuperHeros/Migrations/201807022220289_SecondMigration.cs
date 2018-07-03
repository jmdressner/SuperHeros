namespace SuperHeros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SuperHeroes");
            AddColumn("dbo.SuperHeroes", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SuperHeroes", "Name", c => c.String());
            AddPrimaryKey("dbo.SuperHeroes", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SuperHeroes");
            AlterColumn("dbo.SuperHeroes", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.SuperHeroes", "ID");
            AddPrimaryKey("dbo.SuperHeroes", "Name");
        }
    }
}
