
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

public partial class library_card_update : System.Web.UI.Page
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
        SqlDataAdapter Da = new SqlDataAdapter("select * from library_card where libcardid =" + Request.QueryString["libcardid"], Cn);

        DataSet Ds = new DataSet();
        Ds.Clear();
        Da.Fill(Ds, "library_card");
        if (Ds.Tables["library_card"].Rows.Count > 0 )
        {
            DataRow R ;
            R = Ds.Tables["library_card"].Rows[0];

            span_libcardid.InnerText = R["libcardid"].ToString(); ;
            SqlDataAdapter Da1 = new SqlDataAdapter("select * from members where memid=" + R["memid"], Cn);
            DataSet Ds1 = new DataSet();
            Ds1.Clear();
            Da1.Fill(Ds1, "member");

            R = Ds1.Tables["member"].Rows[0];
            span_member.InnerText = R["memid"].ToString() + " [" + R["title"].ToString() + " " + R["fname"].ToString() + " " + R["mname"].ToString() + " " + R["lname"].ToString() + "]";
        }
    }
    protected void BtnSearchLibCard_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_library_card.aspx");
    }

    protected void BtnNewBook_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("library_card.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }
    }

}

