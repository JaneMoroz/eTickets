using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Add Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema
                        {
                            Logo = "https://i.ibb.co/mHpzCKG/cinema-1.jpg",
                            Name = "Central Cinema",
                            Description = "This is a description."
                        },

                        new Cinema
                        {
                            Logo = "https://i.ibb.co/Tb0k0mJ/cinema-2.jpg",
                            Name = "Manchester Cinema",
                            Description = "This is a description."
                        },

                        new Cinema
                        {
                            Logo = "https://i.ibb.co/fdj3Cxs/cinema-3.jpg",
                            Name = "Circus IMAX Cinema",
                            Description = "This is a description."
                        }
                    });
                    context.SaveChanges();
                }

                //Add Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor
                        {
                            ProfilePictureUrl = "https://i.ibb.co/ctP11JZ/Virginie-Efira.jpg",
                            FullName = "Virginie Efira",
                            Bio = "Virginie Efira was born on May 5, 1977 in Brussels, Belgium. She is an actress and writer..."
                        },

                        new Actor
                        {
                            ProfilePictureUrl = "https://i.ibb.co/xsDDKSZ/Lady-Gaga.jpg",
                            FullName = "Lady Gaga",
                            Bio = "Lady Gaga, born Stefani Joanne Angelina Germanotta, is an American songwriter, singer, actress, philanthropist, dancer and fashion designer. Gaga was born on March 28, 1986 in Manhattan, New York City, to Cynthia Louise (Bissett), a philanthropist and business executive, and Joseph Anthony Germanotta, Jr., an internet entrepreneur. Her father is of..."
                        },

                        new Actor
                        {
                            ProfilePictureUrl = "https://i.ibb.co/Syp4VqL/Jared-Leto.jpg",
                            FullName = "Jared Leto",
                            Bio = "Jared Leto is a very familiar face in recent film history. Although he has always been the lead vocals, rhythm guitar, and songwriter for American band Thirty Seconds to Mars, Leto is an accomplished actor merited by the numerous, challenging projects he has taken in his life. He is known to be selective about his film roles. Jared Leto was born in..."
                        },

                        new Actor
                        {
                            ProfilePictureUrl = "https://i.ibb.co/R0KKX74/Adam-Driver.jpg",
                            FullName = "Adam Driver",
                            Bio = "Adam Douglas Driver was born in San Diego, California. His mother, Nancy (Needham) Wright, is a paralegal from Mishawaka, Indiana, and his father, Joe Douglas Driver, who has deep roots in the American South, is from Little Rock, Arkansas. His stepfather is a Baptist minister. His ancestry includes Dutch, English, German, Irish and Scottish."
                        },

                        new Actor
                        {
                            ProfilePictureUrl = "https://i.ibb.co/Vt3jZ4d/1176468855.jpg",
                            FullName = "Peter Dinklage",
                            Bio = "Peter Dinklage is an American actor. Since his breakout role in Станционный смотритель (2003), he has appeared in numerous films and theatre plays. Since 2011, Dinklage has portrayed Tyrion Lannister in the HBO series &..."
                        },

                        new Actor
                        {
                            ProfilePictureUrl = "https://i.ibb.co/qnMTfB0/Haley-Bennett.jpg",
                            FullName = "Haley Bennett",
                            Bio = "A natural talent with a striking presence, Haley Bennett continues to establish herself as one of Hollywood's most dynamic actresses. Upcoming, Bennett will star opposite Austin Stowell in Carlo Mirabella-Davis's SWALLOW, on which she also serves as an executive producer. Bennett plays 'Hunter,' a pregnant, young housewife, whose seemingly perfect..."
                        },
                    });
                    context.SaveChanges();
                }
                //Add Directors
                if (!context.Directors.Any())
                {
                    context.Directors.AddRange(new List<Director>()
                    {
                        new Director
                        {
                            ProfilePictureUrl = "https://i.ibb.co/2F2pM6w/director-scott.jpg",
                            FullName = "Ridley Scott",
                            Bio = "Described by film producer Michael Deeley as 'the very best eye in the business', director Ridley Scott was born on November 30, 1937 in South Shields, Tyne and Wear (then County Durham). His father was an officer in the Royal Engineers and the family followed him as his career posted him throughout the United Kingdom and Europe before they..."
                        },

                        new Director
                        {
                            ProfilePictureUrl = "https://i.ibb.co/FgLTg98/Joe-Wright.jpg",
                            FullName = "Joe Wright",
                            Bio = "Joe Wright is an English film director. He is best known for Pride & Prejudice (2005), Atonement (2007), Anna Karenina (2012), and Darkest Hour (2017). Wright always had an interest in the arts, especially painting. He would also make films on his Super 8 camera as well as spend time in the evenings acting in a drama club. He began his career ..."
                        },

                        new Director
                        {
                            ProfilePictureUrl = "https://i.ibb.co/0X3x2hP/director-Verhoeven.jpg",
                            FullName = "Paul Verhoeven",
                            Bio = "Paul Verhoeven graduated from the University of Leiden, with a degree in math and physics. He entered the Royal Netherlands Navy, where he began his film career by making documentaries for the Navy and later for TV. In 1969, he directed the popular Dutch TV series, Floris (1969), about a medieval knight. This featured actor Rutger Hauer, who has..."
                        },

                    });
                    context.SaveChanges();
                }
                //Add Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie
                        {
                            Name = "Cyrano",
                            Description = "Too self-conscious to woo Roxanne himself, wordsmith Cyrano de Bergerac helps young Christian nab her heart through love letters.",
                            Price = 39.50,
                            ImageUrl = "https://i.ibb.co/RgwvQ2B/cyrano-medium.jpg",
                            StartDate = DateTime.Now.AddDays(5),
                            EndDate = DateTime.Now.AddDays(12),
                            CinemaId = 1,
                            DirectorId = 2,
                            MovieCategory = MovieCategory.Drama
                        },

                        new Movie
                        {
                            Name = "House of Gucci",
                            Description = "House of Gucci is inspired by the shocking true story of the family empire behind the Italian fashion house of Gucci.",
                            Price = 39.50,
                            ImageUrl = "https://i.ibb.co/82B7V49/house-of-gucci-medium.jpg",
                            StartDate = DateTime.Now.AddDays(-5),
                            EndDate = DateTime.Now.AddDays(18),
                            CinemaId = 3,
                            DirectorId = 1,
                            MovieCategory = MovieCategory.Thriller
                        },

                        new Movie
                        {
                            Name = "Benedetta",
                            Description = "In the late 15th century, with plague ravaging the land, Benedetta Carlini joins the convent in Pescia, Tuscany, as a novice.",
                            Price = 39.50,
                            ImageUrl = "https://i.ibb.co/pKp5Gq2/benedetta-big.jpg",
                            StartDate = DateTime.Now.AddDays(-20),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 2,
                            DirectorId = 3,
                            MovieCategory = MovieCategory.Drama
                        },
                    });
                    context.SaveChanges();
                }

                //Add Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie
                        {
                            ActorId = 1,
                            MovieId = 3
                        },

                        new Actor_Movie
                        {
                            ActorId = 2,
                            MovieId = 2
                        },

                        new Actor_Movie
                        {
                            ActorId = 3,
                            MovieId = 2
                        },

                        new Actor_Movie
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie
                        {
                            ActorId = 5,
                            MovieId = 1
                        },

                        new Actor_Movie
                        {
                            ActorId = 6,
                            MovieId = 1
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
