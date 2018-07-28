namespace ProyectoTelefonos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Internos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Numero = c.Long(nullable: false),
                        Tipo = c.String(),
                        Tn = c.Long(nullable: false),
                        Estado = c.String(),
                        Mostrar = c.Boolean(nullable: false),
                        Observacion = c.String(),
                        SubArea_id = c.Long(nullable: false),
                        Rack_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Racks", t => t.Rack_id, cascadeDelete: true)
                .ForeignKey("dbo.SubAreas", t => t.SubArea_id, cascadeDelete: true)
                .Index(t => t.SubArea_id)
                .Index(t => t.Rack_id);
            
            CreateTable(
                "dbo.Racks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Puesto = c.String(),
                        PuestoTel = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubAreas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                        Referente = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pisos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Numero = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PisoSubAreas",
                c => new
                    {
                        Piso_Id = c.Long(nullable: false),
                        SubArea_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Piso_Id, t.SubArea_Id })
                .ForeignKey("dbo.Pisos", t => t.Piso_Id, cascadeDelete: true)
                .ForeignKey("dbo.SubAreas", t => t.SubArea_Id, cascadeDelete: true)
                .Index(t => t.Piso_Id)
                .Index(t => t.SubArea_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Internos", "SubArea_id", "dbo.SubAreas");
            DropForeignKey("dbo.PisoSubAreas", "SubArea_Id", "dbo.SubAreas");
            DropForeignKey("dbo.PisoSubAreas", "Piso_Id", "dbo.Pisos");
            DropForeignKey("dbo.Internos", "Rack_id", "dbo.Racks");
            DropIndex("dbo.PisoSubAreas", new[] { "SubArea_Id" });
            DropIndex("dbo.PisoSubAreas", new[] { "Piso_Id" });
            DropIndex("dbo.Internos", new[] { "Rack_id" });
            DropIndex("dbo.Internos", new[] { "SubArea_id" });
            DropTable("dbo.PisoSubAreas");
            DropTable("dbo.Pisos");
            DropTable("dbo.SubAreas");
            DropTable("dbo.Racks");
            DropTable("dbo.Internos");
        }
    }
}
