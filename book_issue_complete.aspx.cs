
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

public partial class book_issue_complete : System.Web.UI.Page
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

    protected void BtnTransaction1_Click(object sender, EventArgs e)
    {
        Response.Redirect("transaction_daily.aspx");
    }
    protected void BtnIssueBook_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("transaction_issue_book.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }
    }
    protected void BtnReceiveBook_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("transaction_receive_book.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }
    }

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
            SqlDataAdapter Da = new SqlDataAdapter("select * from library_transaction where tranid =" + Request.QueryString["tranid"], Cn);
            DataSet Ds = new DataSet();
            Ds.Clear();
            Da.Fill(Ds, "library_transaction");
            if( Ds.Tables["library_transaction"].Rows.Count > 0 )
            {
                DataRow r ;
                r = Ds.Tables["library_transaction"].Rows[0];

                SqlDataAdapter Da1 ;
                DataSet Ds1 ;

                Da1 = new SqlDataAdapter("select * from books where bookid=" + r["bookid"], Cn);
                Ds1 = new DataSet();
                Ds1.Clear();
                Da1.Fill(Ds1, "books");
                DataRow r1;
                r1 = Ds1.Tables["books"].Rows[0];
                span_bookid.InnerText = r1["bookid"].ToString();
                span_booktitle.InnerText = r1["title"].ToString();

                Da1 = new SqlDataAdapter("select * from members where memid=(select memid from library_card where libcardid=" + r["libcardid"].ToString() + ") ", Cn);
                Ds1 = new DataSet();
                Ds1.Clear();
                Da1.Fill(Ds1, "members");
                
                r1 = Ds1.Tables["members"].Rows[0];
                span_library.InnerText = r["libcardid"] + " - [" + r1["title"] + " " + r1["fname"] + " " + r1["mname"] + " " + r1["lname"] + "]";



            }

    }
}

