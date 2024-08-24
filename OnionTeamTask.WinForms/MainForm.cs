using OnionTeamTask.DomainLayer.DomainModels;
using OnionTeamTask.ServiceLayer.Interface;
using System.Diagnostics;
using System.Drawing.Printing;

namespace OnionTeamTask.WinForms
{
    public partial class MainForm : Form
    {
        private readonly ITaskService _taskService;
        private readonly ICategoryService _categoryService;
        private readonly IStatusService _statusService;

        public MainForm(ITaskService taskService,
                              ICategoryService categoryService,
                              IStatusService statusService)
        {
            _taskService = taskService;
            _categoryService = categoryService;
            _statusService = statusService;

            InitializeComponent();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowList();
        }


        private void ShowList()
        {
            var taskList = _taskService.GetAllTasks();
            var pagedTasks = taskList
               .OrderBy(t => t.TaskIntId)
               .ToList();
            dgv.DataSource = pagedTasks;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(_taskService);
            form.Show();
        }
    }
}
