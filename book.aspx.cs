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

public partial class book : System.Web.UI.Page
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
            if( DdlPublshers.Text == "Select")
            {
                ClsMain.CreateMessageAlert(this, "Select publishers from the lsit.", "123");
                return;
            }   
            
            if( DdlAuthors.Text == "Select")
            {
                ClsMain.CreateMessageAlert(this, "Select authors from the lsit.", "123");
                return;
            }


            // insert/update the book details

            string AddEdit;
            AddEdit = Request.QueryString["mode"];

            SqlConnection  Cn = new SqlConnection(ClsMain.ConnStr);
            Cn.Open();
            SqlCommand  Com = new SqlCommand();
            SqlDataAdapter Da = new SqlDataAdapter();
            DataSet Ds;
            string StrSql="";



            if( AddEdit == "new" )
            {
                StrSql = "select * from books where 1=2";
            }
            else if( AddEdit == "edit" )
            {
                StrSql = "select * from books where bookid=" + TxtBookId.Text ;
            }
            else
            {
                return;
            }
            


            int PubId;
            int AuthId;
            // find the last book id
            int LastSno;
            Com = new SqlCommand("select max(bookid) from books", Cn);
            LastSno = (int)Com.ExecuteScalar();

            // find the pub id
            Com = new SqlCommand("select pubid from publishers where name='" + DdlPublshers.Text + "'", Cn);
            PubId = (int)Com.ExecuteScalar();

            if( PubId == 0 )
            {
                ClsMain.CreateMessageAlert(this, "Select publishers from the lsit.", "123");
            }

            // find the au id
            Com = new SqlCommand("select au_id from authors where author='" + DdlAuthors.Text + "'", Cn);
            AuthId = (int)Com.ExecuteScalar();

            if (AuthId == 0)
            {
                ClsMain.CreateMessageAlert(this, "Select authors from the lsit.", "123");
            }
            

            Da = new SqlDataAdapter(StrSql, Cn);
            SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
            Ds = new DataSet();
            Ds.Clear();

            Da.Fill(Ds, "books");


            // insert data
            DataRow R;
            if( AddEdit == "new")
            {
                R = Ds.Tables["books"].NewRow();
                R["bookid"] = LastSno + 1;
                TxtBookId.Text = R["bookid"].ToString();
            }
            else
            {
                R = Ds.Tables["books"].Rows[0];
            }
            
            R["title"] = TxtTitle.Text;
            R["yearpublished"] = TxtYear.Text;
            R["isbn"] = TxtISBN.Text;
            R["pubid"] = PubId ;

            R["prepagecount"] = TxtPrePageCount.Text;
            R["pagecount"] = TxtPageCount.Text;
            R["postpagecount"] = TxtPostPageCount.Text;
            if (ChkIsDisk.Checked==true)
            {
                R["IsDiskAvialable"] = 1;
            }
            else
            {
                R["IsDiskAvialable"] = 0;
            }
            R["bindingtype"] = DdlBuindingType.Text;
            
            R["PurchaseDate"] = TxtPurchaseDate.Text;
            R["PurchaseSource"] = TxtPurchaseSource.Text;
            R["KeyWords"] = TxtKeywords.Text;
            R["Description"] = TxtDescription.Text;
            R["price"] = TxtPrice.Text;
            if (ChkNotForIssue.Checked == true)
            {
                R["NotForIssue"] = 1;
            }
            else
            {
                R["NotForIssue"] = 0;
            }
            
            R["CurrentStatus"] = TxtStatus.Text;
            R["faults"] = TxtFault.Text;
            R["userid"] = Session["uid"];
            R["entrydate"] = DateTime.Now.ToString();

            if( AddEdit == "new")
            {
                Ds.Tables["books"].Rows.Add(R);
            }
            
            // update book
            Da.Update(Ds, "books");

            // update authors
            Com = new SqlCommand("delete from book_author where bookid=" + TxtBookId.Text, Cn);
            Com.ExecuteNonQuery();
            Com = new SqlCommand("insert into book_author values(" + TxtBookId.Text + "," + AuthId.ToString() + ")", Cn);
            Com.ExecuteNonQuery();

            
            
            if( AddEdit == "new")
            {
                
                Response.Redirect("book_update.aspx?bookid=" + TxtBookId.Text);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Book details updated!');" + "window.location.href='search_book.aspx';" + "<" + "/script>");
                //Response.Redirect("search_book.aspx");
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
            SqlConnection Cn =new SqlConnection(ClsMain.ConnStr);

            // fill publishers
            SqlDataAdapter da =new SqlDataAdapter("select name from publishers order by 1", Cn);
            DataSet Ds = new DataSet();
            Ds.Clear();
            da.Fill(Ds, "publishers");
            DdlPublshers.Items.Clear();
            DdlPublshers.Items.Add("Select");
            int i ;
            for (i = 0; i<=  Ds.Tables["publishers"].Rows.Count - 1; i++)
            {
                DataRow r;
                r = Ds.Tables["publishers"].Rows[i];
                DdlPublshers.Items.Add(r["name"].ToString());
            }
            

            // fill authors
            da = new SqlDataAdapter("select author from authors order by 1", Cn);
            Ds = new DataSet();
            Ds.Clear();
            da.Fill(Ds, "authors");
            DdlAuthors.Items.Clear();
            DdlAuthors.Items.Add("Select");
            for (i = 0; i<=  Ds.Tables["authors"].Rows.Count - 1; i++)
            {
                DataRow r;
                r = Ds.Tables["authors"].Rows[i];
                DdlAuthors.Items.Add(r["author"].ToString());
            }


            // fill biding type
            DdlBuindingType.Items.Clear();
            DdlBuindingType.Items.Add("Select");
            DdlBuindingType.Items.Add("HARD BINDING");
            DdlBuindingType.Items.Add("SOFT BINDING");

            if( Request.QueryString["mode"] == "new")
            {
                TxtPurchaseDate.Text = DateTime.Today.ToString();
                TxtPageCount.Text = "0";
                TxtPrePageCount.Text = "0";
                TxtPostPageCount.Text = "0";
                TxtFault.Text = "NA";
                TxtPurchaseSource.Text = "NA";
                TxtPrice.Text = "0";
            }
            else if( Request.QueryString["mode"] == "edit")
            {
                int BookId;
                BookId = int.Parse(Request.QueryString["bookid"]);

                da = new SqlDataAdapter("select * from books where bookid =" + BookId, Cn);
                Ds = new DataSet();
                Ds.Clear();
                da.Fill(Ds, "books");

                if( Ds.Tables["books"].Rows.Count > 0)
                {
                    DataRow r ;
                    r = Ds.Tables["books"].Rows[0];
                    TxtBookId.Text = r["bookid"].ToString();
                    TxtTitle.Text = r["title"].ToString ();
                    TxtYear.Text = r["yearpublished"].ToString ();
                    TxtISBN.Text = r["isbn"].ToString ();
                    if (Cn.State == 0)
                    {
                        Cn.Open();
                    }
                    // publishers
                    string PubName;
                    SqlCommand Com = new SqlCommand(" select name from publishers where pubid=" + r["pubid"].ToString(), Cn);
                    PubName = Com.ExecuteScalar().ToString();
                    DdlPublshers.Text = PubName;

                    // authors
                    string AuthorName;
                    Com = new SqlCommand(" select author from authors where au_id=(select au_id from book_author where bookid=" + r["bookid"].ToString() + ")", Cn);
                    AuthorName = Com.ExecuteScalar().ToString();
                    DdlAuthors.Text = AuthorName;
                    if( Cn.State == ConnectionState.Open)
                    {
                        Cn.Close();
                    }
                    
                    TxtPrePageCount.Text = r["prepagecount"].ToString ();
                    TxtPageCount.Text = r["pagecount"].ToString();
                    TxtPostPageCount.Text = r["postpagecount"].ToString();
                    DdlBuindingType.Text = r["bindingtype"].ToString();
                    if (r["IsDiskAvialable"].ToString() == "1")
                    {
                        ChkIsDisk.Checked = true;
                    }
                    else
                    {
                        ChkIsDisk.Checked = false;
                    }
                    
                    TxtPurchaseDate.Text = r["purchasedate"].ToString();
                    TxtPurchaseSource.Text = r["purchasesource"].ToString();
                    TxtKeywords.Text = r["keywords"].ToString();
                    TxtDescription.Text = r["description"].ToString();
                    TxtPrice.Text = r["price"].ToString();
                    if (r["notforissue"].ToString() == "1")
                    {
                        ChkNotForIssue.Checked = true;
                    }
                    else
                    {
                        ChkNotForIssue.Checked = false;
                    }
                    TxtStatus.Text = r["currentstatus"].ToString();
                    TxtFault.Text = r["faults"].ToString();
                }

            }
        }

    }

}


