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
            if (context.Database.EnsureCreated())
            {
                if (!context.Post.Any())
                {
                    context.Post.AddRange(

                        new Post()
                        {
                            Name = "Test",
                            Description = "Lejish",
                            Image = null
                        },
                        new Post()
                        {
                            Name = "DasAuto",
                            Description = "Aruubish",
                            Image = null
                        },
                        new Post()
                        {
                            Name = "aQwa",
                            Description = "Aewea",
                            Image = null
                        }
                        );

                    context.SaveChanges();
                }
            }
        }
    }
}

