﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GuitarMate.Models
{
    public class GuitarPlayer
    {

        public int ID { get; set; }
        public String PlayerName { get; set; }
        public String Location { get; set; }
        public String Instrument { get; set; }
        public String AdDescription { get; set; }
    //    public IdentityUser User { get; set; }

    }

    public class GuitarPlayerDBContext : DbContext
    {
        public DbSet<GuitarPlayer> GuitarPlayers { get; set; }
        

        public GuitarPlayerDBContext()
            : base("GuitarPlayersConnection")
        {
            Database.SetInitializer<GuitarPlayerDBContext>(new DropCreateDatabaseIfModelChanges<GuitarPlayerDBContext>());
        }
    }
}
