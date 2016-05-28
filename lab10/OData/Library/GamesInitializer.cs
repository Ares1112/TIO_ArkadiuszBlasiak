using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class GamesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            List<Game> defaultGames = new List<Game>();
            defaultGames.Add(new Game() { Title = "Game1", CreatorCompany = "Company1", Year = 2011, AgeRate = 17 });
            defaultGames.Add(new Game() { Title = "Game2", CreatorCompany = "Company2", Year = 2012, AgeRate = 16 });
            defaultGames.Add(new Game() { Title = "Game3", CreatorCompany = "Company3", Year = 2013, AgeRate = 15 });
            defaultGames.Add(new Game() { Title = "Game4", CreatorCompany = "Company4", Year = 2014, AgeRate = 14 });
            defaultGames.Add(new Game() { Title = "Game5", CreatorCompany = "Company5", Year = 2015, AgeRate = 13 });
            foreach (Game b in defaultGames)
                context.Games.Add(b);
            context.SaveChanges();

            List<Store> defaultStores = new List<Store>();
            defaultStores.Add(new Store { Name = "Name1", Address = "Address1" });
            defaultStores.Add(new Store { Name = "Name2", Address = "Address2" });
            defaultStores.Add(new Store { Name = "Name3", Address = "Address3" });
            defaultStores.Add(new Store { Name = "Name4", Address = "Address4" });
            defaultStores.Add(new Store { Name = "Name5", Address = "Address5" });
            foreach (Store a in defaultStores)
                context.Stores.Add(a);
            context.SaveChanges();

            List<CardShirt> defaultCardShirts = new List<CardShirt>();
            defaultCardShirts.Add(new CardShirt { Name = "Name1" });
            defaultCardShirts.Add(new CardShirt { Name = "Name2" });
            defaultCardShirts.Add(new CardShirt { Name = "Name3" });
            defaultCardShirts.Add(new CardShirt { Name = "Name4" });
            defaultCardShirts.Add(new CardShirt { Name = "Name5" });
            foreach (CardShirt a in defaultCardShirts)
                context.CardShirts.Add(a);
            context.SaveChanges();
        }
    }
}
