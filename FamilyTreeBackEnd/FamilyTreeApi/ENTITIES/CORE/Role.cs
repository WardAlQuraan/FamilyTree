using ENTITIES.BASE_ENTITY;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENTITIES.CORE
{
    public class Role:BaseEntity
    {
        [Column("ROLE_NAME")]
        public string RoleName { get; set; }
    }
}
