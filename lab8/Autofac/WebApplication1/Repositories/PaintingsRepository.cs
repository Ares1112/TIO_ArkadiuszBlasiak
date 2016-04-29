using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Contexts;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class PaintingsRepository : IPaintingsRepository
    {
        private MuseumContext db = new MuseumContext();

        public int Add(Painting painting)
        {
            db.Paintings.Add(painting);
            db.SaveChanges();

            return painting.Id;
        }

        public bool Delete(int id)
        {
            Painting painting = db.Paintings.Find(id);
            if (painting == null)
            {
                return false;
            }
            db.Paintings.Remove(painting);
            db.SaveChanges();
            return true;
        }

        public Painting Get(int id)
        {
            return db.Paintings.Find(id);
        }

        public List<Painting> GetAll()
        {
            return db.Paintings.ToList();
        }

        public Painting Update(Painting painting)
        {
            Painting p = db.Paintings.Find(painting.Id);
            if (p == null)
                return null;
            p.Title = painting.Title;
            p.Year = painting.Year;
            db.SaveChanges();
            return painting;
        }
    }
}