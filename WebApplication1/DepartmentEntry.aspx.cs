using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class DepartmentEntry : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=SHUVO-PC\SQLEXPRESS;Initial Catalog=University;Integrated Security=True");
              
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                //SqlCommand cmd = new SqlCommand("insert into tbl_department(DepartmentId, DepartmentName)", con);
                //cmd.Parameters.AddWithValue("@DepartmentId", DepartmentCodeTextBox.Text);
                //cmd.Parameters.AddWithValue("@DepartmentName", DepartmentNameTextBox.Text);
               
                //cmd.ExecuteNonQuery();

                //DepartmentCodeTextBox.Text = "";
                //DepartmentNameTextBox.Text = "";
                SqlCommand cmd = new SqlCommand("insert into tbl_department(DepartmentId, DepartmentName) values('" + DepartmentCodeTextBox.Text + "','" + DepartmentNameTextBox.Text + "')",con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}