
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Net.Mail;

namespace DAL.Entities
{

    [Table("ContentsPlaces")]
    public class ContentsPlaces
    {
        [Key]
        public int ID { get; set; }

        [StringLength(40), Column(TypeName = "varchar(40)"), Display(Name = "Üye Adı")]
        public string Name { get; set; }

        [StringLength(40), Column(TypeName = "varchar(40)"), Display(Name = "Title")]
        public string Title { get; set; }
        /*

        [StringLength(40), Column(TypeName = "varchar(40)"), Display(Name = "Yaptiran")]
        public string Owner { get; set; }

        [StringLength(400), Column(TypeName = "Varchar(400)"), Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Column(TypeName = "int"), Display(Name = "Görüntülenme")]
        public int View { get; set; }

        [Column(TypeName = "int"), Display(Name = "Beğeni")]
        public int Like { get; set; }
        public string ImageData { get; set; }

        [Column(TypeName = "datetime"), Display(Name = "Yükleme Tarihi")]
        public DateTime LogDate { get; set; }
        */

        public virtual ICollection<ImageComments> Comments { get; set; }
        public virtual ICollection<ContentsComments> ContentsComments { get; set; }
        public virtual ICollection<PlacesPictures> PlacesPictures { get; set; }
        public virtual ICollection<MediaPicture> MediaPictures { get; set; }
    }
}
