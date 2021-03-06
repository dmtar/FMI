﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flights_Service
{
    public partial class AirportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Code
        {
            get
            {
                object o = ViewState["Code"];
                return (o == null) ? this.AirportCode.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.AirportCode.Text = value.Trim();
                ViewState["Code"] = this.AirportCode.Text.Trim();
            }
        }
        public string AirportPhone
        {
            get
            {
                object o = ViewState["AirportPhone"];
                return (o == null) ? this.AirportPhoneInput.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.AirportPhoneInput.Text = value.Trim();
                ViewState["AirportPhone"] = this.AirportPhoneInput.Text.Trim();
            }
        }
        public string Type
        {
            get
            {
                object o = ViewState["Type"];
                return (o == null) ? this.AirportPhoneType.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.AirportPhoneType.Text = value.Trim();
                ViewState["Type"] = this.AirportPhoneType.Text.Trim();
            }
        }
        public string Fax
        {
            get
            {
                object o = ViewState["Fax"];
                return (o == null) ? this.AirportPhoneFax.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.AirportPhoneFax.Text = value.Trim();
                ViewState["Fax"] = this.AirportPhoneFax.Text.Trim();
            }
        }
        public string City
        {
            get
            {
                object o = ViewState["City"];
                return (o == null) ? this.AirportCity.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.AirportCity.Text = value.Trim();
                ViewState["City"] = this.AirportCity.Text.Trim();
            }
        }
        public string Street
        {
            get
            {
                object o = ViewState["Steet"];
                return (o == null) ? this.AirportStreet.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.AirportStreet.Text = value.Trim();
                ViewState["Street"] = this.AirportStreet.Text.Trim();
            }
        }
        public string Postalcode
        {
            get
            {
                object o = ViewState["Postalcode"];
                return (o == null) ? this.AirportPostalcode.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.AirportPostalcode.Text = value.Trim();
                ViewState["Postalcode"] = this.AirportPostalcode.Text.Trim();
            }
        }
        public string AirportWebsite
        {
            get
            {
                object o = ViewState["AirportWebsite"];
                return (o == null) ? this.AirportWebsiteInput.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.AirportWebsiteInput.Text = value.Trim();
                ViewState["AirportWebsite"] = this.AirportWebsiteInput.Text.Trim();
            }
        }
        public string Airport
        {
            get
            {
                object o = ViewState["Airport"];
                return (o == null) ? this.AirportDropDown.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.AirportDropDown.Text = value.Trim();
                ViewState["Airport"] = this.AirportDropDown.Text.Trim();
            }
        }

        protected void ValidateAirportInfoID(object source, ServerValidateEventArgs args)
        {
            string input = args.Value;
            int AirportID;
            if (int.TryParse(input, out AirportID))
            {
                FlightsEntities context = new FlightsEntities();
                var aircraftsIDs =
                    from airportInfo in context.AirportInfoes
                    select airportInfo.AirportID;
                if (!aircraftsIDs.Any(airport => airport == AirportID))
                    args.IsValid = true;
                else
                {
                    CustomValidator2.ErrorMessage = "* Съществуващо ID";
                    args.IsValid = false;
                }
            }
            else
            {
                CustomValidator2.ErrorMessage = "* Невалидно ID";
                args.IsValid = false;
            }
        }
        /*
        protected void ValidatePhoneType(object source, ServerValidateEventArgs args)
        {
            string input = args.Value;
            if (input == "стационарен" || input == "мобилен")
            {
                args.IsValid = true;
            }
            else
            {
                CustomValidatorPhoneType.ErrorMessage = "Невалиден тип на телефон";
                args.IsValid = false;
            }
        }
         */
    }
}