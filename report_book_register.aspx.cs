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

public partial class reports_book_stock : System.Web.UI.Page
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

    protected void BtnTransaction1_Click(object sender, EventArgs e)
    {
        Response.Redirect("report_transaction.aspx");
    }


    protected void BtnMemberRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("report_member_register.aspx");
    }
    protected void BtnBookRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("report_book_register.aspx");
    }
    protected void BtnLogOut_Click(object sender, System.EventArgs e)
    {
        Session["uid"] = "";
        Session["uname"] = "";
        Session["utype"] = "";

        Response.Redirect("login.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // show data
        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        string s;
        s = "select * from books order by bookid";

        SqlDataAdapter Da = new SqlDataAdapter(s, Cn);

        DataSet Ds = new DataSet();
        Ds.Clear();
        Da.Fill(Ds, "books");
        ViewState["ds"] = Ds;
        GridView1.DataSource = ViewState["ds"];// Ds;
        GridView1.DataMember = "books";
        GridView1.DataBind();


    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = ViewState["ds"];// Ds;
        GridView1.DataMember = "books";
        GridView1.DataBind();
    }
}
