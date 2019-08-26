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
using MetroFramework;
using MetroFramework.Controls;
using WFAPersonelTakibi.Models.Context;
using WFAPersonelTakibi.Models.Entities;

namespace WFAPersonelTakibi
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        void clean()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is ComboBox)
                {
                    ComboBox cmb = (ComboBox)item;
                    cmb.SelectedIndex = -1;
                }
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        void LoadEmployee()
        {
            
            txtAddress.Text = FakeData.PlaceData.GetAddress();
            txtFirstName.Text = FakeData.NameData.GetFirstName();
            txtLastName.Text = FakeData.NameData.GetSurname();
            textBox1.Text = FakeData.NetworkData.GetEmail();
            txtPhone.Text = FakeData.PhoneNumberData.GetPhoneNumber();
            dtBirthDate.Value = FakeData.DateTimeData.GetDatetime();

        }

        MyContext context = new MyContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDepartment.DataSource = context.Departments.ToList();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "DepartmentID";
           
        }
        Employee employee;
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (employee==null)
            {
                employee = new Employee();
            }

            if (!employee.HasImage)
            {
                MessageBox.Show(this,"Lütfen bir resim seçiniz","Kayıt Bildirimi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }


            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.BirthDate = dtBirthDate.Value;
            employee.Mail = textBox1.Text;
            for (int i = 0; i < metroPanel1.Controls.Count; i++)
            {
                if (metroPanel1.Controls[i] is RadioButton)
                {
                    RadioButton rd = (RadioButton)metroPanel1.Controls[i];
                    if (rd.Checked)
                    {
                        employee.Gender = (Gender)Enum.Parse(typeof(Gender), rd.Text);
                    }
                }
            }
            employee.DepartmentID = (Guid)cmbDepartment.SelectedValue;
            employee.Address = txtAddress.Text;
            employee.Phone = txtPhone.Text;
            context.Employees.Add(employee);
            bool result = context.SaveChanges() > 0;
            employee = null;

            MessageBox.Show(this,result ? "Kayıt Eklendi" : "İşlem Hatası", "Kayıt Ekleme Bildirimi",
                MessageBoxButtons.OK,result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            clean();
        }

        private void MetroLink1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.ShowDialog();
        }

        
        private void PcbImageUrl_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*png";
            if (openfile.ShowDialog()==DialogResult.OK)
            {
                if (employee==null)
                {
                    employee = new Employee();
                }
                pcbImageUrl.Image = Image.FromFile(openfile.FileName);
                employee.ImageUrl = $"{Guid.NewGuid()}{System.IO.Path.GetExtension(openfile.FileName)}";

                pcbImageUrl.Image.Save($@"{Environment.CurrentDirectory}\..\..\Images\{employee.ImageUrl}");
                employee.HasImage = true;
            }
        }

        private void MetroLink2_Click(object sender, EventArgs e)
        {
            LoadEmployee();
        }
    }
}
