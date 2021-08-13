using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Net.Mail;

namespace kayaseker.DAL.Entities
{
    [Table("Member")]
    public class Member
    {
        [Key]
        public int ID { get; set; }

        [StringLength(60), Column(TypeName = "varchar(60)"), Display(Name = "Üye Adı")]
        public string NameSurName { get; set; }

        [Column(TypeName = "varchar(60)"), Display(Name = "Mail Adresi")]
        public string Mail { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Kullanıcı Şifresi")]
        public string Password { get; set; }

        [Column(TypeName = "int"), Display(Name = "Üye Rolü")]
        public int RoleNumber { get; set; }

    }
}
