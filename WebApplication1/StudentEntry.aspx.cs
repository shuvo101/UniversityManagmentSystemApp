using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class StudentEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Department();
            }
        }

        protected void StudentButton_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd =
                     new SqlCommand("insert into tbl_Student( SName,  StudentId, SEmail, DepartmentName) values (@StudentName, @StudentID, @StudentEmail, @DepartmentName)", con);

                cmd.Parameters.AddWithValue("@StudentName", StuTextBox.Text);
                cmd.Parameters.AddWithValue("@StudentID", IDTextBox.Text);
                cmd.Parameters.AddWithValue("@StudentEmail", EmailTextBox.Text);
                cmd.Parameters.AddWithValue("@DepartmentName", DepartmentDropDownList.SelectedItem.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
            }
            
        }

        protected void Department()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select DepartmentName from tbl_department", con);
                con.Open();
                DepartmentDropDownList.DataSource = cmd.ExecuteReader();
                DepartmentDropDownList.DataTextField = "DepartmentName";
                DepartmentDropDownList.DataBind();
            }
        }


    }
}