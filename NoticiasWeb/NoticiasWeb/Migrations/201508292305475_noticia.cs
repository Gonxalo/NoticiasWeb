namespace NoticiasWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noticia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Categoria_Id = c.Int(nullable: false, identity: true),
                        NombreCategoria = c.String(nullable: false, maxLength: 200),
                        DescripcionCategoria = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 300),
                        Cuerpo = c.String(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        CreadoPor = c.Int(nullable: false),
                        FechaCreacion = c.String(nullable: false, maxLength: 20),
                        EditadoPor = c.Int(nullable: false),
                        Categoria_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                        Seccion_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id, cascadeDelete: true)
                .ForeignKey("dbo.Seccions", t => t.Seccion_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Seccion_Id);
            
            CreateTable(
                "dbo.Seccions",
                c => new
                    {
                        Seccion_Id = c.Int(nullable: false, identity: true),
                        NombreSeccion = c.String(nullable: false, maxLength: 50),
                        DescripcionSeccion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Seccion_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Usuario_Id = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false, maxLength: 50),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 50),
                        ApellidoMaterno = c.String(nullable: false, maxLength: 50),
                        FechaNaciemiento = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Noticias", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Noticias", "Seccion_Id", "dbo.Seccions");
            DropForeignKey("dbo.Noticias", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.Noticias", new[] { "Seccion_Id" });
            DropIndex("dbo.Noticias", new[] { "Usuario_Id" });
            DropIndex("dbo.Noticias", new[] { "Categoria_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Seccions");
            DropTable("dbo.Noticias");
            DropTable("dbo.Categorias");
        }
    }
}
