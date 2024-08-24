using Microsoft.AspNetCore.Mvc;
using OnionTeamTask.DomainLayer.DomainModels;
using OnionTeamTask.DomainLayer.DTO;
using OnionTeamTask.ServiceLayer.Interface;

namespace OnionTeamTask.Web.Controllers
{
    public class TaskvController : Controller
    {
        private readonly ITaskService _taskService;

        private readonly ICategoryService _categoryService;

        private readonly IStatusService _statusService;

        private readonly ILogger<HomeController> _logger;

        public TaskvController(ITaskService taskService,
                               ICategoryService categoryService,
                               IStatusService statusService,
                               ILogger<HomeController> logger)
        {
            _taskService = taskService;
            _categoryService = categoryService;
            _statusService = statusService;
            _logger = logger;
        }

        public string taskName = "", taskDueDate = "", category = "", status = "", selCategory = "0", selStatus = "0", taskDescription = "", taskID = "";

        public IActionResult Index(string a, Guid id)
        {
            Init();

            switch (a)
            {
                case "a":
                    ViewBag.But = "AddNew";
                    break;

                case "e":
                    ViewBag.But = "Edit";
                    ViewData["fdat"] = GetDetails(id);
                    break;

                case "d":
                    ViewBag.But = "Delete";
                    ViewData["fdat"] = GetDetails(id);
                    break;

                default:
                    break;
            }

            return View();
        }

        private List<Taskd> GetDetails(Guid id)
        {
            var taskDetail = _taskService.GetDetailsForTask(id);
            return taskDetail != null ? new List<Taskd> { taskDetail } : new List<Taskd>();
        }

        public IActionResult Edit()
        {
            GetPost();

            if (Guid.TryParse(taskID, out Guid taskGuid))
            {
                var taskUpdateDto = new TaskUpdateDto
                {
                    TaskName = taskName,
                    TaskDueDate = Convert.ToDateTime(taskDueDate),
                    CategoryId = Convert.ToInt32(selCategory),
                    StatusId = Convert.ToInt32(selStatus),
                    TaskDescription = taskDescription
                };

                _taskService.UpdeteTask(taskGuid, taskUpdateDto);
            }
            else
            {
                throw new ArgumentException("Invalid task ID format.");
            }


            return RedirectToAction("Index", "Home");
        }


        public IActionResult Delete()
        {
            GetPost();
            if (Guid.TryParse(taskID, out Guid taskGuid))
            {
                _taskService.DeleteTask(taskGuid);
            }
            else
            {
                throw new ArgumentException("Invalid task ID format.");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddNew()
        {
            Init();
            GetPost();
            var newTask = new Taskd()
            {
                TaskName = taskName,
                TaskDueDate = Convert.ToDateTime(taskDueDate),
                CategoryId = Convert.ToInt32(selCategory),
                StatusId = Convert.ToInt32(selStatus),
                TaskDescription = taskDescription
            };
            _taskService.CreateNewTask(newTask);
            return RedirectToAction("Index", "Home");
        }

        private void Init()
        {
            ViewData["cat"] = _categoryService.GetAllCategories();
            ViewData["sta"] = _statusService.GetAllStatuses();
        }

        public void GetPost()
        {

            if (Request.Method == "POST")
            {
                taskName = HttpContext.Request.Form["txtTaskName"].ToString();
                taskDueDate = HttpContext.Request.Form["datTaskDueDate"].ToString();

                selCategory = HttpContext.Request.Form["selCategory"].ToString();
                selStatus = HttpContext.Request.Form["selStatus"].ToString();

                taskDescription = HttpContext.Request.Form["txtTaskDescription"].ToString();

                taskID = HttpContext.Request.Form["tGu"].ToString();

            }
        }

        public static string DateFormat(DateTime date)
        {
            //DateTimeFormatInfo format = new DateTimeFormatInfo();
            //format.ShortDatePattern = "yyyy-MM-dd";
            //format.DateSeparator = "-";
            //DateTime date2 = date;
            //DateTime shortDate = Convert.ToDateTime(date2, format);

            //return shortDate.ToString();

            string m;
            if (date.Month.ToString().Length == 1)
            {
                m = "0" + date.Month.ToString();
            }
            else
            {
                m = date.Month.ToString();
            }
            string d;
            if (date.Day.ToString().Length == 1)
            {
                d = "0" + date.Day.ToString();
            }
            else
            {
                d = date.Day.ToString();
            }

            return date.Year.ToString() + "-" + m + "-" + d;

        }

    }
}
