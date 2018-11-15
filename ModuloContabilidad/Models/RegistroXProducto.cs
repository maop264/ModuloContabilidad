namespace ModuloContabilidad.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistroXProductos")]
    public partial class RegistroXProducto
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRegistro { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProducto { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cantidad { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Total { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Registro Registro { get; set; }
    }

    public partial class RegistroXProductoViewModel
    {
        public int IdProducto { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }
        public bool Retirar { get; set; }
        public int Total()
        {
            return Cantidad * PrecioUnitario;
        }
    }
}
