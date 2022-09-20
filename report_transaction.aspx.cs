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

public partial class report_transaction : System.Web.UI.Page
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
         if (IsPostBack == false)
         {
            TxtDateFrom.Text = "2008-08-15 00:00";
            TxtDateTo.Text = "2019-08-15 23:59";


         }
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
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        // create quesry string
        
        string s, s1, s2 ;

        s1 = " and (issuedate between '" + TxtDateFrom.Text + "' and '" + TxtDateTo.Text + "' or receiptdate between '" + TxtDateFrom.Text + "' and '" + TxtDateTo.Text + "' )";

        if (Session["utype"] == "A")
        {
            s2 = " ";
        }
        else if (Session["utype"] == "S" )
        {
            s2 = "userid=" + Session["uid"];
        }
        else
        {
            s2 = "libcardid = (select libcardid from library_card where memid= " + Session["uid"] + ") ";
        }

        s = "select TranID, LibCardID, BookID, IssueDate, ReceiptDate from library_transaction where 1=1" + s1 + s2;



        // show data
        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        SqlDataAdapter Da = new SqlDataAdapter(s, Cn);

        DataSet Ds = new DataSet();
        Ds.Clear();
        Da.Fill(Ds, "transaction");
        if (Ds.Tables["transaction"].Rows.Count <= 0)
        {

            span_search_result.InnerHtml = "<br><br><b>No record found.</b><br><br>";
            GridView1.Columns.Clear();
            GridView1.DataBind();
            
           // Exit Sub
        }
        else
        {
            span_search_result.InnerHtml = "<b><br>" + Ds.Tables["transaction"].Rows.Count + " record found.</b><br><br>";
            GridView1.DataSource = Ds;
            GridView1.DataMember = "transaction";
            GridView1.DataBind();
        }

    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Text = "<a href=transaction_receive_book.aspx?mode=edit&tranid=" + e.Row.Cells[0].Text + ">" + e.Row.Cells[0].Text + "</a>";
    }
}


