using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data.SqlTypes;

public partial class Bill_Entry_Update_BillEntry : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Search_BillRefNo_DD();

            Bind_Search_AggricultureCollege_DD();
            Bind_Search_Component_DD();
            Bind_Search_AccountHeadName_DD();

            ItemCategory_Bind_Dropdown();
            UOM_Bind_Dropdown();

            //Session["UserId"] = "10004"; // user id
            //Session["UserRole"] = "Tech"; // useer role
        }
    }

    //=========================={ Alert & Paging }==========================
    private void alert(string mssg)
    {
        // alert pop-up with only message
        string message = mssg;
        string script = $"alert('{message}');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "messageScript", script, true);
    }



    //=========================={ Sweet Alert JS }==========================
    private void getSweetAlertSuccessRedirectMandatory(string titles, string mssg, string redirectUrl)
    {
        string title = titles;
        string message = mssg;
        string icon = "success";
        string confirmButtonText = "OK";
        string allowOutsideClick = "false"; // Prevent closing on outside click

        string sweetAlertScript =
        $@"<script>
            Swal.fire({{ 
                title: '{title}', 
                text: '{message}', 
                icon: '{icon}', 
                confirmButtonText: '{confirmButtonText}', 
                allowOutsideClick: {allowOutsideClick}
            }}).then((result) => {{
                if (result.isConfirmed) {{
                    window.location.href = '{redirectUrl}';
                }}
            }});
        </script>";
        ClientScript.RegisterStartupScript(this.GetType(), "sweetAlert", sweetAlertScript, false);
    }

    // sweet alert - error only block
    private void getSweetAlertErrorMandatory(string titles, string mssg)
    {
        string title = titles;
        string message = mssg;
        string icon = "error";
        string confirmButtonText = "OK";
        string allowOutsideClick = "false"; // Prevent closing on outside click

        string sweetAlertScript =
        $@"<script>
            Swal.fire({{ 
                title: '{title}', 
                text: '{message}', 
                icon: '{icon}', 
                confirmButtonText: '{confirmButtonText}', 
                allowOutsideClick: {allowOutsideClick}
            }});
        </script>";
        ClientScript.RegisterStartupScript(this.GetType(), "sweetAlert", sweetAlertScript, false);
    }




    //=========================={ Binding Dropdowns }==========================
    private void Bind_Search_BillRefNo_DD()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Bills1722 order by RefNo desc";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddScBillRefNo.DataSource = dt;
            ddScBillRefNo.DataTextField = "RefNo";
            ddScBillRefNo.DataValueField = "RefNo";
            ddScBillRefNo.DataBind();
            ddScBillRefNo.Items.Insert(0, new ListItem("------ Select Bill Ref No ------", "0"));
        }
    }

    private void Bind_Search_AggricultureCollege_DD()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            //string sql = "select * from AgriColleges722 where UnvUnit = @UnvUnit";
            string sql = "select * from AgriColleges722";
            SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@UnvUnit", universityID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddScAggriCollg.DataSource = dt;
            ddScAggriCollg.DataTextField = "CollName";
            ddScAggriCollg.DataValueField = "CollID";
            ddScAggriCollg.DataBind();
            ddScAggriCollg.Items.Insert(0, new ListItem("------Select Aggriculture College------", "0"));
        }
    }

    private void Bind_Search_Component_DD()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from ComponentMaster722";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddScComponent.DataSource = dt;
            ddScComponent.DataTextField = "CmNm";
            ddScComponent.DataValueField = "ComID";
            ddScComponent.DataBind();
            ddScComponent.Items.Insert(0, new ListItem("------Select Component------", "0"));
        }
    }

    private void Bind_Search_AccountHeadName_DD()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            //string sql = "select * from AcHeads722 where AcHSubgroup = @AcHSubgroup";
            string sql = "select * from AcHeads722";
            SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@AcHSubgroup", accountHeadSubGroupID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddScAccHeadName.DataSource = dt;
            ddScAccHeadName.DataTextField = "AcHeadName";
            ddScAccHeadName.DataValueField = "AcID";
            ddScAccHeadName.DataBind();
            ddScAccHeadName.Items.Insert(0, new ListItem("------Select Acc Head Name------", "0"));
        }
    }



    // item insert dropdowns
    private void ItemCategory_Bind_Dropdown()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from ItemActivityCategory722";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ItemCategory.DataSource = dt;
            ItemCategory.DataTextField = "ItCatNm";
            ItemCategory.DataValueField = "ItemCatID";
            ItemCategory.DataBind();
            ItemCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
    }

    private void Item_Bind_Dropdown(string itemCategoryID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from ItemActivityMaster722 where AcCatNm = @AcCatNm";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@AcCatNm", itemCategoryID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            Item.DataSource = dt;
            Item.DataTextField = "AcAtmNm";
            Item.DataValueField = "ItemID";
            Item.DataBind();
            Item.Items.Insert(0, new ListItem("Select Item", "0"));
        }
    }

    private void UOM_Bind_Dropdown()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from UOMs722";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            UOM.DataSource = dt;
            UOM.DataTextField = "umName";
            UOM.DataValueField = "umCode";
            UOM.DataBind();
            UOM.Items.Insert(0, new ListItem("Select UOM", "0"));
        }
    }




    //=========================={ Drop Down Event }==========================
    protected void ItemCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        string itemCategoryID = ItemCategory.SelectedValue;

        if (ItemCategory.SelectedValue != "0")
        {
            Item_Bind_Dropdown(itemCategoryID);
        }
        else
        {
            // clearing the items in the dropdown
            Item.Items.Clear();
            Item.Items.Insert(0, new ListItem("Select Item", "0"));
        }
    }





    //=========================={ Fetch Datatable }==========================
    protected void gridSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //binding GridView to PageIndex object
        gridSearch.PageIndex = e.NewPageIndex;

        DataTable pagination = (DataTable)Session["PaginationDataSource"];

        gridSearch.DataSource = pagination;
        gridSearch.DataBind();
    }

    private DataTable GetBillDT(string billRefNo)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Bills1722 where RefNo = @RefNo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@RefNo", billRefNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    private DataTable GetAggricultureCollegeDT(string aggriCollegeRefID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from AgriColleges722 where CollID = @CollID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@CollID", aggriCollegeRefID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    private DataTable GetComponentDT(string componentRefID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from ComponentMaster722 where ComID = @ComID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ComID", componentRefID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    private DataTable GetAccountHeadNameDT(string accHeadNameRefID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from AcHeads722 where AcID = @AcID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@AcID", accHeadNameRefID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }


    // new tax head
    private DataTable getAccountHead()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            //string sql = "select * from AcHeads722 as ach INNER JOIN AcHeadGroups722 as acg ON ach.AcHGName = acg.AchgID where acg.AchgID = 'DT001'";
            string sql = "select * from AcHeads722 where IsTaxApplied = '1000001'";
            SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@icNumber", imprestCardNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    // exsiting tax head details
    private DataTable getAccountHeadExisting(string bills1RefNo)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from BillTaxHead722 where Bills1RefNo = @Bills1RefNo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Bills1RefNo", bills1RefNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    // get new item reference no
    private string GetItemRefNo(SqlConnection con, SqlTransaction transaction)
    {
        string nextRefNo = "10001";

        string sql = "SELECT ISNULL(MAX(CAST(ItemRefNo AS INT)), 10000) + 1 AS nextRefNo FROM Bills2722";
        SqlCommand cmd = new SqlCommand(sql, con, transaction);

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);

        if (dt.Rows.Count > 0) nextRefNo = dt.Rows[0]["nextRefNo"].ToString();
        return nextRefNo;

        //object result = cmd.ExecuteScalar();
        //if (result != null && result != DBNull.Value) { nextRefID = result.ToString(); }
        //return Convert.ToInt32(nextRefID);
    }

    // check for tax head for bill
    private bool CheckTaxHeadForBillRefNo(string bills1RefNo, SqlConnection con, SqlTransaction transaction)
    {
        string sql = "SELECT * FROM BillTaxHead722 WHERE Bills1RefNo=@Bills1RefNo";

        SqlCommand cmd = new SqlCommand(sql, con, transaction);
        cmd.Parameters.AddWithValue("@Bills1RefNo", bills1RefNo);
        cmd.ExecuteNonQuery();

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);

        if (dt.Rows.Count > 0) return true;
        else return false;
    }

    // get new tax reference no
    private string GetNewTaxRefNo(SqlConnection con, SqlTransaction transaction)
    {
        string nextRefNo = "1000001";

        string sql = "SELECT ISNULL(MAX(CAST(RefNO AS INT)), 1000000) + 1 AS NextRefNo FROM BillTaxHead722";
        SqlCommand cmd = new SqlCommand(sql, con, transaction);

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);

        if (dt.Rows.Count > 0) nextRefNo = dt.Rows[0]["NextRefNo"].ToString();
        return nextRefNo;
    }

    // check for document exists for bill
    private bool checkForDocuUploadedExist(string docRefNo, SqlConnection con, SqlTransaction transaction)
    {
        string sql = "SELECT * FROM BillDocUpload722 WHERE RefNo=@RefNo";

        SqlCommand cmd = new SqlCommand(sql, con, transaction);
        cmd.Parameters.AddWithValue("@RefNo", docRefNo);
        cmd.ExecuteNonQuery();

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);

        if (dt.Rows.Count > 0) return true;
        else return false;
    }

    // get new document reference no
    private string GetNewDocReferenceNo(SqlConnection con, SqlTransaction transaction)
    {
        string nextRefNo = "1000001";

        string sql = "SELECT ISNULL(MAX(CAST(RefNo AS INT)), 1000000) + 1 AS NextRefNo FROM BillDocUpload722";
        SqlCommand cmd = new SqlCommand(sql, con, transaction);

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);

        if (dt.Rows.Count > 0) nextRefNo = dt.Rows[0]["NextRefNo"].ToString();
        return nextRefNo;
    }





    //=========================={ Search Dropdown }==========================
    protected void btnNewBill_Click(object sender, EventArgs e)
    {
        Response.Redirect("BillEntryNew.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGridView();
    }

    private void BindGridView()
    {
        searchGridDiv.Visible = true;

        // dropdown values
        string billsRefNo = ddScBillRefNo.SelectedValue; // bill erf no

        string aggriCollegeRefID = ddScAggriCollg.SelectedValue;
        string componentRefID = ddScComponent.SelectedValue;
        string accHeadNameRefID = ddScAccHeadName.SelectedValue;

        // date - from & to date
        //DateTime fromDate = DateTime.Parse(ScFromDate.Text);
        //DateTime toDate = DateTime.Parse(ScToDate.Text);

        DateTime fromDate;
        DateTime toDate;

        if (!DateTime.TryParse(ScFromDate.Text, out fromDate)) { fromDate = SqlDateTime.MinValue.Value; }
        if (!DateTime.TryParse(ScToDate.Text, out toDate)) { toDate = SqlDateTime.MaxValue.Value; }


        // DTs
        DataTable billDT = GetBillDT(billsRefNo);

        DataTable aggriCollegeDT = GetAggricultureCollegeDT(aggriCollegeRefID);
        DataTable componentDT = GetComponentDT(componentRefID);
        DataTable accHeadNameDT = GetAccountHeadNameDT(accHeadNameRefID);

        // dt values
        string bills1RefNumber = (billDT.Rows.Count > 0) ? billDT.Rows[0]["RefNo"].ToString() : string.Empty;

        string aggriCollegeID = (aggriCollegeDT.Rows.Count > 0) ? aggriCollegeDT.Rows[0]["CollID"].ToString() : string.Empty;
        string componentID = (componentDT.Rows.Count > 0) ? componentDT.Rows[0]["ComID"].ToString() : string.Empty;
        string accHeadID = (accHeadNameDT.Rows.Count > 0) ? accHeadNameDT.Rows[0]["AcID"].ToString() : string.Empty;

        DataTable searchResultDT = SearchRecords(bills1RefNumber, fromDate, toDate, aggriCollegeID, componentID, accHeadID);

        // binding the search grid
        gridSearch.DataSource = searchResultDT;
        gridSearch.DataBind();

        //Required for jQuery DataTables to work.
        gridSearch.UseAccessibleHeader = true;
        gridSearch.HeaderRow.TableSection = TableRowSection.TableHeader;

        Session["PaginationDataSource"] = searchResultDT;
    }

    public DataTable SearchRecords(string billsRefNo, DateTime fromDate, DateTime toDate, string aggriCollegeID, string componentID, string accHeadID)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            //string sql = $@"SELECT bill.*, unit.unitName 
            //                FROM Bills1751 as bill inner join Units751 as unit
            //                on bill.Unit = unit.unitCode 
            //                WHERE 1=1";

            string sql = $@"SELECT bills1.RefNo,  bills1.vouDate, bills1.RcptNo, aggriCollg.CollName, sch.SchName, bills1.TotalChallanAmt 
                            FROM Bills1722 as bills1 
                            INNER JOIN AgriColleges722 as aggriCollg ON bills1.CollName = aggriCollg.CollID
                            INNER JOIN Schemes722 as sch ON bills1.vouScheme = sch.SchID
                            INNER JOIN AcHeads722 as ach ON bills1.vouAcHead = ach.AcID
                            WHERE 1=1";

            if (!string.IsNullOrEmpty(billsRefNo))
            {
                sql += " AND RefNo = @RefNo";

            }

            if (fromDate != null)
            {
                sql += " AND vouDate >= @FromDate";
            }

            if (toDate != null)
            {
                sql += " AND vouDate <= @ToDate";
            }


            if (!string.IsNullOrEmpty(aggriCollegeID))
            {
                sql += " AND CollName = @CollName";
            }

            if (!string.IsNullOrEmpty(componentID))
            {
                sql += " AND Component = @Component";
            }

            if (!string.IsNullOrEmpty(accHeadID))
            {
                sql += " AND vouAcHead = @vouAcHead";
            }

            sql += " ORDER BY bills1.RefNo DESC";




            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (!string.IsNullOrEmpty(billsRefNo))
                {
                    command.Parameters.AddWithValue("@RefNo", billsRefNo);
                }

                if (fromDate != null)
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                }

                if (toDate != null)
                {
                    command.Parameters.AddWithValue("@ToDate", toDate);
                }



                if (!string.IsNullOrEmpty(aggriCollegeID))
                {
                    command.Parameters.AddWithValue("@CollName", aggriCollegeID);
                }

                if (!string.IsNullOrEmpty(componentID))
                {
                    command.Parameters.AddWithValue("@Component", componentID);
                }

                if (!string.IsNullOrEmpty(accHeadID))
                {
                    command.Parameters.AddWithValue("@vouAcHead", accHeadID);
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }




    //=========================={ GridView RowDeleting }==========================

    protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gridView = (GridView)sender;

        // item gridview
        if (gridView.ID == "itemGrid")
        {
            int rowIndex = e.RowIndex;

            DataTable dt = ViewState["ItemDetails_VS"] as DataTable;

            if (dt != null && dt.Rows.Count > rowIndex)
            {
                dt.Rows.RemoveAt(rowIndex);

                ViewState["ItemDetails_VS"] = dt;
                Session["ItemDetails"] = dt;

                itemGrid.DataSource = dt;
                itemGrid.DataBind();

                // re-calculating total amount n assigning back to textbox
                double? totalBillAmount = dt.AsEnumerable().Sum(row => row["Amount"] is DBNull ? (double?)null : Convert.ToDouble(row["Amount"])) ?? 0.0;
                txtBillAmount.Text = totalBillAmount.HasValue ? totalBillAmount.Value.ToString("N2") : "0.00";

                // re-calculating taxes
                //FillTaxHead();
            }
        }

        // document gridview
        //if (gridView.ID == "GridDocument")
        //{
        //    int rowIndex = e.RowIndex;

        //    DataTable dt = ViewState["DocDetails_VS"] as DataTable;

        //    if (dt != null && dt.Rows.Count > rowIndex)
        //    {
        //        dt.Rows.RemoveAt(rowIndex);

        //        ViewState["DocDetails_VS"] = dt;
        //        Session["DocUploadDT"] = dt;

        //        GridDocument.DataSource = dt;
        //        GridDocument.DataBind();
        //    }
        //}
    }






    //=========================={ Update - Fill Details }==========================
    protected void gridSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkView")
        {
            int rowId = Convert.ToInt32(e.CommandArgument);
            Session["Bills1RefNo"] = rowId;

            searchGridDiv.Visible = false;
            divTopSearch.Visible = false;
            UpdateDiv.Visible = true;

            // bills1 header
            FillBills1Details(rowId.ToString());

            // bills2 item details
            FillBils2ItemDetails(rowId.ToString());

            // filling item tax head gridview
            FillTaxHead();

            // binding documents uploaded gridview
            FillDocUploadDetails(rowId.ToString());
        }
    }


    private void FillBills1Details(string bills1RefNo)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            string sql = $@"select bills1.vouDate, bills1.vouNo, bills1.RcptNo, bills1.vouAmt, bills1.TaxApplied, bills1.vouRemark, 
                            bills1.TotalChallanAmt, bills1.TotalDeduct, bills1.TotalAdd, bills1.NetAmount, 
                            unireg.UnvUName, collg.CollName, accRule.AcRule, schCat.Category, 
                            sch.SchName, comp.CmNm, accHGName.AcHGName, accHSubgrp.SubGroup, accHName.AcHeadName
                            
                            from bills1722 as bills1
                            INNER JOIN UnvUnits722 as unireg on bills1.vouUnit = unireg.UnvID
                            INNER JOIN AgriColleges722 as collg on bills1.CollName = collg.CollID
                            INNER JOIN AcRule722 as accRule on bills1.AccRule = accRule.arID
                            INNER JOIN SchCat722 as schCat on bills1.schCat = schCat.IdNO
                            INNER JOIN Schemes722 as sch on bills1.vouScheme = sch.SchID
                            INNER JOIN ComponentMaster722 as comp on bills1.Component = comp.ComID
                            INNER JOIN AcHeadGroups722 as accHGName on bills1.vouAcGroup = accHGName.AchgID
                            INNER JOIN AcHeadSubGroups722 as accHSubgrp on bills1.AcHSubGroup = accHSubgrp.AchsgID
                            INNER JOIN AcHeads722 as accHName on bills1.vouAcHead = accHName.AcID
                            where bills1.RefNo=@RefNo";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@RefNo", bills1RefNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            Session["HeaderDataTable"] = dt;



            // header details - textbox and Date
            
            DateTime challanDate = DateTime.Parse(dt.Rows[0]["vouDate"].ToString());
            ChallanDate.Text = challanDate.ToString("yyyy-MM-dd");

            ChallanNo.Text = dt.Rows[0]["vouNo"].ToString();
            ReceiptNo.Text = dt.Rows[0]["RcptNo"].ToString();
            ChalanAmt.Text = dt.Rows[0]["vouAmt"].ToString();
            CustomerName.Text = dt.Rows[0]["vouRemark"].ToString();

            // dropdowns

            UniRegion.DataSource = dt;
            UniRegion.DataTextField = "UnvUName";
            UniRegion.DataValueField = "UnvUName";
            UniRegion.DataBind();
            UniRegion.Items.Insert(0, new ListItem("------Select University Region------", "0"));

            if (UniRegion.SelectedIndex < 2) UniRegion.SelectedIndex = 1;


            AgriCollg.DataSource = dt;
            AgriCollg.DataTextField = "CollName";
            AgriCollg.DataValueField = "CollName";
            AgriCollg.DataBind();
            AgriCollg.Items.Insert(0, new ListItem("------Select Agriculture College------", "0"));

            if (AgriCollg.SelectedIndex < 2) AgriCollg.SelectedIndex = 1;


            AccRule.DataSource = dt;
            AccRule.DataTextField = "AcRule";
            AccRule.DataValueField = "AcRule";
            AccRule.DataBind();
            AccRule.Items.Insert(0, new ListItem("------Select Accounting Rule------", "0"));

            if (AccRule.SelectedIndex < 2) AccRule.SelectedIndex = 1;


            SchCateg.DataSource = dt;
            SchCateg.DataTextField = "Category";
            SchCateg.DataValueField = "Category";
            SchCateg.DataBind();
            SchCateg.Items.Insert(0, new ListItem("------Select Scheme Category------", "0"));

            if (SchCateg.SelectedIndex < 2) SchCateg.SelectedIndex = 1;


            Scheme.DataSource = dt;
            Scheme.DataTextField = "SchName";
            Scheme.DataValueField = "SchName";
            Scheme.DataBind();
            Scheme.Items.Insert(0, new ListItem("------Select Scheme------", "0"));

            if (Scheme.SelectedIndex < 2) Scheme.SelectedIndex = 1;


            Component.DataSource = dt;
            Component.DataTextField = "CmNm";
            Component.DataValueField = "CmNm";
            Component.DataBind();
            Component.Items.Insert(0, new ListItem("------Select Component------", "0"));

            if (Component.SelectedIndex < 2) Component.SelectedIndex = 1;


            AccHeadGroupName.DataSource = dt;
            AccHeadGroupName.DataTextField = "AcHGName";
            AccHeadGroupName.DataValueField = "AcHGName";
            AccHeadGroupName.DataBind();
            AccHeadGroupName.Items.Insert(0, new ListItem("------Select Acc Head Grp Name------", "0"));

            if (AccHeadGroupName.SelectedIndex < 2) AccHeadGroupName.SelectedIndex = 1;


            AccHeadSubGroup.DataSource = dt;
            AccHeadSubGroup.DataTextField = "SubGroup";
            AccHeadSubGroup.DataValueField = "SubGroup";
            AccHeadSubGroup.DataBind();
            AccHeadSubGroup.Items.Insert(0, new ListItem("------Select Acc Head Sub Group------", "0"));

            if (AccHeadSubGroup.SelectedIndex < 2) AccHeadSubGroup.SelectedIndex = 1;

            AccHeadName.DataSource = dt;
            AccHeadName.DataTextField = "AcHeadName";
            AccHeadName.DataValueField = "AcHeadName";
            AccHeadName.DataBind();
            AccHeadName.Items.Insert(0, new ListItem("------Select Acc Head Name------", "0"));

            if (AccHeadName.SelectedIndex < 2) AccHeadName.SelectedIndex = 1;

        }
    }

    private void FillBils2ItemDetails(string bills1RefNo)
    {
        itemDiv.Visible = true;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Bills2722 where RefNo = @RefNo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@RefNo", bills1RefNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            itemGrid.DataSource = dt;
            itemGrid.DataBind();

            ViewState["ItemDetails_VS"] = dt;
            Session["ItemDetails"] = dt;

            double? totalBillAmount = dt.AsEnumerable().Sum(row => row["Amount"] is DBNull ? (double?)null : Convert.ToDouble(row["Amount"])) ?? 0.0;
            txtBillAmount.Text = totalBillAmount.HasValue ? totalBillAmount.Value.ToString("N2") : "0.00";

            Session["TotalBillAmount"] = totalBillAmount;
        }
    }

    private void FillDocUploadDetails(string bills1RefNo)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from BillDocUpload722 where BillRefNo = @BillRefNo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@BillRefNo", bills1RefNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            docGrid.Visible = true;

            GridDocument.DataSource = dt;
            GridDocument.DataBind();

            ViewState["DocDetails_VS"] = dt;
            Session["DocUploadDT"] = dt;
        }
    }




    //=========================={ Item Save Button Click Event }==========================
    protected void btnItemInsert_Click(object sender, EventArgs e)
    {
        // inserting bill details
        insertBillDetails();

        // filling item tax head gridview
        FillTaxHead();
    }

    private void insertBillDetails()
    {
        string itemCategory = ItemCategory.SelectedValue;
        string item = Item.SelectedValue;
        string uom = UOM.SelectedValue;
        double price = Convert.ToDouble(Price.Text.ToString());
        double qty = Convert.ToDouble(Quantity.Text.ToString());
        double amount = (price * qty);

        if (price >= 0.00 && qty >= 0)
        {
            DataTable dt = ViewState["ItemDetails_VS"] as DataTable ?? createBillDatatable();

            AddRowToBillDetailsDataTable(dt, item, uom, price, qty, amount);

            ViewState["ItemDetails_VS"] = dt;
            Session["ItemDetails"] = dt;

            if (dt.Rows.Count > 0)
            {
                itemDiv.Visible = true;

                itemGrid.DataSource = dt;
                itemGrid.DataBind();

                double? totalBillAmount = dt.AsEnumerable().Sum(row => row["Amount"] is DBNull ? (double?)null : Convert.ToDouble(row["Amount"])) ?? 0.0;
                txtBillAmount.Text = totalBillAmount.HasValue ? totalBillAmount.Value.ToString("N2") : "0.00";

                Session["TotalBillAmount"] = totalBillAmount;

                // clearing input fields
                ItemCategory.SelectedIndex = 0;
                Item.SelectedIndex = 0;
                UOM.SelectedIndex = 0;
                Price.Text = string.Empty;
                Quantity.Text = string.Empty;
            }
        }
        else
        {
            string title = "Negative Values";
            string message = "please add positive values";
            getSweetAlertErrorMandatory(title, message);
        }
    }

    private DataTable createBillDatatable()
    {
        DataTable dt = new DataTable();

        // reference no
        //DataColumn RefNo = new DataColumn("RefNo", typeof(string));
        //dt.Columns.Add(RefNo);

        // item category
        DataColumn ItemCategory = new DataColumn("AlcnNo", typeof(string));
        dt.Columns.Add(ItemCategory);

        // item
        DataColumn Item = new DataColumn("Item", typeof(string));
        dt.Columns.Add(Item);

        // uom
        DataColumn UOM = new DataColumn("UOM", typeof(string));
        dt.Columns.Add(UOM);

        // price
        DataColumn Price = new DataColumn("Price", typeof(double));
        dt.Columns.Add(Price);

        // quantity
        DataColumn Qty = new DataColumn("Qty", typeof(double));
        dt.Columns.Add(Qty);

        // amount
        DataColumn Amount = new DataColumn("Amount", typeof(double));
        dt.Columns.Add(Amount);

        return dt;
    }

    private void AddRowToBillDetailsDataTable(DataTable dt, string item, string uom, double price, double qty, double amount)
    {
        // Create a new row
        DataRow row = dt.NewRow();

        // Set values for the new row
        //row["RefNo"] = refNo;
        row["AlcnNo"] = item;
        row["Item"] = item;
        row["UOM"] = uom;
        row["Price"] = price;
        row["Qty"] = qty;
        row["Amount"] = amount;

        // Add the new row to the DataTable
        dt.Rows.Add(row);
    }




    //=========================={ Tax Head }==========================
    protected void GridTax_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            // Set the row in edit mode
            e.Row.RowState = e.Row.RowState ^ DataControlRowState.Edit;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string bills1Refno = Session["Bills1RefNo"].ToString();

            // fetching acount head or taxes
            DataTable accountHeadExistingDT = getAccountHeadExisting(bills1Refno);
            DataTable accountHeadNewDT = getAccountHead();

            if (accountHeadExistingDT.Rows.Count > 0)
            {
                //=================================={ Add/Less column }========================================
                DropDownList ddlAddLess = (DropDownList)e.Row.FindControl("AddLess");

                if (ddlAddLess != null)
                {
                    string addLessValue = accountHeadExistingDT.Rows[e.Row.RowIndex]["AddLess"].ToString();
                    ddlAddLess.SelectedValue = addLessValue;
                }

                //=================================={ Percentage/Amount column }========================================
                DropDownList ddlPerOrAmnt = (DropDownList)e.Row.FindControl("PerOrAmnt");

                if (ddlPerOrAmnt != null)
                {
                    string perOrAmntValue = accountHeadExistingDT.Rows[e.Row.RowIndex]["PerOrAmnt"].ToString();
                    ddlPerOrAmnt.SelectedValue = perOrAmntValue;
                }
            }
            else
            {
                //=================================={ Add/Less column }========================================
                DropDownList ddlAddLess = (DropDownList)e.Row.FindControl("AddLess");

                if (ddlAddLess != null)
                {
                    string addLessValue = accountHeadNewDT.Rows[e.Row.RowIndex]["AddLess"].ToString();
                    ddlAddLess.SelectedValue = addLessValue;
                }

                //=================================={ Percentage/Amount column }========================================
                DropDownList ddlPerOrAmnt = (DropDownList)e.Row.FindControl("PerOrAmnt");

                if (ddlPerOrAmnt != null)
                {
                    string perOrAmntValue = accountHeadNewDT.Rows[e.Row.RowIndex]["PerOrAmnt"].ToString();
                    ddlPerOrAmnt.SelectedValue = perOrAmntValue;
                }
            }
        }
    }

    protected void ddTaxOrNot_SelectedIndexChanged(object sender, EventArgs e)
    {
        string taxOrNot = ddTaxOrNot.SelectedValue;

        if (ddTaxOrNot.SelectedValue == "Yes")
        {
            divTaxHead.Visible = true;
        }
        else
        {
            divTaxHead.Visible = false;
        }
    }

    private void FillTaxHead()
    {
        string bills1Refno = Session["Bills1RefNo"].ToString();

        // total bill amount
        double totalBillAmount = Convert.ToDouble(Session["TotalBillAmount"]);

        // fetching acount head or taxes
        DataTable accountHeadExistingDT = getAccountHeadExisting(bills1Refno);
        DataTable accountHeadNewDT = getAccountHead();

        // Header Datatable
        DataTable headerDataTable = (DataTable)Session["HeaderDataTable"];

        if (headerDataTable.Rows[0]["TaxApplied"].ToString() == "Yes")
        {
            ddTaxOrNot.SelectedValue = "Yes";
            divTaxHead.Visible = true;

            // checking if the column exists inside the datatable, to remove them and copying data to new one
            if (accountHeadExistingDT.Columns.Contains("AccountHead"))
            {
                DataColumn achg = new DataColumn("AcHGName", typeof(string));
                DataColumn achcode = new DataColumn("AcHCode", typeof(string));

                accountHeadExistingDT.Columns.Add(achg);
                accountHeadExistingDT.Columns.Add(achcode);

                foreach (DataRow row in accountHeadExistingDT.Rows)
                {
                    row["AcHGName"] = row["AccountHead"];
                    row["AcHCode"] = row["DeductHeadCode"];
                }

                accountHeadExistingDT.Columns.Remove("AccountHead");
                accountHeadExistingDT.Columns.Remove("DeductHeadCode");
            }

            Session["AccountHeadDT"] = accountHeadExistingDT;

            // fill tax heads
            autoFilltaxHeads(accountHeadExistingDT, totalBillAmount);
        }
        else
        {
            Session["AccountHeadDT"] = accountHeadNewDT;

            // fill tax heads
            autoFilltaxHeads(accountHeadNewDT, totalBillAmount);
        }
    }

    private void autoFilltaxHeads(DataTable accountHeadDT, double bscAmnt)
    {
        double basicAmount = bscAmnt;
        double totalDeduction = 0.00;
        double totalAddition = 0.00;
        double netAmount = 0.00;

        foreach (DataRow row in accountHeadDT.Rows)
        {
            double percentage = Convert.ToDouble(row["FactorInPer"]);

            double factorInPer = (basicAmount * percentage) / 100;

            if (row["AddLess"].ToString() == "Add")
            {
                totalAddition = totalAddition + factorInPer;
            }
            else
            {
                totalDeduction = totalDeduction + factorInPer;
            }

            row["TaxAmount"] = factorInPer;
        }

        GridTax.DataSource = accountHeadDT;
        GridTax.DataBind();

        // filling total deduction
        txtTotalDeduct.Text = Math.Abs(totalDeduction).ToString("N2");

        // filling total addition
        txtTotalAdd.Text = totalAddition.ToString("N2");

        // Net Amount after tax deductions or addition
        netAmount = (basicAmount + totalAddition) - Math.Abs(totalDeduction);
        txtNetAmnt.Text = netAmount.ToString("N2");
    }

    protected void btnReCalTax_Click(object sender, EventArgs e)
    {
        // Account Head DataTable
        DataTable dt = (DataTable)Session["AccountHeadDT"];

        // Perform calculations or other logic based on the updated values
        double totalBill = Convert.ToDouble(txtBillAmount.Text);
        double totalDeduction = 0.00;
        double totalAddition = 0.00;
        double netAmount = 0.00;

        foreach (GridViewRow row in GridTax.Rows)
        {
            // Accessing the updated dropdown values from the grid
            string updatedAddLessValue = ((DropDownList)row.FindControl("AddLess")).SelectedValue;
            string updatedPerOrAmntValue = ((DropDownList)row.FindControl("PerOrAmnt")).SelectedValue;

            int rowIndex = row.RowIndex;

            // reading parameters from gridview
            TextBox AcHNameStr = row.FindControl("AcHeadName") as TextBox;
            TextBox FactorInPercentage = row.FindControl("FactorInPer") as TextBox;
            DropDownList perOrAmntDropDown = row.FindControl("PerOrAmnt") as DropDownList;
            DropDownList AddLessDropown = row.FindControl("AddLess") as DropDownList;
            TextBox TaxAccountHeadAmount = row.FindControl("TaxAmount") as TextBox;

            string AcHName = (AcHNameStr.Text).ToString();
            double factorInPer = Convert.ToDouble(FactorInPercentage.Text);
            string perOrAmnt = perOrAmntDropDown.SelectedValue;
            string addLess = AddLessDropown.SelectedValue;
            double taxAmount = Convert.ToDouble(TaxAccountHeadAmount.Text);

            if (perOrAmnt == "Amount")
            {
                taxAmount = factorInPer;

                // setting tax head amount
                TaxAccountHeadAmount.Text = Math.Abs(taxAmount).ToString("N2");

                if (addLess == "Add")
                {
                    totalAddition = totalAddition + taxAmount;
                }
                else
                {
                    totalDeduction = totalDeduction + taxAmount;
                }
            }
            else
            {
                // tax amount (based on add or less)
                taxAmount = (totalBill * factorInPer) / 100;

                // setting tax head amount
                TaxAccountHeadAmount.Text = Math.Abs(taxAmount).ToString("N2");

                if (addLess == "Add")
                {
                    totalAddition = totalAddition + taxAmount;
                }
                else
                {
                    totalDeduction = totalDeduction + taxAmount;
                }
            }
        }

        // setting total deduction
        txtTotalDeduct.Text = Math.Abs(totalDeduction).ToString("N2");

        // setting total addition
        txtTotalAdd.Text = totalAddition.ToString("N2");

        // Net Amount after tax deductions or addition
        netAmount = (totalBill + totalAddition) - Math.Abs(totalDeduction);
        txtNetAmnt.Text = netAmount.ToString("N2");
    }



    //----------============={ Upload Documents }=============----------
    protected void btnDocUpload_Click(object sender, EventArgs e)
    {
        // setting the file size in web.config file (web.config should not be read only)
        //settingHttpRuntimeForFileSize();

        if (fileDoc.HasFile)
        {
            string FileExtension = System.IO.Path.GetExtension(fileDoc.FileName);

            if (FileExtension == ".xlsx" || FileExtension == ".xls")
            {

            }

            // file name
            string onlyFileNameWithExtn = fileDoc.FileName.ToString();

            // getting unique file name
            string strFileName = GenerateUniqueId(onlyFileNameWithExtn);

            // saving and getting file path
            string filePath = getServerFilePath(strFileName);

            // Retrieve DataTable from ViewState or create a new one
            DataTable dt = ViewState["DocDetails_VS"] as DataTable ?? CreateDocDetailsDataTable();

            // filling document details datatable
            AddRowToDocDetailsDataTable(dt, onlyFileNameWithExtn, filePath);

            // Save DataTable to ViewState
            ViewState["DocDetails_VS"] = dt;
            Session["DocUploadDT"] = dt;

            if (dt.Rows.Count > 0)
            {
                docGrid.Visible = true;

                // binding document details gridview
                GridDocument.DataSource = dt;
                GridDocument.DataBind();
            }
        }
    }

    private string GenerateUniqueId(string strFileName)
    {
        long timestamp = DateTime.Now.Ticks;
        //string guid = Guid.NewGuid().ToString("N"); //N to remove hypen "-" from GUIDs
        string guid = Guid.NewGuid().ToString();
        string uniqueID = timestamp + "_" + guid + "_" + strFileName;
        return uniqueID;
    }

    private string getServerFilePath(string strFileName)
    {
        string orgFilePath = Server.MapPath("~/Portal/Public/" + strFileName);

        // saving file
        fileDoc.SaveAs(orgFilePath);

        //string filePath = Server.MapPath("~/Portal/Public/" + strFileName);
        //file:///C:/HostingSpaces/PAWAN/cdsmis.in/wwwroot/Pms2/Portal/Public/638399011215544557_926f9320-275e-49ad-8f59-32ecb304a9f1_EMB%20Recording.pdf

        // replacing server-specific path with the desired URL
        //string baseUrl = "http://101.53.144.92/mpkv/Ginie/External?url=.."; // server
        string baseUrl = "http://mpkv.in/Ginie/External?url=.."; // domain
        string relativePath = orgFilePath.Replace(Server.MapPath("~/Portal/Public/"), "Portal/Public/");

        // Full URL for the hyperlink
        string fullUrl = $"{baseUrl}/{relativePath}";

        return fullUrl;
    }

    private DataTable CreateDocDetailsDataTable()
    {
        DataTable dt = new DataTable();

        // file name
        DataColumn DocName = new DataColumn("DocName", typeof(string));
        dt.Columns.Add(DocName);

        // Doc uploaded path
        DataColumn DocPath = new DataColumn("DocPath", typeof(string));
        dt.Columns.Add(DocPath);

        return dt;
    }

    private void AddRowToDocDetailsDataTable(DataTable dt, string onlyFileNameWithExtn, string filePath)
    {
        // Create a new row
        DataRow row = dt.NewRow();

        // Set values for the new row
        row["DocName"] = onlyFileNameWithExtn;
        row["DocPath"] = filePath;

        // Add the new row to the DataTable
        dt.Rows.Add(row);
    }




    //----------============={ Submit Button Event }=============----------
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BillEntry.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (itemGrid.Rows.Count > 0)
        {
            if (GridDocument.Rows.Count > 0)
            {
                string bills1RefNo = Session["Bills1RefNo"].ToString();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        // update header
                        UpdateHeader(bills1RefNo, con, transaction);

                        // update details
                        UpdateDetails(bills1RefNo, con, transaction);

                        // update tax heads
                        string isTaxApplied = ddTaxOrNot.SelectedValue;
                        if (isTaxApplied == "Yes")
                        {
                            UpdateTaxation(bills1RefNo, con, transaction);
                        }

                        // update documents
                        UpdateDocuments(bills1RefNo, con, transaction);

                        if(transaction != null) transaction.Commit();

                        getSweetAlertSuccessRedirectMandatory("Challan Updated!", $"The Challan Reference No: {bills1RefNo} Updated Successfully!", "BillEntry.aspx");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        con.Close();
                        transaction.Dispose();
                    }
                }
            }
            else
            {
                getSweetAlertErrorMandatory("No Documents Found", "please add minimum one document");
            }
        }
        else
        {
            getSweetAlertErrorMandatory("No Service Found", "please minim one services");
        }
    }



    private void UpdateHeader(string bills1RefNo, SqlConnection con, SqlTransaction transaction)
    {
        DataTable BillHeaderDT = (DataTable)Session["HeaderDataTable"];

        //double totalBillAmount = Convert.ToDouble(Session["TotalBillAmount"]);
        double totalBillAmount = Convert.ToDouble(txtBillAmount.Text);


        // total add, deduct and net amount
        string isTaxApplied = ddTaxOrNot.Text.ToString();

        double totalDeduction = Convert.ToDouble(txtTotalDeduct.Text);
        double totalAddition = Convert.ToDouble(txtTotalAdd.Text);
        double netBillAmount = 0.00;

        if (isTaxApplied == "Yes") netBillAmount = Convert.ToDouble(txtNetAmnt.Text);
        else netBillAmount = totalBillAmount; // normal bill amount same as total bill amount


        string sql = $@"UPDATE Bills1722 SET TotalChallanAmt=@TotalChallanAmt, TaxApplied=@TaxApplied, TotalDeduct=@TotalDeduct, 
                        TotalAdd=@TotalAdd, NetAmount=@NetAmount 
                        WHERE RefNo=@RefNo";

        SqlCommand cmd = new SqlCommand(sql, con, transaction);
        cmd.Parameters.AddWithValue("@TotalChallanAmt", totalBillAmount);
        cmd.Parameters.AddWithValue("@TaxApplied", isTaxApplied);
        cmd.Parameters.AddWithValue("@TotalDeduct", totalDeduction);
        cmd.Parameters.AddWithValue("@TotalAdd", totalAddition);
        cmd.Parameters.AddWithValue("@NetAmount", netBillAmount);
        cmd.Parameters.AddWithValue("@RefNo", bills1RefNo);
        cmd.ExecuteNonQuery();

        //SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //ad.Fill(dt);
    }

    private void UpdateDetails(string bills1RefNo, SqlConnection con, SqlTransaction transaction)
    {
        DataTable itemsDT = (DataTable)Session["ItemDetails"];

        foreach (GridViewRow row in itemGrid.Rows)
        {
            int rowIndex = row.RowIndex;

            // Item, UOM, Price, Qty, Amount
            string itemCategory = itemsDT.Rows[rowIndex]["AlcnNo"].ToString();
            string item = itemsDT.Rows[rowIndex]["Item"].ToString();
            string uom = itemsDT.Rows[rowIndex]["UOM"].ToString();
            double price = Convert.ToDouble(itemsDT.Rows[rowIndex]["Price"]);
            double quantity = Convert.ToDouble(itemsDT.Rows[rowIndex]["Qty"]);
            double amount = Convert.ToDouble(itemsDT.Rows[rowIndex]["Amount"]);

            // item ref no to update
            string itemRefNo = itemsDT.Rows[rowIndex]["ItemRefNo"].ToString();

            if(itemRefNo != "") // update
            {
                string sql = $@"UPDATE Bills2722 SET
                                AlcnNo=@AlcnNo, Item=@Item, UOM=@UOM, Price=@Price, Qty=@Qty, Amount=@Amount
                                WHERE ItemRefNo=@ItemRefNo";

                SqlCommand cmd = new SqlCommand(sql, con, transaction);
                cmd.Parameters.AddWithValue("@AlcnNo", itemCategory);
                cmd.Parameters.AddWithValue("@Item", item);
                cmd.Parameters.AddWithValue("@UOM", uom);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Qty", quantity);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@ItemRefNo", itemRefNo);
                cmd.ExecuteNonQuery();
            }
            else // insert
            {
                string userID = Session["UserId"].ToString();

                // getting new reference number for item
                string itemRefNo_New = GetItemRefNo(con, transaction);

                string sql = $@"INSERT INTO Bills2722 
                                (ItemRefNo, RefNo, AlcnNo, Item, UOM, Price, Qty, Amount, SaveBy) 
                                VALUES 
                                (@ItemRefNo, @RefNo, @AlcnNo, @Item, @UOM, @Price, @Qty, @Amount, @SaveBy)";

                SqlCommand cmd = new SqlCommand(sql, con, transaction);
                cmd.Parameters.AddWithValue("@ItemRefNo", itemRefNo_New);
                cmd.Parameters.AddWithValue("@RefNo", bills1RefNo);
                cmd.Parameters.AddWithValue("@AlcnNo", itemCategory);
                cmd.Parameters.AddWithValue("@Item", item);
                cmd.Parameters.AddWithValue("@UOM", uom);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Qty", quantity);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@SaveBy", userID);
                cmd.ExecuteNonQuery();

                //SqlDataAdapter ad = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);
            }
        }
    }

    private void UpdateTaxation(string bills1RefNo, SqlConnection con, SqlTransaction transaction)
    {
        DataTable dt = (DataTable)Session["AccountHeadDT"];

        if (dt != null)
        {
            bool isBillHasTaxHead = CheckTaxHeadForBillRefNo(bills1RefNo, con, transaction);

            foreach (GridViewRow row in GridTax.Rows)
            {
                // to get the current row index
                int rowIndex = row.RowIndex;


                // additional details
                string AccountHeadCode = dt.Rows[rowIndex]["AcHCode"].ToString();


                // Tax Head Grid Details
                TextBox AcHNameStr = row.FindControl("AcHeadName") as TextBox;
                string AccountHeadName = (AcHNameStr.Text).ToString();

                TextBox TaxRateTXT = row.FindControl("FactorInPer") as TextBox;
                double taxRate = Convert.ToDouble(TaxRateTXT.Text);

                DropDownList perOrAmntDropDown = row.FindControl("PerOrAmnt") as DropDownList;
                string perOrAmnt = perOrAmntDropDown.SelectedValue;

                DropDownList AddLessDropown = row.FindControl("AddLess") as DropDownList;
                string addLess = AddLessDropown.SelectedValue;

                TextBox TaxAccountHeadAmount = row.FindControl("TaxAmount") as TextBox;
                double taxAmount = Convert.ToDouble(TaxAccountHeadAmount.Text);



                if (isBillHasTaxHead) // update
                {
                    string bills1RefNo_Existing = dt.Rows[rowIndex]["RefID"].ToString(); // existing

                    string sql = $@"UPDATE BillTaxHead722 SET
                                    FactorInPer=@FactorInPer, PerOrAmnt=@PerOrAmnt, AddLess=@AddLess, TaxAmount=@TaxAmount
                                    WHERE RefNO=@RefNO";

                    SqlCommand cmd = new SqlCommand(sql, con, transaction);
                    cmd.Parameters.AddWithValue("@FactorInPer", taxRate);
                    cmd.Parameters.AddWithValue("@PerOrAmnt", perOrAmnt);
                    cmd.Parameters.AddWithValue("@AddLess", addLess);
                    cmd.Parameters.AddWithValue("@TaxAmount", taxAmount);
                    cmd.Parameters.AddWithValue("@RefNO", bills1RefNo_Existing);
                    cmd.ExecuteNonQuery();
                }
                else // insert
                {
                    string userID = Session["UserId"].ToString();

                    string billRefNo_New = GetNewTaxRefNo(con, transaction);

                    string sql = $@"INSERT INTO BillTaxHead722 
                                    (RefNO, Bills1RefNo, AcHeadName, AcHCode, FactorInPer, PerOrAmnt, AddLess, TaxAmount, SaveBy) 
                                    VALUES 
                                    (@RefNO, @Bills1RefNo, @AcHeadName, @AcHCode, @FactorInPer, @PerOrAmnt, @AddLess, @TaxAmount, @SaveBy)";

                    SqlCommand cmd = new SqlCommand(sql, con, transaction);
                    cmd.Parameters.AddWithValue("@RefNO", billRefNo_New);
                    cmd.Parameters.AddWithValue("@Bills1RefNo", bills1RefNo);
                    cmd.Parameters.AddWithValue("@AcHeadName", AccountHeadName);
                    cmd.Parameters.AddWithValue("@AcHCode", AccountHeadCode);
                    cmd.Parameters.AddWithValue("@FactorInPer", taxRate);
                    cmd.Parameters.AddWithValue("@PerOrAmnt", perOrAmnt);
                    cmd.Parameters.AddWithValue("@AddLess", addLess);
                    cmd.Parameters.AddWithValue("@TaxAmount", taxAmount);
                    cmd.Parameters.AddWithValue("@SaveBy", userID);
                    cmd.ExecuteNonQuery();

                    //SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //ad.Fill(dt);
                }
            }
        }
    }

    private void UpdateDocuments(string bills1RefNo, SqlConnection con, SqlTransaction transaction)
    {
        DataTable documentsDT = (DataTable)Session["DocUploadDT"];

        foreach (GridViewRow row in GridDocument.Rows)
        {
            int rowIndex = row.RowIndex;

            string docName = documentsDT.Rows[rowIndex]["DocName"].ToString();

            HyperLink hypDocPath = (HyperLink)row.FindControl("DocPath");
            string docPath = hypDocPath.NavigateUrl;

            string docRefNo = documentsDT.Rows[rowIndex]["RefNo"].ToString();

            bool isDocExist = checkForDocuUploadedExist(docRefNo, con, transaction);

            if (isDocExist)
            {

            }
            else
            {
                string userID = Session["UserId"].ToString();

                // new document reference no
                string docRefNo_New = GetNewDocReferenceNo(con, transaction);

                string sql = $@"INSERT INTO BillDocUpload722 
                                (RefNo, BillRefNo, DocName, DocPath, SaveBy) 
                                values 
                                (@RefNo, @BillRefNo, @DocName, @DocPath, @SaveBy)";

                SqlCommand cmd = new SqlCommand(sql, con, transaction);
                cmd.Parameters.AddWithValue("@RefNo", docRefNo_New);
                cmd.Parameters.AddWithValue("@BillRefNo", bills1RefNo);
                cmd.Parameters.AddWithValue("@DocName", docName);
                cmd.Parameters.AddWithValue("@DocPath", docPath);
                cmd.Parameters.AddWithValue("@SaveBy", userID);
                cmd.ExecuteNonQuery();

                //SqlDataAdapter ad = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);
            }
        }
    }

}