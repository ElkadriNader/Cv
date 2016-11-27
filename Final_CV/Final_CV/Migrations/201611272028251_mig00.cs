namespace Final_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig00 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        value = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.Cvs",
                c => new
                    {
                        CvID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CvID);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceID = c.Int(nullable: false, identity: true),
                        Year = c.DateTime(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        CampanyName = c.String(),
                        CampanySite = c.String(),
                        ReferenceName = c.String(),
                        ReferenceContact = c.String(),
                    })
                .PrimaryKey(t => t.ExperienceID);
            
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        FormationID = c.Int(nullable: false, identity: true),
                        Year = c.DateTime(nullable: false),
                        Title = c.String(),
                        Place = c.String(),
                        Description = c.String(),
                        ReferenceName = c.String(),
                        ReferenceMail = c.String(),
                        ReferencePhone = c.String(),
                    })
                .PrimaryKey(t => t.FormationID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LangaugeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Niveau = c.Int(nullable: false),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.LangaugeID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Niveau = c.Int(nullable: false),
                        Logo = c.String(),
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
