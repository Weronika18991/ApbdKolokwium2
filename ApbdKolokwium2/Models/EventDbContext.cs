using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApbdKolokwium2.Models
{
    public class EventDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistEvent> ArtistEvents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventOrganiser> EventOrganizers { get; set; }
        public DbSet<Organiser> Organizers { get; set; }
        
        protected EventDbContext()
        {
        }

        public EventDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>(opt =>
            {
                opt.HasKey(e => e.IdArtist);
                opt.Property(e => e.IdArtist).ValueGeneratedOnAdd();
                opt.Property(e => e.Nickname).HasMaxLength(30).IsRequired();

                opt.HasMany(e => e.ArtistEvents)
                    .WithOne(e => e.Artist)
                    .HasForeignKey(e => e.IdArtist);
            });
            
            modelBuilder.Entity<ArtistEvent>(opt =>
            {
                opt.HasKey(e => new {e.IdEvent, e.IdArtist});
            });

            modelBuilder.Entity<Event>(opt =>
            {
                opt.HasKey(e => e.IdEvent);
                opt.Property(e => e.IdEvent).ValueGeneratedOnAdd();
                opt.Property(e => e.Name).HasMaxLength(30).IsRequired();

                opt.HasMany(e => e.ArtistEvents)
                    .WithOne(e => e.Event)
                    .HasForeignKey(e => e.IdEvent);
                
                opt.HasMany(e => e.EventOrganisers)
                    .WithOne(e => e.Event)
                    .HasForeignKey(e => e.IdEvent);
            });

            modelBuilder.Entity<Organiser>(opt =>
            {
                opt.HasKey(e => e.IdOrganiser);
                opt.Property(e => e.IdOrganiser).ValueGeneratedOnAdd();
                opt.Property(e => e.Name).HasMaxLength(30).IsRequired();
                
                opt.HasMany(e => e.EventOrganizers)
                    .WithOne(e => e.Organiser)
                    .HasForeignKey(e => e.IdOrganiser);
            });

            modelBuilder.Entity<EventOrganiser>(opt =>
            {
                opt.HasKey(e => new {e.IdEvent, e.IdOrganiser});
            });
            
            
            var artists = new List<Artist>();
            artists.Add(new Artist()
            {
                Nickname = "Nana",
                IdArtist = 1
            });

            artists.Add(new Artist()
            {
                Nickname = "Pipi",
                IdArtist = 2
            });
            artists.Add(new Artist()
            {
                Nickname = "LilPipi",
                IdArtist = 3
            });

            artists.Add(new Artist()
            {
                Nickname = "Tede",
                IdArtist = 4
            });


            modelBuilder.Entity<Artist>().HasData(artists);

            var artist_Events = new List<ArtistEvent>();
            artist_Events.Add(new ArtistEvent()
            {
                IdEvent = 1,
                IdArtist = 1,
                PerformanceDate = Convert.ToDateTime("01.01.2005")
            });

            artist_Events.Add(new ArtistEvent()
            {
                IdEvent = 2,
                IdArtist = 2,
                PerformanceDate = Convert.ToDateTime("01.01.2008")
            });

            artist_Events.Add(new ArtistEvent()
            {
                IdEvent = 3,
                IdArtist = 3,
                PerformanceDate = Convert.ToDateTime("01.01.2010")
            });
            artist_Events.Add(new ArtistEvent()
            {
                IdEvent = 4,
                IdArtist = 4,
                PerformanceDate = Convert.ToDateTime("01.01.2015")
            });

            modelBuilder.Entity<ArtistEvent>().HasData(artist_Events);


            var events = new List<Event>();
            events.Add(new Event()
            {
                IdEvent = 1,
                Name = "Super imprezka",
                StartDate = Convert.ToDateTime("01.01.2005"),
                EndDate = Convert.ToDateTime("11.01.2005")
            });

            events.Add(new Event()
            {
                IdEvent = 2,
                Name = "Czadowa impreza",
                StartDate = Convert.ToDateTime("01.01.2008"),
                EndDate = Convert.ToDateTime("11.01.2008")
            });

            events.Add(new Event()
            {
                IdEvent = 3,
                Name = "Extra Widowisko",
                StartDate = Convert.ToDateTime("01.01.2010"),
                EndDate = Convert.ToDateTime("12.01.2010")
            });

            events.Add(new Event()
            {
                IdEvent = 4,
                Name = "Mocne Mello",
                StartDate = Convert.ToDateTime("01.01.2015"),
                EndDate = Convert.ToDateTime("05.01.2015")
            });

            modelBuilder.Entity<Event>().HasData(events);

            var event_Organisers = new List<EventOrganiser>();
            event_Organisers.Add(new EventOrganiser()
            {
                IdEvent = 1,
                IdOrganiser = 1
            });
            event_Organisers.Add(new EventOrganiser()
            {
                IdEvent = 2,
                IdOrganiser = 2
            });
            event_Organisers.Add(new EventOrganiser()
            {
                IdEvent = 3,
                IdOrganiser = 3
            });
            event_Organisers.Add(new EventOrganiser()
            {
                IdEvent = 4,
                IdOrganiser = 4
            });
            modelBuilder.Entity<EventOrganiser>().HasData(event_Organisers);


            var organisers = new List<Organiser>();
            organisers.Add(new Organiser()
            {
                IdOrganiser = 1,
                Name = "MichałX"
            });
            organisers.Add(new Organiser()
            {
                IdOrganiser = 2,
                Name = "MacelZ"
            });
            organisers.Add(new Organiser()
            {
                IdOrganiser = 3,
                Name = "TomuS"
            });
            organisers.Add(new Organiser()
            {
                IdOrganiser = 4,
                Name = "SpayDeer"
            });

            modelBuilder.Entity<Organiser>().HasData(organisers);



        }
    }
}