namespace MyCV_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cvs", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Experiences", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Formations", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Languages", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Skills", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Contacts");
            AddPrimaryKey("dbo.Contacts", "Id");
            DropPrimaryKey("dbo.Cvs");
            AddPrimaryKey("dbo.Cvs", "Id");
            DropPrimaryKey("dbo.Experiences");
            AddPrimaryKey("dbo.Experiences", "Id");
            DropPrimaryKey("dbo.Formations");
            AddPrimaryKey("dbo.Formations", "Id");
            DropPrimaryKey("dbo.Languages");
            AddPrimaryKey("dbo.Languages", "Id");
            DropPrimaryKey("dbo.Skills");
            AddPrimaryKey("dbo.Skills", "Id");
            DropColumn("dbo.Contacts", "ContactID");
            DropColumn("dbo.Cvs", "CvId");
            DropColumn("dbo.Experiences", "ExperienceID");
            DropColumn("dbo.Formations", "FormationID");
            DropColumn("dbo.Languages", "LanguageID");
            DropColumn("dbo.Skills", "SkillID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "SkillID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Languages", "LanguageID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Formations", "FormationID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Experiences", "ExperienceID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cvs", "CvId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Contacts", "ContactID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Skills");
            AddPrimaryKey("dbo.Skills", "SkillID");
            DropPrimaryKey("dbo.Languages");
            AddPrimaryKey("dbo.Languages", "LanguageID");
            DropPrimaryKey("dbo.Formations");
            AddPrimaryKey("dbo.Formations", "FormationID");
            DropPrimaryKey("dbo.Experiences");
            AddPrimaryKey("dbo.Experiences", "ExperienceID");
            DropPrimaryKey("dbo.Cvs");
            AddPrimaryKey("dbo.Cvs", "CvId");
            DropPrimaryKey("dbo.Contacts");
            AddPrimaryKey("dbo.Contacts", "ContactID");
            DropColumn("dbo.Skills", "Id");
            DropColumn("dbo.Languages", "Id");
            DropColumn("dbo.Formations", "Id");
            DropColumn("dbo.Experiences", "Id");
            DropColumn("dbo.Cvs", "Id");
            DropColumn("dbo.Contacts", "Id");
        }
    }
}
