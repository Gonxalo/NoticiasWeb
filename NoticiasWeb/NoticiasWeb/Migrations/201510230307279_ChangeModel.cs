namespace NoticiasWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Noticias", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Noticias", new[] { "Usuario_Id" });
            RenameColumn(table: "dbo.Noticias", name: "Usuario_Id", newName: "usuario_Usuario_Id");
            AlterColumn("dbo.Noticias", "usuario_Usuario_Id", c => c.Int());
            CreateIndex("dbo.Noticias", "usuario_Usuario_Id");
            AddForeignKey("dbo.Noticias", "usuario_Usuario_Id", "dbo.Usuarios", "Usuario_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Noticias", "usuario_Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Noticias", new[] { "usuario_Usuario_Id" });
            AlterColumn("dbo.Noticias", "usuario_Usuario_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Noticias", name: "usuario_Usuario_Id", newName: "Usuario_Id");
            CreateIndex("dbo.Noticias", "Usuario_Id");
            AddForeignKey("dbo.Noticias", "Usuario_Id", "dbo.Usuarios", "Usuario_Id", cascadeDelete: true);
        }
    }
}
