using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace ShippersCRUD
{
    public partial class ReadUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ButtonUpdate.Enabled = false;
            }
            UpdateGridView();
        }

        public void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = (localdb)\MSSQLLocalDB; integrated security = true; database = northwind");
            // SqlConnection conn = new SqlConnection(@"data source = CPH-PC0WWCJQ; integrated security = true; database = northwind");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select * from shippers";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();

                GridViewShippers.DataSource = rdr;
                GridViewShippers.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = northwind");
            // SqlConnection conn = new SqlConnection(@"data source = CPH-PC0WWCJQ; integrated security = true; database = northwind");
            SqlCommand cmd = null;
            // we use parameters (indicated by the @) instead of just taking the values from the TextBox'es
            // To avoid bad guys sql injection
            string sqlupd = "update shippers set CompanyName = @CompanyName, Phone = @Phone where ShipperID = @ShipperID";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@ShipperID", SqlDbType.Int);
                cmd.Parameters.Add("@CompanyName", SqlDbType.Text);
                cmd.Parameters.Add("@Phone", SqlDbType.Text);

                cmd.Parameters["@ShipperID"].Value = Convert.ToInt32(GridViewShippers.SelectedRow.Cells[1].Text);
                cmd.Parameters["@CompanyName"].Value = TextBoxCompanyName.Text;
                cmd.Parameters["@Phone"].Value = TextBoxPhone.Text;

                cmd.ExecuteNonQuery();

                LabelMessage.Text = "Shipper updated";
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            UpdateGridView();
        }

        protected void ButtonGoTocreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx");
        }

        protected void ButtonGoToDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx");
        }

        protected void GridViewShippers_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxCompanyName.Text = GridViewShippers.SelectedRow.Cells[2].Text;
            TextBoxPhone.Text = GridViewShippers.SelectedRow.Cells[3].Text;
            LabelMessage.Text = "You have chosen ShipperID " + GridViewShippers.SelectedRow.Cells[1].Text;
            ButtonUpdate.Enabled = true;
        }
    }
}