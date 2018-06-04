namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIsCurrentToIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lists", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Lists", "IsCurrent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lists", "IsCurrent", c => c.Boolean(nullable: false));
            DropColumn("dbo.Lists", "IsActive");
        }
    }
}
