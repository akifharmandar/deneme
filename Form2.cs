using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using FakeData;
using System.Data.Entity;

namespace WFAPersonelTakibi
{ using System;
    using Models;
    using Models.Context;
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }
        MyContext context = new MyContext();

        void EmployeeListesi()
        {
            dgvEmployees.DataSource = context.Employees.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Mail,
                x.Phone,
                x.BirthDate,
                x.Gender,
                x.Department.Name
            }).ToList();
        }
        void EmployeeListesi(Guid ID)
        {
            dgvEmployees.DataSource = context
                .Employees
                .Where(x=>x.DepartmentID==ID)
                .Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Mail,
                x.Phone,
                x.BirthDate,
                x.Gender,
                x.Department.Name
            }).ToList();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            EmployeeListesi();
            comboBox1.DataSource = context.Departments.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "DepartmentID";
            comboBox1.SelectedIndex = -1;
        }

        private void TsmDuzenle_Click(object sender, EventArgs e)
        {

        }

        private void TsmSil_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeListesi((Guid)comboBox1.SelectedValue);
        }
    }
}
