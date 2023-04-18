using ENTITIES.BASE_ENTITY;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENTITIES.TREE
{
    public class Family:BaseEntity
    {
        [Column("FAMILY_NAME")]
        public string FamilyName { get; set; }
    }
}
