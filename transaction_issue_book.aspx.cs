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

public partial class transaction_issue_book : System.Web.UI.Page
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
        if (IsPostBack == false)
        {
            TxtLibId.Text = "";
            TxtTranID.Text = "";
            TxtBookId.Text = "";
            TxtIssueDate.Text = DateTime.Now.ToString();
        }
    }

    protected void BtnTransaction11_Click(object sender, EventArgs e)
    {
        Response.Redirect("transaction_daily.aspx");
    }
    protected void BtnIssueBook_Click(object sender, EventArgs e)
    {
            if (Session["utype"] == "A" && Session["utype"] == "S" )
            {
                Response.Redirect("transaction_issue_book.aspx?mode=new");
            }
            else
            {
                ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
            }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        // validation
        // check for libcard id..if already book issued
        // show message that he need to return the book first
        if (TxtLibId.Text == "0")
        {
            ClsMain.CreateMessageAlert(this, "Enter Lib Card.", "123");
            return;
        }
        if (TxtBookId.Text  == "0" )
        {
            ClsMain.CreateMessageAlert(this, "Enter book id.", "123");
            return;
        }

        int LibCardID;
        SqlDataAdapter da ;
        DataSet Ds ;
        SqlCommand Com ;
        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        if (Cn.State == 0 )
        {
            Cn.Open();
        }
        Com = new SqlCommand("select libcardid from library_card where libcardid=" + TxtLibId.Text, Cn);
        LibCardID = int.Parse(Com.ExecuteScalar().ToString());
        if (LibCardID == 0)
        {
            ClsMain.CreateMessageAlert(this, "Lib Card ID not found.", "123");
            return;
        }

        // check for book alaredy issued to this lib card
        da = new SqlDataAdapter("select * from library_transaction where receiptdate is null and libcardid =" + LibCardID, Cn);
        Ds = new DataSet();
        Ds.Clear();

        da.Fill(Ds, "library_transaction");
        if (Ds.Tables["library_transaction"].Rows.Count > 0 )
        {
            DataRow r;
            r=Ds.Tables["library_transaction"].Rows[0];
            ClsMain.CreateMessageAlert(this, "Library card no " + LibCardID + ", have allready book Id - " + r["bookid"].ToString() + " issued and not return back. can not issue more book.", "123");
            return;
        }

        // check for book issued
        da = new SqlDataAdapter("select * from books where bookid=" + TxtBookId.Text, Cn);
        Ds = new DataSet();
        Ds.Clear();
        da.Fill(Ds, "books");
        if (Ds.Tables["books"].Rows.Count > 0 )
        {
            DataRow r1;
            r1 = Ds.Tables["books"].Rows[0];
            if (r1["notforissue"].ToString() == "1" )
            {
                ClsMain.CreateMessageAlert(this, "Selected book is not available for issue.", "123");
                return;
            }
            if (r1["currentstatus"].ToString() != "NOT ISSUED" )
            {
                ClsMain.CreateMessageAlert(this, "Selected book is not available, It already issued", "123");
                return;
            }
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Book ID not found.", "123");
            return;
        }

        // insert into library transaction

        // get lats tranid
        int LastSno ;
        Com = new SqlCommand("select max(tranid) from library_transaction", Cn);
        LastSno = int.Parse(Com.ExecuteScalar().ToString()) + 1;

        TxtTranID.Text = LastSno.ToString() ;


        da = new SqlDataAdapter("select * from library_transaction where 1=2", Cn);
        SqlCommandBuilder Cb =new SqlCommandBuilder(da);
        Ds = new DataSet();
        Ds.Clear();

        da.Fill(Ds, "library_transaction");
        DataRow R ;
        R = Ds.Tables["library_transaction"].NewRow();
        R["tranid"] = int.Parse(TxtTranID.Text);
        R["libcardid"] = int.Parse(TxtLibId.Text);
        R["bookid"] = int.Parse(TxtBookId.Text);
        R["issuedate"] = DateTime.Now .ToString();
        R["issueduserid"] = Session["uid"];

        Ds.Tables["library_transaction"].Rows.Add(R);

        da.Update(Ds, "library_transaction");


        // update book currect status
        Com = new SqlCommand("update books set currentstatus='ISSUED' where bookid=" + TxtBookId.Text, Cn);
        Com.ExecuteNonQuery();

        if (Cn.State == ConnectionState.Open )
        {
            Cn.Close();
        }
        Response.Redirect("book_issue_complete.aspx?tranid=" + TxtTranID.Text);

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



    protected void BtnLibCardFind_Click(object sender, EventArgs e)
    {

    }
    protected void BtnBookFind_Click(object sender, EventArgs e)
    {

    }
}

