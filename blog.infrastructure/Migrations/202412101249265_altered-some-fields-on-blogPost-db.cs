namespace blog.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteredsomefieldsonblogPostdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPosts", "UpdatedByUserId", c => c.Int(nullable: false));
            AddColumn("dbo.BlogPosts", "UpdatedByName", c => c.String());
            AddColumn("dbo.BlogPosts", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsDeleted");
            DropColumn("dbo.BlogPosts", "DateUpdated");
            DropColumn("dbo.BlogPosts", "UpdatedByName");
            DropColumn("dbo.BlogPosts", "UpdatedByUserId");
        }
    }
}
