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