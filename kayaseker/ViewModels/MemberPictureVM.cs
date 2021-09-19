using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kayaseker.DAL.Entities;
namespace kayaseker.WebUI.ViewModels
{
    public class MemberPictureVM : Controller
    {
        public Member Member { get; set; }
        public MediaPicture MediaPicture { get; set; }
        public List<MediaPicture> MediaPictures { get; set; }
        public ImageComments Imagecomment { get; set; }
        public List<ImageComments> ImageComments { get; set; }
        public List<ContentsComments> ContentsComments{ get; set; }

    }
}
