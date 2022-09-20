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

public partial class author : System.Web.UI.Page
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
  
  
    protected void BtnSearchBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_book.aspx");
    }
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

              SqlConnection  Cn = new SqlConnection(ClsMain.ConnStr);
              Cn.Open();
              SqlCommand  Com = new SqlCommand();
              SqlDataAdapter  Da =new SqlDataAdapter();
              DataSet  Ds;
              string StrSql="";



              if( AddEdit == "new")
              {
                  StrSql = "select * from authors where 1=2";
              }
              else if( AddEdit =="edit" )
              {
                  StrSql = "select * from authors where au_id=" + TxtAuthorId.Text;
              }
              else
              {
                  //break;
              }
              



              // find the last book id
              int LastSno;
              Com = new SqlCommand("select max(au_id) from authors", Cn);
              LastSno =  (int)Com.ExecuteScalar() ;



              Da = new SqlDataAdapter(StrSql, Cn);
              SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
              Ds = new DataSet();
              Ds.Clear();

              Da.Fill(Ds, "authors");


              // insert data
              DataRow  R;
              if (AddEdit == "new")
              {
                  R = Ds.Tables["authors"].NewRow();
                  R["au_id"] = LastSno + 1;
                  TxtAuthorId.Text = R["au_id"].ToString();
              }
              else
              {
                  R = Ds.Tables["authors"].Rows[0];
              }
              
              R["author"] = TxtAuthorName.Text;
              if (TxtYear.Text == "")
              {
                  TxtYear.Text = "0";
              }
              R["year_born"] = int.Parse(TxtYear.Text);
              R["description"] = TxtDescription.Text;

              if( AddEdit == "new")
              {
                  Ds.Tables["authors"].Rows.Add(R);
              }
             
              //update book
              Da.Update(Ds, "authors");



              if( AddEdit == "new")
              {
                  Response.Redirect("author_update.aspx?au_id=" + TxtAuthorId.Text);
              }
              else
              {
                  this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Author details updated!');" + "window.location.href='search_author.aspx';" + "<" + "/script>");
                  //Response.Redirect("search_author.aspx");
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
          SqlConnection  Cn = new SqlConnection(ClsMain.ConnStr);
          SqlDataAdapter  Da ;
          DataSet  Ds ;

          
          if (Request.QueryString["mode"] == "new" )
          {
              TxtYear.Text = "";
              TxtAuthorName.Text = "";
              TxtDescription.Text = "NA";
          }
          else if(Request.QueryString["mode"] == "edit" )
          {
              int AuId;
              AuId =int.Parse(Request.QueryString["au_id"].ToString());


              Da = new SqlDataAdapter("select * from authors where au_id =" + AuId, Cn);
              Ds = new DataSet();
              Ds.Clear();
              Da.Fill(Ds, "authors");

              if (Ds.Tables["authors"].Rows.Count > 0)
              {
                  DataRow  r;
                  r = Ds.Tables["authors"].Rows[0];
                  TxtAuthorId.Text = r["au_id"].ToString();
                  TxtAuthorName.Text = r["author"].ToString();
                  TxtYear.Text = r["year_born"].ToString();
                  TxtDescription.Text = r["description"].ToString();

              }
          }



      }
    }
}


