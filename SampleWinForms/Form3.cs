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
    public partial class Form3 : Form
    {
        FileStream fs;
        public Form3()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                prod.id = Convert.ToInt32(txtProdId.Text);
                prod.name = txtProdName.Text;
                prod.price = Convert.ToInt32(txtProdPrice.Text);
                fs = new FileStream(@"D:\Product", FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, prod);
                MessageBox.Show("File Created");
            }
            catch (Exception ex)
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
                Product prod = new Product();
                fs = new FileStream(@"D:\Product", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                prod = (Product)bf.Deserialize(fs);
                txtProdId.Text = prod.id.ToString();
                txtProdName.Text = prod.name.ToString();
                txtProdPrice.Text = prod.price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnXMLWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                prod.id = Convert.ToInt32(txtProdId.Text);
                prod.name = txtProdName.Text;
                prod.price = Convert.ToInt32(txtProdPrice.Text);
                fs = new FileStream(@"D:\ProductXML", FileMode.Create, FileAccess.Write);
                XmlSerializer xs = new XmlSerializer(typeof(Product));
                xs.Serialize(fs, prod);
                MessageBox.Show("XML File Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        private void btnXMLRead_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                fs = new FileStream(@"D:\ProductXML", FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(Product));
                prod = (Product)xs.Deserialize(fs);
                txtProdId.Text = prod.id.ToString();
                txtProdName.Text = prod.name.ToString();
                txtProdPrice.Text = prod.price.ToString();
            }
            catch (Exception ex)
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
            try
            {
                Product prod = new Product();
                prod.id = Convert.ToInt32(txtProdId.Text);
                prod.name = txtProdName.Text;
                prod.price = Convert.ToInt32(txtProdPrice.Text);
                fs = new FileStream(@"D:\ProductSoap", FileMode.Create, FileAccess.Write);
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, prod);
                MessageBox.Show("Soap File Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnSOAPRead_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                fs = new FileStream(@"D:\ProductSoap", FileMode.Open, FileAccess.Read);
                SoapFormatter sf = new SoapFormatter();
                prod = (Product)sf.Deserialize(fs);
                txtProdId.Text = prod.id.ToString();
                txtProdName.Text = prod.name.ToString();
                txtProdPrice.Text = prod.price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnJSONWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                prod.id = Convert.ToInt32(txtProdId.Text);
                prod.name = txtProdName.Text;
                prod.price = Convert.ToInt32(txtProdPrice.Text);
                fs = new FileStream(@"D:\ProductJSON", FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize(fs, prod);
                MessageBox.Show("JSON File Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnJSONRead_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                fs = new FileStream(@"D:\ProductJSON", FileMode.Open, FileAccess.Read);
                prod = JsonSerializer.Deserialize<Product>(fs);
                txtProdId.Text = prod.id.ToString();
                txtProdName.Text = prod.name.ToString();
                txtProdPrice.Text = prod.price.ToString();
            }
            catch (Exception ex)
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

