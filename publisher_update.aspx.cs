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

public partial class publisher_update : System.Web.UI.Page
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
        SqlDataAdapter Da = new SqlDataAdapter("select * from publishers where pubid =" + Request.QueryString["pubid"], Cn);

        DataSet Ds = new DataSet();
        Ds.Clear();
        Da.Fill(Ds, "publishers");
        DataRow r;
        r = Ds.Tables["publishers"].Rows[0];

        span_pubid.InnerText = r["pubid"].ToString();
        span_pubname.InnerText = r["name"].ToString();
    }
    protected void BtnNewBook_Click(object sender, EventArgs e)
    {
        Response.Write(Session["utype"].ToString());
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("book.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }

    }
    protected void BtnSearchBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_book.aspx");
    }
    protected void BtnSearchAuthor_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_author.aspx");
    }
    protected void BtnNewAuthor_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("author.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }
    }
    protected void BtnSearchPublisher_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_publisher.aspx");
    }
    protected void BtnNewPublisher_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("publisher.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }
    }


}

