namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListItems",
                c => new
                    {
                        ListItemId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListItemId)
                .ForeignKey("dbo.Lists", t => t.ListId, cascadeDelete: true)
                .Index(t => t.ListId);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        IsCurrent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListItems", "ListId", "dbo.Lists");
            DropIndex("dbo.ListItems", new[] { "ListId" });
            DropTable("dbo.Lists");
            DropTable("dbo.ListItems");
        }
    }
}
