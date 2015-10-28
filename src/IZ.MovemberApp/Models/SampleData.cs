using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Linq;

namespace IZ.MovemberApp.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serivceProvider)
        {
            var context = serivceProvider.GetService<IzMovemberContext>();
            if (context.Database.AsRelational().Exists())
            {
                if (!context.Post.Any())
                {
                    var Testy = context.Authors.Add(
                        new Author {LastName = "Testy", FirstName = "Tusla"}).Entity;
                    var Gustaf = context.Authors.Add(
                        new Author {LastName = "Soderqvist", FirstName = "Gustaf"}).Entity;
                    context.Post.AddRange(

                        new Post()
                        {
                            Name = "Test",
                            Description = "TeslaAsrsash",
                            Author = Gustaf,
                            Image = null
                        },
                        new Post()
                        {
                            Name = "DasAuto",
                            Description = "Aruubish",
                            Author = Gustaf,
                            Image = null
                        },
                        new Post()
                        {
                            Name = "aQwa",
                            Description = "Aewea",
                            Author = Testy,
                            Image = null
                        }
                        );

                    context.SaveChanges();
                }
            }
        }
    }
}

