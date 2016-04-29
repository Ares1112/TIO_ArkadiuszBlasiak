namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(),
                        ArtistSurname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Paintings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.Paintings");
            DropTable("public.Artists");
        }
    }
}
