using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Flights_Service.App_Code
{
    public class XMLCreatorLINQ
    {
        private XDocument doc;

        public void CreateFlightXMLDocument(String path, string dtd, Flight flight)
        {
            XDocumentType type = new XDocumentType("Flight", null, dtd, null);
            doc = new XDocument(type);

            XElement root = new XElement(FlightElements.ROOT_ELEMENT);
            XElement FlightID = new XElement(FlightElements.FLIGHT_ID, flight.FlightID);
            XElement Date = new XElement(FlightElements.FLIGHT_DATE, flight.Date);
            XElement DepTime = new XElement(FlightElements.FLIGHT_DEPTIME, flight.DepTime);
            XElement ArrvTime = new XElement(FlightElements.FLIGHT_ARRVTIME, flight.ArrvTime);
            XElement GroundOp = new XElement(FlightElements.FLIGHT_GROUNDOP, flight.GroundOp);
            root.Add(FlightID);
            root.Add(Date);
            root.Add(DepTime);
            root.Add(ArrvTime);
            root.Add(GroundOp);
            //Airline
            XElement Airline = new XElement(FlightElements.FLIGHT_AIRLINE);
            Airline.Add(new XElement(FlightElements.FLIGHT_AIRLINE_AIRLINEID, flight.Airline.AirlineID));
            Airline.Add(new XElement(FlightElements.FLIGHT_AIRLINE_NAME, flight.Airline.Name));
            Airline.Add(new XElement(FlightElements.FLIGHT_AIRLINE_AIRLINECOUNTRY, flight.Airline.AirlineCountry));
            Airline.Add(new XElement(FlightElements.FLIGHT_AIRLINE_PHONE, flight.Airline.Phone));
            XElement AirlineWebsite = new XElement(FlightElements.FLIGHT_AIRLINE_WEBSITE);
            if (flight.Airline.OnlineCheckIN == "on")
            {
                AirlineWebsite.Add(new XAttribute(FlightElements.FLIGHT_AIRLINE_WEBSITE_ONLINECHECKIN, "да"));
            }
            else
            {
                AirlineWebsite.Add(new XAttribute(FlightElements.FLIGHT_AIRLINE_WEBSITE_ONLINECHECKIN, "не"));
            }
            if (flight.Airline.HotelBooking == "on")
            {
                AirlineWebsite.Add(new XAttribute(FlightElements.FLIGHT_AIRLINE_WEBSITE_HOTELBOOKING, "да"));
            }
            else
            {
                AirlineWebsite.Add(new XAttribute(FlightElements.FLIGHT_AIRLINE_WEBSITE_HOTELBOOKING, "не"));
            }
            if (flight.Airline.CarRental == "on")
            {
                AirlineWebsite.Add(new XAttribute(FlightElements.FLIGHT_AIRLINE_WEBSITE_CARRENTAL, "да"));
            }
            else
            {
                AirlineWebsite.Add(new XAttribute(FlightElements.FLIGHT_AIRLINE_WEBSITE_CARRENTAL, "не"));
            }
            Airline.Add(AirlineWebsite);
            root.Add(Airline);

            //Aircraft
            XElement Aircraft = new XElement(FlightElements.FLIGHT_AIRCRAFT);
            Aircraft.Add(new XAttribute(FlightElements.FLIGHT_AIRCRAFT_TYPE, flight.Aircraft.Type));
            Aircraft.Add(new XAttribute(FlightElements.FLIGHT_AIRCRAFT_CAPACITY, flight.Aircraft.Capacity));
            Aircraft.Add(new XAttribute(FlightElements.FLIGHT_AIRCRAFT_ENGINES, flight.Aircraft.Engines));
            Aircraft.Add(new XElement(FlightElements.FLIGHT_AIRCRAFT_AIRCRAFTID, flight.Aircraft.AircraftID));
            Aircraft.Add(new XElement(FlightElements.FLIGHT_AIRCRAFT_DESCRIPTION, flight.Aircraft.Description));
            Aircraft.Add(new XElement(FlightElements.FLIGHT_AIRCRAFT_FIRSTDATE, flight.Aircraft.FirstDate));
            Aircraft.Add(new XElement(FlightElements.FLIGHT_AIRCRAFT_LENGTH, flight.Aircraft.Length));
            Aircraft.Add(new XElement(FlightElements.FLIGHT_AIRCRAFT_HEIGHT, flight.Aircraft.Height));
            Aircraft.Add(new XElement(FlightElements.FLIGHT_AIRCRAFT_WINGSPAN, flight.Aircraft.Wingspan));
            Aircraft.Add(new XElement(FlightElements.FLIGHT_AIRCRAFT_DIAMETER, flight.Aircraft.Description));
            Aircraft.Add(new XElement(FlightElements.FLIGHT_AIRCRAFT_SPEED, flight.Aircraft.Speed));
            Aircraft.Add(new XElement(FlightElements.FLIGHT_AIRCRAFT_MANUFACTURER, flight.Aircraft.Manufacturer));
            root.Add(Aircraft);
            System.Diagnostics.Debug.Write(flight.AirportInfoes.Count);
            //AirportInfos
            foreach(var userAirportInfo in flight.AirportInfoes)
            {
                XElement AirportInfo = new XElement(FlightElements.FLIGHT_AIRPORTINFO);
                AirportInfo.Add(new XAttribute(FlightElements.FLIGHT_AIRPORTINFO_AIRPORT, userAirportInfo.Airport));
                AirportInfo.Add(new XElement(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTID, userAirportInfo.AirportID));
                AirportInfo.Add(new XElement(FlightElements.FLIGHT_AIRPORTINFO_CODE, userAirportInfo.Code));
                XElement AirportPhone = new XElement(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTPHONE, userAirportInfo.AirportPhone);
                AirportPhone.Add(new XAttribute(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTPHONE_TYPE, userAirportInfo.Type));
                if (userAirportInfo.Fax == "on")
                {
                    AirportPhone.Add(new XAttribute(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTPHONE_FAX, "да"));
                }
                else
                {
                    AirportPhone.Add(new XAttribute(FlightElements.FLIGHT_AIRPORTINFO_AIRPORTPHONE_FAX, "не"));
                }
                XElement Address = new XElement(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS);
                Address.Add(new XElement(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS_CITY, userAirportInfo.City));
                Address.Add(new XElement(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS_STREET, userAirportInfo.Street));
                Address.Add(new XElement(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS_POSTALCODE, userAirportInfo.Postalcode));
                Address.Add(new XElement(FlightElements.FLIGHT_AIRPORTINFO_ADDRESS_AIRPORTWEBSITE, userAirportInfo.AirportWebsite));
                AirportInfo.Add(AirportPhone);
                AirportInfo.Add(Address);
                root.Add(AirportInfo);
            }


            //Members
            foreach (var userMember in flight.Members)
            {
                XElement Member = new XElement(FlightElements.FLIGHT_MEMBER);
                Member.Add(new XAttribute(FlightElements.FLIGHT_MEMBER_MEMBERID, userMember.MemberID));
                Member.Add(new XElement(FlightElements.FLIGHT_MEMBER_MEMBERNAME, userMember.MemberName));
                Member.Add(new XElement(FlightElements.FLIGHT_MEMBER_COUNTRY, userMember.Country));
                Member.Add(new XElement(FlightElements.FLIGHT_MEMBER_AGE, userMember.Age));
                Member.Add(new XElement(FlightElements.FLIGHT_MEMBER_YEARS, userMember.Years));
                root.Add(Member);
            }

            doc.Add(root);
            doc.Save(path);
        }
    }
}