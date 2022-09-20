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

public partial class user_change_password : System.Web.UI.Page
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
    protected void BtnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_change_password.aspx");
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
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        //validation
        if (TxtUserID.Text == "")
        {
            ClsMain.CreateMessageAlert(this, "Enter user name.", "123");
            return;
        }

        if (TxtOldPassword.Text  == "")
        {
            ClsMain.CreateMessageAlert(this, "Enter old password.", "123");
            return;
        }

        if( TxtNewPassword.Text == "" )
        {
            ClsMain.CreateMessageAlert(this, "Enter new password.", "123");
            return;
        }

        if (TxtNewPassword.Text != TxtConfirmPassword.Text)
        {
            ClsMain.CreateMessageAlert(this, "New and confirm password are not matched.", "123");
            return;
        }


        // valid from database for old password

        SqlConnection Cn =new SqlConnection(ClsMain.ConnStr);
        SqlDataAdapter Da ;
        DataSet Ds ;

        Da = new SqlDataAdapter("select * from user_master where username ='" + TxtUserID.Text +"'", Cn);
        Ds = new DataSet();
        Ds.Clear();
        Da.Fill(Ds, "user_master");
        if (Ds.Tables["user_master"].Rows.Count == 1 )
        {
            DataRow r;
            r=Ds.Tables["user_master"].Rows[0];
            if (r["userpassword"].ToString() == TxtOldPassword.Text )
            {
                if (Cn.State == 0 )
                {
                    Cn.Open();
                }
                SqlCommand Com = new SqlCommand("update user_master set userpassword='" + TxtNewPassword.Text + "' where username='" + TxtUserID.Text + "'", Cn);
                Com.ExecuteNonQuery();
                ClsMain.CreateMessageAlert(this, "Password has been changed.", "123");
            }
            else
            {
                ClsMain.CreateMessageAlert(this, "Invalid password.", "123");
                return;
            }
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "User id not found.", "123");
            return;
        }
    
    }

}
