namespace ModuloContabilidad.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoRegistros")]
    public partial class TipoRegistro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoRegistro()
        {
            Registros = new HashSet<Registro>();
        }

        [Key]
        public int IdTipoRegistro { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
