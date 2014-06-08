using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Flights_Service.App_Code;
using System.IO;
using System.Collections.Specialized;

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
            XMLValidator validator = new XMLValidator();
            base.OnInit(e);
            dynamicAirports = new List<AirportControl>();
            dynamicMembers = new List<MemberControl>();
            for (int i = 0; i < airportsCount; i++)
            {
                AirportControl ac = LoadControl("~/AirportControl.ascx") as AirportControl;
                ac.ID = "airport" + (i + 1).ToString();
                dynamicAirports.Add(ac);
                AirportPlaceHolder.Controls.Add(ac);

                if (airportsCount > 1)
                {
                    Button button = new Button();
                    button.ID = "removeAirport" + (i + 1).ToString();
                    button.Text = "Изтрий";
                    button.Click += new EventHandler(Remove);
                    button.CausesValidation = false;
                    AirportPlaceHolder.Controls.Add(button);
                }
            }
            for (int i = 0; i < membersCount; i++)
            {
                MemberControl ac = LoadControl("~/MemberControl.ascx") as MemberControl;
                ac.ID = "member" + (i + 1).ToString();
                dynamicMembers.Add(ac);
                MemberPlaceHolder.Controls.Add(ac);

                if (membersCount > 1)
                {
                    Button button = new Button();
                    button.ID = "removeMember" + (i + 1).ToString();
                    button.Text = "Изтрий";
                    button.Click += new EventHandler(Remove);
                    button.CausesValidation = false;
                    MemberPlaceHolder.Controls.Add(button);
                }
            }
        }
        protected void Remove(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            bool is_airport = Regex.Match(clicked.ClientID, @"Airport").Success;
            bool is_member = Regex.Match(clicked.ClientID, @"Member").Success;
            if (!is_airport && !is_member)
            {
                throw new Exception();
            }
            if (is_airport)
            {
                int controlCount = int.Parse(Regex.Match(clicked.ClientID, @"\d+").ToString());
                if (controlCount != airportsCount)
                    while (true)
                    {
                        AirportControl airport = AirportPlaceHolder.FindControl("airport" + controlCount) as AirportControl;
                        AirportControl nextAirport = AirportPlaceHolder.FindControl("airport" + (controlCount + 1).ToString()) as AirportControl;
                        airport.Code = nextAirport.Code;
                        airport.AirportPhone = nextAirport.AirportPhone;
                        airport.Type= nextAirport.Type;
                        airport.Fax = nextAirport.Fax;
                        airport.City = nextAirport.City;
                        airport.Street = nextAirport.Street;
                        airport.Postalcode = nextAirport.Postalcode;
                        airport.AirportWebsite = nextAirport.AirportWebsite;
                        airport.Airport = nextAirport.Airport;
                        controlCount++;
                        if (controlCount == airportsCount) break;
                    }
                Control airportControl = AirportPlaceHolder.FindControl("airport" + controlCount.ToString());
                AirportPlaceHolder.Controls.Remove(airportControl);
                dynamicAirports.Remove(airportControl as AirportControl);
                Control rmButton = AirportPlaceHolder.FindControl("removeAirport" + controlCount.ToString());
                AirportPlaceHolder.Controls.Remove(rmButton);
                if (controlCount == 2)
                {
                    rmButton = AirportPlaceHolder.FindControl("removeAirport1");
                    AirportPlaceHolder.Controls.Remove(rmButton);
                }
                airportsCount--;   
            }
            if (is_member)
            {
                int controlCount = int.Parse(Regex.Match(clicked.ClientID, @"\d+").ToString());
                if (controlCount != membersCount)
                    while (true)
                    {
                        MemberControl member = MemberPlaceHolder.FindControl("member" + controlCount) as MemberControl;
                        MemberControl nextMember = MemberPlaceHolder.FindControl("member" + (controlCount + 1).ToString()) as MemberControl;
                        member.MemberName = nextMember.MemberName;
                        member.Position = nextMember.Position;
                        member.Country= nextMember.Country;
                        member.Age = nextMember.Age;
                        member.Years = nextMember.Years;
                        controlCount++;
                        if (controlCount == membersCount) break;
                    }
                Control memberControl = MemberPlaceHolder.FindControl("member" + controlCount.ToString());
                MemberPlaceHolder.Controls.Remove(memberControl);
                dynamicMembers.Remove(memberControl as MemberControl);
                Control rmButton = MemberPlaceHolder.FindControl("removeMember" + controlCount.ToString());
                MemberPlaceHolder.Controls.Remove(rmButton);
                if (controlCount == 2)
                {
                    rmButton = MemberPlaceHolder.FindControl("removeMember1");
                    MemberPlaceHolder.Controls.Remove(rmButton);
                }
                membersCount--;
            }
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
            string input = args.Value;
            int Engines;
            if (int.TryParse(input, out Engines))
            {
                if (Engines > 0 && Engines < 10)
                    args.IsValid = true;
                else
                {
                    CustomValidatorValidateEngines.ErrorMessage = "Брой двигатели е число от 0 до 10!";
                    args.IsValid = false;
                }
            }
            else
            {
                CustomValidatorValidateEngines.ErrorMessage = "Невалидни данни!";
                args.IsValid = false;
            }
        }

        protected void ValidateCapacity(object source, ServerValidateEventArgs args)
        {
            string input = args.Value;
            int Capacity;
            if (int.TryParse(input, out Capacity))
            {
                if (Capacity > 0 && Capacity < 550)
                    args.IsValid = true;
                else
                {
                    CustomValidatorValidateCapacity.ErrorMessage = "Капацитета е число от 0 до 550!";
                    args.IsValid = false;
                }
            }
            else
            {
                CustomValidatorValidateCapacity.ErrorMessage = "Невалидни данни!";
                args.IsValid = false;
            }
        }

        protected void ValidateDecimal(object source, ServerValidateEventArgs args)
        {
            string input = args.Value;
            int Number;
            decimal Test;
            if (int.TryParse(input, out Number))
            {
                args.IsValid = true;
            }
            if (decimal.TryParse(input, out Test))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        protected void ValidateAirlineID(object source, ServerValidateEventArgs args)
        {
            string input = args.Value;
            int AirlineID;
            if (int.TryParse(input, out AirlineID))
            {
                FlightsEntities context = new FlightsEntities();
                var airlinesIDs =
                    from airline in context.Airlines
                    select airline.AirlineID;
                if (!airlinesIDs.Any(airline => airline == AirlineID))
                    args.IsValid = true;
                else
                {
                    CustomValidatorAirlineID.ErrorMessage = "* Съществуващо ID";
                    args.IsValid = false;
                }
            }
            else
            {
                CustomValidatorAirlineID.ErrorMessage = "* Невалидно ID";
                args.IsValid = false;
            }
        }

        protected void ValidateAircraftID(object source, ServerValidateEventArgs args)
        {
            string input = args.Value;
            int AircraftID;
            if (int.TryParse(input, out AircraftID))
            {
                FlightsEntities context = new FlightsEntities();
                var aircraftsIDs =
                    from aircraft in context.Aircraft
                    select aircraft.AircraftID;
                if (!aircraftsIDs.Any(aircraft => aircraft == AircraftID))
                    args.IsValid = true;
                else
                {
                    CustomValidatorAircraftID.ErrorMessage = "* Съществуващо ID";
                    args.IsValid = false;
                }
            }
            else
            {
                CustomValidatorAircraftID.ErrorMessage = "* Невалидно ID";
                args.IsValid = false;
            }
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
            if (Page.IsValid)
            {
                
                XMLCreatorLINQ creator = new XMLCreatorLINQ();
                FlightsEntities flightContext = new FlightsEntities();
                Flight flight = new Flight();
                flight.FlightID = Int32.Parse(Request.Form["ctl00$body$FlightID"]);
                flight.Date = Request.Form["ctl00$body$Date"];
                flight.FlightNumber = Request.Form["ctl00$body$FlightNumber"];
                flight.DepTime = Request.Form["ctl00$body$DepTime"];
                flight.ArrvTime = Request.Form["ctl00$body$ArrvTime"];
                flight.Status = Request.Form["ctl00$body$Status"];
                flight.GroundOp = Request.Form["ctl00$body$GroundOp"];

                flight.Airline = new Airline
                {
                   AirlineID = Int32.Parse(Request.Form["ctl00$body$AirlineID"]),
                   Name = Request.Form["ctl00$body$AirlineName"],
                   AirlineCountry = Request.Form["ctl00$body$AirlineCountry"],
                   Phone = Request.Form["ctl00$body$AirlinePhone"],
                   Website = Request.Form["ctl00$body$AirlineWebsite"],
                   OnlineCheckIN = Request.Form["ctl00$body$OnlineCheckIN"],
                   HotelBooking = Request.Form["ctl00$body$HotelBooking"],
                   CarRental = Request.Form["ctl00$body$CarRental"]
                };
                flight.Aircraft = new Aircraft
                {
                    Type = Request.Form["ctl00$body$Type"],
                    Capacity = Request.Form["ctl00$body$Capacity"],
                    Engines = Request.Form["ctl00$body$Engines"],
                    AircraftID = Int32.Parse(Request.Form["ctl00$body$AircraftID"]),
                    Description = Request.Form["ctl00$body$Description"],
                    FirstDate = Request.Form["ctl00$body$FirstDate"],
                    Length = Request.Form["ctl00$body$Length"],
                    Height = Request.Form["ctl00$body$Height"],
                    Wingspan = Request.Form["ctl00$body$Wingspan"],
                    Diameter = Request.Form["ctl00$body$Diameter"],
                    Speed = Request.Form["ctl00$body$Speed"],
                    Manufacturer = Request.Form["ctl00$body$Manufacturer"]
                };

                AirportInfo airportInfo;
                for (int i = 0; i < airportsCount; i++)
                {
                    airportInfo = new AirportInfo();
                    airportInfo.Airport = Request.Form["ctl00$body$airport" + (i + 1) + "$AirportDropDown"];
                    airportInfo.AirportID = Int32.Parse(Request.Form["ctl00$body$airport" + (i + 1) + "$AirportID"]);
                    airportInfo.Code = Request.Form["ctl00$body$airport" + (i + 1) + "$AirportCode"];
                    airportInfo.AirportPhone = Request.Form["ctl00$body$airport" + (i + 1) + "$AirportPhoneInput"];
                    airportInfo.Type = Request.Form["ctl00$body$airport" + (i + 1) + "$AirportPhoneType"];
                    airportInfo.Fax = Request.Form["ctl00$body$airport" + (i + 1) + "$AirportPhoneFax"];
                    airportInfo.City = Request.Form["ctl00$body$airport" + (i + 1) + "$AirportCity"];
                    airportInfo.Street = Request.Form["ctl00$body$airport" + (i + 1) + "$AirportStreet"];
                    airportInfo.Postalcode = Request.Form["ctl00$body$airport" + (i + 1) + "$AirportPostalcode"];
                    airportInfo.AirportWebsite = Request.Form["ctl00$body$airport" + (i + 1) + "$AirportWebsiteInput"];
                    flight.AirportInfoes.Add(airportInfo);
                }

                Member member;
                for (int i = 0; i < membersCount; i++)
                {
                    member = new Member();
                    member.Position = Request.Form["ctl00$body$member" + (i + 1) + "$MemberPosition"];
                    member.MemberID = Int32.Parse(Request.Form["ctl00$body$member" + (i + 1) + "$MemberID"]);
                    member.MemberName = Request.Form["ctl00$body$member" + (i + 1) + "$MemberNameInput"];
                    member.Country = Request.Form["ctl00$body$member" + (i + 1) + "$MemberCountry"];
                    member.Age = Request.Form["ctl00$body$member" + (i + 1) + "$MemberAge"];
                    member.Years = Request.Form["ctl00$body$member" + (i + 1) + "$MemberYears"];
                    flight.Members.Add(member);
                }
                creator.CreateFlightXMLDocument(Server.MapPath("~/App_Data/" + flight.FlightID + ".xml"),"Flights.dtd", flight);

                flightContext.Flights.AddObject(flight);
                flightContext.SaveChanges();
                DivForm.Visible = false;
                DivSuccess.Visible = true;
                XMLValidator validator = new XMLValidator();
                try
                {
                    validator.Validate(Server.MapPath("~/App_Data/" + flight.FlightID + ".xml"));
                    DivDTDSuccess.Visible = true;
                }
                catch (Exception)
                {
                    DivDTDFalse.Visible = true;
                }
            }
        }
    }
}