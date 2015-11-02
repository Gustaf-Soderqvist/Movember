using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Linq;
using Microsoft.AspNet.Builder;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IZ.MovemberApp.Models.SampleData
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serivceProvider)
        {
            var context = serivceProvider.GetService<IzMovemberContext>();

            if (!context.Post.Any() || !context.User.Any())
            {
                context.Post.AddRange(
                    new Post() { Name = "Penuis", Description = "Lejish", Image = null, Date = DateTime.Now },
                    new Post() { Name = "DasAuto", Description = "Aruubish", Image = null, Date = DateTime.Now },
                    new Post() { Name = "aQwa", Description = "Aewea", Image = null, Date = DateTime.Now });

                context.User.AddRange(
                          new User { Name = "Heidi Grundström", Email = "heidi.grundstrom@infozone.se" },
                          new User { Name = "Olga Baradzinskaya", Email = "olga.baradzinskaya@infozone.se" },
                          new User { Name = "Ahmet Akin", Email = "ahmet.akin@infozone.se" },
                          new User { Name = "Ashwin Rego", Email = "ashwin.rego@infozoneus.com" },
                          new User { Name = "Fredrik Ehnö", Email = "fredrik.ehno@infozone.se" },
                          new User { Name = "Frej Sojé-Berggren", Email = "frej.soje-berggren@infozone.se" },
                          new User { Name = "Hampus", Email = "hampus@infozone.se" },
                          new User { Name = "Joachim Carlsson", Email = "joachim.carlsson@infozone.se" },
                          new User { Name = "Mathias Carnemark", Email = "mathias.carnemark@infozone.se" },
                          new User { Name = "Tommy Rydel", Email = "tommy.rydel@infozone.se" },
                          new User { Name = "Per Möllersten", Email = "per.mollersten@infozone.se" },
                          new User { Name = "Carina Åkerberg", Email = "carina.akerberg@infozone.se" },
                          new User { Name = "Hans Frisk", Email = "hans.frisk@infozone.se" },
                          new User { Name = "Heidi Grundström", Email = "heidi.grundstrom@infozone.se" },
                          new User { Name = "Mats Aronsson", Email = "mats.aronsson@infozone.se" },
                          new User { Name = "Olga Baradzinskaya", Email = "olga.baradzinskaya@infozone.se" },
                          new User { Name = "Sverker Carnemark", Email = "sverker@infozone.se" },
                          new User { Name = "Therese Sjöberg", Email = "therese.sjoberg@infozone.se" },
                          new User { Name = "Andreas Sjökvist", Email = "andreas.sjokvist@infozone.se" },
                          new User { Name = "Björn Wikzell", Email = "bjorn.wikzell@infozone.se" },
                          new User { Name = "Daniel Bark", Email = "daniel.bark@infozone.se" },
                          new User { Name = "Fredrik Fehler", Email = "fredrik.fehler@infozone.se" },
                          new User { Name = "Johan Carlén", Email = "johan.carlen@infozone.se" },
                          new User { Name = "Johan Söderqvist", Email = "johan.soderqvist@infozone.se" },
                          new User { Name = "Jörgen Persson", Email = "jorgen.persson@infozone.se" },
                          new User { Name = "Mattias Rutberg", Email = "mattias.rutberg@infozone.se" },
                          new User { Name = "Nicklas Ojava", Email = "nicklas.ojava@infozone.se" },
                          new User { Name = "Tobias Westervall", Email = "tobias.westervall@infozone.se" },
                          new User { Name = "Yama Bahar", Email = "yama.bahar@infozone.se" },
                          new User { Name = "Benny Silfvergren", Email = "Benny.Silfvergren@infozone.se" },
                          new User { Name = "Rickard Rosén", Email = "rickard.rosen@infozone.se" },
                          new User { Name = "Therese Sjöberg", Email = "therese.sjoberg@infozone.se" },
                          new User { Name = "Ulf Rundqvist", Email = "ulf.rundqvist@infozone.se" },
                          new User { Name = "Andreas Hagsten", Email = "andreas.hagsten@infozone.se" },
                          new User { Name = "Fredrik Avar", Email = "fredrik.avar@infozone.se" },
                          new User { Name = "Fredrik Lejdholt", Email = "fredrik.lejdholt@infozone.se" },
                          new User { Name = "Gustaf Söderqvist", Email = "gustaf.soderqvist@infozone.se" },
                          new User { Name = "Jesper Augustsson", Email = "jesper.augustsson@infozone.se" },
                          new User { Name = "Mattias Bylund", Email = "mattias.bylund@infozone.se" },
                          new User { Name = "Nicklas Lindblom", Email = "nicklas.lindblom@infozone.se" },
                          new User { Name = "Robin Ljunglöf", Email = "robin.ljunglof@infozone.se" },
                          new User { Name = "Sebastian Porsemo", Email = "sebastian.porsemo@infozone.se" },
                          new User { Name = "Stefan Gerdin", Email = "stefan.gerdin@infozone.se" },
                          new User { Name = "Tobias Westervall", Email = "tobias.westervall@infozone.se" },
                          new User { Name = "Ulf Rundqvist", Email = "ulf.rundqvist@infozone.se" },
                          new User { Name = "Viktor Blomqvist", Email = "viktor.blomqvist@infozone.se" });

                    context.SaveChanges();
                }
        }
        private class UniqueUserByEmail : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                return x.Email == y.Email;
            }

            public int GetHashCode(User obj)
            {
                return obj.Email.GetHashCode();
            }
        }
    }

}




