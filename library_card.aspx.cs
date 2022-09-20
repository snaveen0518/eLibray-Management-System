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

public partial class library_card : System.Web.UI.Page
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
        SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
        if (Cn.State == 0)
        {
            Cn.Open();
        }
        SqlCommand Com = new SqlCommand();
        SqlDataAdapter Da = new SqlDataAdapter();
        DataSet Ds;
        string StrSql="";
        // validation
        // check for allready assigned member
        if ( int.Parse(TxtMemID.Text) <= 0)
        {
            ClsMain.CreateMessageAlert(this, "Enter member id.", "123");
            return;
        }

        Com = new SqlCommand("select memid from members where memid=" + TxtMemID.Text, Cn);
        if( int.Parse(Com.ExecuteScalar().ToString()) <= 0)
        {
            ClsMain.CreateMessageAlert(this, "Member ID not found.", "123");
            return;
        }

        //'>>> check for valid date
        //If IsDate(TxtValidFrom.Text) = False Then
        //    ClsMain.CreateMessageAlert(Me, "Enter valid date for 'Valid from date'.", "123")
        //    Exit Sub
        //End If
        //If IsDate(TxtValidUpto.Text) = False Then
        //    ClsMain.CreateMessageAlert(Me, "Enter valid date for 'Valid upto date'.", "123")
        //    Exit Sub
        //End If
        //If CDate(TxtValidFrom.Text) > CDate(TxtValidUpto.Text) Then
        //    ClsMain.CreateMessageAlert(Me, "Check the date range 'Valid Upto' date must be grater than 'Valid From' date.", "123")
        //    Exit Sub
        //End If

         //addition check from category master


         //insert/update the book details

        string AddEdit;
        AddEdit = Request.QueryString["mode"];

        if( AddEdit == "new" )
            StrSql = "select * from library_card where 1=2";
        else if (AddEdit == "edit")
            StrSql = "select * from library_card where libcardid=" + TxtLibCardID.Text;
        else
        {
            return;
        }



        // find the last pub id
        int LastSno;
        Com = new SqlCommand("select max(libcardid) from library_card", Cn);
        LastSno =int.Parse(Com.ExecuteScalar().ToString());

        Da = new SqlDataAdapter(StrSql, Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        Ds = new DataSet();
        Ds.Clear();

        Da.Fill(Ds, "library_card");


        // insert data
        DataRow R;
        if ( AddEdit == "new")
        {
            R = Ds.Tables["library_card"].NewRow();
            R["libcardid"] = LastSno + 1;
            R["createdate"] = DateTime.Now.ToString() ;
            R["userid"] = Session["uid"];

            TxtLibCardID.Text = R["libcardid"].ToString() ;
        }
        else
        {
            R = Ds.Tables["library_card"].Rows[0];
        }
        
        R["memid"] = TxtMemID.Text;
        R["validfrom"] = TxtValidFrom.Text;
        R["validupto"] = TxtValidUpto.Text;
        if (ChkIsActive.Checked==true)
        {
            R["isactive"]=1;
        }
        else
        {
            R["isactive"]=0;
        }

        if( AddEdit == "new")
        {
            Ds.Tables["library_card"].Rows.Add(R);
        }
        
        // update library_card
        Da.Update(Ds, "library_card");

        // insert library card history
        // get last cardhisid
        Com = new SqlCommand("select max(CardHisID) from library_card_history", Cn);
        LastSno = int.Parse(Com.ExecuteScalar().ToString());

        Da = new SqlDataAdapter("select * from library_card_history where 1=2", Cn);
        Cb = new SqlCommandBuilder(Da);
        Ds = new DataSet();
        Ds.Clear();

        Da.Fill(Ds, "library_card_history");
        R = Ds.Tables["library_card_history"].NewRow();
        R["CardHisID"] = LastSno + 1;
        R["LibCardID"] = TxtLibCardID.Text;
        R["memid"] = TxtMemID.Text;
        R["userid"] = Session["uid"];
        R["validfrom"] = TxtValidFrom.Text;
        R["validupto"] = TxtValidUpto.Text;
        if (ChkIsActive.Checked==true)
        {
            R["isactive"]=1;
        }
        else
        {
            R["isactive"]=0;
        }
        R["updatedate"] =DateTime.Now.ToString ();

        Ds.Tables["library_card_history"].Rows.Add(R);

        Da.Update(Ds, "library_card_history");


        if( AddEdit == "new" )
        {
            Response.Redirect("library_card_update.aspx?libcardid=" + TxtLibCardID.Text);
        }
        else
        {
            Response.Redirect("search_library_card.aspx");
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
        if (IsPostBack == false )
        {
            SqlConnection Cn = new SqlConnection(ClsMain.ConnStr);
            SqlDataAdapter Da ;
            DataSet Ds ;


            if (Request.QueryString["mode"] == "new" )
            {
                TxtMemID.Text = "";
                ChkIsActive.Checked = true;
                TxtValidFrom.Text = DateTime.Today.ToString();
                TxtValidUpto.Text = DateTime.Today.AddMonths(1).ToString();
            }

            else if( Request.QueryString["mode"] == "edit")
            {
                int LibCardId ;
                LibCardId =int.Parse( Request.QueryString["libcardid"]);

                Da= new SqlDataAdapter("select * from library_card where LibCardId =" + LibCardId.ToString(), Cn);
                Ds = new DataSet();
                Ds.Clear();
                Da.Fill(Ds, "library_card");

                if( Ds.Tables["library_card"].Rows.Count > 0 )
                {
                    DataRow r ;
                    r = Ds.Tables["library_card"].Rows[0];
                    TxtLibCardID.Text = r["libcardid"].ToString();
                    TxtMemID.Text = r["memid"].ToString();
                    TxtCreateDate.Text = r["createdate"].ToString();
                    TxtValidFrom.Text = r["validfrom"].ToString();
                    TxtValidUpto.Text = r["validupto"].ToString();
                    if (r["isactive"].ToString() == "1")
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


    protected void BtnFind_Click(object sender, EventArgs e)
    {

    }
}

