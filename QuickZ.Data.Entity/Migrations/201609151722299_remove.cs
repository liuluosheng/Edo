namespace QuickZ.Data.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Age");
            DropColumn("dbo.Users", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Sex", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
        }
    }
}
