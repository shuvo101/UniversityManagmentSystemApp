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
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentId();
                course();
            }
        }

        protected void ResultSaveButton_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd =
                    new SqlCommand("insert into tbl_enroll(StudentId, SName, SEmail, DepartmentName, CourseName, Result) values (@StudentID, @StudentName, @StudentEmail, @DepartmentName, @CourseName, @Result)", con);

                cmd.Parameters.AddWithValue("@StudentName", StudNameTextBox.Text);
                cmd.Parameters.AddWithValue("@StudentID", StudDropDownList.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@StudentEmail", EmailTextBox.Text);
                cmd.Parameters.AddWithValue("@DepartmentName", DepartmentTextBox.Text);
                cmd.Parameters.AddWithValue("@CourseName", CourseDropDownList.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Result", ResultDropDownList.SelectedItem.ToString());
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
                StudDropDownList.DataSource = cmd.ExecuteReader();
                StudDropDownList.DataTextField = "StudentId";
                StudDropDownList.DataBind();
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

        protected void StudDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmde = new SqlCommand("select SName, SEmail, DepartmentName from tbl_Student where StudentId='" + StudDropDownList.SelectedValue + "'", con);
                con.Open();
                SqlDataReader dr;
                dr = cmde.ExecuteReader();
                while (dr.Read())
                {
                    StudNameTextBox.Text = dr.GetString(0);
                    EmailTextBox.Text = dr.GetValue(1).ToString();
                    DepartmentTextBox.Text = dr.GetValue(2).ToString();
                }
                con.Close();
            }
        }
    }
}