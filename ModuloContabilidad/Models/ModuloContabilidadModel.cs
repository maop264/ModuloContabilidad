namespace ModuloContabilidad.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModuloContabilidadModel : DbContext
    {
        public ModuloContabilidadModel()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
        public virtual DbSet<TipoRegistro> TipoRegistros { get; set; }
        public virtual DbSet<RegistroXProducto> RegistroXProductos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Registros)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CodReferencia)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.RegistroXProductos)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Registro>()
                .Property(e => e.NumeroFactura)
                .IsUnicode(false);

            modelBuilder.Entity<Registro>()
                .Property(e => e.Concepto)
                .IsUnicode(false);

            modelBuilder.Entity<Registro>()
                .HasMany(e => e.RegistroXProductos)
                .WithRequired(e => e.Registro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoRegistro>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoRegistro>()
                .HasMany(e => e.Registros)
                .WithRequired(e => e.TipoRegistro)
                .WillCascadeOnDelete(false);
        }
    }
}
