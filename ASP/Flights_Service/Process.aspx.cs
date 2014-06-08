using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flights_Service.App_Code;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Flights_Service
{
    public partial class Process : System.Web.UI.Page
    {
        private int filesNumber = 0;
        private FlightsEntities context = new FlightsEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XMLProcessorLINQ processor = new XMLProcessorLINQ();
                string[] files = Directory.GetFiles(Server.MapPath("~/App_Data"), "*.xml", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    filesNumber++;
                    try
                    {

                        processor.LoadFile(file);
                        Flight flight = processor.GetFlight();
                        var bss = from r in context.Flights
                                  select r.FlightID;
                        if (bss.Any(id => id == flight.FlightID))
                        {
                            LiteralControl lic = new LiteralControl("<p class=\"fail\">" + filesNumber + ". "
                                + file + " - Полет с ID=" + flight.FlightID + " вече съществува в БД!</p>");
                            PanelResults.Controls.Add(lic);
                        }
                        else
                        {
                            context.Flights.AddObject(flight);
                            context.SaveChanges();
                            LiteralControl lic = new LiteralControl("<p class=\"success\">" + filesNumber
                                + ". " + file + " - Обработен успешно!</p>");
                            PanelResults.Controls.Add(lic);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Write(ex);
                        LiteralControl lic = new LiteralControl("<p class=\"fail\">" + filesNumber + ". "
                            + file + " - " + ex.Message + " " + ex.InnerException + "</p>");
                        PanelResults.Controls.Add(lic);
                    }
                }

            }
        }
        protected void TruncateDB(object sender, EventArgs e)
        {
            SqlConnection con =
                new SqlConnection();
            con.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["FlightsConnectionString"].ToString();
            List<SqlCommand> commands = new List<SqlCommand>();
            commands.Add(new SqlCommand(@"delete from Flights.dbo.Aircraft"));
            commands.Add(new SqlCommand(@"delete from Flights.dbo.Airline"));
            commands.Add(new SqlCommand(@"delete from Flights.dbo.AirportInfo"));
            commands.Add(new SqlCommand(@"delete from Flights.dbo.Flight"));
            commands.Add(new SqlCommand(@"delete from Flights.dbo.Member"));
            commands.Add(new SqlCommand(@"delete from Flights.dbo.Flights2Airports"));
            commands.Add(new SqlCommand(@"delete from Flights.dbo.Flights2Members"));
            con.Open();
            foreach (SqlCommand c in commands)
            {
                c.Connection = con;
                c.CommandType = System.Data.CommandType.Text;
                c.ExecuteNonQuery();
            }
            con.Close();
            TruncateLabel.Text = "Базата е празна!";
        }
    }
}