using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class login : System.Web.UI.Page 
{

    protected void Page_Load(object sender, System.EventArgs e)
    {
        Session["uid"] = "";
        Session["uname"] = "";
        Session["utype"] = "";
       
    }

    protected void BtnSubmit_Click( object sender,System.EventArgs e)
    {


        SqlConnection cn=new SqlConnection() ;
        cn.ConnectionString =ClsMain.ConnStr ;
        cn.Open() ;

        SqlDataAdapter da = new SqlDataAdapter("select * from user_master where isenable=1 and username='" + TxtUserName.Text + "' and userpassword='" + TxtUserPassword.Text + "'", cn);
        DataSet ds = new DataSet();
        da.Fill(ds,"usermaster");
        if (ds.Tables["usermaster"].Rows.Count > 0)
        {
            DataRow R;
            R = ds.Tables["usermaster"].Rows[0];
            Session["uid"] = R["userid"].ToString();
            Session["uname"] = R["username"].ToString();
            
            if (R["usertype"].ToString() == "ADMIN")
            {
                Session["utype"] = "A";
                
            }
            else
            {
                if (R["usertype"].ToString() == "STAFF")
                {
                    Session["utype"] = "S";
                }
                else
                {
                    Session["utype"] = "M";
                }
            }

            Response.Redirect("default.aspx");
        }
        else
        {
            
            ClsMain.CreateMessageAlert( this , "Login fail, Invalid user name/password.", "123");
        }

    }


}
 