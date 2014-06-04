using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;

namespace Flights_Service
{
    public partial class Input : System.Web.UI.Page
    {
        static int airportsCount = 1;
        static int membersCount = 1;

        private List<AirportControl> dynamicAirports;
        private List<MemberControl> dynamicMembers;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (this.Page.Request.Form.AllKeys.Contains("ctl00$body$btnAddAirport"))
            {
                airportsCount++;
            }
            if (this.Page.Request.Form.AllKeys.Contains("ctl00$body$btnAddMember"))
            {
                membersCount++;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            dynamicAirports = new List<AirportControl>();
            for (int i = 0; i < airportsCount; i++)
            {
                AirportControl ac = LoadControl("~/AirportControl.ascx") as AirportControl;
                ac.ID = "airport" + (i + 1).ToString();
                dynamicAirports.Add(ac);
                AirportPlaceHolder.Controls.Add(ac);

                if (airportsCount > 1)
                {
                    Button button = new Button();
                    button.ID = "rm" + (i + 1).ToString();
                    button.Text = "Изтрий";
                    button.Click += new EventHandler(RemoveAirport);
                    button.CausesValidation = false;
                    AirportPlaceHolder.Controls.Add(button);
                }
            }
        }
        protected void RemoveAirport(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int controlCount = int.Parse(Regex.Match(clicked.ClientID, @"\d+").ToString());
            if (controlCount != airportsCount)
                while (true)
                {
                    AirportControl airport = AirportPlaceHolder.FindControl("airport" + controlCount) as AirportControl;
                    AirportControl nextAirport = AirportPlaceHolder.FindControl("airport" + (controlCount + 1).ToString()) as AirportControl;
                    airport.Code = nextAirport.Code;
                    airport.AirportPhone = nextAirport.AirportPhone;
                   
                    controlCount++;
                    if (controlCount == airportsCount) break;
                }
            Control airportControl = AirportPlaceHolder.FindControl("book" + controlCount.ToString());
            AirportPlaceHolder.Controls.Remove(airportControl);
            dynamicAirports.Remove(airportControl as AirportControl);
            Control rmButton = AirportPlaceHolder.FindControl("rm" + controlCount.ToString());
            AirportPlaceHolder.Controls.Remove(rmButton);
            if (controlCount == 2)
            {
                rmButton = AirportPlaceHolder.FindControl("rm1");
                AirportPlaceHolder.Controls.Remove(rmButton);
            }
            airportsCount--;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAirport_Click(object sender, EventArgs e)
        {
            
        }


        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            
        }

        protected void ValidateEngines(object source, ServerValidateEventArgs args)
        {
            //TODO: check the input number, engines should be more than 0 and less than 6.
            args.IsValid = true;
        }

        protected void ValidateCapacity(object source, ServerValidateEventArgs args)
        {
            //TODO: check the input number, capacity is between 0 and 550.
            args.IsValid = true;
        }

        protected void ValidateDecimal(object source, ServerValidateEventArgs args)
        {
            //TODO: check the input number.
            args.IsValid = true;
        }

        protected void ValidateAirlineID(object source, ServerValidateEventArgs args)
        {
            //TODO: check the ID.
            args.IsValid = true;
        }

        protected void ValidateAircraftID(object source, ServerValidateEventArgs args)
        {
            //TODO: check the ID.
            args.IsValid = true;
        }

        protected void ValidateFlightID(object source, ServerValidateEventArgs args)
        {
            string input = args.Value;
            int FlightID;
            if (int.TryParse(input, out FlightID))
            {
                FlightsEntities context = new FlightsEntities();
                var flightsIDs =
                    from flight in context.Flights
                    select flight.FlightID;
                if (!flightsIDs.Any(flight => flight == FlightID))
                    args.IsValid = true;
                else
                {
                    CustomValidatorFlightID.ErrorMessage = "* Съществуващо ID";
                    args.IsValid = false;
                }
            }
            else
            {
                CustomValidatorFlightID.ErrorMessage = "* Невалидно ID";
                args.IsValid = false;
            }

        }

        protected void valDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Parse("1000/12/28");
            DateTime maxDate = DateTime.Parse("9999/12/28");
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }

        protected void ValidateTime(object source, ServerValidateEventArgs args)
        {
            string thetime = args.Value;
            Regex checktime =
                new Regex(@"^(20|21|22|23|[01]d|d)(([:][0-5]d){1,2})$");

            if (checktime.IsMatch(thetime))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }

        protected void BtnSubmit_Click(object source, System.EventArgs args)
        {
            //TODO: export the form data to the database.
        }

    }
}