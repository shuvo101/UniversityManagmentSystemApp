using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace WebApplication1
{
    public partial class ViewResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentId();
                GridView();
            }
        }

        protected void StudentId()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select StudentId from tbl_Student", con);
                con.Open();
                StuReDropDownList.DataSource = cmd.ExecuteReader();
                StuReDropDownList.DataTextField = "StudentId";
                StuReDropDownList.DataBind();
                con.Close();
            }
        }

        protected void GridView()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select CourseName, Result from tbl_enroll where StudentId = '" + StuReDropDownList.SelectedValue + "'", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
        }

        protected void StuReDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmde = new SqlCommand("select SName, SEmail, DepartmentName from tbl_enroll where StudentId='" + StuReDropDownList.SelectedValue + "'", con);
                con.Open();
                SqlDataReader dr;
                dr = cmde.ExecuteReader();
                while (dr.Read())
                {
                    StuNameTextBox.Text = dr.GetString(0);
                    EmailTextBox.Text = dr.GetValue(1).ToString();
                    DepartTextBox.Text = dr.GetValue(2).ToString();
                }
                con.Close();
            }
        }

        protected void MakePdfButton_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(GridView1.HeaderRow.Cells.Count);


            foreach (TableCell headeCell in GridView1.HeaderRow.Cells)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(headeCell.Text));
                pdfTable.AddCell(pdfPCell);
            }


            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfTable.AddCell(pdfPCell);
                }
            }

            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-disposition", "Attachment;filename=Employee.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();


        }


    }
}