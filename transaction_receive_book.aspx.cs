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


public partial class transaction_receive_book : System.Web.UI.Page
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
            if (Request.QueryString["mode"] == "edit" )
            {
                int TrnId ;
                TrnId =int.Parse( Request.QueryString["tranid"]);
                // get deatils
                // if already receive book disable update
                SqlDataAdapter da;
                DataSet Ds ;

                SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
                da= new SqlDataAdapter("select * from library_transaction where tranid=" + TrnId, Cn);
                Ds = new DataSet();
                Ds.Clear();
                da.Fill(Ds, "library_transaction");
                if (Ds.Tables["library_transaction"].Rows.Count > 0)
                {
                    DataRow R ;
                    R = Ds.Tables["library_transaction"].Rows[0];
                    TxtLibCardID.Text = R["libcardid"].ToString();
                    TxtTranID.Text = R["tranid"].ToString();
                    TxtBookID.Text = R["bookid"].ToString();
                    TxtIssueDate.Text = R["issuedate"].ToString();

                    TxtReceiptDate.Text = R["ReceiptDate"].ToString();
                    if (R["findanyfault"].ToString() == "1")
                    {
                        ChkIsFault.Checked = true;
                    }
                    else
                    {
                        ChkIsFault.Checked = false;
                    }
                    
                    TxtFaultDescription.Text = R["faultdescription"].ToString();

                    if  ( R["receiptdate"].ToString()!="" ) 
                    {
                        BtnSubmit.Enabled = false;
                    }
                    else
                    {
                        BtnSubmit.Enabled = true;
                        TxtReceiptDate.Text = DateTime.Now.ToString();
                        int TotalDay ;
                        System.TimeSpan TS = new System.TimeSpan(DateTime.Now.Ticks - DateTime.Parse(R["issuedate"].ToString()).Ticks );

                        TotalDay= TS.Days ;
                        
                        if (TotalDay > 30 )
                        {
                            int td;
                            td=(TotalDay - 30) * 2;
                            TxtLateFine.Text = td.ToString();
                        }
                    }
                }
            }
           else
            {

                TxtLibCardID.Text = "";
                TxtTranID.Text = "";
                TxtBookID.Text = "";
                TxtIssueDate.Text = "";
                TxtLateFine.Text = "0";
                ChkIsFault.Checked = false;
                TxtFaultDescription.Text = "";
                TxtReceiptDate.Text = DateTime.Now.ToString();
            }
        }
    
    }
    
    protected void BtnTransaction1_Click(object sender, EventArgs e)
    {
        Response.Redirect("transaction_daily.aspx");
    }
    protected void BtnIssueBook_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
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
       if( Session["uid"] == "")
       {
            ClsMain.CreateMessageAlert(this, "Your seesion is expired.", "123");
            return;
       }

        // update transaction
        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        SqlDataAdapter Da =new SqlDataAdapter("select * from library_transaction where tranid=" + TxtTranID.Text + " and receiptdate is null ", Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        DataSet Ds = new DataSet();
        Ds.Clear();
        Da.Fill(Ds, "library_transaction");
        if (Ds.Tables["library_transaction"].Rows.Count > 0 )
        {
            DataRow R ;
            R = Ds.Tables["library_transaction"].Rows[0];
            R["receiptdate"] =DateTime.Now.ToString ();
            if (ChkIsFault.Checked == true)
            {
                R["findanyfault"] = 1;
            }
            else
            {
                R["findanyfault"] = 0;
            }
            R["faultdescription"] =  TxtFaultDescription.Text;
            R["latefine"]=int.Parse(TxtLateFine.Text);
            R["ReceiveUserID"] = Session["uid"];

            Da.Update(Ds, "library_transaction");

            Response.Redirect("transaction_daily.aspx");

        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Can not update, Invalid transaction id/ or book already received.", "123");
        }

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

   protected void BtnGo_Click(object sender, EventArgs e)
    {
        // show last transaction for the libarry card


        // get deatils
        // if already receive book disable update
        SqlDataAdapter da ;
        DataSet Ds;

        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        da= new SqlDataAdapter("select top 1 * from library_transaction where libcardid=" +TxtLibCardID.Text + " order by tranid desc ", Cn);
        Ds = new DataSet();
        Ds.Clear();
        da.Fill(Ds, "library_transaction");
        if (Ds.Tables["library_transaction"].Rows.Count > 0 )
        {
            DataRow R ;
            R = Ds.Tables["library_transaction"].Rows[0];
            //TxtLibCardID.Text = R("libcardid")
            TxtTranID.Text = R["tranid"].ToString();
            TxtBookID.Text = R["bookid"].ToString();
            TxtIssueDate.Text = R["issuedate"].ToString();

            TxtReceiptDate.Text = R["ReceiptDate"].ToString();
            if (R["findanyfault"].ToString() == "1")
            {
                ChkIsFault.Checked = true;
            }
            else
            {
                ChkIsFault.Checked = false;
            }
            TxtFaultDescription.Text = R["faultdescription"].ToString();

            if (R["receiptdate"].ToString() != "" )
            {
                BtnSubmit.Enabled = false;
            }
            else
            {
                BtnSubmit.Enabled = true;
                TxtReceiptDate.Text = DateTime.Now.ToString();
                int TotalDay ;

                System.TimeSpan TS = new System.TimeSpan(DateTime.Now.Ticks - DateTime.Parse(R["issuedate"].ToString()).Ticks);

                TotalDay = TS.Days;

                if (TotalDay > 30)
                {
                    int td;
                    td = (TotalDay - 30) * 2;
                    TxtLateFine.Text = td.ToString();
                }



            }

        }
        else
        {

            ClsMain.CreateMessageAlert(this, "No Details found for the libarry card.", "123");

            TxtLibCardID.Text = "";
            TxtTranID.Text = "";
            TxtBookID.Text = "";
            TxtIssueDate.Text = "";
            TxtLateFine.Text = "0";
            ChkIsFault.Checked = false;
            TxtFaultDescription.Text = "";
            TxtReceiptDate.Text = DateTime.Now.ToString();
        }
    }

    protected void BtnFindBook_Click(object sender, EventArgs e)
    {

    }
}
