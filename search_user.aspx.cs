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
public partial class search_user : System.Web.UI.Page
{

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
    protected void BtnMemberCategory_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("member_category.aspx");
        }
        else
        {
            ClsMain.CreateMessageAlert(this , "Unauthorized access.", "123");
        }
            
    }
    protected void BtnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_change_password.aspx");
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
                    // search book
            // create quesry string
            string s = "";
            string s1  = "";
            string s2  = "";
            string s3  = "";

            if ( TxtUserID.Text== "" )
            {
            }
            else
            {
                s1 = " and userid =" + TxtUserID.Text + " ";
            }
            
            if (TxtName.Text == "" )
            {
            }
            else
            {
                s2 = " and username like '" + TxtName.Text + "%'";
            }
            


            s = s1 + s2 + s3;
            
            if (s == "")
            {
                ClsMain.CreateMessageAlert(this, "Enter search condition", "123");
            }
                
           

            //>>> show data
            SqlConnection cn=new SqlConnection (ClsMain.ConnStr);

            SqlDataAdapter Da = new SqlDataAdapter("select UserID,UserName,UserType from user_master where 1 = 1 " + s, cn);

            DataSet Ds = new DataSet();
            Ds.Clear();
            Da.Fill(Ds, "user_master");
            if (Ds.Tables["user_master"].Rows.Count <= 0 )
            {

                span_search_result.InnerHtml = "<br><b>No record found.</b>";
                GridView1.Columns.Clear();
                GridView1.DataBind();

            }
            else
            {
                span_search_result.InnerHtml = "<b><br>" + Ds.Tables["user_master"].Rows.Count + "record found.</b><br>";
                GridView1.DataSource = Ds;
                GridView1.DataMember = "user_master";
                GridView1.DataBind();
            }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Text = "<a href=user.aspx?mode=edit&userid=" + e.Row.Cells[0].Text + ">" + e.Row.Cells[0].Text + "</a>";
    }
}

