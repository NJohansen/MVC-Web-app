using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Assignment.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AssignmentCourseContext(
                serviceProvider.GetRequiredService<DbContextOptions<AssignmentCourseContext>>()))
            {
                // Look for any Courses available.
                if (context.Course.Any())
                {
                    return;   // DB has been seeded
                }

                context.Course.AddRange(
                    new Course
                     {
                        Name = "Computersystemer",
                        Date = DateTime.Parse("2018-6-1"),
                        ECTS ="5",
                     },
                     
                    new Course
                     {
                         Name = "Objektorienteret Programmering",
                         Date = DateTime.Parse("2018-6-1"),
                         ECTS = "20",
                     },

                     new Course
                     {
                         Name = "Introduktion til Software Engineering",
                         Date = DateTime.Parse("2018-6-1"),
                         ECTS ="5",
                     },

                     new Course
                     {
                         Name = "Organisationsorienteret Softwareudvikling: Semesterprojekt",
                         Date = DateTime.Parse("2018-6-1"),
                         ECTS = "10",
                     },

                     new Course
                     {
                         Name = "Organisation og Software Engineering   ",
                         Date = DateTime.Parse("2018-6-1").Date,
                         ECTS = "10",
                     }


                );


                // Look for any Courses available.
                if (context.Profile.Any())
                {
                    return;   // DB has been seeded
                }

                context.Profile.AddRange(
                    new Profile
                    {
                        Name = "Niclas Johansen",
                        Description = "I am a 24 year old Full-Stack Developer focusing on crafting great experiences on the web. I love the momentum of the web and how it pushes the technology forward. I’m always experimenting with the latest technologies and tools to find the best solutions.",
                        Resume = "Lately I've worked as web developer mainly with focus on PHP project and native web apps. I've been working with web development the last 7 years.",
                        ProgrammingLanguage = "JavaScript, PHP, RUST, C#, JAVA"
                    }

                );
                context.SaveChanges();

                // Look for any Courses available.
                if (context.ProgrammingLanguages.Any())
                {
                    return;   // DB has been seeded
                }

                context.ProgrammingLanguages.AddRange(
                    new ProgrammingLanguage
                    {
                        Language = "JavaScript",
                        Experience = "Intermediate"
                    },

                    new ProgrammingLanguage
                    {
                        Language = "PHP",
                        Experience = "Medium"
                    },

                    new ProgrammingLanguage
                    {
                        Language = "RUST",
                        Experience = "Beginner"
                    },

                     new ProgrammingLanguage
                     {
                         Language = "C#",
                         Experience = "Intermediate"
                     },

                     new ProgrammingLanguage
                    {
                        Language = "JAVA",
                        Experience = "Medium"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}