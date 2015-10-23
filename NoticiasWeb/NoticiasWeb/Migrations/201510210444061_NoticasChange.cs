namespace NoticiasWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoticasChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NoticiasCategorias", "Noticias_Id", "dbo.Noticias");
            DropForeignKey("dbo.NoticiasCategorias", "Categoria_Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.SeccionNoticias", "Seccion_Seccion_Id", "dbo.Seccions");
            DropForeignKey("dbo.SeccionNoticias", "Noticias_Id", "dbo.Noticias");
            DropIndex("dbo.NoticiasCategorias", new[] { "Noticias_Id" });
            DropIndex("dbo.NoticiasCategorias", new[] { "Categoria_Categoria_Id" });
            DropIndex("dbo.SeccionNoticias", new[] { "Seccion_Seccion_Id" });
            DropIndex("dbo.SeccionNoticias", new[] { "Noticias_Id" });
            AddColumn("dbo.Noticias", "categoria_Categoria_Id", c => c.Int());
            AddColumn("dbo.Noticias", "seccion_Seccion_Id", c => c.Int());
            CreateIndex("dbo.Noticias", "categoria_Categoria_Id");
            CreateIndex("dbo.Noticias", "seccion_Seccion_Id");
            AddForeignKey("dbo.Noticias", "categoria_Categoria_Id", "dbo.Categorias", "Categoria_Id");
            AddForeignKey("dbo.Noticias", "seccion_Seccion_Id", "dbo.Seccions", "Seccion_Id");
            DropColumn("dbo.Noticias", "Categoria_Id");
            DropColumn("dbo.Noticias", "Seccion_Id");
            DropTable("dbo.NoticiasCategorias");
            DropTable("dbo.SeccionNoticias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SeccionNoticias",
                c => new
                    {
                        Seccion_Seccion_Id = c.Int(nullable: false),
                        Noticias_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seccion_Seccion_Id, t.Noticias_Id });
            
            CreateTable(
                "dbo.NoticiasCategorias",
                c => new
                    {
                        Noticias_Id = c.Int(nullable: false),
                        Categoria_Categoria_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Noticias_Id, t.Categoria_Categoria_Id });
            
            AddColumn("dbo.Noticias", "Seccion_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Noticias", "Categoria_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Noticias", "seccion_Seccion_Id", "dbo.Seccions");
            DropForeignKey("dbo.Noticias", "categoria_Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.Noticias", new[] { "seccion_Seccion_Id" });
            DropIndex("dbo.Noticias", new[] { "categoria_Categoria_Id" });
            DropColumn("dbo.Noticias", "seccion_Seccion_Id");
            DropColumn("dbo.Noticias", "categoria_Categoria_Id");
            CreateIndex("dbo.SeccionNoticias", "Noticias_Id");
            CreateIndex("dbo.SeccionNoticias", "Seccion_Seccion_Id");
            CreateIndex("dbo.NoticiasCategorias", "Categoria_Categoria_Id");
            CreateIndex("dbo.NoticiasCategorias", "Noticias_Id");
            AddForeignKey("dbo.SeccionNoticias", "Noticias_Id", "dbo.Noticias", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SeccionNoticias", "Seccion_Seccion_Id", "dbo.Seccions", "Seccion_Id", cascadeDelete: true);
            AddForeignKey("dbo.NoticiasCategorias", "Categoria_Categoria_Id", "dbo.Categorias", "Categoria_Id", cascadeDelete: true);
            AddForeignKey("dbo.NoticiasCategorias", "Noticias_Id", "dbo.Noticias", "Id", cascadeDelete: true);
        }
    }
}
