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
public partial class _Default : System.Web.UI.Page 
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
        
            SqlConnection Cn=new SqlConnection();
            Cn.ConnectionString=ClsMain.ConnStr;
            if(Cn.State==0)
            {
                Cn.Open();
            }
            SqlCommand Com=new SqlCommand();
            String iCount;

        Com = new SqlCommand("select count(*) from books", Cn);
           
        iCount = Com.ExecuteScalar().ToString();

        span_bookcount.InnerText = iCount;
        Com.CommandText = "select count(*) from members";
        Com.Connection = Cn;


        iCount = Com.ExecuteScalar().ToString();
        span_membercount.InnerText = iCount;

        span_membercount.InnerText = iCount;
        Com.CommandText = "select getdate()";
        Com.Connection = Cn;

        span_serverdate.InnerText = Com.ExecuteScalar().ToString();
 
             
    }
    

}

