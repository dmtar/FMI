using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flights_Service
{
    public partial class MemberControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string MemberName
        {
            get
            {
                object o = ViewState["MemberName"];
                return (o == null) ? this.MemberNameInput.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.MemberNameInput.Text = value.Trim();
                ViewState["MemberName"] = this.MemberNameInput.Text.Trim();
            }
        }
        public string Position
        {
            get
            {
                object o = ViewState["Position"];
                return (o == null) ? this.MemberPosition.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.MemberPosition.Text = value.Trim();
                ViewState["Position"] = this.MemberPosition.Text.Trim();
            }
        }
        public string Country
        {
            get
            {
                object o = ViewState["Country"];
                return (o == null) ? this.MemberCountry.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.MemberCountry.Text = value.Trim();
                ViewState["Country"] = this.MemberCountry.Text.Trim();
            }
        }
        public string Age
        {
            get
            {
                object o = ViewState["Age"];
                return (o == null) ? this.MemberAge.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.MemberAge.Text = value.Trim();
                ViewState["Age"] = this.MemberAge.Text.Trim();
            }
        }
        public string Years
        {
            get
            {
                object o = ViewState["Years"];
                return (o == null) ? this.MemberYears.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.MemberYears.Text = value.Trim();
                ViewState["Years"] = this.MemberYears.Text.Trim();
            }
        }
    }
}