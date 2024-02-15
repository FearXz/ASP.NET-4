using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_4
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAutoDropDownList();
            }

        }
        protected void getAutoDropDownList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "SELECT IDAuto, Modello FROM Auto";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem listItem = new ListItem();
                    listItem.Text = reader["Modello"].ToString();
                    listItem.Value = reader["IDAuto"].ToString();

                    dropDownAutoList.Items.Add(listItem);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }
        }

        protected void GetDetailCar_Click(object sender, EventArgs e)
        {
            string selectedCar = dropDownAutoList.SelectedValue;

            if (selectedCar != "null")
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ToString();
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();

                    string query = $"SELECT * FROM Auto WHERE IDAuto = {selectedCar}";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally { conn.Close(); }
            }
        }
    }
}