
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

public partial class member_category : System.Web.UI.Page
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
        // show data
        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        SqlDataAdapter Da = new SqlDataAdapter("select CategoryID, CategoryType, LateFine, DepositAmount from category where 1 = 1 ", Cn);

        DataSet Ds = new DataSet();
        Ds.Clear();
        Da.Fill(Ds, "category");
        if (Ds.Tables["category"].Rows.Count <= 0)
        {

            span_search_result.InnerHtml = "<br><br><b>No record found.</b>";
            GridView1.Columns.Clear();
            GridView1.DataBind();

            return;
        }
        else
        {
            span_search_result.InnerHtml = "<br><br><b>" + Ds.Tables["category"].Rows.Count + " record found.</b><br><br>";
            GridView1.DataSource = Ds;
            GridView1.DataMember = "category";
            GridView1.DataBind();
        }
    }
    protected void BtnSearchUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_user.aspx");
    }
    protected void BtnNewUser_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("user.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }
    }

    protected void BtnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_change_password.aspx");
    }

    protected void BtnNewCategory_Click(object sender, EventArgs e)
    {
        Response.Redirect("member_category_details.aspx?mode=new");
    }

    protected void BtnMemberCategory_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("member_category.aspx");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        e.Row.Cells[0].Text = "<a href=member_category_details.aspx?mode=edit&categoryid=" + e.Row.Cells[0].Text + ">" + e.Row.Cells[0].Text + "</a>";
    }



}

