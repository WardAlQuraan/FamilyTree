using ENTITIES.BASE_ENTITY;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENTITIES.TREE
{
    public class Tree:BaseEntity
    {
        // Foriegn key to Family
        [Column("FAMILY_ID")]
        public int FamilyId { get; set; }
        // Foriegn key to Tree
        [Column("PARENT_ID")]
        public int? ParentId { get; set; }
        [Column("WIFE_NAME")]
        public string WifeName { get; set; }
        [Column("BIRTH_DATE")]
        public DateTime? BirthDate { get; set; }
    }
}
