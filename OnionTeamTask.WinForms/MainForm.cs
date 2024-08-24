using OnionTeamTask.DomainLayer.DomainModels;
using OnionTeamTask.DomainLayer.DTO;
using OnionTeamTask.ServiceLayer.Interface;
using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnionTeamTask.WinForms
{
    public partial class MainForm : Form
    {
        public Guid taskGuid = Guid.Empty;

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            ///--------------------------------------------------------
            if (taskGuid != Guid.Empty)
            {
                string selCategory = cboCategory.SelectedValue.ToString();
                string selStatus = cboStatus.SelectedValue.ToString();

                var taskUpdateDto = new TaskUpdateDto
                {
                    TaskName = txtTaskName.Text,
                    TaskDueDate = Convert.ToDateTime(dtpTaskDueDate.Value),
                    CategoryId = Convert.ToInt32(selCategory),
                    StatusId = Convert.ToInt32(selStatus),
                    TaskDescription = txtTaskDescription.Text
                };
                _taskService.UpdeteTask(taskGuid, taskUpdateDto);
            }
            else
            {
                MessageBox.Show("Select record to edit.");
            }
            CleanForm();
            ShowList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (taskGuid != Guid.Empty)
            {
                _taskService.DeleteTask(taskGuid);

                CleanForm();
                ShowList();
            }
            else
            {
                MessageBox.Show("Select record to edit.");
            }
        }

        private void CleanForm()
        {
            txtTaskName.Text = "";
            txtTaskDescription.Text = "";

            cboCategory.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string strID = dgv.Rows[dgv.CurrentCellAddress.Y].Cells[0].Value.ToString() as string;
            Guid gId = Guid.Parse(strID);

            Taskd taskd1 = _taskService.GetDetailsForTask(gId);

            DateTime date = taskd1.TaskDueDate;

            //da = OnionTeamTask.Web.Controllers.TaskvController.DateFormat(date);

            txtTaskName.Text = taskd1.TaskName;
            dtpTaskDueDate.Value = date;
            cboCategory.SelectedValue = taskd1.CategoryId;
            cboStatus.SelectedValue = taskd1.StatusId;
            txtTaskDescription.Text = taskd1.TaskDescription;
            taskGuid = taskd1.TaskId;

        }

        //private List<Taskd> GetDetails(Guid id)
        //{
        //    var taskDetail = _taskService.GetDetailsForTask(id);
        //    return taskDetail != null ? new List<Taskd> { taskDetail } : new List<Taskd>();
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanForm();
            ShowList();
        }
    }
}
