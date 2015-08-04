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
    public partial class TeacherEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Department();
            course();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd =
                    new SqlCommand("insert into tbl_teacher( tName, tAddress, temail, tContactNumber, DepartmentName, CourseName, Credit) values (@tName, @tAddress, @temail, @tContactNumber, @DepartmentName, @CourseName, @Credit)", con);
                
                cmd.Parameters.AddWithValue("@tName", TeacherNameTextBox.Text);
                cmd.Parameters.AddWithValue("@tAddress", AddressTextBox.Text);
                cmd.Parameters.AddWithValue("@temail", EmailTextBox.Text);
                cmd.Parameters.AddWithValue("@tContactNumber", ContactTextBox.Text);
                cmd.Parameters.AddWithValue("@DepartmentName", DepartmentDropDownList.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@CourseName", DesignationDropDownList.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Credit", CreditTextBox.Text);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        protected void course()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select CourseName from tbl_Course", con);
                con.Open();

                DesignationDropDownList.DataSource = cmd.ExecuteReader();
                DesignationDropDownList.DataTextField = "CourseName";
                DesignationDropDownList.DataBind();
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