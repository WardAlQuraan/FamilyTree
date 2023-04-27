using ENTITIES.BASE_ENTITY;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENTITIES.TREE
{
    public class Tree:BaseEntity
    {
        // Foriegn key to Family
        [Required]
        [Column("FAMILY_ID")]
        public int FamilyId { get; set; }
        // Foriegn key to Tree
        [Column("PARENT_ID")]
        public int? ParentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Column("WIFE_NAME")]
        public string WifeName { get; set; }
        [Column("BIRTH_DATE")]
        public DateTime? BirthDate { get; set; }
        public string Parents { get; set; }
        [Column("IMAGE_NAME")]
        public string ImageName { get; set; }
        [Column("GIRLS_NUM")]
        public int? GirlNums { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
