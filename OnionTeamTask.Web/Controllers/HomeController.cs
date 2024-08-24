using Microsoft.AspNetCore.Mvc;
using OnionTeamTask.DomainLayer.DomainModels;
using OnionTeamTask.ServiceLayer.Interface;
//using OnionTeamTask.Web.Models;
using System.Diagnostics;


namespace OnionTeamTask.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITaskService _taskService;

        private readonly ICategoryService _categoryService;

        private readonly IStatusService _statusService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ITaskService taskService,
                              ICategoryService categoryService,
                              IStatusService statusService,
                              ILogger<HomeController> logger)
        {
            _taskService = taskService;
            _categoryService = categoryService;
            _statusService = statusService;
            _logger = logger;
        }


        public IActionResult Index(int p)
        {
            if (p == 0)
            {
                p = 1;
            }

            int pageSize = 4;
            int pageNumber = p;

            var taskList = _taskService.GetAllTasks();
            int totalCount = taskList.Count();

            // Calculate total number of pages
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            // Fetch the required page of tasks
            var pagedTasks = taskList
               .OrderBy(t => t.TaskIntId)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToList();

            ViewData["Poracka"] = pagedTasks;

            // Setup pagination ViewBag variables
            ViewBag.page = pageNumber;
            ViewBag.pages = totalPages;
            ViewBag.leftPage = Math.Max(1, pageNumber - 1);  // Handle the left page
            ViewBag.rightPage = Math.Min(totalPages, pageNumber + 1);  // Handle the right page

            return View();
        }

        //[Route("")]
        [Route("Home/Taskv/{a?}")]
        public IActionResult Taskv(string a)
        {
            string taskName = "", taskDueDate = "", category = "", status = "", selCategory = "", selStatus = "", taskDescription = "";

            ViewData["cat"] = _categoryService.GetAllCategories();
            ViewData["sta"] = _statusService.GetAllStatuses();

            //if (Request.Method == "POST")
            //{
            //    taskName = HttpContext.Request.Form["txtTaskName"].ToString();
            //    taskDueDate = HttpContext.Request.Form["datTaskDueDate"].ToString();

            //    selCategory = HttpContext.Request.Form["selCategory"].ToString();
            //    selStatus = HttpContext.Request.Form["selStatus"].ToString();

            //    taskDescription = HttpContext.Request.Form["txtTaskDescription"].ToString();

            //    using (var context = new TeamTaskManDbContext())
            //    {
            //        var tsk1 = new Taskd() { 
            //            TaskName = taskName, 
            //            TaskDueDate = Convert.ToDateTime(taskDueDate), 
            //            CategoryId = Convert.ToInt32(selCategory),
            //            StatusId = Convert.ToInt32(selStatus),
            //            TaskDescription = taskDescription
            //        };
            //        context.Taskds.Add(tsk1);
            //        context.SaveChanges();
            //    }
            //}

            switch (a)
            {
                case "e":
                    //Edit

                    //string taskName, taskDueDate;
                    ////gud = HttpContext.Request.Form["txtGuid"].ToString();
                    //taskName = HttpContext.Request.Form["txtTaskName"].ToString();
                    //taskDueDate = HttpContext.Request.Form["taskDueDate"].ToString();


                    ViewBag.But = "Edit";
                    break;
                case "d":
                    //using (var context = new TeamTaskManDbContext())
                    //{
                    //    var tsk1 = new Taskd() { TaskName = "1st Grade" };
                    //    context.Taskds.Add(tsk1);
                    //    context.SaveChanges();
                    //}
                    ViewBag.But = "Delete";
                    break;

                case "n":


                    break;

                default:
                    ViewBag.But = "Add New";
                    break;
            }



            return View();
        }

        public IActionResult Taskv()
        {
            string taskName = "", taskDueDate = "", category = "", status = "", selCategory = "", selStatus = "", taskDescription = "";

            ViewData["cat"] = _categoryService.GetAllCategories();
            ViewData["sta"] = _statusService.GetAllStatuses();


            if (Request.Method == "POST")
            {
                taskName = HttpContext.Request.Form["txtTaskName"].ToString();
                taskDueDate = HttpContext.Request.Form["datTaskDueDate"].ToString();

                selCategory = HttpContext.Request.Form["selCategory"].ToString();
                selStatus = HttpContext.Request.Form["selStatus"].ToString();

                taskDescription = HttpContext.Request.Form["txtTaskDescription"].ToString();

                var newTask = new Taskd()
                {
                    TaskName = taskName,
                    TaskDueDate = Convert.ToDateTime(taskDueDate),
                    CategoryId = Convert.ToInt32(selCategory),
                    StatusId = Convert.ToInt32(selStatus),
                    TaskDescription = taskDescription
                };
                _taskService.CreateNewTask(newTask);
            }

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
