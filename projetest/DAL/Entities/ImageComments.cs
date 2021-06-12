using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Net.Mail;

namespace DAL.Entities
{
    [Table("ImageComments")]
    public class ImageComments
    {
        [Key]
        public int ID { get; set; }

        [StringLength(60), Column(TypeName = "varchar(60)"), Display(Name = "Yorumlayan")]
        public string UserName { get; set; }

        [StringLength(40), Column(TypeName = "varchar(40)"), Display(Name = "Title")]
        public string Title { get; set; }
        public DateTime CommentDate { get; set; }

        [StringLength(400), Column(TypeName = "Varchar(400)"), Display(Name = "Açıklama")]
        public string Text { get; set; }

        [Column(TypeName = "int"), Display(Name = "Beğeni")]
        public int Like { get; set; }
        public int? MemberID { get; set; }
        public Member Member { get; set; }
        public int? pictureID { get; set; }
        public MediaPicture Picture{ get; set; }

    }
}
