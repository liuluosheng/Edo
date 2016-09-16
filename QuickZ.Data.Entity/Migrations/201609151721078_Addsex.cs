namespace QuickZ.Data.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addsex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Sex", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Sex");
        }
    }
}
