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

public partial class member : System.Web.UI.Page
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


    protected void BtnSearchMember_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_member.aspx");
    }

    protected void BtnNewMember_Click(object sender, EventArgs e)
    {
        
        if (Session["utype"].ToString() == "A" || Session["utype"].ToString() == "S")
        {
            Response.Redirect("member.aspx?mode=new");
        }
        else
        {
            ClsMain.CreateMessageAlert(this, "Unauthorized access.", "123");
        }
        
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        // validation
        if (TxtFName.Text == "")
        {
            ClsMain.CreateMessageAlert(this, "Enter first name.", "123");
            return;
        }
        
        if (DdlCategory.Text == "Select")
        {
            ClsMain.CreateMessageAlert(this, "Select category from the lsit.", "123");
            return;
        }
        


        // insert/update the members details

        String AddEdit;
        AddEdit = Request.QueryString["mode"];

        SqlConnection Cn= new SqlConnection(ClsMain.ConnStr);
        Cn.Open();
        SqlCommand Com = new SqlCommand();
        SqlDataAdapter Da = new SqlDataAdapter();
        DataSet Ds ;
        string StrSql="";



        if( AddEdit == "new")
        {
            StrSql = "select * from members where 1=2";
        }
        else if (AddEdit == "edit" )
        {
            StrSql = "select * from members where memid="  + TxtMemberID.Text;
        }
        else
        {
            return;
        }
        


        int CatID;

        // find the last book id
        int LastSno;
        Com = new SqlCommand("select max(memid) from members", Cn);
        LastSno = int.Parse( Com.ExecuteScalar().ToString());

        // find the cat id
        Com = new SqlCommand("select categoryid from category where categorytype='" +DdlCategory.Text + "'", Cn);
        CatID = int.Parse( Com.ExecuteScalar().ToString());

        if (CatID == 0 )
        {
            ClsMain.CreateMessageAlert(this, "Select category from the lsit.", "123");
        }
        



        Da = new SqlDataAdapter(StrSql, Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        Ds = new DataSet();
        Ds.Clear();

        Da.Fill(Ds, "members");


        // insert data
        DataRow R ;
        if( AddEdit == "new")
        {
            R = Ds.Tables["members"].NewRow();
            R["memid"] = LastSno + 1;
            TxtMemberID.Text = R["memid"].ToString();
        }
        else
        {
            R = Ds.Tables["members"].Rows[0];
        }
        R["catid"] = CatID;
        R["createdate"] = DateTime.Now.ToString();
        R["userid"] = Session["uid"];
        R["title"] = TxtTitle.Text;
        R["fname"] = TxtFName.Text;
        R["mname"] = TxtMName.Text;
        R["lname"] = TxtLName.Text;
        R["dob"] = TxtDOB.Text;
        R["profession"] = TxtProfession.Text;
        R["qualification"] = TxtQualification.Text;
        R["address"] = TxtAddress.Text;
        R["city"] = TxtCity.Text;
        R["postalcode"] = TxtPin.Text;
        R["country"] = TxtCountry.Text;
        R["email"] = TxtEmail.Text;
        R["telephoneo"] = TxtTeleOffice.Text;
        R["telephoneh"] = TxtTeleHome.Text;
        R["mobileno"] = TxtMobile.Text;


        if ( AddEdit == "new")
        {
            Ds.Tables["members"].Rows.Add(R);
        }
        
        // update members
        Da.Update(Ds, "members");



        if( AddEdit == "new")
        {
            Response.Redirect("member_update.aspx?memid=" + TxtMemberID.Text);
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Member details updated!');" + "window.location.href='search_member.aspx';" + "<" + "/script>");
            //Response.Redirect("search_member.aspx");
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

            // fill category
            SqlDataAdapter da = new SqlDataAdapter("select categorytype from category order by 1", Cn);
            DataSet Ds = new DataSet();
            Ds.Clear();
            da.Fill(Ds, "category");
            DdlCategory.Items.Clear();
            DdlCategory.Items.Add("Select");
            int i ;


            for (i = 0; i <= Ds.Tables["category"].Rows.Count - 1; i++ )
            {
                DataRow r1;
                r1=Ds.Tables["category"].Rows[i];
                DdlCategory.Items.Add(r1["categorytype"].ToString());
            }


            if( Request.QueryString["mode"] == "new" )
            {
                TxtTitle.Text = "";
                TxtFName.Text = "";
                TxtMName.Text = "";
                TxtLName.Text = "";
                TxtDOB.Text = DateTime.Today.ToString ();
                DdlCategory.Text = "Select";
            }
            else if( Request.QueryString["mode"] == "edit" )
            {
                int MemID;
                MemID =int.Parse ( Request.QueryString["memid"]);

                da = new SqlDataAdapter("select * from members where memid =" + MemID, Cn);
                Ds = new DataSet();
                Ds.Clear();
                da.Fill(Ds, "members");

                if( Ds.Tables["members"].Rows.Count > 0 )
                {
                    DataRow r ;
                    r = Ds.Tables["members"].Rows[0];
                    TxtMemberID.Text = r["memid"].ToString();
                    // category
                    string CategoryType ;
                    if (Cn.State == 0 )
                    {
                        Cn.Open();
                    }
                    SqlCommand Com = new SqlCommand(" select categorytype from category where categoryid=" + r["catid"].ToString() , Cn);
                    CategoryType = Com.ExecuteScalar().ToString();
                    DdlCategory.Text = CategoryType;
                    if (Cn.State == ConnectionState.Open  )
                    {
                        Cn.Close();
                    }

                    TxtTitle.Text = r["title"].ToString();
                    TxtFName.Text = r["fname"].ToString();
                    TxtMName.Text = r["mname"].ToString();
                    TxtLName.Text = r["lname"].ToString();
                    TxtDOB.Text = r["dob"].ToString();
                    TxtProfession.Text = r["profession"].ToString();
                    TxtQualification.Text = r["qualification"].ToString();
                    TxtAddress.Text = r["address"].ToString();
                    TxtCity.Text = r["city"].ToString();
                    TxtPin.Text = r["postalcode"].ToString();
                    TxtCountry.Text = r["country"].ToString();
                    TxtEmail.Text = r["email"].ToString();
                    TxtTeleOffice.Text = r["telephoneo"].ToString();
                    TxtTeleHome.Text = r["telephoneh"].ToString();
                    TxtMobile.Text = r["mobileno"].ToString();

                }
            }

        }
  
    }
}
