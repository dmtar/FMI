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
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void IsValidTime_ServerValidate(object source, ServerValidateEventArgs args)
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
           
            
        }

    }
}