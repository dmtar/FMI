using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Flights_Service.App_Code
{
    public class XMLProcessorLINQ
    {
        private Flight flight;
        private Aircraft aircraft;
        private AirportInfo airportInfo;
        private Airline airline;
        private Member member;

        private XElement xFlight;

        public void LoadFile(String file)
        {
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
            XElement AirlineID = xFlight.Element(FlightElements.FLIGHT_AIRLINE_AIRLINEID);
            XElement AircraftID = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_AIRCRAFTID);

            this.flight = new Flight();

            this.flight.FlightID = Int16.Parse(FlightID.Value);
            this.flight.FlightNumber = FlightNumber.Value;
            this.flight.Date = Date.Value;
            this.flight.DepTime = DepTime.Value;
            this.flight.ArrvTime = ArrvTime.Value;
            this.flight.Status = Status.Value;
            this.flight.GroundOp = GroundOp.Value;
            this.flight.AirlineID = Int16.Parse(AirlineID.Value);
            this.flight.AircraftID = Int16.Parse(AircraftID.Value);
        }
        private void InitAircraft()
        {
            XElement AircraftID = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_AIRCRAFTID);
            XElement Description = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_DESCRIPTION);
            XElement FirstDate = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_FIRSTDATE);
            XElement Length = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_LENGTH);
            XElement Height = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_HEIGHT);
            XElement Wingspan = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_WINGSPAN);
            XElement Diameter = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_DIAMETER);
            XElement Speed = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_SPEED);
            XElement Manufacturer = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_MANUFACTURER);
            IEnumerable<XAttribute> attributes = from node in xFlight.Attributes()
                                                 select node;
            string Type = null;
            string Capacity = null;
            string Engines = null;
            foreach (var item in attributes)
            {
                if (item.Name == FlightElements.FLIGHT_AIRCRAFT_TYPE) 
                    Type = item.Value;
                if (item.Name == FlightElements.FLIGHT_AIRCRAFT_CAPACITY) 
                    Capacity = item.Value;
                if (item.Name == FlightElements.FLIGHT_AIRCRAFT_ENGINES)
                    Engines = item.Value;
            }
            this.aircraft = new Aircraft();

            this.aircraft.AircraftID = Int16.Parse(AircraftID.Value);
            this.aircraft.Description = Description.Value;
            this.aircraft.FirstDate = FirstDate.Value;           
            this.aircraft.Length = Decimal.Parse(Length.Value);
            this.aircraft.Height = Decimal.Parse(Height.Value);
            this.aircraft.Wingspan = Decimal.Parse(Wingspan.Value);
            this.aircraft.Diameter = Decimal.Parse(Diameter.Value);
            this.aircraft.Speed = Decimal.Parse(Speed.Value);
            this.aircraft.Manufacturer = Manufacturer.Value;
            this.aircraft.Type = Type;
            this.aircraft.Capacity = Int16.Parse(Capacity);
            this.aircraft.Engines = Byte.Parse(Engines);
        }
        private void InitAirportInfo() 
        {
            XElement AirportID = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_AIRCRAFTID);
            XElement Code = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_DESCRIPTION);
            XElement AirportPhone = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_FIRSTDATE);
            XElement City = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_WINGSPAN);
            XElement Street = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_DIAMETER);
            XElement Postalcode = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_SPEED);
            XElement AirportWebsite = xFlight.Element(FlightElements.FLIGHT_AIRCRAFT_MANUFACTURER);
            IEnumerable<XAttribute> attributes = from node in xFlight.Attributes()
                                                 select node;
            string Fax = null;
            string Airport = null;
            foreach (var item in attributes)
            {
                if (item.Name == FlightElements.FLIGHT_AIRPORTINFO_AIRPORTPHONE_FAX)
                    Fax = item.Value;
                if (item.Name == FlightElements.FLIGHT_AIRPORTINFO_AIRPORT)
                    Airport = item.Value;
            }
            this.airportInfo = new AirportInfo();
            this.airportInfo.AirportID = Int16.Parse(AirportID.Value);
            this.airportInfo.Code = Code.Value;
            this.airportInfo.AirportPhone = AirportPhone.Value;
            this.airportInfo.City = City.Value;
            this.airportInfo.Street = Street.Value;
            this.airportInfo.Postalcode = Postalcode.Value;
            this.airportInfo.AirportWebsite = AirportWebsite.Value;
        }
        private void InitMember()
        {
 
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