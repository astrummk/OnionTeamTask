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

            cboCategory.DataSource = _categoryService.GetAllCategories();
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryID";
            cboCategory.SelectedIndex = -1;

            cboStatus.DataSource = _statusService.GetAllStatuses();
            cboStatus.DisplayMember = "StatusName";
            cboStatus.ValueMember = "StatusId";
            cboStatus.SelectedIndex = -1;


            //ViewData["sta"] = _statusService.GetAllStatuses();

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
               .OrderByDescending(t => t.TaskIntId)
               .ToList();
            dgv.DataSource = pagedTasks;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(_taskService);
            form.Show();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string selCategory = cboCategory.SelectedValue.ToString();
            string selStatus = cboStatus.SelectedValue.ToString();

            var newTask = new Taskd()
            {
                TaskName = txtTaskName.Text,
                TaskDueDate = Convert.ToDateTime(dtpTaskDueDate.Value),
                CategoryId = Convert.ToInt32(selCategory),
                StatusId = Convert.ToInt32(selStatus),
                TaskDescription = txtTaskDescription.Text
            };
            _taskService.CreateNewTask(newTask);

            CleanForm();
            ShowList();
        }

        private void CleanForm()
        {
            txtTaskName.Text = "";
            txtTaskDescription.Text = "";

            cboCategory.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
        }
    }
}
