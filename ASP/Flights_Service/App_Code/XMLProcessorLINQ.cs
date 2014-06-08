using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.Objects.DataClasses;

namespace Flights_Service.App_Code
{
    public class XMLProcessorLINQ
    {
        private Flight flight;
        private Aircraft aircraft;
        private Airline airline;

        private XElement xFlight;

        public void LoadFile(String file)
        {
            XMLValidator validator = new XMLValidator();
            validator.Validate(file);
            xFlight = XElement.Load(file);
        }

        private void InitFlight()
        {
            XElement FlightID= xFlight.Element(FlightElements.FLIGHT_ID);
            XElement FlightNumber = xFlight.Element(FlightElements.FLIGHT_NUMBER);
            XElement Date = xFlight.Element(FlightElements.FLIGHT_DATE);
            XElement DepTime = xFlight.Element(FlightElements.FLIGHT_DEPTIME);
            XElement ArrvTime = xFlight.Element(FlightElements.FLIGHT_ARRVTIME);
            XElement Status = xFlight.Element(FlightElements.FLIGHT_STATUS);
            XElement GroundOp = xFlight.Element(FlightElements.FLIGHT_GROUNDOP);
            XElement airlineElement = xFlight.Element(FlightElements.FLIGHT_AIRLINE);
            XElement aircraftElement = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT);
            IEnumerable<XElement> members = from node in xFlight.Elements(FlightElements.FLIGHT_MEMBER)
                                             select node;
            IEnumerable<XElement> airportInfos = from node in xFlight.Elements(FlightElements.FLIGHT_AIRPORTINFO)
                                            select node;
            //Init the Airline
            this.airline = new Airline();
            this.airline.AirlineID = Int16.Parse(airlineElement.Element(FlightElements.FLIGHT_AIRLINE_AIRLINEID).Value);
            this.airline.Name = airlineElement.Element(FlightElements.FLIGHT_AIRLINE_NAME).Value;
            this.airline.AirlineCountry = airlineElement.Element(FlightElements.FLIGHT_AIRLINE_AIRLINECOUNTRY).Value;
            this.airline.Phone = airlineElement.Element(FlightElements.FLIGHT_AIRLINE_PHONE).Value;
            this.airline.Website = airlineElement.Element(FlightElements.FLIGHT_AIRLINE_WEBSITE).Value;
            this.airline.OnlineCheckIN = airlineElement.Element(FlightElements.FLIGHT_AIRLINE_WEBSITE).Attribute(FlightElements.FLIGHT_AIRLINE_WEBSITE_ONLINECHECKIN).Value;
            this.airline.HotelBooking = airlineElement.Element(FlightElements.FLIGHT_AIRLINE_WEBSITE).Attribute(FlightElements.FLIGHT_AIRLINE_WEBSITE_HOTELBOOKING).Value;
            this.airline.CarRental = airlineElement.Element(FlightElements.FLIGHT_AIRLINE_WEBSITE).Attribute(FlightElements.FLIGHT_AIRLINE_WEBSITE_CARRENTAL).Value;

            //Init the aircraft
            this.aircraft = new Aircraft();
            this.aircraft.AircraftID = Int16.Parse(aircraftElement.Element(FlightElements.FLIGHT_AIRCRAFT_AIRCRAFTID).Value);
            this.aircraft.Description = aircraftElement.Element(FlightElements.FLIGHT_AIRCRAFT_DESCRIPTION).Value;
            this.aircraft.FirstDate = aircraftElement.Element(FlightElements.FLIGHT_AIRCRAFT_FIRSTDATE).Value;
            this.aircraft.Length = aircraftElement.Element(FlightElements.FLIGHT_AIRCRAFT_LENGTH).Value;
            this.aircraft.Height = aircraftElement.Element(FlightElements.FLIGHT_AIRCRAFT_HEIGHT).Value;
            this.aircraft.Wingspan = aircraftElement.Element(FlightElements.FLIGHT_AIRCRAFT_WINGSPAN).Value;
            this.aircraft.Diameter = aircraftElement.Element(FlightElements.FLIGHT_AIRCRAFT_DIAMETER).Value;
            this.aircraft.Speed = aircraftElement.Element(FlightElements.FLIGHT_AIRCRAFT_SPEED).Value;
            this.aircraft.Manufacturer = aircraftElement.Element(FlightElements.FLIGHT_AIRCRAFT_MANUFACTURER).Value;
            this.aircraft.Type = aircraftElement.Attribute(FlightElements.FLIGHT_AIRCRAFT_TYPE).Value;
            this.aircraft.Capacity = aircraftElement.Attribute(FlightElements.FLIGHT_AIRCRAFT_CAPACITY).Value;
            this.aircraft.Engines = aircraftElement.Attribute(FlightElements.FLIGHT_AIRCRAFT_ENGINES).Value;

            //Init the flight
            this.flight = new Flight();
            this.flight.FlightID = Int16.Parse(FlightID.Value);
            this.flight.FlightNumber = FlightNumber.Value;
            this.flight.Date = Date.Value;
            this.flight.DepTime = DepTime.Value;
            this.flight.ArrvTime = ArrvTime.Value;
            this.flight.Status = Status.Value;
            this.flight.GroundOp = GroundOp.Value;
            //Init the 1 to 1 foreign keys
            this.flight.Airline = this.airline;
            this.flight.Aircraft = this.aircraft;
            
            //Setting up members
            EntityCollection<Member> membersCollection = new EntityCollection<Member>();
            foreach (var member in members)
            {
                membersCollection.Add(new Member
                {
                    MemberID = Int16.Parse(member.Element(FlightElements.FLIGHT_MEMBER_MEMBERID).Value),
                    MemberName = member.Element(FlightElements.FLIGHT_MEMBER_MEMBERNAME).Value,
                    Position = member.Attribute(FlightElements.FLIGHT_MEMBER_POSITION).Value,
                    Country = member.Element(FlightElements.FLIGHT_MEMBER_COUNTRY).Value,
                    Age = Int16.Parse(member.Element(FlightElements.FLIGHT_MEMBER_AGE).Value),
                    Years = Int16.Parse(member.Element(FlightElements.FLIGHT_MEMBER_YEARS).Value)
                }); 
            }
            flight.Members = membersCollection;
            
            //Setting up airportInfos
            EntityCollection<AirportInfo> airportInfosCollection = new EntityCollection<AirportInfo>();
            foreach (var airportInfo in airportInfos)
            {
                AirportInfo test = new AirportInfo();
                airportInfosCollection.Add(new AirportInfo
                {
                    AirportID = Int16.Parse(airportInfo.Element(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTID).Value),
                    Airport = airportInfo.Attribute(FlightElements.FLIGHT_AIRPORTINFO_AIRPORT).Value,
                    Code = airportInfo.Element(FlightElements.FLIGHT_AIRPORTINFO_CODE).Value,
                    AirportPhone = airportInfo.Element(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTPHONE).Value,
                    Fax = airportInfo.Element(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTPHONE).Attribute(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTPHONE_FAX).Value,
                    Type = airportInfo.Element(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTPHONE).Attribute(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTPHONE_TYPE).Value,
                    City = airportInfo.Element(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS).Element(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS_CITY).Value,
                    Street = airportInfo.Element(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS).Element(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS_STREET).Value,
                    Postalcode = airportInfo.Element(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS).Element(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS_POSTALCODE).Value,
                    AirportWebsite = airportInfo.Element(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS).Element(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS_AIRPORTWEBSITE).Value
    
                });
            }
            flight.AirportInfoes = airportInfosCollection;
        }
         
        public Flight GetFlight()
        {
            InitFlight();
            if (flight != null)
            {
                return this.flight;
            }
            else
            {
                throw new Exception("Something went wrong!");
            }
        }
       
    }
}