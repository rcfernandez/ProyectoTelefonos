namespace ProyectoTelefonos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Area", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.SubArea", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Interno", "Observacion", c => c.String(maxLength: 500));
            AlterColumn("dbo.Directo", "Numero", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Directo", "Numero", c => c.Long(nullable: false));
            AlterColumn("dbo.Interno", "Observacion", c => c.String());
            AlterColumn("dbo.SubArea", "Nombre", c => c.String());
            AlterColumn("dbo.Area", "Nombre", c => c.String());
        }
    }
}
