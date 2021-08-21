using fjallGuiderna.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fjallGuiderna.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                // Check that database exist
                context.Database.EnsureCreated();

                // Location
                if (!context.Location.Any())
                {
                    context.Location.AddRange(new List<Location>()
                    {
                        new Location()
                        {
                            PictureUrl = "https://www.skistar.com/globalassets/bilder-nya-skistar.com/skidorter_profilbilder/are/are_var.jpg?maxwidth=924&quality=80",
                            Name = "Åre",
                            Description = "Från Åre by startar många spännande aktiviter och guidade turer både på skutan och närliggande områden."
                        },
                        new Location()
                        {
                            PictureUrl = "https://www.ottsjo.se/wp-content/uploads/2018/10/fjallbynh%C3%B6stDSC_6147-1024x450.jpeg",
                            Name = "Ottsjö",
                            Description = "I södra Årefjällen ligger den pitoreska fjällbyn Ottsjö, härifrån startar flera fina vandringsleder och på vintern fina turleder."
                        },
                        new Location()
                        {
                            PictureUrl = "https://cdn-assets.alltrails.com/uploads/photo/image/31187012/large_bb4aa723262a9ecaea6f1c49b4bd853d.jpg",
                            Name = "Vålådalen",
                            Description = "Från klassiska Vålådalen utgår flera fina leder, både upp på Ottfjället och in i naturreservartet 'Vålådalens naturreservat'. Här vandrar man i både urskog och fjällmiljö. Leder in mot Lunndörrspasset startar härifrån.Cyckling, toppturer, offpist, vandring, Turskidåkning och forspaddling är bara några av de äventyr som går uppleva i Vålådalen."
                        }

                    });
                    context.SaveChanges();

                }
               
                // Guide
                if (!context.Guide.Any())
                {
                    context.Guide.AddRange(new List<Guide>()
                    {
                        new Guide()
                        {
                            ProfilePictureUrl = "http://bjornedin.se/images/200411_bjorn.jpg",
                            FullName = "Björn Edin",
                            Age = 36,
                            GuideDescription = "Björn har åkt skidor sedan han var tre och har stor erfarenhet av fjällmiljö. Björn leder främst guidade turskidåkningsturer och toppturer med snowboard."
                        },
                        new Guide()
                        {
                            ProfilePictureUrl = "https://images.unsplash.com/photo-1593104547489-5cfb3839a3b5?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=2072&q=80",
                            FullName = "Lisa Olsson",
                            Age = 32,
                            GuideDescription = "Lisa är utbildad fjällguide och tar med dig på både på topturer, sköna vandringar, kajakturer mm."
                        },
                    });
                    context.SaveChanges();
                }

                // Category
                if (!context.Category.Any())
                {
                    context.Category.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            PictureUrl=  "https://images.unsplash.com/photo-1594882645126-14020914d58d?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=2263&q=80",
                            Name = "Löpning"
                        },
                         new Category()
                        {
                            PictureUrl=  "https://images.pexels.com/photos/7615952/pexels-photo-7615952.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                            Name = "Kajak"
                        },
                          new Category()
                        {
                            PictureUrl=  "https://images.pexels.com/photos/39645/moose-bull-elk-yawns-39645.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                            Name = "Viltspanning"
                        },
                           new Category()
                        {
                            PictureUrl=  "https://images.unsplash.com/photo-1594882645126-14020914d58d?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=2263&q=80",
                            Name = "Turskidor"
                        },
                            new Category()
                        {
                            PictureUrl=  "https://wwwfunasdalense.cdn.triggerfish.cloud/uploads/2020/08/erikleonsson2020-1-scaled-e1597428582475.jpg",
                            Name = "Topptur offpist"
                        },
                                new Category()
                        {
                            PictureUrl=  "https://images.pexels.com/photos/1448055/pexels-photo-1448055.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                            Name = "Vandring"
                        }

                    });
                    context.SaveChanges();

                }
                // Activity
                if (!context.NatureActivity.Any())
                {
                    context.NatureActivity.AddRange(new List<NatureActivity>()
                        {
                            new NatureActivity()
                            {
                                PictureUrl = "https://live.staticflickr.com/351/19022134910_b8e9eebea3_b.jpg",
                                Name = "Vandring till Pyramiderna",
                                Description = "Följ med på en dagsvandring till de klassiska pyramiderna. Pyrmiderna skapades av inlandsisen och är ett väldigt speciellt geoliskt fenomen, vi utgår från Valbo och vandringen beräknas ta 5-7 h, beroende på tempo samt hur länge ni vill stanna vis Pyramiderna",
                                Price = 599,
                                StartDate = new DateTime(2021, 9, 13, 8, 1, 1),
                                EndDate = new DateTime(2021, 9, 13, 16, 1, 1),
                                NumberOfParticipants = 8,
                                LocationId = 3,
                                GuideId = 1,
                                CategoryId = 6
                            },
                            new NatureActivity()
                            {
                                PictureUrl = "https://h24-original.s3.amazonaws.com/258766/25498858-Dlc6H.jpg",
                                Name = "Kajak på Ottsjön",
                                Description = "En sagolik paddlingstur väntar med både fina sandstränder, fantastisk omgivning, mysiga små åkrokar vi kan paddla in på.",
                                Price = 1599,
                                StartDate = new DateTime(2021, 9, 8, 8, 30, 1),
                                EndDate = new DateTime(2021, 9, 8, 16, 1, 1),
                                NumberOfParticipants = 4,
                                LocationId = 2,
                                GuideId = 2,
                                CategoryId = 2
                            }
                        });
                    context.SaveChanges();
                }
                
                
            }
        }
    }
}
