namespace NoticiasWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noticiasweb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Noticias", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.Noticias", "Seccion_Id", "dbo.Seccions");
            DropIndex("dbo.Noticias", new[] { "Categoria_Id" });
            DropIndex("dbo.Noticias", new[] { "Seccion_Id" });
            CreateTable(
                "dbo.NoticiasCategorias",
                c => new
                    {
                        Noticias_Id = c.Int(nullable: false),
                        Categoria_Categoria_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Noticias_Id, t.Categoria_Categoria_Id })
                .ForeignKey("dbo.Noticias", t => t.Noticias_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Categoria_Id, cascadeDelete: true)
                .Index(t => t.Noticias_Id)
                .Index(t => t.Categoria_Categoria_Id);
            
            CreateTable(
                "dbo.SeccionNoticias",
                c => new
                    {
                        Seccion_Seccion_Id = c.Int(nullable: false),
                        Noticias_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seccion_Seccion_Id, t.Noticias_Id })
                .ForeignKey("dbo.Seccions", t => t.Seccion_Seccion_Id, cascadeDelete: true)
                .ForeignKey("dbo.Noticias", t => t.Noticias_Id, cascadeDelete: true)
                .Index(t => t.Seccion_Seccion_Id)
                .Index(t => t.Noticias_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeccionNoticias", "Noticias_Id", "dbo.Noticias");
            DropForeignKey("dbo.SeccionNoticias", "Seccion_Seccion_Id", "dbo.Seccions");
            DropForeignKey("dbo.NoticiasCategorias", "Categoria_Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.NoticiasCategorias", "Noticias_Id", "dbo.Noticias");
            DropIndex("dbo.SeccionNoticias", new[] { "Noticias_Id" });
            DropIndex("dbo.SeccionNoticias", new[] { "Seccion_Seccion_Id" });
            DropIndex("dbo.NoticiasCategorias", new[] { "Categoria_Categoria_Id" });
            DropIndex("dbo.NoticiasCategorias", new[] { "Noticias_Id" });
            DropTable("dbo.SeccionNoticias");
            DropTable("dbo.NoticiasCategorias");
            CreateIndex("dbo.Noticias", "Seccion_Id");
            CreateIndex("dbo.Noticias", "Categoria_Id");
            AddForeignKey("dbo.Noticias", "Seccion_Id", "dbo.Seccions", "Seccion_Id", cascadeDelete: true);
            AddForeignKey("dbo.Noticias", "Categoria_Id", "dbo.Categorias", "Categoria_Id", cascadeDelete: true);
        }
    }
}
