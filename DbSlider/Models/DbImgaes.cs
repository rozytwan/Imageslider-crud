using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DbSlider.Models
{
    public class DbImgaes
    {
         public int id { get; set; }
        public string ImageName { get; set; }

        [Display(Name ="Select Image")]
        public string ImagePath { get; set; }
        public bool Status{ get; set; }



    }
}