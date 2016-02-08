namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePaths : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilePaths", "PostId", "dbo.Post");
            DropIndex("dbo.FilePaths", new[] { "PostId" });
            DropTable("dbo.FilePaths");
        }
    }
}
