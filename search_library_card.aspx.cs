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

public partial class search_library_card : System.Web.UI.Page
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
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        // search card
        // create quesry string
        string s  = "";
        string s1  = "";
        string s2  = "";
        string s3  = "";

        if (TxtLibCardID.Text !="" )
        {
            s1 = " and libcardid = " + TxtLibCardID.Text + " ";
        }
        if (TxtMemberID.Text != "")
        {
            s2 = " and memid =  " + TxtMemberID.Text + " ";
        }



        s = s1 + s2 + s3;

        if( s == "" )
        {
            ClsMain.CreateMessageAlert(this, "Enter search condition", "123");
            return;
        }

        //show data
        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        SqlDataAdapter Da = new SqlDataAdapter("select *  from library_card where 1 = 1 " + s, Cn);

        DataSet Ds = new DataSet();
        Ds.Clear();
        Da.Fill(Ds, "library_card");
        if (Ds.Tables["library_card"].Rows.Count <= 0)
        {

            span_search_result.InnerHtml = "<br><br><b>No record found.</b><br><br>";
            GridView1.Columns.Clear();
            GridView1.DataBind();

            return;
        }
        else
        {
            span_search_result.InnerHtml = "<br><br><b>" + Ds.Tables["library_card"].Rows.Count + " record found.</b><br><br>";
            GridView1.DataSource = Ds;
            GridView1.DataMember = "library_card";
            GridView1.DataBind();
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Text = "<a href=library_card.aspx?mode=edit&libcardid=" + e.Row.Cells[0].Text + ">" + e.Row.Cells[0].Text + "</a>";
    }
}


