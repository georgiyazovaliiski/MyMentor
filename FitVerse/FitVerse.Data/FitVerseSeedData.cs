using AgilityPack;
using FitVerse.Model;
using FitVerse.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace FitVerse.Data
{
    public class FitVerseSeedData:DropCreateDatabaseIfModelChanges<FitVerseEntities>
    {
        protected override void Seed(FitVerseEntities context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetFoods().ForEach(c => context.ThingsToEat.Add(c));
            GetGadgets().ForEach(g => context.Gadgets.Add(g));
            context.Commit();
            GetExercises().ForEach(e => context.Exercises.Add(e));
            context.Commit();


            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var hasher = new PasswordHasher();

            var user = new ApplicationUser
            {
                UserName = "abhimanyu",
                PasswordHash = hasher.HashPassword("abhimanyu"),
                priorities = new Priorities()
            };
            user.schedule = new Week();
            user.schedule.Days = new List<Day>();

            Day day = new Day();
            day.Components = new List<Component>();
            Component component = new FreeTime(new TimeSpan(9999), new TimeSpan(99999),"Discotechka",1);
            component.Name = "Shit";
            day.Components.Add(component);
            user.schedule.Days.Add(day);
            user.priorities = new Priorities();
            user.stats = new Stats();

            manager.Create(user, "abhimanyu");


        }

        private List<Exercise> GetExercises()
        {
            Exercise e = new Exercise();

            return new List<Exercise>
            {
                new Exercise {
                    Name = "Лежанка",
                    bodyPart = BodyPart.Chest,
                    Description = "Супер упражнение за гърди!"
                },
                new Exercise {
                    Name = "Гребане с лост",
                    bodyPart = BodyPart.Back,
                    Description = "Супер упражнение за гръб!"
                },
                new Exercise {
                    Name = "Раменна преса с дъмбели",
                    bodyPart = BodyPart.Shoulders,
                    Description = "Супер упражнение за рамо!"
                },
                new Exercise {
                    Name = "Бицепсово сгъване",
                    bodyPart = BodyPart.Biceps,
                    Description = "Супер упражнение за бицепсите ти!"
                },
                new Exercise {
                    Name = "Трицепсово избутване с кабели",
                    bodyPart = BodyPart.Triceps,
                    Description = "Супер упражнение за трицепсите ти!"
                },
                new Exercise {
                    Name = "Клек",
                    bodyPart = BodyPart.Triceps,
                    Description = "Супер упражнение за трицепсите ти!"
                },
                new Exercise {
                    Name = "Повдигане с прасец",
                    bodyPart = BodyPart.Calves,
                    Description = "Супер упражнение за прасците ти!"
                },
                new Exercise {
                    Name = "Екстензии за предно бедро",
                    bodyPart = BodyPart.Legs,
                    Description = "Супер упражнение за крака!"
                },
                new Exercise {
                    Name = "Monkey Shrugs",
                    bodyPart = BodyPart.Traps,
                    Description = "Супер упражнение за трапец!"
                },
                new Exercise {
                    Name = "Дъска",
                    bodyPart = BodyPart.Abs,
                    Description = "Супер упражнение за коремните мускули!"
                },
                new Exercise {
                    Name = "Руски туист",
                    bodyPart = BodyPart.Abs,
                    Description = "Супер упражнение за страничните мускули!"
                },
                new Exercise {
                    Name = "Бедрено избутване",
                    bodyPart = BodyPart.Gluteus,
                    Description = "Супер упражнение за глутеуса!"
                }
            };
        }

        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Name = "Tablets"
                },
                new Category {
                    Name = "Laptops"
                },
                new Category {
                    Name = "Mobiles"
                }
            };
        }

        private static List<ThingToEat> GetFoods()
        {
            Console.OutputEncoding = Encoding.UTF8;
            DBPopulator populator = new DBPopulator();
            List<ThingToEat> populating = populator.Scrape("http://spidersport.com/calories.php");
            /*return new List<ThingToEat>
            {
                new ThingToEat {
                    Name = "Картофи",
                    Calories = 300,
                    Protein = 20,
                    Fat = 10,
                    Carbs = 40,
                    TypeOfFood = TypeOfFood.Vegetable
                },
                new ThingToEat {
                    Name = "Пилешко филе",
                    Calories = 150,
                    Protein = 40,
                    Fat = 4,
                    Carbs = 10,
                    TypeOfFood = TypeOfFood.Meat
                },
                new ThingToEat {
                    Name = "Кисело мляко",
                    Calories = 450,
                    Protein = 13.5,
                    Fat = 10,
                    Carbs = 40,
                    TypeOfFood = TypeOfFood.Dairy
                },
                new ThingToEat {
                    Name = "Ягоди",
                    Calories = 450,
                    Protein = 13.5,
                    Fat = 10,
                    Carbs = 40,
                    TypeOfFood = TypeOfFood.Fruit
                }
            }*/
            return populating;
        }

        private static List<Meal> GetMeals()
        {
            return new List<Meal>
            {
                new Meal {
                    Name = "Chicken"
                },
                new Meal {
                    Name = "Rice"
                },
                new Meal {
                    Name = "Lettuce"
                }
            };
        }

        private static List<Gadget> GetGadgets()
        {
            return new List<Gadget>
            {
                new Gadget {
                    Name = "ProntoTec 7",
                    Description = "Android 4.4 KitKat Tablet PC, Cortex A8 1.2 GHz Dual Core Processor,512MB / 4GB,Dual Camera,G-Sensor (Black)",
                    CategoryID = 1,
                    Price = 46.99m,
                    Image = "prontotec.jpg"
                },
                new Gadget {
                    Name = "Samsung Galaxy",
                    Description = "Android 4.4 Kit Kat OS, 1.2 GHz quad-core processor",
                    CategoryID = 1,
                    Price = 120.95m,
                    Image= "samsung-galaxy.jpg"
                },
                new Gadget {
                    Name = "NeuTab® N7 Pro 7",
                    Description = "NeuTab N7 Pro tablet features the amazing powerful, Quad Core processor performs approximately Double multitasking running speed, and is more reliable than ever",
                    CategoryID = 1,
                    Price = 59.99m,
                    Image= "neutab.jpg"
                },
                new Gadget {
                    Name = "Dragon Touch® Y88X 7",
                    Description = "Dragon Touch Y88X tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
                    CategoryID = 1,
                    Price = 54.99m,
                    Image= "dragon-touch.jpg"
                },
                new Gadget {
                    Name = "Alldaymall A88X 7",
                    Description = "This Alldaymall tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
                    CategoryID = 1,
                    Price = 47.99m,
                    Image= "Alldaymall.jpg"
                },
                new Gadget {
                    Name = "ASUS MeMO",
                    Description = "Pad 7 ME170CX-A1-BK 7-Inch 16GB Tablet. Dual-Core Intel Atom Z2520 1.2GHz CPU",
                    CategoryID = 1,
                    Price = 94.99m,
                    Image= "asus-memo.jpg"
                },
                // Code ommitted 
            };
        }
    }
}
