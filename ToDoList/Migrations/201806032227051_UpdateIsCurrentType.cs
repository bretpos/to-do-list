namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIsCurrentType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lists", "IsCurrent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lists", "IsCurrent", c => c.Int(nullable: false));
        }
    }
}
