using MyCV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class EFCv : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Cv> Cvs { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Formations> Formations { get; set; }
        public DbSet<Skills> Skills { get; set; }

    }
}