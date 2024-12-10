namespace blog.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setdateUpdateanddateDeletedtonullableonBlogPosttbl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.BlogPosts", "DateDeleted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "DateDeleted", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BlogPosts", "DateUpdated", c => c.DateTime(nullable: false));
        }
    }
}
