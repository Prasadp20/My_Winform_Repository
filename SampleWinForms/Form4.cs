using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SampleWinForms
{
    public partial class Form4 : Form
    {
        FileStream fs;
        public Form4()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();

                emp.Id = Convert.ToInt32(txtEmpId.Text);
                emp.Name = txtEmpName.Text;
                emp.Salary = Convert.ToDouble(txtEmpSalary.Text);

                fs = new FileStream(@"D:\Employee", FileMode.Create, FileAccess.Write);

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, emp);

                MessageBox.Show("Binary File Created");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();

                fs = new FileStream(@"D:\Employee", FileMode.Open, FileAccess.Read);

                BinaryFormatter bf = new BinaryFormatter();
                emp = (Employee)bf.Deserialize(fs);

                txtEmpId.Text = emp.Id.ToString();
                txtEmpName.Text = emp.Name.ToString();
                txtEmpSalary.Text = emp.Salary.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnXmlWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();

                emp.Id = Convert.ToInt32(txtEmpId.Text);
                emp.Name = txtEmpName.Text;
                emp.Salary = Convert.ToDouble(txtEmpSalary.Text);

                fs = new FileStream(@"D:\XML Employee", FileMode.Create, FileAccess.Write);

                XmlSerializer xs = new XmlSerializer(typeof(Employee));
                xs.Serialize(fs, emp);

                MessageBox.Show("XML File Created");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();

                fs = new FileStream(@"D:\XML Employee", FileMode.Open, FileAccess.Read);

                XmlSerializer xs = new XmlSerializer(typeof(Employee));
                emp = (Employee)xs.Deserialize(fs);

                txtEmpId.Text = emp.Id.ToString();
                txtEmpName.Text = emp.Name;
                txtEmpSalary.Text = emp.Salary.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnSOAPWrite_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            emp.Id = Convert.ToInt32(txtEmpId.Text);
            emp.Name = txtEmpName.Text;
            emp.Salary = Convert.ToInt32(txtEmpSalary.Text);

            fs = new FileStream(@"D:\SOAP Employee", FileMode.Create, FileAccess.Write);

            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fs, emp);
            MessageBox.Show("SOAP File Created");

        }

        private void btnSOAPRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();

                fs = new FileStream(@"D:\SOAP Employee", FileMode.Open, FileAccess.Read);

                SoapFormatter sf = new SoapFormatter();
                emp = (Employee)sf.Deserialize(fs);

                txtEmpId.Text = emp.Id.ToString();
                txtEmpName.Text = emp.Name;
                txtEmpSalary.Text = emp.Salary.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnJsonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();

                emp.Id = Convert.ToInt32(txtEmpId.Text);
                emp.Name = txtEmpName.Text;
                emp.Salary = Convert.ToDouble(txtEmpSalary.Text);

                fs = new FileStream(@"D:\ JSON Employee", FileMode.Create, FileAccess.Write);

                JsonSerializer.Serialize(fs, emp);
                MessageBox.Show("JSON File Created");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        private void btnJsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();

                fs = new FileStream(@"D:\ JSON Employee", FileMode.Open, FileAccess.Read);

                emp = JsonSerializer.Deserialize<Employee>(fs);

                txtEmpId.Text = emp.Id.ToString();
                txtEmpName.Text = emp.Name;
                txtEmpSalary.Text = emp.Salary.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
