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
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ButtonDelete.Enabled = false;
                UpdateGridView();
            }

            // Default will the sewrver not know when a selection has changed in a DropDownList
            DropDownListShippers.AutoPostBack = true;
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

                // rdr kan kun læses én gang
                rdr.Close();
                rdr = cmd.ExecuteReader();

                DropDownListShippers.DataSource = rdr;
                // DataTextField is shown
                DropDownListShippers.DataTextField = "CompanyName";
                // DataValueField is returned
                DropDownListShippers.DataValueField = "ShipperID";
                DropDownListShippers.DataBind();
                DropDownListShippers.Items.Insert(0, "Select a shipper");
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

        protected void DropDownListShippers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownListShippers.SelectedIndex != 0)
            {
                LabelMessage.Text = "You have chosen shipper " + DropDownListShippers.SelectedValue;
                ButtonDelete.Enabled = true;
            }
            else
            {
                LabelMessage.Text = "You have chosen none";
                ButtonDelete.Enabled = false;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = northwind");
            // SqlConnection conn = new SqlConnection(@"data source = CPH-PC0WWCJQ; integrated security = true; database = northwind");
            SqlCommand cmd = null;
            // we use parameters (indicated by the @) instead of just taking the values from the TextBox'es
            // To avoid bad guys sql injection
            string sqldel = "delete from shippers where ShipperID = @ShipperID";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqldel, conn);
                cmd.Parameters.Add("@ShipperID", SqlDbType.Int);

                cmd.Parameters["@ShipperID"].Value = Convert.ToInt32(DropDownListShippers.SelectedValue);

                cmd.ExecuteNonQuery();

                LabelMessage.Text = "The shipper " + DropDownListShippers.SelectedValue + " named " + DropDownListShippers.SelectedItem.Text + " has been deleted";
                ButtonDelete.Enabled = false;
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
    }
}