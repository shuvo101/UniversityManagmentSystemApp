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
    public partial class Enrol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentId();
                course();
            }
        }

        protected void EnrollButton_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd =
                    new SqlCommand("insert into tbl_enroll(StudentId, SName, SEmail, DepartmentName, CourseName) values (@StudentID, @StudentName, @StudentEmail, @DepartmentName, @CourseName)", con);

                cmd.Parameters.AddWithValue("@StudentName", StudentNameTextBox.Text);
                cmd.Parameters.AddWithValue("@StudentID", StudentIDDropDownList.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@StudentEmail", EmailTextBox.Text);
                cmd.Parameters.AddWithValue("@DepartmentName", DepartmentTextBox.Text);
                cmd.Parameters.AddWithValue("@CourseName", CourseDropDownList.SelectedItem.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        protected void StudentId()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select StudentId from tbl_Student", con);
                con.Open();
                StudentIDDropDownList.DataSource = cmd.ExecuteReader();
                StudentIDDropDownList.DataTextField = "StudentId";
                StudentIDDropDownList.DataBind();
                con.Close();
            }
        }

        protected void course()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select CourseName from tbl_Course", con);
                con.Open();
                CourseDropDownList.DataSource = cmd.ExecuteReader();
                CourseDropDownList.DataTextField = "CourseName";
                CourseDropDownList.DataBind();
                con.Close();
            }
        }

        protected void StudentIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmde = new SqlCommand("select SName, SEmail, DepartmentName from tbl_Student where StudentId='" + StudentIDDropDownList.SelectedValue + "'", con);
                con.Open();
                SqlDataReader dr;
                dr = cmde.ExecuteReader();
                while (dr.Read())
                {
                    StudentNameTextBox.Text = dr.GetString(0);
                    EmailTextBox.Text = dr.GetValue(1).ToString();
                    DepartmentTextBox.Text = dr.GetValue(2).ToString();
                }
                con.Close();
            }
        }
    }
}