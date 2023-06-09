﻿using ENTITIES.BASE_ENTITY;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENTITIES.CORE
{
    public class User:BaseEntity
    {
        [Column("FIRST_NAME")]
        public string FirstName { get; set; }
        [Column("LAST_NAME")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; } 
        //Forign Key to ROLE
        [Column("ROLE_ID")]
        public int RoleId { get; set; }
        [MinLength(8)]
        public string Password { get; set; }

    }
}
