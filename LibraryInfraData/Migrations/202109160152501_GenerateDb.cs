namespace LibraryInfraData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenerateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sexo",
                c => new
                    {
                        SexoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.SexoId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        SexoId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 30, unicode: false),
                        bit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Sexo", t => t.SexoId)
                .Index(t => t.SexoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "SexoId", "dbo.Sexo");
            DropIndex("dbo.Usuario", new[] { "SexoId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Sexo");
        }
    }
}
