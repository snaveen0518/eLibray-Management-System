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

public partial class findbook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = ClsMain.ConnStr;
        cn.Open();



        String strSQL;
        strSQL = "select BookID, Title, ISBN, Description from books where Title like '" + TxtFirstName.Text + "%' and ISBN like '" + TxtLastName.Text + "%' order by BookID ";
        SqlDataAdapter da = new SqlDataAdapter(strSQL, cn);

        da.Fill(ds, "books");


        if (ds.Tables[0].Rows.Count > 0)
        {
            ViewState["dt"] = ds.Tables["books"];
            gvTeleVerification.DataSource = ViewState["dt"]; //ds.Tables["members"];
            gvTeleVerification.DataBind();
            gvTeleVerification.Visible = true;
        }

        else
        {

            lblMessage.Text = "No Records Matching";
            lblMessage.Visible = true;
        }

        da.Dispose();
    }
    protected void gvTeleVerification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            LinkButton lnkRID;
            lnkRID = (LinkButton)e.Row.FindControl("lnkRID");
            lnkRID.Attributes.Add("onclick", "FillRID('" + lnkRID.Text + "')");
        }
    }
    protected void gvTeleVerification_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTeleVerification.PageIndex = e.NewPageIndex;
        gvTeleVerification.DataSource = ViewState["dt"];// ds.Tables["members"];
        gvTeleVerification.DataBind();
    }
}
