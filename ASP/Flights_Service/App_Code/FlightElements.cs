using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flights_Service.App_Code
{
    class FlightElements
    {
        public static string ROOT_ELEMENT = "Flight";
        public static string ROOT_ELEMENT_XPATH = "/Flight";
        public static string XML_VERSION = "1.0";
        public static string XML_ENCODING = "UTF-8";

        public static string FLIGHT_ID = "FlightID";
        public static string FLIGHT_DATE = "Date";
        public static string FLIGHT_NUMBER = "FlightNumber";
        public static string FLIGHT_DEPTIME = "DepTime";
        public static string FLIGHT_ARRVTIME = "ArrvTime";
        public static string FLIGHT_STATUS = "Status";
        public static string FLIGHT_GROUNDOP = "GroundOp";

        public static string FLIGHT_AIRLINE = "Airline";
        public static string FLIGHT_AIRLINE_AIRLINEID = "AirlineID";
        public static string FLIGHT_AIRLINE_NAME = "Name";
        public static string FLIGHT_AIRLINE_PHONE = "Phone";
        public static string FLIGHT_AIRLINE_WEBSITE = "Website";
        public static string FLIGHT_AIRLINE_WEBSITE_ONLINECHECKIN = "OnlineCheckIN";
        public static string FLIGHT_AIRLINE_WEBSITE_HOTELBOOKING = "HotelBooking";
        public static string FLIGHT_AIRLINE_WEBSITE_CARRENTAL = "CarRental";

        public static string FLIGHT_AIRCRAFT = "Aircraft";
        public static string FLIGHT_AIRCRAFT_AIRCRAFTID = "AircraftID";
        public static string FLIGHT_AIRCRAFT_DESCRIPTION = "Description";
        public static string FLIGHT_AIRCRAFT_TYPE = "Type";
        public static string FLIGHT_AIRCRAFT_CAPACITY = "Capacity";
        public static string FLIGHT_AIRCRAFT_ENGINES = "Engines";
        public static string FLIGHT_AIRCRAFT_FIRSTDATE = "FirstDate";
        public static string FLIGHT_AIRCRAFT_LENGTH = "Length";
        public static string FLIGHT_AIRCRAFT_HEIGHT = "Height";
        public static string FLIGHT_AIRCRAFT_WINGSPAN = "Wingspan";
        public static string FLIGHT_AIRCRAFT_DIAMETER = "Diameter";
        public static string FLIGHT_AIRCRAFT_SPEED = "Speed";
        public static string FLIGHT_AIRCRAFT_MANUFACTURER = "Manufacturer";

        public static string FLIGHT_AIRPORTINFO = "AirportInfo";
        public static string FLIGHT_AIRPORTINFO_AIRPORT = "Airport";
        public static string FLIGHT_AIRPORTINFO_AIRPORTID = "AirportID";
        public static string FLIGHT_AIRPORTINFO_CODE = "Code";
        public static string FLIGHT_AIRPORTINFO_AIRPORTPHONE = "AirportPhone";
        public static string FLIGHT_AIRPORTINFO_AIRPORTPHONE_TYPE = "Type";
        public static string FLIGHT_AIRPORTINFO_AIRPORTPHONE_FAX = "Fax";
        public static string FLIGHT_AIRPORTINFO_ADDRESS = "Address";
        public static string FLIGHT_AIRPORTINFO_ADDRESS_CITY = "City";
        public static string FLIGHT_AIRPORTINFO_ADDRESS_STREET = "Street";
        public static string FLIGHT_AIRPORTINFO_ADDRESS_POSTALCODE = "Postalcode";
        public static string FLIGHT_AIRPORTINFO_ADDRESS_AIRPORTWEBSITE = "AirportWebsite";

        public static string FLIGHT_MEMBER = "Member";
        public static string FLIGHT_MEMBER_POSITION = "Position";
        public static string FLIGHT_MEMBER_MEMBERID = "MemberID";
        public static string FLIGHT_MEMBER_MEMBERNAME = "MemberName";
        public static string FLIGHT_MEMBER_COUNTRY = "Country";
        public static string FLIGHT_MEMBER_AGE = "Age";
        public static string FLIGHT_MEMBER_YEARS= "Years";
    }
}