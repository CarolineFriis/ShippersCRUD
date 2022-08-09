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
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = (localdb)\MSSQLLocalDB; integrated security = true; database = northwind");
            // SqlConnection conn = new SqlConnection(@"data source = CPH-PC0WWCJQ; integrated security = true; database = northwind");
            SqlCommand cmd = null;
            // we use parameters (indicated by the @) instead of just taking the values from the TextBox'es
            // To avoid bad guys sql injection
            string sqlins = "insert into shippers values (@CompanyName, @Phone)";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@CompanyName", SqlDbType.Text);
                cmd.Parameters.Add("@Phone", SqlDbType.Text);

                cmd.Parameters["@CompanyName"].Value = TextBoxCompanyName.Text;
                cmd.Parameters["@Phone"].Value = TextBoxPhone.Text;

                cmd.ExecuteNonQuery();

                LabelMessage.Text = "Shipper added";
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
    }
}