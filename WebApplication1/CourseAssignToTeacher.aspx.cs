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
    public partial class CourseAssignToTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Department();
                  course();
                Teacher();
            }
           
        }

        protected void AssignButton_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd =
                    new SqlCommand("insert into tbl_AssignToTeacher( DepartmentName,  tName, Course_Id, CourseName, Course_Credit) values (@DepartmentName, @tName, @Course_Id, @CourseName, @Course_Credit)", con);

                cmd.Parameters.AddWithValue("@DepartmentName", DeprtDropDownList.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@tName", TeacherDropDownList.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Course_Id", CourseCodeDropDownList.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@CourseName", SubjectNameTextBox.Text);
                cmd.Parameters.AddWithValue("@Course_Credit", CreditTextBox.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void course()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select Course_Id from tbl_Course", con);
                con.Open();
                CourseCodeDropDownList.DataSource = cmd.ExecuteReader();
                CourseCodeDropDownList.DataTextField = "Course_Id";
                CourseCodeDropDownList.DataBind();
                con.Close();
             }
        }

        protected void Department()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select DepartmentName from tbl_department", con);
                con.Open();
                DeprtDropDownList.DataSource = cmd.ExecuteReader();
                DeprtDropDownList.DataTextField = "DepartmentName";
                DeprtDropDownList.DataBind();
            }
        }

        protected void Teacher()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select tName from tbl_teacher", con);
                con.Open();
                TeacherDropDownList.DataSource = cmd.ExecuteReader();
                TeacherDropDownList.DataTextField = "tName";
                TeacherDropDownList.DataBind();
            }
        }


        protected void CourseCodeDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
           
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmde = new SqlCommand("select CourseName, Course_Credit from tbl_Course where Course_Id='" + CourseCodeDropDownList.SelectedValue + "'", con);
                con.Open();
                SqlDataReader dr;
                dr = cmde.ExecuteReader();
                while (dr.Read())
                {
                    SubjectNameTextBox.Text = dr.GetString(0);
                    CreditTextBox.Text = dr.GetValue(1).ToString();
                }
                con.Close();
            }

        }
    }
}