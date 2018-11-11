namespace ModuloContabilidad.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Productos")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            RegistroXProductos = new HashSet<RegistroXProducto>();
        }

        [Key]
        public int IdProducto { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string CodReferencia { get; set; }

        public string Descripcion { get; set; }

        public int ValorUnitario { get; set; }

        public int IVA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroXProducto> RegistroXProductos { get; set; }
    }
}
