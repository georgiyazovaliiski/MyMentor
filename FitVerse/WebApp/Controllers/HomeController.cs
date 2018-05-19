using AgilityPack;
using FitVerse.Data;
using FitVerse.Model;
using FitVerse.Model.Models;
using Microsoft.AspNet.Identity;
using Service.IServices;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FitVerseEntities db = new FitVerseEntities();
        private readonly IPrioritiesService prioritiesService;
        private readonly IWeekService weekService;
        private readonly IDayService dayService;
        private readonly IComponentService componentService;
        private readonly IChallengeService challengeService;
        private readonly IStatsService statsService;
        private readonly IEatingComponentService eatingComponentService;
        private readonly IUserFitnessGoalsService userFitnessGoalsService;
        private readonly INewsService newsService;

        public HomeController(INewsService newsService, IUserFitnessGoalsService userFitnessGoalsService, IEatingComponentService eatingComponentService, IStatsService statsService, IChallengeService challengeService, IComponentService componentService, IPrioritiesService prioritiesService, IWeekService weekService, IDayService dayService)
        {
            this.eatingComponentService = eatingComponentService;
            this.newsService = newsService;
            this.statsService = statsService;
            this.challengeService = challengeService;
            this.componentService = componentService;
            this.dayService = dayService;
            this.prioritiesService = prioritiesService;
            this.weekService = weekService;
            this.userFitnessGoalsService = userFitnessGoalsService;
        }

        public ActionResult AddReadNews(string link)
        {

            var addingNews = new News();
            addingNews.HrefAttribute = link;
            addingNews.MomentOfReading = DateTime.Now;
            addingNews.ReadByUser = User.Identity.GetUserId();
            
            if(!newsService.FindIfNewsHadBeenReadRecently(addingNews))
            {
                newsService.CreateNews(addingNews);
                newsService.SaveNews();
            }

            return Json("Готово!",JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult CheckIfTestDone()
        {

            var priorities = prioritiesService.GetPrioritiesByUserId(User.Identity.GetUserId());
            
            return PartialView("~/Views/Shared/_CheckIfTestDone.cshtml", check(priorities));
        }

        public PartialViewResult NewsLoad()
        {
            if (User.Identity.IsAuthenticated)
            {
                ScraperNews scraper = new ScraperNews();
                var scraped = scraper.Scrape("https://news.bg/sport");
                return PartialView("~/Views/Shared/_NewsLoad.cshtml", scraped);
            }
            return PartialView("~/Views/Shared/_NewsLoad.cshtml");
        }

        public ActionResult getScheduleForDay(int day)
        {
            if (User.Identity.IsAuthenticated)
            {
                var Parser = new EnglishToBGParser();
                var week = weekService.GetWeekByUserId(User.Identity.GetUserId());
                var weekId = weekService.GetWeekByUserId(User.Identity.GetUserId()).Id;
                if (week.Days.Count!=null) {
                    var dayFromWeek = dayService.GetDaysByWeekId(weekId)[day].Id;
                    var components = componentService.GetComponentsByDayId(dayFromWeek);
                    
                    return Json(components.Select(a => new { Id = a.Id, Name = Parser.ParseLanguages(a.Name), StartHour = a.StartTime.Hours, StartMinutes = a.StartTime.Minutes, EndHour = a.EndTime.Hours, EndMinutes = a.EndTime.Minutes }).ToList(), JsonRequestBehavior.AllowGet);
                }
            }
            return Json("Error!", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetComponent(int id)
        {
            var componentToDraw = componentService.GetComponent(id);
            var Parser = new EnglishToBGParser();
            componentToDraw.Name = Parser.ParseLanguages(componentToDraw.Name);
            var GenericDTO = new ComponentDTO(componentToDraw);
            Type DTODiscriminator = componentToDraw.GetType();

            if (DTODiscriminator == typeof(Eating))
            {
                Eating partial = (Eating)componentToDraw;
                GenericDTO.MealPieces = ConvertToDTOMeal(partial.MealPieces);
                GenericDTO.DETERMINATOR = TypeOfComponent.Eating;
            }

            else if (DTODiscriminator == typeof(FitnessTime))
            {
                FitnessTime partial = (FitnessTime)componentToDraw;
                GenericDTO.Workout = ConvertToDTOWorkout(partial);
                GenericDTO.DETERMINATOR = TypeOfComponent.Workout;
            }
            else if (DTODiscriminator == typeof(EduTime))
            {
                EduTime partial = (EduTime)componentToDraw;
                GenericDTO.DETERMINATOR = TypeOfComponent.EduTime;
            }
            else if (DTODiscriminator == typeof(FreeTime))
            {
                FreeTime partial = (FreeTime)componentToDraw;
                GenericDTO.DETERMINATOR = TypeOfComponent.FreeTime;
            }
            return Json(GenericDTO, JsonRequestBehavior.AllowGet);
        }

        private WorkoutDTO ConvertToDTOWorkout(FitnessTime workout)
        {
            WorkoutDTO dto = new WorkoutDTO(workout);
            return dto;
        }

        private List<EatingComponentDTO> ConvertToDTOMeal(List<EatingComponent> mealPieces)
        {
            List<EatingComponentDTO> converted = new List<EatingComponentDTO>();
            foreach (var item in mealPieces)
            {
                EatingComponentDTO dto = new EatingComponentDTO();
                dto.Name = item.Food.Name;
                dto.Calories = item.Calories;
                dto.Carbs = item.Carbs;
                dto.Fat = item.Fat;
                dto.PortionMassInGrams = item.PortionMassInGrams;
                dto.Protein = item.Protein;
                converted.Add(dto);
            }
            return converted;
        }

        public ActionResult CompleteComponent(int id)
        {
            componentService.CompleteComponent(id);
            componentService.SaveComponent();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        private bool check(Priorities priorities)
        {
            if (priorities.socialParam + priorities.fitnessParam + priorities.educationParam == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        [HttpPost]
        public ActionResult GetDataFromQuestionaire(Questionaire questionaire)
        {
            var gender = questionaire.Questions[1];
            var StudyPeriod = int.Parse(questionaire.Questions[9]);

            //var eduPeriod = questionaire.Questions[1];
            var answers = questionaire.Questions.GetRange(1, questionaire.Questions.Count - 2);

            Analyse(StudyPeriod,gender, answers);

            return Json("Тестът беше анализиран успешно!", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult GetDailyChallenges()
        {
            List<Challenge> challenges = new List<Challenge>();
            ChallengePicker challengePicker = new ChallengePicker();

            var oldchallengesFromDB = this.challengeService
                .GetChallenges()
                .Where(a => a.dateCreated.Day == DateTime.Now.Day && 
                            a.UserId == User.Identity.GetUserId())
                .Take(3)
                .ToList();

            if(oldchallengesFromDB.Count == 0)
            while(oldchallengesFromDB.Count != 3)
            {
                 oldchallengesFromDB = this.challengeService
                .GetChallenges()
                .Where(a => a.dateCreated.Day == DateTime.Now.Day &&
                            a.UserId == User.Identity.GetUserId())
                .Take(3)
                .ToList();
                    String[] parameters = challengePicker.PickAChallenge().Split('-').ToArray();
                Challenge challenge = new Challenge(
                    parameters[0],
                    int.Parse(parameters[2]),
                    parameters[1],
                    User.Identity.GetUserId()
                );
                    if (!challenges.Select(a=>a.Name).ToList().Contains(challenge.Name))
                    {
                        challengeService.CreateChallenge(challenge);
                        challengeService.SaveChallenge();
                        challenges.Add(challenge);
                    }
            }
            else
            {
                challenges = oldchallengesFromDB;
            }

            return PartialView("~/Views/Shared/_DailyChallenges.cshtml", challenges.Where(a=>a.Completed == false).ToList());
        }
        
        public ActionResult FinishChallenge(int id)
        {
            var challenge = challengeService.CompleteChallenge(id);
            if (challenge.TypeOfChallenge.Equals("Social"))
            {
                statsService.UpdateStats(0,challenge.PointsAward,0,
                    User.Identity.GetUserId());
                statsService.SaveStats();
            }
            else if (challenge.TypeOfChallenge.Equals("Fitness"))
            {
                statsService.UpdateStats(challenge.PointsAward, 0, 0, 
                    User.Identity.GetUserId());
                statsService.SaveStats();
            }
            else if (challenge.TypeOfChallenge.Equals("Education"))
            {
                statsService.UpdateStats(0, 0, challenge.PointsAward, 
                    User.Identity.GetUserId());
                statsService.SaveStats();
            }
            return RedirectToAction("Index");
        }

        public void Analyse(int StudyPeriod, String gender, List<String> answers)
        {
            var weekId = this.weekService.GetWeekByUserId(User.Identity.GetUserId()).Id;
            var Days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            var fit = answers.Where(a => a.Equals("fitness")).Count();
            var soc = answers.Where(a => a.Equals("social")).Count();
            var edu = answers.Where(a => a.Equals("education")).Count();

            var max = getMaxPriority(fit, soc, edu);
            var min = getMinPriority(fit, soc, edu);
            var mid = getMidPriority(fit, soc, edu);

            List<int> prioritiesHelper = new List<int>();
            prioritiesHelper.AddRange(new int[] { fit, soc, edu });
            prioritiesHelper.Sort();

            setPriorities(fit, soc, edu);

            Programs programs = new Programs();

            for (int i = 0; i < 5; i++)
            {
                var weekDay = new Day();
                weekDay.DayInWeek = Days[i];
                weekDay.Components = new List<Component>();
                weekDay.WeekID = weekId;

                string[] programItems = programs.programForMorningSchool;

                if (StudyPeriod == 2)
                {
                    programItems = programs.programForEveningSchool;
                }            

                for (int itemIndex = 0; itemIndex < programItems.Length; itemIndex++)
                {
                    var parameters = programItems[itemIndex].Split('-').ToArray();
                    var type = parameters[0];
                    var start = parameters[1];
                    var end = parameters[2];

                    Component component = null;

                    if (type.Equals("Snack") || type.Equals("Breakfast") || type.Equals("Lunch") || type.Equals("Dinner"))
                    {
                        UserFitnessGoals userFitnessGoals = userFitnessGoalsService.GetUserFitnessGoalsByUserId(User.Identity.GetUserId());
                        List<EatingComponent> mealPieces = new List<EatingComponent>();
                        /*if (!userFitnessGoals.Goal.Equals("None"))
                        {
                            mealPieces = eatingComponentService
                                .CreateMeal(
                                    type, 
                                    userFitnessGoals.CaloriesForDay, 
                                    userFitnessGoals.Goal
                                )
                                .ToList();
                        }*/

                        //If DB IS DROPPED ADD MEAL
                        component = new Eating(
                            TimeSpan.Parse(start),
                            TimeSpan.Parse(end),
                            type, 
                            0,
                            mealPieces
                        );
                    }
                    else if (type.Equals("School") || type.Equals("StudyTime"))
                    {
                        component = new EduTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0, type);
                    }
                    else if (type.Equals("FreeTime"))
                    {
                        component = new FreeTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0);
                    }
                    else if (type.EndsWith("Priority"))
                    {
                        var firstPriority = prioritiesHelper[0].GetType().ToString();
                        var secondPriority = prioritiesHelper[1].GetType().ToString();
                        var thirdPriority = prioritiesHelper[2].GetType().ToString();
                        if (mid.Equals("SecondPriority"))
                        {
                            if (mid.EndsWith("FitnessTime"))
                            {
                                //ADD WORKOUT FUNCTIONALLITY
                                component = new FitnessTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0, new List<ExerciseInWorkout>());
                            }
                            else if (mid.EndsWith("EduTime"))
                            {
                                component = new EduTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0, type);
                            }
                            else if(mid.EndsWith("FreeTime"))
                            {
                                component = new FreeTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0);
                            }
                        }
                        else if (type.Equals("ThirdPriority"))
                        {
                            if (min.EndsWith("FitnessTime"))
                            {
                                //ADD WORKOUT FUNCTIONALLITY
                                component = new FitnessTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0, new List<ExerciseInWorkout>());
                            }
                            else if (min.EndsWith("EduTime"))
                            {
                                component = new EduTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0, type);
                            }
                            else if (min.EndsWith("FreeTime"))
                            {
                                component = new FreeTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0);
                            }
                        }
                        else if (type.Equals("FirstPriority"))
                        {
                            if (max.EndsWith("FitnessTime"))
                            {
                                //ADD WORKOUT FUNCTIONALLITY
                                component = new FitnessTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0, new List<ExerciseInWorkout>());
                            }
                            else if (max.EndsWith("EduTime"))
                            {
                                component = new EduTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0, type);
                            }
                            else if (max.EndsWith("FreeTime"))
                            {
                                component = new FreeTime(TimeSpan.Parse(start), TimeSpan.Parse(end), type, 0);
                            }
                        }
                    }
                    if (component!=null)
                    weekDay.Components.Add(component);
                }

                this.dayService.CreateDay(weekDay);
                this.dayService.SaveDay();
            }


            //var max = Math.Max(Math.Max(fit, soc), edu);
        }

        public void setPriorities(int fit, int soc, int edu)
        {
            var prioritiesForCreation = prioritiesService.GetPrioritiesByUserId(User.Identity.GetUserId());
            
            prioritiesForCreation.educationParam = edu;
            prioritiesForCreation.socialParam = soc;
            prioritiesForCreation.fitnessParam = fit;

            prioritiesService.UpdatePriorities(prioritiesForCreation);
            prioritiesService.SavePriorities();
        }

        public string getMaxPriority(int fit, int soc, int edu)
        {
            var max = Math.Max(Math.Max(fit,soc),edu);
            if (max == fit)
            {
                return "FitnessTime";
            }
            else if(max == soc)
            {
                return "SocialTime";
            }
            else if (max == edu)
            {
                return "EduTime";
            }
            else
            {
                return "SocialTime";
            }
        }
        public string getMinPriority(int fit, int soc, int edu)
        {
            var min = Math.Min(Math.Min(fit, soc), edu);
            if (min == fit)
            {
                return "FitnessTime";
            }
            else if (min == soc)
            {
                return "SocialTime";
            }
            else if (min == edu)
            {
                return "EduTime";
            }
            else
            {
                return "SocialTime";
            }
        }
        public string getMidPriority(int fit, int soc, int edu)
        {
            var min = Math.Min(Math.Min(fit, soc), edu);
            var max = Math.Max(Math.Max(fit, soc), edu);
            var mid = Math.Max(Math.Max(fit, soc), edu);
            if ((max == soc && min == edu) || (max == edu && min == soc))
            {
                return "FitnessTime";
            }
            else if ((max == fit && min == edu) || (max == edu && min == fit))
            {
                return "SocialTime";
            }
            else if ((max == soc && min == fit) || (max == fit && min == soc))
            {
                return "EduTime";
            }
            else
            {
                return "SocialTime";
            }
        }
    }
}