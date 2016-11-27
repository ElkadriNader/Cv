namespace Final_CV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig001 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Languages", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Languages", "Name", c => c.String());
        }
    }
}
