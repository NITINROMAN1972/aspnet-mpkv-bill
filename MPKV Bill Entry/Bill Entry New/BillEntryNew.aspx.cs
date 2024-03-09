using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Xml.Linq;

public partial class Bill_Entry_New_BillEntryNew : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Project: MPKV
        // Code: 722

        if (!IsPostBack)
        {
            // challan date
            ChallanDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // binding dropdowns
            BinUniversityRegion_Bind_Dropdown();
            AccountingRule_Bind_Dropdown();
            SchemeCategory_Bind_Dropdown();
            Components_Bind_Dropdown();
            AccountHeadGroupName_Bind_Dropdown();
            ModeOfPayment_Bind_Dropdown();
            ItemCategory_Bind_Dropdown();
            UOM_Bind_Dropdown();

        }
    }


    //=========================={ Alert }==========================
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
    private void BinUniversityRegion_Bind_Dropdown()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from UnvUnits722";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            UniRegion.DataSource = dt;
            UniRegion.DataTextField = "UnvUName";
            UniRegion.DataValueField = "UnvID";
            UniRegion.DataBind();
            UniRegion.Items.Insert(0, new ListItem("------Select University Region------", "0"));
        }
    }

    private void AggriucltureCollege_Bind_Dropdown(string universityID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from AgriColleges722 where UnvUnit = @UnvUnit";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@UnvUnit", universityID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ad.Fill(dt);
            con.Close();

            AgriCollg.DataSource = dt;
            AgriCollg.DataTextField = "CollName";
            AgriCollg.DataValueField = "CollID";
            AgriCollg.DataBind();
            AgriCollg.Items.Insert(0, new ListItem("------Select Aggriculture College------", "0"));
        }
    }

    private void AccountingRule_Bind_Dropdown()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from AcRule722";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            AccRule.DataSource = dt;
            AccRule.DataTextField = "AcRule";
            AccRule.DataValueField = "arID";
            AccRule.DataBind();
            AccRule.Items.Insert(0, new ListItem("------Select Accounting Rule------", "0"));
        }
    }

    private void SchemeCategory_Bind_Dropdown()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from SchCat722";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            SchCateg.DataSource = dt;
            SchCateg.DataTextField = "Category";
            SchCateg.DataValueField = "IdNO";
            SchCateg.DataBind();
            SchCateg.Items.Insert(0, new ListItem("------Select Scheme Category------", "0"));
        }
    }

    private void Scheme_Bind_Dropdown(string schemeCategoryID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Schemes722 where SchCat = @SchCat";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SchCat", schemeCategoryID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ad.Fill(dt);
            con.Close();

            Scheme.DataSource = dt;
            Scheme.DataTextField = "SchName";
            Scheme.DataValueField = "SchID";
            Scheme.DataBind();
            Scheme.Items.Insert(0, new ListItem("------Select Scheme------", "0"));
        }
    }

    private void Components_Bind_Dropdown()
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

            Component.DataSource = dt;
            Component.DataTextField = "CmNm";
            Component.DataValueField = "ComID";
            Component.DataBind();
            Component.Items.Insert(0, new ListItem("------Select Component------", "0"));
        }
    }

    private void AccountHeadGroupName_Bind_Dropdown()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from AcHeadGroups722";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            AccHeadGroupName.DataSource = dt;
            AccHeadGroupName.DataTextField = "AcHGName";
            AccHeadGroupName.DataValueField = "AchgID";
            AccHeadGroupName.DataBind();
            AccHeadGroupName.Items.Insert(0, new ListItem("------Select Acc Head Group Name------", "0"));
        }
    }

    private void AccountHeadSubGroup_Bind_Dropdown(string accountHeadGroupID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from AcHeadSubGroups722 where AcHGroup = @AcHGroup";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@AcHGroup", accountHeadGroupID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            AccHeadSubGroup.DataSource = dt;
            AccHeadSubGroup.DataTextField = "SubGroup";
            AccHeadSubGroup.DataValueField = "AchsgID";
            AccHeadSubGroup.DataBind();
            AccHeadSubGroup.Items.Insert(0, new ListItem("------Select Acc Head Sub Group------", "0"));
        }
    }

    private void AccountHeadName_Bind_Dropdown(string accountHeadSubGroupID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from AcHeads722 where AcHSubgroup = @AcHSubgroup";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@AcHSubgroup", accountHeadSubGroupID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            AccHeadName.DataSource = dt;
            AccHeadName.DataTextField = "AcHeadName";
            AccHeadName.DataValueField = "AcID";
            AccHeadName.DataBind();
            AccHeadName.Items.Insert(0, new ListItem("------Select Acc Head Name------", "0"));
        }
    }

    private void ModeOfPayment_Bind_Dropdown()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            ModeOfPayment.Items.Insert(0, new ListItem("------Select Mode Of Payment------", "0"));
        }
    }

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
            ItemCategory.Items.Insert(0, new ListItem("------Select Category------", "0"));
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
            Item.Items.Insert(0, new ListItem("------Select Item------", "0"));
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
            UOM.Items.Insert(0, new ListItem("------Select UOM------", "0"));
        }
    }



    //=========================={ Drop Down Event }==========================
    protected void UniRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        string universityID = UniRegion.SelectedValue;

        if (UniRegion.SelectedValue != "0")
        {
            AggriucltureCollege_Bind_Dropdown(universityID);
        }
        else
        {
            // clearing the items in the AgriCollg dropdown
            AgriCollg.Items.Clear();
            AgriCollg.Items.Insert(0, new ListItem("------Select Aggriculture College------", "0"));
        }
    }

    protected void SchCateg_SelectedIndexChanged(object sender, EventArgs e)
    {
        string schemeCategoryID = SchCateg.SelectedValue;

        if (SchCateg.SelectedValue != "0")
        {
            Scheme_Bind_Dropdown(schemeCategoryID);
        }
        else
        {
            // clearing the items in the dropdown
            Scheme.Items.Clear();
            Scheme.Items.Insert(0, new ListItem("------Select Scheme------", "0"));
        }
    }

    protected void AccHeadGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string accountHeadGroupID = AccHeadGroupName.SelectedValue;

        if (AccHeadGroupName.SelectedValue != "0")
        {
            AccountHeadSubGroup_Bind_Dropdown(accountHeadGroupID);
        }
        else
        {
            // clearing the items in the dropdown
            AccHeadSubGroup.Items.Clear();
            AccHeadSubGroup.Items.Insert(0, new ListItem("------Select Acc Head Sub Group------", "0"));
        }
    }

    protected void AccHeadSubGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        string accountHeadSubGroupID = AccHeadSubGroup.SelectedValue;

        if (AccHeadSubGroup.SelectedValue != "0")
        {
            AccountHeadName_Bind_Dropdown(accountHeadSubGroupID);
        }
        else
        {
            // clearing the items in the dropdown
            AccHeadName.Items.Clear();
            AccHeadName.Items.Insert(0, new ListItem("------Select Acc Head Name------", "0"));
        }
    }

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
            Item.Items.Insert(0, new ListItem("------Select Item------", "0"));
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




    //=========================={ Fetch Data }==========================
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

    private int GetBills1_ReferenceNumber()
    {
        string nextRefID = "10001";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "SELECT ISNULL(MAX(CAST(RefNo AS INT)), 10000) + 1 AS NextRefID FROM Bills1722";
            SqlCommand cmd = new SqlCommand(sql, con);

            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value) { nextRefID = result.ToString(); }
            return Convert.ToInt32(nextRefID);
        }
    }

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
                FillTaxHead();
            }
        }

        // document gridview
        if (gridView.ID == "GridDocument")
        {
            int rowIndex = e.RowIndex;

            DataTable dt = ViewState["DocDetails_VS"] as DataTable;

            if (dt != null && dt.Rows.Count > rowIndex)
            {
                dt.Rows.RemoveAt(rowIndex);

                ViewState["DocDetails_VS"] = dt;
                Session["DocUploadDT"] = dt;

                GridDocument.DataSource = dt;
                GridDocument.DataBind();
            }
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
            // fetching acount head or taxes
            DataTable accountHeadDT = getAccountHead();

            //=================================={ Add/Less column }========================================
            DropDownList ddlAddLess = (DropDownList)e.Row.FindControl("AddLess");

            if (ddlAddLess != null)
            {
                string addLessValue = accountHeadDT.Rows[e.Row.RowIndex]["AddLess"].ToString();
                ddlAddLess.SelectedValue = addLessValue;
            }

            //=================================={ Percentage/Amount column }========================================
            DropDownList ddlPerOrAmnt = (DropDownList)e.Row.FindControl("PerOrAmnt");

            if (ddlPerOrAmnt != null)
            {
                string perOrAmntValue = accountHeadDT.Rows[e.Row.RowIndex]["PerOrAmnt"].ToString();
                ddlPerOrAmnt.SelectedValue = perOrAmntValue;
            }
        }
    }

    private void FillTaxHead()
    {
        // fetching acount head or taxes
        DataTable accountHeadDT = getAccountHead();
        Session["AccountHeadDT"] = accountHeadDT;

        // total bill amount
        double totalBillAmount = Convert.ToDouble(txtBillAmount.Text);

        // fill tax heads
        autoFilltaxHeads(accountHeadDT, totalBillAmount);
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
            TextBox AcHeadNameTxt = row.FindControl("AcHeadName") as TextBox;
            TextBox FactorInPerTxt = row.FindControl("FactorInPer") as TextBox;
            DropDownList perOrAmntDropDown = row.FindControl("PerOrAmnt") as DropDownList;
            DropDownList AddLessDropown = row.FindControl("AddLess") as DropDownList;
            TextBox TaxAccountHeadAmount = row.FindControl("TaxAmount") as TextBox;

            string accountHeadName = (AcHeadNameTxt.Text).ToString();
            double taxRate = Convert.ToDouble(FactorInPerTxt.Text);
            string perOrAmnt = perOrAmntDropDown.SelectedValue;
            string addLess = AddLessDropown.SelectedValue;
            double taxAmount = Convert.ToDouble(TaxAccountHeadAmount.Text);

            if (perOrAmnt == "Amount")
            {
                taxAmount = taxRate;

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
                taxAmount = (totalBill * taxRate) / 100;

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
        Response.Redirect("BillEntryNew.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (itemGrid.Rows.Count > 0)
        {
            if (GridDocument.Rows.Count > 0)
            {
                string bills1RefNo = GetBills1_ReferenceNumber().ToString();

                Session["Bills1RefNo"] = bills1RefNo;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        // inserting header
                        InsertHeader(bills1RefNo, con, transaction);

                        // inserting details
                        insertBillDetails(bills1RefNo, con, transaction);

                        // inserting tax head


                        // inserting documents


                        transaction.Commit();
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



    private void InsertHeader(string bills1RefNo, SqlConnection con, SqlTransaction transaction)
    {
        DateTime challanDate = DateTime.Parse(ChallanDate.Text);
        string challanNo = ChallanNo.Text.ToString();
        string receiptNo = ReceiptNo.Text.ToString();

        string universityRegion = UniRegion.SelectedValue;
        string aggricultureCollege = AgriCollg.SelectedValue;
        string accountingRule = AccRule.SelectedValue;

        string schemeCategory = SchCateg.SelectedValue;
        string scheme = Scheme.SelectedValue;
        string component = Component.SelectedValue;

        string accountHeadGroupName = AccHeadGroupName.SelectedValue;
        string accountHeadSubGroup = AccHeadSubGroup.SelectedValue;
        string accountHeadName = AccHeadName.SelectedValue;

        double amount = Convert.ToDouble(ChalanAmt.Text);
        string transactionRefNo = TransacRefNo.Text.ToString();
        string modeOfPayment = ModeOfPayment.SelectedValue;


        double totalBillAmount = Convert.ToDouble(txtBillAmount.Text);

        string isTaxApplied = ddTaxOrNot.SelectedValue; // tax applied Yes or No

        double totalDeduction = Convert.ToDouble(txtTotalDeduct.Text);
        double totalAddition = Convert.ToDouble(txtTotalAdd.Text);
        double netBillAmount = 0.00;

        if (isTaxApplied == "Yes")
        {
            netBillAmount = Convert.ToDouble(txtNetAmnt.Text);
        }
        else
        {
            netBillAmount = totalBillAmount; // net amount == total bill amount
        }


        string sql = $@"INSERT INTO Bills1722 
                        (RefNo, vouDate, vouNo, RcptNo, vouUnit, CollName, AccRule, schCat, vouScheme, Component, 
                        vouAcGroup, AcHSubGroup, vouAcHead, vouAmt, vouTxnRef, vouMOP, TotalChallanAmt, TaxApplied, TotalDeduct, TotalAdd, NetAmount) 
                        VALUES 
                        (@RefNo, @vouDate, @vouNo, @RcptNo, @vouUnit, @CollName, @AccRule, @schCat, @vouScheme, @Component, @vouAcGroup, @AcHSubGroup,
                        @vouAcHead, @vouAmt, @vouTxnRef, @vouMOP, @TotalChallanAmt, @TaxApplied, @TotalDeduct, @TotalAdd, @NetAmount)";

        SqlCommand cmd = new SqlCommand(sql, con, transaction);
        cmd.Parameters.AddWithValue("@RefNo", bills1RefNo);
        cmd.Parameters.AddWithValue("@vouDate", challanDate);
        cmd.Parameters.AddWithValue("@vouNo", challanNo);
        cmd.Parameters.AddWithValue("@RcptNo", receiptNo);
        cmd.Parameters.AddWithValue("@vouUnit", universityRegion);
        cmd.Parameters.AddWithValue("@CollName", aggricultureCollege);
        cmd.Parameters.AddWithValue("@AccRule", accountingRule);
        cmd.Parameters.AddWithValue("@schCat", schemeCategory);
        cmd.Parameters.AddWithValue("@vouScheme", scheme);
        cmd.Parameters.AddWithValue("@Component", component);
        cmd.Parameters.AddWithValue("@vouAcGroup", accountHeadGroupName);
        cmd.Parameters.AddWithValue("@AcHSubGroup", accountHeadSubGroup);
        cmd.Parameters.AddWithValue("@vouAcHead", accountHeadName);
        cmd.Parameters.AddWithValue("@vouAmt", amount);
        cmd.Parameters.AddWithValue("@vouTxnRef", transactionRefNo);
        cmd.Parameters.AddWithValue("@vouMOP", modeOfPayment);
        cmd.Parameters.AddWithValue("@TotalChallanAmt", totalBillAmount);
        cmd.Parameters.AddWithValue("@TaxApplied", isTaxApplied);
        cmd.Parameters.AddWithValue("@TotalDeduct", totalDeduction);
        cmd.Parameters.AddWithValue("@TotalAdd", totalAddition);
        cmd.Parameters.AddWithValue("@NetAmount", netBillAmount);
        //cmd.ExecuteNonQuery();

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);
    }

    private void insertBillDetails(string bills1RefNo, SqlConnection con, SqlTransaction transaction)
    {
        DataTable itemsDT = (DataTable)Session["ItemDetails"];

        foreach (DataRow row in itemsDT.Rows)
        {
            string newBills2RefNo = GetItemRefNo(con, transaction);

            // item items
            string itemCategory = row["AlcnNo"].ToString() ?? string.Empty;
            string item = row["Item"].ToString();
            string uom = row["UOM"].ToString();
            double quantity = Convert.ToDouble(row["Qty"].ToString());
            double price = Convert.ToDouble(row["Price"].ToString());
            double amount = Convert.ToDouble(row["Amount"].ToString());

            string sql = $@"INSERT INTO Bills2722 (ItemRefNo, RefNo, AlcnNo, Item, UOM, Price, Qty, Amount) 
                            VALUES 
                            (@ItemRefNo, @RefNo, @AlcnNo, @Item, @UOM, @Price, @Qty, @Amount)";

            SqlCommand cmd = new SqlCommand(sql, con, transaction);
            cmd.Parameters.AddWithValue("@ItemRefNo", newBills2RefNo);
            cmd.Parameters.AddWithValue("@RefNo", bills1RefNo);
            cmd.Parameters.AddWithValue("@AlcnNo", itemCategory);
            cmd.Parameters.AddWithValue("@Item", item);
            cmd.Parameters.AddWithValue("@UOM", uom);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Qty", quantity);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.ExecuteNonQuery();

            //SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //ad.Fill(dt);
        }
    }

}
