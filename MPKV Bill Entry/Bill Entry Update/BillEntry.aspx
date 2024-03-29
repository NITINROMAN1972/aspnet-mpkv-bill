﻿<%@ Page Language="C#" UnobtrusiveValidationMode="None" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="BillEntry.aspx.cs" Inherits="Bill_Entry_Update_BillEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Update</title>

    <!-- Boottrap CSS -->
    <link href="../assests/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assests/css/bootstrap1.min.css" rel="stylesheet" />

    <!-- Bootstrap JS -->
    <script src="../assests/js/bootstrap.bundle.min.js"></script>
    <script src="../assests/js/bootstrap1.min.js"></script>

    <!-- Popper.js -->
    <script src="../assests/js/popper.min.js"></script>
    <script src="../assests/js/popper1.min.js"></script>

    <!-- jQuery -->
    <script src="../assests/js/jquery-3.6.0.min.js"></script>
    <script src="../assests/js/jquery.min.js"></script>
    <script src="../assests/js/jquery-3.3.1.slim.min.js"></script>

    <!-- Select2 library CSS and JS -->
    <link href="../assests/select2/select2.min.css" rel="stylesheet" />
    <script src="../assests/select2/select2.min.js"></script>

    <!-- Sweet Alert CSS and JS -->
    <link href="../assests/sweertalert/sweetalert2.min.css" rel="stylesheet" />
    <script src="../assests/sweertalert/sweetalert2.all.min.js"></script>

    <!-- Sumo Select CSS and JS -->
    <link href="../assests/sumoselect/sumoselect.min.css" rel="stylesheet" />
    <script src="../assests/sumoselect/jquery.sumoselect.min.js"></script>

    <!-- DataTables CSS & JS -->
    <link href="../assests/DataTables/datatables.min.css" rel="stylesheet" />
    <script src="../assests/DataTables/datatables.min.js"></script>

    <script src="billentry-update.js"></script>
    <link rel="stylesheet" href="billentry-update.css" />


</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <!-- Top Control Div STarts -->
        <div id="divTopSearch" runat="server" visible="true">
            <div class="col-md-12 mx-auto">

                <!-- Bill Control -->
                <div class="">

                    <!-- Heading -->
                    <div class="justify-content-end d-flex mb-0 mt-4 px-0">
                        <div class="col-md-6 px-0">
                            <div class="fw-semibold fs-3 text-dark-emphasis">
                                <asp:Literal ID="Literal14" Text="Challan Details" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="col-md-6 text-end px-0">
                            <div class="fw-semibold fs-5">
                                <asp:Button ID="btnNewBill" runat="server" Text="New Challan +" OnClick="btnNewBill_Click" CssClass="btn btn-custom text-white shadow" />
                            </div>
                        </div>
                    </div>

                    <div class="card mt-2 shadow-sm">
                        <div class="card-body">

                            <!-- Search Dropdowns -->
                            <div id="divSearchEmb" runat="server" visible="true">
                                <div class="card-body">

                                    <!-- 1st Row -->
                                    <div class="row mb-2">

                                        <!-- Search Bill Ref No DD -->
                                        <div class="col-md-4 align-self-end">
                                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                                <asp:Literal ID="Literal15" Text="" runat="server">Challan Reference Number</asp:Literal>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddScBillRefNo" runat="server" AutoPostBack="true" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                        <!-- Search From Date -->
                                        <div class="col-md-4 align-self-end">
                                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                                <asp:Literal ID="Literal22" Text="" runat="server">From Date</asp:Literal>
                                            </div>
                                            <asp:TextBox runat="server" ID="ScFromDate" type="date" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                                        </div>

                                        <!-- Search To Date -->
                                        <div class="col-md-4 align-self-end">
                                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                                <asp:Literal ID="Literal23" Text="" runat="server">To Date</asp:Literal>
                                            </div>
                                            <asp:TextBox runat="server" ID="ScToDate" type="date" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                                        </div>

                                    </div>

                                    <!-- 2nd Row -->
                                    <div class="row mb-2">

                                        <!-- Search Agriculture College DD -->
                                        <div class="col-md-4 align-self-end">
                                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                                <asp:Literal ID="Literal21" Text="" runat="server">Aggriculture College (Center)</asp:Literal>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddScAggriCollg" runat="server" AutoPostBack="true" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                        <!-- Search DD Component -->
                                        <div class="col-md-4 align-self-end">
                                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                                <asp:Literal ID="Literal13" Text="" runat="server">Component</asp:Literal>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddScComponent" runat="server" AutoPostBack="true" class="form-control is-invalid"></asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                        <!-- Searc DD Account Head Name -->
                                        <div class="col-md-4 align-self-end">
                                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                                <asp:Literal ID="Literal16" Text="" runat="server">Account Head Name</asp:Literal>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddScAccHeadName" runat="server" AutoPostBack="true" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </div>

                                    <!-- 3rd Row -->
                                    <div class="row mb-2 mt-4">
                                        <div class="col-md-10"></div>

                                        <!-- Search Button -->
                                        <div class="col-md-2">
                                            <div class="text-end">
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-custom col-md-10 text-white shadow" />
                                            </div>
                                        </div>
                                    </div>


                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <!-- Search Grid Div Starts -->
                <div id="searchGridDiv" visible="false" runat="server" class="mt-5">
                    <asp:GridView ShowHeaderWhenEmpty="true" ID="gridSearch" runat="server" AutoGenerateColumns="false" OnRowCommand="gridSearch_RowCommand" AllowPaging="true" PageSize="10"
                        CssClass="table table-bordered border border-1 border-dark-subtle table-hover text-center grid-custom" OnPageIndexChanging="gridSearch_PageIndexChanging" PagerStyle-CssClass="gridview-pager">
                        <HeaderStyle CssClass="" />
                        <Columns>
                            <asp:TemplateField ControlStyle-CssClass="col-md-1" HeaderText="Sr.No">
                                <ItemTemplate>
                                    <asp:HiddenField ID="id" runat="server" Value="id" />
                                    <span>
                                        <%#Container.DataItemIndex + 1%>
                                    </span>
                                </ItemTemplate>
                                <ItemStyle CssClass="col-md-1" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="RefNo" HeaderText="Challan Ref No" ItemStyle-CssClass="col-xs-3 align-middle text-start fw-light" />
                            <asp:BoundField DataField="vouDate" HeaderText="Challan Date" ItemStyle-CssClass="col-xs-2 align-middle text-start fw-light" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="RcptNo" HeaderText="Receipt No" ItemStyle-CssClass="col-xs-3 align-middle text-start fw-light" />
                            <asp:BoundField DataField="CollName" HeaderText="Aggriculture College" ItemStyle-CssClass="col-xs-3 align-middle text-start fw-light" />
                            <asp:BoundField DataField="SchName" HeaderText="Scheme" ItemStyle-CssClass="col-xs-3 align-middle text-start fw-light" />
                            <asp:BoundField DataField="TotalChallanAmt" HeaderText="Challan Amount" ItemStyle-CssClass="col-xs-3 align-middle text-start fw-light" />

                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnedit" CommandArgument='<%# Eval("RefNo") %>' CommandName="lnkView" ToolTip="Edit" CssClass="shadow-sm">
                                        <asp:Image runat="server" ImageUrl="~/portal/assests/img/pencil-square.svg" AlternateText="Edit" style="width: 16px; height: 16px;"/>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
                <!-- Search Grid Div Ends -->

            </div>
        </div>
        <!-- Top Control Div Ends -->



        <!-- Update Div Starts -->
        <div id="UpdateDiv" runat="server" visible="false">


            <!-- Heading -->
            <div class="col-md-12 mx-auto fw-normal fs-3 fw-medium ps-0 pb-2 text-dark-emphasis mb-3">
                <asp:Literal Text="Challan Details" runat="server"></asp:Literal>
            </div>


            <!-- Bill Header UI Starts-->
            <div class="card col-md-12 mx-auto mt-2 py-2 shadow-sm rounded-3">
                <div class="card-body">


                    <!-- 1st row Starts -->
                    <div class="row mb-2">

                        <!-- Challan Date -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal12" Text="" runat="server">Challan Date</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="rr1" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(select challan date)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:TextBox runat="server" ID="ChallanDate" type="date" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                        </div>

                        <!-- Challan No -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal6" Text="" runat="server">Challan Number</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="rr2" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(select challan no)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:TextBox runat="server" ID="ChallanNo" type="text" ReadOnly="true" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                        </div>

                        <!-- Receipt No -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal7" Text="" runat="server">Receipt Number</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="rrr1" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(select receipt no)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:TextBox runat="server" ID="ReceiptNo" type="text" ReadOnly="true" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                        </div>

                    </div>
                    <!-- 1st row Ends -->


                    <!-- 2nd row Starts -->
                    <div class="row mb-2">

                        <!-- University Region -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal1" Text="" runat="server">University Region</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="rr3" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select university region)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:DropDownList ID="UniRegion" AutoPostBack="false" runat="server" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                        </div>

                        <!-- Agriculture College (Centre) -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal2" Text="" runat="server">Agriculture College (Centre)</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="r4" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select aggriculture center)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="AgriCollg" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass="" ClientIDMode="Static"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <!-- Agriculture College (Centre) -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal8" Text="" runat="server">Accounting Rule</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select accouting rule)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:DropDownList ID="AccRule" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass="" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                    </div>
                    <!-- 2nd row Ends -->


                    <!-- 3rd row Starts -->
                    <div class="row mb-2">

                        <!-- Scheme Category -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal3" Text="" runat="server">Scheme Category</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select scheme category)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:DropDownList ID="SchCateg" AutoPostBack="false" runat="server" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                        </div>

                        <!-- Scheme -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal4" Text="" runat="server">Scheme</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select scheme)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="Scheme" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass="" ClientIDMode="Static"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <!-- Component -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal5" Text="" runat="server">Component</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select component)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:DropDownList ID="Component" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass="" ClientIDMode="Static"></asp:DropDownList>
                        </div>

                    </div>
                    <!-- 3rd row Ends -->


                    <!-- 4th row Starts -->
                    <div class="row mb-2">

                        <!-- Acc Head Group Name -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal9" Text="" runat="server">Account Head Group Name</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select acc group name)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:DropDownList ID="AccHeadGroupName" AutoPostBack="false" runat="server" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                        </div>

                        <!-- Acc Head Sub Group -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal10" Text="" runat="server">Account Head Sub Group</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select acc sub group)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="AccHeadSubGroup" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass="" ClientIDMode="Static"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <!-- Acc Head Name -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal11" Text="" runat="server">Account Head Name</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select acc head name)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="AccHeadName" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass="" ClientIDMode="Static"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                    <!-- 4th row Ends -->


                    <!-- 5th row Starts -->
                    <div class="row mb-2">

                        <!-- Challan Amount -->
                        <div class="col-md-4 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal17" Text="" runat="server">Amount</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(enter amount)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:TextBox runat="server" ID="ChalanAmt" type="number" steps="0.01" ReadOnly="true" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                        </div>

                        <!-- Customer Name -->
                        <div class="col-md-8 align-self-end">
                            <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                <asp:Literal ID="Literal18" Text="" runat="server">Customer Name</asp:Literal>
                                <div>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="CustomerName" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(enter transaction ref no)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <asp:TextBox runat="server" ID="CustomerName" type="text" ReadOnly="true" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                        </div>

                    </div>
                    <!-- 5th row Ends -->

                </div>
            </div>
            <!-- Bill Header UI Ends-->




            <!-- Item UI Starts -->
            <div class="card col-md-12 mx-auto mt-5 rounded-3">
                <div class="card-body">


                    <!-- Heading -->
                    <div class="fw-normal fs-5 fw-medium text-body-secondary border-bottom mb-3">
                        <asp:Literal Text="Item Details" runat="server"></asp:Literal>
                    </div>


                    <!-- Insert Insert Panel Starts -->
                    <div class="px-0">

                        <!-- 1st Row Starts -->
                        <div class="row mb-2">

                            <!-- Item Category -->
                            <div class="col-md-2 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal19" Text="" runat="server">Item Category<em style="color: red">*</em></asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="rr6" ControlToValidate="ItemCategory" ValidationGroup="ItemSave" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select item category)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:DropDownList ID="ItemCategory" OnSelectedIndexChanged="ItemCategory_SelectedIndexChanged" runat="server" AutoPostBack="true" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                            </div>

                            <!-- Item -->
                            <div class="col-md-2 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal20" Text="" runat="server">Item<em style="color: red">*</em></asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="Item" ValidationGroup="ItemSave" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select item)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:DropDownList ID="Item" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                            </div>

                            <!-- UOM -->
                            <div class="col-md-2 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal24" Text="" runat="server">UOM<em style="color: red">*</em></asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="UOM" ValidationGroup="ItemSave" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(select uom)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:DropDownList ID="UOM" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                            </div>

                            <!-- Quantity -->
                            <div class="col-md-2 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal25" Text="" runat="server">Quantity</asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="Quantity" ValidationGroup="ItemSave" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(select quantity)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:TextBox ID="Quantity" runat="server" type="number" steps="0.01" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                            </div>

                            <!-- Price -->
                            <div class="col-md-2 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal26" Text="" runat="server">Price</asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="rr9" ControlToValidate="Price" ValidationGroup="ItemSave" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(select price)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:TextBox ID="Price" runat="server" type="number" steps="0.01" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                            </div>

                            <!-- Add Button -->
                            <div class="col-md-2 align-self-end text-end">
                                <div class="pb-0 mb-0">
                                    <asp:Button ID="btnItemInsert" runat="server" Text="Add +" OnClick="btnItemInsert_Click" ValidationGroup="ItemSave" CssClass="btn btn-success text-white shadow mb-5 col-md-7 button-position" />
                                </div>
                            </div>

                        </div>
                        <!-- 1st Row Ends -->

                        <!-- 2nd Row Starts -->
                        <div class="">
                        </div>
                        <!-- 2nd Row Ends -->

                    </div>
                    <!-- Insert Insert Panel Ends -->


                    <!-- Item GridView Starts -->
                    <div id="itemDiv" runat="server" visible="false" class="mt-3">

                        <asp:GridView ShowHeaderWhenEmpty="true" ID="itemGrid" runat="server" AutoGenerateColumns="false" OnRowDeleting="Grid_RowDeleting"
                            CssClass="table table-bordered  border border-1 border-dark-subtle text-center grid-custom mb-3">
                            <HeaderStyle CssClass="align-middle" />
                            <Columns>
                                <asp:TemplateField ControlStyle-CssClass="col-md-1" HeaderText="Sr.No">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="id" runat="server" Value="id" />
                                        <span>
                                            <%#Container.DataItemIndex + 1%>
                                        </span>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="col-md-1" />
                                    <ItemStyle Font-Size="15px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="AlcnNo" HeaderText="Item Category" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />
                                <asp:BoundField DataField="Item" HeaderText="Item" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />
                                <asp:BoundField DataField="UOM" HeaderText="UOM" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />
                                <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />
                                <asp:BoundField DataField="Qty" HeaderText="Qty" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />

                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>'>
                                            <asp:Image runat="server" ImageUrl="~/portal/assests/img/modern-cross-fill.svg" AlternateText="Edit" style="width: 28px; height: 28px;"/>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>

                        <!-- Total Bill & Tax Visibility Dropdown -->
                        <div class="row px-0 mb-3">

                            <!-- DD Apply Tax Or Not -->
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddTaxOrNot" runat="server" OnSelectedIndexChanged="ddTaxOrNot_SelectedIndexChanged" AutoPostBack="true" CssClass="col-md-12 text-center fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2">
                                    <asp:ListItem Text="No Tax Head" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Apply Tax Head" Value="Yes"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3"></div>
                            <div class="col-md-3"></div>

                            <!-- Total Bill -->
                            <div class="col-md-3 align-self-end text-end">
                                <asp:Literal ID="Literal27" Text="" runat="server">Total Bill Amount</asp:Literal>
                                <div class="input-group">
                                    <span class="input-group-text fs-5 fw-semibold">₹</span>
                                    <asp:TextBox runat="server" ID="txtBillAmount" CssClass="form-control fw-lighter border border-2" ReadOnly="true" placeholder="Total Bill Amount"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <!-- Tax Grid Starts -->
                        <div id="divTaxHead" runat="server" visible="false">

                            <asp:GridView ShowHeaderWhenEmpty="true" ID="GridTax" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridTax_RowDataBound" CssClass="table text-center">
                                <HeaderStyle CssClass="align-middle table-secondary fw-light" />
                                <Columns>

                                    <asp:TemplateField HeaderText="Account Head" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-4 align-middle text-start fw-light">
                                        <ItemTemplate>
                                            <asp:TextBox ID="AcHeadName" Text='<%# Bind("AcHeadName") %>' runat="server" Enabled="false" CssClass="col-md-9 fw-light bg-white border-0 py-1 px-2"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Factor in %" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-2 align-middle">
                                        <ItemTemplate>
                                            <asp:TextBox ID="FactorInPer" Text='<%# Bind("FactorInPer") %>' type="number" step="0.01" title="Enter a number two decimals" runat="server" Enabled="true" CssClass="col-md-9 fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="% / Amount" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-2 align-middle">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="PerOrAmnt" runat="server" CssClass="col-md-6 text-center fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2">
                                                <asp:ListItem Text="%" Value="Percentage"></asp:ListItem>
                                                <asp:ListItem Text="₹" Value="Amount"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Add / Less" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-2 align-middle">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="AddLess" runat="server" CssClass="col-md-6 text-center fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2">
                                                <asp:ListItem Text="+" Value="Add"></asp:ListItem>
                                                <asp:ListItem Text="-" Value="Less"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Amount" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-3 align-middle">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TaxAmount" Text='<%# Bind("TaxAmount") %>' type="number" step="0.01" runat="server" Enabled="true" ReadOnly="true" CssClass="col-md-9 fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                            <!-- Re-Calculate Tax -->

                            <div class="mt-3 mb-3">
                                <div class="text-end">
                                    <asp:Button ID="btnReCalTax" runat="server" Text="Re-Calculate" OnClick="btnReCalTax_Click" CssClass="btn btn-custom text-white mb-3" />
                                </div>
                            </div>


                            <!-- Net Deduction, Addition & Total Bill Amounts -->
                            <div class="row mb-3">
                                <!-- Total Deduction -->
                                <div class="col-md-3 align-self-end">
                                    <asp:Literal ID="Literal28" Text="Total Deductions :" runat="server"></asp:Literal>
                                    <div class="input-group text-end">
                                        <span class="input-group-text fs-5 fw-light">₹</span>
                                        <asp:TextBox runat="server" ID="txtTotalDeduct" CssClass="form-control fw-lighter border border-2" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <!-- Total Addition -->
                                <div class="col-md-3 align-self-end">
                                    <asp:Literal ID="Literal29" Text="Total Additions :" runat="server"></asp:Literal>
                                    <div class="input-group text-end">
                                        <span class="input-group-text fs-5 fw-light">₹</span>
                                        <asp:TextBox runat="server" ID="txtTotalAdd" CssClass="form-control fw-lighter border border-2" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-3"></div>

                                <!-- Net Amount -->
                                <div class="col-md-3 align-self-end text-end">
                                    <asp:Literal ID="Literal30" Text="Net Amount :" runat="server"></asp:Literal>
                                    <div class="input-group text-end">
                                        <span class="input-group-text fs-5 fw-light">₹</span>
                                        <asp:TextBox runat="server" ID="txtNetAmnt" CssClass="form-control fw-lighter border border-2" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- Tax Grid Ends -->

                    </div>
                    <!-- Item GridView Ends -->



                    <!-- Heading Document -->
                    <div class="border-top border-bottom border-secondary-subtle py-2 mt-4">
                        <div class="fw-normal fs-5 fw-medium text-body-secondary">
                            <asp:Literal Text="Document Upload" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <!-- Documents Upload -->
                    <div class="row">
                        <div class="col-md-6">
                            <div class="mt-4 input-group has-validation">
                                <asp:FileUpload ID="fileDoc" runat="server" CssClass="form-control" aria-describedby="inputGroupPrepend" />
                                <asp:Button ID="btnDocUpload" OnClick="btnDocUpload_Click" runat="server" Text="Upload +" AutoPost="true" CssClass="btn btn-custom btn-outline-secondary" />
                            </div>
                            <h6 class="pt-3 fw-lighter fs-6 text-secondary-subtle">User can upload Requisition and other Documents !</h6>
                        </div>
                        <div class="col-md-6"></div>
                    </div>
                    <!-- Documents Upload Ends -->

                    <!-- Document Grid Starts -->
                    <div id="docGrid" class="mt-5" runat="server" visible="false">
                        <asp:GridView ShowHeaderWhenEmpty="true" ID="GridDocument" EnableViewState="true" runat="server" AutoGenerateColumns="false" OnRowDeleting="Grid_RowDeleting"
                            CssClass="table table-bordered border border-light-subtle text-start mt-3 grid-custom">
                            <HeaderStyle CssClass="align-middle fw-light fs-6" />
                            <Columns>

                                <asp:TemplateField ControlStyle-CssClass="col-md-1" HeaderText="Sr.No">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="id" runat="server" Value="id" />
                                        <span>
                                            <%#Container.DataItemIndex + 1%>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="DocName" HeaderText="File Name" ReadOnly="true" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />

                                <asp:TemplateField HeaderText="View Document" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="DocPath" runat="server" Text="View Uploaded Document" NavigateUrl='<%# Eval("DocPath") %>' Target="_blank" CssClass="text-decoration-none"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>'>
                                            <asp:Image runat="server" ImageUrl="~/portal/assests/img/modern-cross-fill.svg" AlternateText="Edit" style="width: 28px; height: 28px;"/>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                    <!-- Document Grid Ends -->

                    <!-- Submit Button -->
                    <div class="">
                        <div class="row mt-5 mb-2">
                            <div class="col-md-6 text-start">
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-custom text-white shadow mb-5" />
                            </div>
                            <div class="col-md-6 text-end">
                                <asp:Button ID="btnSubmit" Enabled="true" runat="server" Text="Submit" ValidationGroup="finalSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-custom text-white shadow mb-5" />
                            </div>
                        </div>
                    </div>


                </div>
            </div>
            <!-- Item UI Ends -->



        </div>
        <!-- Update Div Ends -->


    </form>
</body>
</html>
