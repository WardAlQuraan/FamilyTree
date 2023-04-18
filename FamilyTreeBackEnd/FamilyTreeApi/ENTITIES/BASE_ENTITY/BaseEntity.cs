using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENTITIES.BASE_ENTITY
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [Column("MODIFICATION_DATE")]
        public DateTime? ModificationDate { get; set; }

        [Column("CREATION_BY")]
        public string CreationBy { get; set; }
        [Column("MODIFICATION_BY")]
        public string ModificationBy { get; set; }
        [Column("IS_DELETED")]
        public int IsDeleted { get; set; }

    }
}
