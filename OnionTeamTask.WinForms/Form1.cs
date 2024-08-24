using OnionTeamTask.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnionTeamTask.WinForms
{
    public partial class Form1 : Form
    {
        public Form1(ITaskService _taskService)
        {
            InitializeComponent();
            var taskList = _taskService.GetAllTasks();
            var pagedTasks = taskList
               .OrderBy(t => t.TaskIntId)
               .ToList();
            dgv.DataSource = pagedTasks;
        }
    }
}
