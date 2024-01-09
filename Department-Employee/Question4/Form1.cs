using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Question4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (-1 == BusinessLayer.Departments.UpdateDepartments())
            {
                Validate();
                bindingSource1.ResetBindings(false);
                bindingSource1.DataSource = Data.EF.GetDepartments().ToBindingList();
                bindingSource1.Sort = "DeptId";
                MessageBox.Show("Impossible to update/delete departments");
            }
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            if (-1 == BusinessLayer.Employees.UpdateEmployees())
            {
                Validate();
                bindingSource2.ResetBindings(false);
                bindingSource2.DataSource = Data.EF.GetEmployees().ToBindingList();
                bindingSource2.Sort = "EmpId";
            }
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = Data.EF.GetDepartments().ToBindingList();
            bindingSource1.Sort = "DeptId";
            dataGridView1.DataSource = bindingSource1;
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource2.DataSource = Data.EF.GetEmployees().ToBindingList();
            bindingSource2.Sort = "EmpId";
            dataGridView1.DataSource = bindingSource2;

            dataGridView1.Columns["EmpId"].HeaderText = "Employee ID";
            dataGridView1.Columns["EmpId"].DisplayIndex = 0;
            dataGridView1.Columns["Name"].DisplayIndex = 1;
            dataGridView1.Columns["Salary"].DisplayIndex = 2;
            dataGridView1.Columns["DeptId"].DisplayIndex = 3;
        }

        

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("DataError: Impossible to add/modify/delete");
            e.Cancel = false;
        }
    }
}
