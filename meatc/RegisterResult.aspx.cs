using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class RegisterResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindResult();
    }

    private void BindResult()
    {
        if (Session["StateId"] != null && Session["StateId"].ToString().Equals("3"))
        {
            lblInfo.Text = "很抱歉，您的信息未通过管理员审批！";
        }        
    }
}
