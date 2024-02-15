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
                        selectedModel.InnerText = reader["Modello"].ToString();
                        selectedBasePrice.InnerText = $"Prezzo base: {reader["PrezzoBase"]:N3} €";
                        selectedImg.Src = reader["Immagine"].ToString();
                        double totale = 0;
                        double prezzoBase = Convert.ToDouble(reader["PrezzoBase"]);

                        if (CerchionInLega.Checked)
                        {
                            totale += reader["CerchioniInLega"] != DBNull.Value ? Convert.ToDouble(reader["CerchioniInLega"]) : 0;
                        }
                        if (climatizzatore.Checked)
                        {
                            totale += reader["Climatizzatore"] != DBNull.Value ? Convert.ToDouble(reader["Climatizzatore"]) : 0;
                        }
                        if (VerniceCromata.Checked)
                        {
                            totale += reader["VerniceCromata"] != DBNull.Value ? Convert.ToDouble(reader["VerniceCromata"]) : 0;
                        }
                        if (DoppioAirbag.Checked)
                        {
                            totale += reader["DoppioAirbag"] != DBNull.Value ? Convert.ToDouble(reader["DoppioAirbag"]) : 0;
                        }
                        if (ABS.Checked)
                        {
                            totale += reader["ABS"] != DBNull.Value ? Convert.ToDouble(reader["ABS"]) : 0;
                        }

                        int anniGaranzia = Convert.ToInt32(garanzia.SelectedValue);

                        if (anniGaranzia > 1 && anniGaranzia < 6)
                        {
                            totale += anniGaranzia * (reader["PrezzoGaranzia"] != DBNull.Value ? Convert.ToDouble(reader["PrezzoGaranzia"]) : 0);
                        }


                        selectedTotalPrice.InnerText = "Prezzo Totale: " + (totale + prezzoBase).ToString("N3") + " €";

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