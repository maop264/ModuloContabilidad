namespace ModuloContabilidad.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registros")]
    public partial class Registro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registro()
        {
            RegistroXProductos = new HashSet<RegistroXProducto>();
        }

        [Key]
        public int IdRegistro { get; set; }

        public DateTime FechaRegistro { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroFactura { get; set; }

        public double SubTotal { get; set; }

        public double IVA { get; set; }

        public int TotalFactura { get; set; }

        public int IdTipoRegistro { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual TipoRegistro TipoRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroXProducto> RegistroXProductos { get; set; }
    }
}
