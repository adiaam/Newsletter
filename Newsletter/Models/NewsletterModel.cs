using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newsletter.Models
{
    public class NewsletterModel
    {
        [Key]
        public int Id { get; set; }
        //[Required,MaxLength(255)]
        public string Vorname { get; set; }
        //[Required,MaxLength(255)]
        public string Nachname { get; set; }
        //[Required,EmailAddress]
        public string Email { get; set; }
    }
}
