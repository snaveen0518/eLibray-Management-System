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

public partial class member_category_details : System.Web.UI.Page
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
        if( Session["utype"] == "A" && Session["utype"] == "S")
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
        if( Session["utype"] == "A" && Session["utype"] == "S")
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
        // validation
        if (TxtCategoryType.Text == "" )
        {
            ClsMain.CreateMessageAlert(this, "Enter category type.", "123");
            return;
        }

        // insert/update the user details

        string AddEdit;
        AddEdit = Request.QueryString["mode"];

        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        Cn.Open();
        SqlCommand Com = new SqlCommand();
        SqlDataAdapter Da = new SqlDataAdapter();
        DataSet Ds ;
        string StrSql ="";



        if ( AddEdit == "new" )
        {
            StrSql = "select * from category where 1=2";
        }
        else if (AddEdit == "edit" )
        {
            StrSql = "select * from category where categoryid=" + TxtCategoryID.Text;
        }
        else
        {
            return;
        }



        // find the last user id
        int LastSno;
        Com = new SqlCommand("select max(categoryid) from category", Cn);
        LastSno = int.Parse(Com.ExecuteScalar().ToString()) ;



        Da = new SqlDataAdapter(StrSql, Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        Ds = new DataSet();
        Ds.Clear();

        Da.Fill(Ds, "category");


        // insert data
        DataRow R ;
        if (AddEdit == "new")
        {
            R = Ds.Tables["category"].NewRow();
            R["categoryid"] = LastSno + 1;
            TxtCategoryID.Text = R["categoryid"].ToString() ;
        }
        else
        {
            R = Ds.Tables["category"].Rows[0];
        }


        R["categorytype"] = TxtCategoryType.Text;

        R["NoOfBooks"] = TxtNoOfBook.Text;
        R["NoOfDays"] = int.Parse (TxtNoOfDays.Text);
        R["latefine"] =int.Parse( TxtLateFine.Text);
        R["DepositAmount"] = int.Parse(TxtDepositAmount.Text);
        R["CardRenewFees"] = int.Parse(TxtRenewFees.Text);



        if (AddEdit == "new" )
        {
            Ds.Tables["category"].Rows.Add(R);
        }
        
        // update book
        Da.Update(Ds, "category");



        if (AddEdit == "new" )
        {
            Response.Redirect("category_update.aspx?categoryid=" + TxtCategoryID.Text);
        }
        else
        {
            Response.Redirect("member_category.aspx");
        }
        


        if (Cn.State == ConnectionState.Open)
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
        if (IsPostBack == false)
        {



            SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
            SqlDataAdapter Da ;
            DataSet Ds ;


            if (Request.QueryString["mode"] == "new")
            {
                TxtCategoryType.Text = "";
                TxtNoOfBook.Text = "0";
                TxtNoOfDays.Text = "0";
                TxtLateFine.Text = "0";
                TxtDepositAmount.Text = "0";
                TxtRenewFees.Text = "0";
            }
            else if ( Request.QueryString["mode"] == "edit")
            {
                int CategoryID;
                CategoryID = int.Parse(Request.QueryString["categoryid"]);

                Da = new SqlDataAdapter("select * from category where categoryid =" + CategoryID.ToString(), Cn);
                Ds = new DataSet();
                Ds.Clear();
                Da.Fill(Ds, "category");

                if (Ds.Tables["category"].Rows.Count > 0)
                {
                    DataRow r ;
                    r = Ds.Tables["category"].Rows[0];
                    TxtCategoryID.Text = r["categoryid"].ToString();
                    TxtCategoryType.Text = r["categorytype"].ToString();
                    TxtNoOfBook.Text = r["NoOfBooks"].ToString();
                    TxtNoOfDays.Text = r["NoOfDays"].ToString();
                    TxtLateFine.Text = r["latefine"].ToString();
                    TxtDepositAmount.Text = r["DepositAmount"].ToString();
                    TxtRenewFees.Text = r["CardRenewFees"].ToString();

                }
            }

        }

    }
}
