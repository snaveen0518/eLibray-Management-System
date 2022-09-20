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

public partial class publisher : System.Web.UI.Page
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

    protected void BtnNewBook_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("book.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }

    }
    protected void BtnSearchBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_book.aspx");
    }
    protected void BtnSearchAuthor_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_author.aspx");
    }
    protected void BtnNewAuthor_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("author.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }
    }
    protected void BtnSearchPublisher_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_publisher.aspx");
    }
    protected void BtnNewPublisher_Click(object sender, EventArgs e)
    {
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("publisher.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
       // validation



        // insert/update the book details

        string AddEdit;
        AddEdit = Request.QueryString["mode"];

        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        Cn.Open();
        SqlCommand Com = new SqlCommand();
        SqlDataAdapter Da = new SqlDataAdapter();
        DataSet Ds ;
        string StrSql="";



        if (AddEdit == "new" )
        {
            StrSql = "select * from publishers where 1=2";
        }
        else if (AddEdit == "edit")
        {
            StrSql = "select * from publishers where pubid=" + TxtPubId.Text;
        }
        else
        {
            return;
        }
        
        // find the last pub id
        int LastSno;
        Com = new SqlCommand("select max(pubid) from publishers", Cn);
        LastSno =int.Parse(Com.ExecuteScalar().ToString());

       

        Da = new SqlDataAdapter(StrSql, Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        Ds = new DataSet();
        Ds.Clear();

        Da.Fill(Ds, "publishers");


        // insert data
        DataRow R ;
        if (AddEdit == "new" )
        {
            R = Ds.Tables["publishers"].NewRow();
            R["pubid"] = LastSno + 1;
            TxtPubId.Text =R["pubid"].ToString();
        }
        else
        {
            R = Ds.Tables["publishers"].Rows[0];
        }
        
        R["name"] = TxtName.Text;
        R["company_name"] = TxtCompnayName.Text;
        R["address"] = TxtAddress.Text;
        R["city"] = TxtCity.Text;
        R["state"] = TxtState.Text;
        R["pin"] = TxtPin.Text;
        R["telephone"] = TxtTelephone.Text;
        R["fax"] = TxtFax.Text;
        R["emailid"] = TxtEmailID.Text;
        R["website"] = TxtWebSite.Text;
        R["comments"] = TxtComments.Text;


        if (AddEdit == "new")
        {
            Ds.Tables["publishers"].Rows.Add(R);
        }
       
        // update book
        Da.Update(Ds, "publishers");

        if (AddEdit == "new")
        {
            Response.Redirect("publisher_update.aspx?pubid=" + TxtPubId.Text);
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Publisher details updated!');" + "window.location.href='search_publisher.aspx';" + "<" + "/script>");
            //Response.Redirect("search_publisher.aspx");
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
        if( IsPostBack == false)
        {
            SqlConnection Cn= new SqlConnection(ClsMain.ConnStr);
            SqlDataAdapter Da ;
            DataSet Ds;


            if( Request.QueryString["mode"] == "new" )
            {
                TxtName.Text = "";
                TxtCompnayName.Text = "";
                TxtAddress.Text = "";
                TxtPin.Text = "";
            }

            else if( Request.QueryString["mode"] == "edit" )
            {
                int PubId;
                PubId = int.Parse(Request.QueryString["pubid"]);

                Da = new SqlDataAdapter("select * from publishers where pubid =" + PubId.ToString(), Cn);
                Ds = new DataSet();
                Ds.Clear();
                Da.Fill(Ds, "publishers");

                if (Ds.Tables["publishers"].Rows.Count > 0 )
                {
                    DataRow r ;
                    r = Ds.Tables["publishers"].Rows[0];
                    TxtPubId.Text = r["pubid"].ToString();
                    TxtName.Text = r["name"].ToString();
                    TxtCompnayName.Text = r["company_name"].ToString();
                    TxtAddress.Text = r["address"].ToString();
                    TxtCity.Text = r["city"].ToString();
                    TxtState.Text = r["state"].ToString();
                    TxtPin.Text = r["pin"].ToString();
                    TxtTelephone.Text = r["telephone"].ToString();
                    TxtFax.Text = r["fax"].ToString();
                    TxtEmailID.Text = r["emailid"].ToString();
                    TxtWebSite.Text = r["website"].ToString();
                    TxtComments.Text = r["comments"].ToString();
                }
            }

        }
    }
}



