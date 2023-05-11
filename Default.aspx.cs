using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OP2_LAB4_U4_05
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TestQuestionsLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("/TestQuestions.aspx");
        }

        protected void MusicQuestionsLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MusicQuestions.aspx");
        }

        protected void AnalyticsLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Analytics.aspx");
        }
    }
}