using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CourseEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select DepartmentName from tbl_Course", con);
                con.Open();

                DepeartmentDropDownList.DataSource = cmd.ExecuteReader();
                DepeartmentDropDownList.DataTextField = "DepartmentName";
                DepeartmentDropDownList.DataBind();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_Course( Course_Id, CourseName, Course_Credit, Description, DepartmentName, Semester) values (@CourseId, @CourseName, @Course_Credit, @Description, @DepartmentName, @Semester)", con);


                cmd.Parameters.AddWithValue("@CourseId", CourseCodeTextBox.Text);
                cmd.Parameters.AddWithValue("@CourseName", CourseNameTextBox.Text);
                cmd.Parameters.AddWithValue("@Course_Credit", CreditTextBox.Text);
                cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@DepartmentName", DepeartmentDropDownList.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Semester", SemesterDropDownList.SelectedItem.ToString());
                con.Open();
                //SqlCommand cmd = new SqlCommand("insert into tbl_Course(Course_Id, CourseName, Course_Credit, Description, Semester ) values('" + CourseCodeTextBox.Text + "','" + CourseNameTextBox.Text + "', '" + CreditTextBox.Text + "', '" + DescriptionTextBox.Text + "', '" + SemesterDropDownList.SelectedIndex + "')", con);
                cmd.ExecuteNonQuery();
                //con.Close();
                
            }

        }

        protected void DepeartmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(CS))
            //{
            //   // con.Open();
            //   //// SqlDataAdapter sda;
            //   // DataTable dt=new DataTable();

            //   // SqlDataAdapter sda = new SqlDataAdapter("Select DepartmentName from tbl_department", con);
               
            //   // sda.Fill(dt);
            //   // SqlDataReader dr;
            //   // while (dr.Read())
            //   // {
            //   //     DepeartmentDropDownList.SelectedValue = dt.Rows[0][0].ToString();
            //   //}
                
            //   // con.Close();

            //    con.Open();
            //    SqlDataReader dr;
            //    string str = "Select DepartmentName from tbl_department";
            //    SqlCommand cmd = new SqlCommand(str, con);
                
            //    DataTable dt=new DataTable();
            //   // cmd.ExecuteNonQuery();
            //    dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        DepeartmentDropDownList.SelectedValue=dr.GetString(0)  ;
            //    }
            //    con.Close();   

            //}
        }

        protected void SemesterDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}