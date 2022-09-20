

using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class member_update : System.Web.UI.Page
{

    //
    protected void BtnBooks_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("search_book.aspx");
    }

    protected void BtnHome_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("default.aspx");
    }


    protected void BtnAdmin_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("search_user.aspx");
    }

    protected void BtnMembers_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("search_member.aspx");
    }

    protected void BtnLibraryCard_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("search_library_card.aspx");
    }

    protected void BtnTransaction_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("transaction_daily.aspx");
    }

    protected void BtnReports_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("report_transaction.aspx");
    }


    protected void BtnLogOut_Click(object sender, System.EventArgs e)
    {
        Session["uid"] = "";
        Session["uname"] = "";
        Session["utype"] = "";

        Response.Redirect("login.aspx");
    }


    //
  


    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Session["utype"] == null)
        {
            Session["uid"] = "";
            Session["uname"] = "";
            Session["utype"] = "";

            Response.Redirect("login.aspx");
            return;
        }
        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        SqlDataAdapter Da = new SqlDataAdapter("select * from members where memid =" + Request.QueryString["memid"], Cn);

        DataSet Ds = new DataSet();
        Ds.Clear();
        Da.Fill(Ds, "members");
        if (Ds.Tables["members"].Rows.Count > 0) 
        {
            DataRow R;
            R = Ds.Tables["members"].Rows[0];

            span_memid.InnerText = R["memid"].ToString();
            span_memname.InnerText = R["title"].ToString() + " " + R["fname"].ToString() + " " + R["mname"].ToString() + " " + R["lname"].ToString();
        }
    }
    protected void BtnSearchMember_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_member.aspx");
    }
    protected void BtnNewMember_Click(object sender, EventArgs e)
    {

        if( Session["utype"].ToString() == "A" || Session["utype"].ToString()  == "S")
        {
            Response.Redirect("member.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }

    }
}


