using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Initializers
{
    public class MuseumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            List<Painting> defaultPaintings = new List<Painting>();
            defaultPaintings.Add(new Painting() { Title = "PAINTING1", Year = 2000});
            defaultPaintings.Add(new Painting() { Title = "PAINTING2", Year = 2001 });
            defaultPaintings.Add(new Painting() { Title = "PAINTING3", Year = 2002 });
            foreach (Painting b in defaultPaintings)
                context.Paintings.Add(b);
            context.SaveChanges();

            List<Artist> defaultArtists = new List<Artist>();
            defaultArtists.Add(new Artist { ArtistName = "NAME1", ArtistSurname = "SURNAME1" });
            defaultArtists.Add(new Artist { ArtistName = "NAME2", ArtistSurname = "SURNAME2" });
            defaultArtists.Add(new Artist { ArtistName = "NAME3", ArtistSurname = "SURNAME3" });
            foreach (Artist a in defaultArtists)
                context.Artists.Add(a);
            context.SaveChanges();

        }
    }
}