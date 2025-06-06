using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Shop
{
    public partial class Forms3 : Form
    {
        public Forms3()
        {
            InitializeComponent();
        }


        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text.Trim());
            string name = txtname.Text.Trim();
            decimal price = decimal.Parse(txtprice.Text.Trim());
            string connectionString = "server=localhost;user id=root;password=;database=c#";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO product (pid, pname, pprice) VALUES (@id, @name, @price)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // استخدام المعاملات الآمنة
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("تمت إضافة المنتج بنجاح!");
                    }
                    else
                    {
                        MessageBox.Show("لم يتم إضافة المنتج.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ: " + ex.Message);
                }
            }
        }

        

        private void Guna2Button2_Click(object sender, EventArgs e)
        {  
            // parse confirt id to int
            int id = int.Parse(txtid.Text.Trim());
            string name = txtname.Text.Trim();
            decimal price = decimal.Parse(txtprice.Text.Trim());
            string connectionString = "server=localhost;user id=root;password=;database=c#";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // تحقق أولاً هل البيانات موجودة
                    string checkQuery = "SELECT COUNT(*) FROM product WHERE pid = @id AND pname = @name AND pprice = @price";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@id", id);
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@price", price);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        // حذف السجل
                        string deleteQuery = "DELETE FROM product WHERE pid = @id AND pname = @name AND pprice = @price";
                        MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@id", id);
                        deleteCmd.Parameters.AddWithValue("@name", name);
                        deleteCmd.Parameters.AddWithValue("@price", price);

                        deleteCmd.ExecuteNonQuery();

                        MessageBox.Show("تم حذف المنتج بنجاح.");
                    }
                    else
                    {
                        MessageBox.Show("لم يتم العثور على المنتج بهذه البيانات.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ: " + ex.Message);
                }
            }
        }

    }
                }