using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Net.Mail;

namespace kayaseker.DAL.Entities
{
    public class PlacesPictures
    {
        [Key]
        public int ID { get; set; }
        public ContentsPlaces contentsPlaces { get; set; }

    }
}
