using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Image_Analysis.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "name")]
        public string FromName { get; set; }
        [Required, Display(Name = "email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Message { get; set; }
    }
}