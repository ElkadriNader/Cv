namespace MyCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false),
                        value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.Cvs",
                c => new
                    {
                        CvId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CvId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceID = c.Int(nullable: false, identity: true),
                        Year = c.DateTime(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CampanyName = c.String(nullable: false),
                        CampanySite = c.String(nullable: false),
                        ReferenceName = c.String(nullable: false),
                        ReferenceContact = c.String(),
                    })
                .PrimaryKey(t => t.ExperienceID);
            
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        FormationID = c.Int(nullable: false, identity: true),
                        Year = c.DateTime(nullable: false),
                        Title = c.String(nullable: false),
                        Place = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ReferenceName = c.String(nullable: false),
                        ReferenceMail = c.String(),
                        ReferencePhone = c.String(),
                    })
                .PrimaryKey(t => t.FormationID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        Langue = c.String(nullable: false),
                        Niveau = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Niveau = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
            DropTable("dbo.Languages");
            DropTable("dbo.Formations");
            DropTable("dbo.Experiences");
            DropTable("dbo.Cvs");
            DropTable("dbo.Contacts");
        }
    }
}
