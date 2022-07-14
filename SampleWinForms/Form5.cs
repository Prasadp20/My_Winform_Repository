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
    public partial class Form5 : Form
    {
        FileStream fs;
        public Form5()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Course cs = new Course();
                cs.Id = Convert.ToInt32(txtCourseId.Text);
                cs.Name = txtCourseName.Text;
                cs.fee = Convert.ToDouble(txtCourseFee.Text);

                fs = new FileStream(@"D:\Binary Course", FileMode.Create, FileAccess.Write);

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, cs);

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
                Course cs = new Course();

                fs = new FileStream(@"D:\Binary Course", FileMode.Open, FileAccess.Read);

                BinaryFormatter bf = new BinaryFormatter();
                cs = (Course)bf.Deserialize(fs);

                txtCourseId.Text = cs.Id.ToString();
                txtCourseName.Text = cs.Name;
                txtCourseFee.Text = cs.fee.ToString();
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
                Course cs = new Course();

                cs.Id = Convert.ToInt32(txtCourseId.Text);
                cs.Name = txtCourseName.Text;
                cs.fee = Convert.ToDouble(txtCourseFee.Text);

                fs = new FileStream(@"D:\XML Course", FileMode.Create, FileAccess.Write);

                XmlSerializer xs = new XmlSerializer(typeof(Course));
                xs.Serialize(fs, cs);
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
                Course cs = new Course();

                fs = new FileStream(@"D:\XML Course", FileMode.Open, FileAccess.Read);

                XmlSerializer xs = new XmlSerializer(typeof(Course));
                cs = (Course)xs.Deserialize(fs);

                txtCourseId.Text = cs.Id.ToString();
                txtCourseName.Text = cs.Name;
                txtCourseFee.Text = cs.fee.ToString();
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

        private void btnSoapWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Course cs = new Course();

                cs.Id = Convert.ToInt32(txtCourseId.Text);
                cs.Name = txtCourseName.Text;
                cs.fee = Convert.ToDouble(txtCourseFee.Text);

                fs = new FileStream(@"D:\SOAP Course", FileMode.Create, FileAccess.Write);
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, cs);
                MessageBox.Show("SOAP File Created");
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

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
            try
            {
                Course cs = new Course();

                fs = new FileStream(@"D:\SOAP Course", FileMode.Open, FileAccess.Read);

                SoapFormatter sf = new SoapFormatter();
                cs = (Course)sf.Deserialize(fs);

                txtCourseId.Text = cs.Id.ToString();
                txtCourseName.Text = cs.Name;
                txtCourseFee.Text = cs.fee.ToString();
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
                Course cs = new Course();

                cs.Id = Convert.ToInt32(txtCourseId.Text);
                cs.Name = txtCourseName.Text;
                cs.fee = Convert.ToDouble(txtCourseFee.Text);

                fs = new FileStream(@"D:\JSON Course", FileMode.Create, FileAccess.Write);

                JsonSerializer.Serialize(fs, cs);

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
                Course cs = new Course();

                fs = new FileStream(@"D:\JSON Course", FileMode.Open, FileAccess.Read);

                cs = JsonSerializer.Deserialize<Course>(fs);

                txtCourseId.Text = cs.Id.ToString();
                txtCourseName.Text = cs.Name;
                txtCourseFee.Text = cs.fee.ToString();
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
