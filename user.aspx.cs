
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
public partial class user : System.Web.UI.Page
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
            Response.Redirect("member_category.aspx?mode=new");
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
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
            // validation
            if (TxtUserName.Text == "")
            {
                ClsMain.CreateMessageAlert(this, "Enter user name.", "123");
                return;
            }
            if (TxtUserPassword.Text == "")
            {
                ClsMain.CreateMessageAlert(this, "Enter password.", "123");
                return;
            }
            if (DdlUserType.Text == "Select")
            {
                ClsMain.CreateMessageAlert(this, "Select user type.", "123");
                return;
            }
            // insert/update the user details

            string AddEdit;
            AddEdit = Request.QueryString["mode"];

            SqlConnection Cn= new SqlConnection(ClsMain.ConnStr);
            Cn.Open();
            SqlCommand Com = new SqlCommand();
            SqlDataAdapter Da = new SqlDataAdapter();
            DataSet Ds;
            string StrSql="";



            if (AddEdit == "new" )
            {
                StrSql = "select * from user_master where 1=2";
            }
            else if (AddEdit == "edit")
            {
                StrSql = "select * from user_master where userid=" + TxtUserID.Text;
            }
            else
            {
                return;
            }
            
            // find the last user id
            int LastSno;
            Com = new SqlCommand("select max(userid) from user_master", Cn);
            LastSno = int.Parse(Com.ExecuteScalar().ToString());



            Da = new SqlDataAdapter(StrSql, Cn);
            SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
            Ds = new DataSet();
            Ds.Clear();

            Da.Fill(Ds, "user_master");


            // insert data
            DataRow R ;
            if (AddEdit == "new")
            {
                R = Ds.Tables["user_master"].NewRow();
                R["userid"] = LastSno + 1;
                TxtUserID.Text = R["userid"].ToString();
            }
            else
            {
                R = Ds.Tables["user_master"].Rows[0];
            }
           
            R["username"] = TxtUserName.Text;
            R["userpassword"] = TxtUserPassword.Text;
            R["usertype"] = DdlUserType.Text;
            if (ChkIsActive.Checked == true)
            {
                R["isenable"] = 1;
            }
            else
            {
                R["isenable"] = 0;
            }

            if (AddEdit == "new" )
            {
                Ds.Tables["user_master"].Rows.Add(R);
            }
            
            // update book
            Da.Update(Ds, "user_master");



            if (AddEdit == "new")
            {
                Response.Redirect("user_update.aspx?userid=" + TxtUserID.Text);
            }
            else
            {
                Response.Redirect("search_user.aspx");
            }


            if (Cn.State == ConnectionState.Open )
            {
                Cn.Close();
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
           if (IsPostBack == false )
           {

                //user type
                DdlUserType.Items.Clear();
                DdlUserType.Items.Add("Select");
                DdlUserType.Items.Add("ADMIN");
                DdlUserType.Items.Add("STAFF");
                DdlUserType.Items.Add("MEMBER");



                SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
                SqlDataAdapter Da ;
                DataSet Ds;


                if (Request.QueryString["mode"] == "new")
                {
                    TxtUserName.Text = "";
                    TxtUserPassword.Text = "";
                    ChkIsActive.Checked = true;
                }
                else if (Request.QueryString["mode"] == "edit" )
                {
                    int UserID ;
                    UserID = int.Parse( Request.QueryString["userid"].ToString());

                    Da = new SqlDataAdapter("select * from user_master where userid =" + UserID, Cn);
                    Ds = new DataSet();
                    Ds.Clear();
                    Da.Fill(Ds, "user_master");

                    if (Ds.Tables["user_master"].Rows.Count > 0 )
                    {
                        DataRow r ;
                        r = Ds.Tables["user_master"].Rows[0];
                        TxtUserID.Text = r["userid"].ToString();
                        TxtUserName.Text = r["username"].ToString();
                        TxtUserPassword.Text = r["userpassword"].ToString();
                        DdlUserType.Text = r["usertype"].ToString();
                        if (r["isenable"].ToString() == "1")
                        {
                            ChkIsActive.Checked = true;
                        }
                        else
                        {
                            ChkIsActive.Checked = false;
                        }

                    }
                }

           }

    }
    
 }
