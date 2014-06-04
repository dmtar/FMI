using System;
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
                return (o == null) ? this.CodeInput.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.CodeInput.Text = value.Trim();
                ViewState["ISBN"] = this.CodeInput.Text.Trim();
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
    }
}