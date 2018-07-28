namespace ProyectoTelefonos
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public class ModelDB : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'ModelDB' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'ProyectoTelefonos.ModelDB' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'ModelDB'  en el archivo de configuración de la aplicación.
        public ModelDB() : base("name=ModelDB")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Interno> Interno { get; set; }
        public DbSet<SubArea> SubArea { get; set; }
        public DbSet<Rack> Rack { get; set; }
        public DbSet<Piso> Piso { get; set; }
    }

    [Table("Internos")]
    public class Interno
    {
        public long Id { get; set; }
        public long Numero { get; set; }
        public string Tipo { get; set; }
        public long Tn { get; set; }
        public string Estado { get; set; }
        public bool Mostrar { get; set; }
        public string Observacion { get; set; }

        [ForeignKey("SubArea")]
        [Column("SubArea_id")]
        public virtual long SubArea_id { get; set; }
        public virtual SubArea SubArea { get; set; }

        [ForeignKey("Rack")]
        [Column("Rack_id")]
        public virtual long Rack_id { get; set; }
        public virtual Rack Rack { get; set; }
    }

    [Table("SubAreas")]
    public class SubArea
    {
        public SubArea()
        {
            Internos = new Collection<Interno>();
            Pisos = new Collection<Piso>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Referente { get; set; }

        public virtual ICollection<Interno> Internos { get; set; }
        public virtual ICollection<Piso> Pisos { get; set; }
    }

    [Table("Racks")]
    public class Rack
    {
        public Rack()
        {
            Internos = new Collection<Interno>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Puesto { get; set; }
        public long PuestoTel { get; set; }

        public virtual ICollection<Interno> Internos { get; set; }
    }

    [Table("Pisos")]
    public class Piso
    {
        public Piso()
        {
            SubAreas = new Collection<SubArea>();
        }

        public long Id { get; set; }
        public long Numero { get; set; }

        public virtual ICollection<SubArea> SubAreas { get; set; }
    }


}



//1. – Borrar el directorio Migrations de tu proyecto.
//2. – Borrar la tabla _MigrationsHistory de tu base de datos.
//3. – Ejecutar el siguiente comando en la consola de administración de paquetes.

//Enable-Migrations -EnableAutomaticMigrations -Force

//4. – Finalmente ejecutar:

//Add-Migration Initial