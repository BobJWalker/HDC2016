using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace CodeAperture.HDC2016.SampleSite.Models
{
    public class LogModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        public DateTime Logged { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }

        public string UserName { get; set; }

        public string ServerName { get; set; }

        public string Port { get; set; }

        public string Url { get; set; }

        public bool Https { get; set; }

        public string ServerAddress { get; set; }

        public string RemoteAddress { get; set; }

        public string Logger { get; set; }

        public string CallSite { get; set; }

        public string Exception { get; set; }
    }
}