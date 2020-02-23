namespace projetASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                        prenom = c.String(nullable: false),
                        cin = c.String(nullable: false),
                        cne = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        date_naissance = c.DateTime(nullable: false),
                        filiere = c.String(),
                        tele = c.Int(nullable: false),
                        address = c.String(),
                        ville = c.String(),
                        prev_etablissement = c.String(),
                        type_diplome = c.String(),
                        note = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Etudiants");
            DropTable("dbo.Admins");
        }
    }
}
