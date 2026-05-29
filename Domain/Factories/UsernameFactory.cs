using System;
using Domain.DomainObjects.User;

namespace Domain.Factories
{
    public class UsernameFactory
    {
        private static readonly string[] Adjectives = ["Lustiger", "Schneller", "Kleiner", "Großer", "Starker", "Cleverer", "Fröhlicher", "Mutiger", "Flinker",
        "Sanfter", "Wilder", "Lauter", "Leiser", "Fauliger", "Fleißiger", "Neugieriger", "Tapferer", "Schlauer", "Stolzer", "Netter", "Bunter", "Weiser", "Junger",
        "Alter", "Frecher", "Schöner", "Dunkler", "Heller", "Mutiger", "Freundlicher", "Süßer", "Böser", "Glücklicher", "Starker", "Schneller", "Langsamer"];
        private static readonly string[] Animals = ["Tiger", "Löwe", "Adler", "Wolf", "Falke", "Panther", "Hai", "Bär", "Fuchs", "Phoenix", "Drache",
        "Rabe", "Panda", "Koala", "Pinguin", "Delfin", "Gorilla", "Igel", "Hase", "Frosch", "Hirsch", "Elefant", "Affe", "Esel", "Elch", "Papagei"];

        private static readonly Random Random = new();
        public Username CreateRandomUsername => new($"{Adjectives[Random.Next(Adjectives.Length)]}{Animals[Random.Next(Animals.Length)]}");
    }
}