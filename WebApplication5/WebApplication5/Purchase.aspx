<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="WebApplication5.Purchase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%@ MasterType VirtualPath="~/Main.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Welcome To Purchase Section</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
              <li class="breadcrumb-item active">Purchase</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>
     <!-- Main content -->
    <section class="content">

      <!-- Default box -->
      <div class="card">
          <div class="card-header">
          <h3 class="card-title">Add Vendor Record</h3>
              <div class="card-tools">
            <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
              <i class="fas fa-minus"></i>
            </button>
            <!-- <button type="button" class="btn btn-tool" data-card-widget="remove" title="Remove"> -->
              <i class="fas fa-times"></i>
            </button>
          </div>
        </div>
                  <div class="card-body">
                  <div class="form-group">

                    <label for="exampleInputEmail1">Vendor</label>
                    <asp:DropDownList class="form-control" ID="Drpvendor" runat="server"></asp:DropDownList>
                      <span style="margin-top: 5px;">Add new Vendor here</span>
                      <asp:ScriptManager runat="server"></asp:ScriptManager>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Button2" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button2"
                                                    CancelControlID="Button2" BackgroundCssClass="Background">
                                                </cc1:ModalPopupExtender>

                                                <cc1:ModalPopupExtender ID="Modalpopupextender1" runat="server" PopupControlID="Panl1" TargetControlID="Button2"
                                                    BackgroundCssClass="Background">
                                                </cc1:ModalPopupExtender>
                                                <asp:Button CssClass="btn-primary" ID="Button2" runat="server" Text="+" />
                                                <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none;">
                                                    <iframe style="width: 800px; height: 600px; margin-left: 5%;" id="irm1" src="Vendor.aspx" runat="server"></iframe>
                                                    <br />
                                                    <asp:Button ID="btnRefresh" CssClass="btn-primary" runat="server" Text="Close" style="background: red; border: none; padding: 8px;" />
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                  </div>
                  <div class="form-group">
                    <label for="exampleInputEmail1">Product</label>
                      <asp:DropDownList class="form-control" ID="drpproduct" runat="server" AutoPostBack="True" placeholder="Enter product name"></asp:DropDownList>
                  <span style="margin-top: 5px;">Add new Product here</span>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Button22" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panl12" TargetControlID="Button22"
                                                CancelControlID="Button22" BackgroundCssClass="Background">
                                            </cc1:ModalPopupExtender>
                                            <cc1:ModalPopupExtender ID="Modalpopupextender3" runat="server" PopupControlID="Panl12" TargetControlID="Button22"
                                                BackgroundCssClass="Background">
                                            </cc1:ModalPopupExtender>
                                            <asp:Button CssClass="btn-primary" ID="Button22" runat="server" Text="+" />
                                            <asp:Panel ID="Panl12" runat="server" CssClass="Popup" align="center" Style="display: none;">
                                                <iframe style="width: 900px; height: 600px; margin-left: 5%;" id="Iframe1" src="Products.aspx" runat="server"></iframe>
                                                <br />
                                                <asp:Button ID="Button4" CssClass="btn-primary" runat="server" Text="Close" style="background: red; border: none; padding: 8px;" />
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                  </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">Purchase Date</label>
                    <asp:TextBox class="form-control" ID="Txtdate" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">Quantity</label>
                    <asp:TextBox class="form-control" ID="txtqualtity" runat="server" TextMode="Number" placeholder="Enter quantity"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">Purchase Price</label>
                    <asp:TextBox class="form-control" ID="txtpurchaseprice" runat="server" TextMode="Number" placeholder="Enter quantity"></asp:TextBox>
                  </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">Sell Price</label>
                    <asp:TextBox class="form-control" ID="txtprice" runat="server" TextMode="Number" placeholder="Enter sell price"></asp:TextBox>
                  </div>
                    <div class="form-check">
                                    <asp:CheckBox runat="server" class="form-check-input" type="checkbox" value="0" ID="chknew" />
                                    <label class="form-check-label" for="defaultCheck1" style="font-weight: bold;">Is New</label>
                                    <asp:CheckBox runat="server" class="form-check-input" type="checkbox" value="0" Style="margin-left: 2%;" ID="chkpta" />
                                    <label class="form-check-label" for="defaultCheck2" style="font-weight: bold; margin-left: 4%; margin-top: 3.8px;">PTA Approve</label>
                                </div>
                    <asp:Label runat="server" ID="txtvalid" text=""  style="color:#ff0000; font-weight: bold;" />
 
                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                  <asp:Button runat="server" id="submitbtn" OnClientClick="stoprefreshbtnclick()" type="button" class="btn btn-primary" Text="Submit" CausesValidation="False" OnClick="submitbtn_Click"  />
                    <asp:Button runat="server" Visible="false" id="btnupdate" type="button" class="btn btn-default" Text="Update" CausesValidation="False" OnClick="btnupdate_Click" style="background: #007BFF; color: white;" />
                    <br />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                </div>
        </div>
        <script type="text/javascript">
            <%--window.onload = function () {
                var seconds = 5;
                setTimeout(function () {
                    document.getElementById("<%=displaymessage.ClientID %>").style.display = "none";
                }, seconds * 1000);
            }--%>
            function alertme() {
                Swal.fire(

'Record Inserted!',
'Mobile Shop Management System',
'success'

)

            }

            function easy() {
                Swal.fire(
                  'Good job!',
                  'You clicked the button!',
                  'success'
                )
            }

            function deleteme() {
                Swal.fire(

'Record Deleted!',
'Mobile Shop Management System',
'success'

)
            }
            function updateme() {
                Swal.fire(

'Record Updated!',
'Mobile Shop Management System',
'success'

)
            }

            if (window.history.replaceState) {
                window.history.replaceState(null, null, window.location.href);
            }

</script>  
    </section>

    <!-- /.content -->
      <!-- Main content -->
    <section class="content">

      <!-- Default box -->
      <div class="card">
        <div class="card-header">
          <h3 class="card-title">Purchase Record</h3>

          <div class="card-tools">
            <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
              <i class="fas fa-minus"></i>
            </button>
            <!-- <button type="button" class="btn btn-tool" data-card-widget="remove" title="Remove"> -->
              <i class="fas fa-times"></i>
            </button>
          </div>
        </div>

        <div class="card-body" style="overflow: scroll; height: 500px;">
            <div class="form-group">
                    <label for="exampleInputName">Search by Product Name</label>
                    <asp:Textbox id="txtsearchname" OnTextChanged="txtsearchname_TextChanged" AutoPostBack="true" runat="server" type="text" class="form-control" placeholder="Enter name here" AutoCompleteType="Disabled" />
                  </div>
            <asp:Label runat="server" Visible="false" ID="displaymessage" text=""  style="color:#ff0000; font-weight: bold;" />    
            <%--<div class="card-footer">
                  <asp:Button runat="server" id="Button1" OnClientClick="stoprefreshbtnclick()" type="button" class="btn btn-primary" Text="Search" OnClick="Button1_Click1" CausesValidation="False"  />
            </div>--%>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
           <table class="table table-bordered">
    <thead>
        <tr>
            <%--<th>Sno</th>--%>
            <th>Sno</th>
            <th>Purchase ID</th>
            <th>Product Name</th>
            <th>Quantity</th>
            <th>Purchase Price</th>
            <th>Sell Price</th>
            <th>Is New</th>
            <th>PTA Approve</th>
            <th>Total Purchase Price</th>
            <th>Total Sell Price</th>
        </tr>
    </thead>
               </HeaderTemplate>
                 <ItemTemplate>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Sno") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("PurchaseID") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("PurchasePrice") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("SellPrice") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("IsNew") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("PTAApprove") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("TotalPurchasePrice") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("TotalSellPrice") %>'></asp:Label></td>
                                    <td>
                                        <asp:LinkButton class="btn btn-warning" Text="Edit" ID="btnEdit" CommandName="EDIT" CommandArgument='<%#Eval("Sno") %>' ToolTip="Edit Record" runat="server" Style="color: #ffffff; background: #04AA60; border: none;" />
                                    </td>
                                    <td>
                                        <asp:LinkButton class="btn btn-warning" OnClientClick="return confirm('Are You Want To Delete This Record?')" Text="Delete" ID="btnDelete" CommandName="delete" CommandArgument='<%#Eval("Sno") %>' ToolTip="Edit Record" runat="server" Style="color: #ffffff; background: #D9534F; border: none;" />
                                    </td>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </section>
  </div>
  <!-- /.content-wrapper -->

  <footer class="main-footer">
    <div class="float-right d-none d-sm-block">
      <b>Version</b> 3.1.0
    </div>
    <strong>Copyright &copy; 2021 <a href="#">Mobile Management System</a></strong> All rights reserved.
  </footer>

  <!-- Control Sidebar -->
  <aside class="control-sidebar control-sidebar-dark">
    <!-- Control sidebar content goes here -->
  </aside>
  <!-- /.control-sidebar -->
<!-- ./wrapper -->

    <!-- REQUIRED SCRIPTS -->
      <!-- jQuery -->
      <script src="Master Page layout/plugins/jquery/jquery.min.js"></script>
      <!-- Bootstrap -->
      <script src="Master Page layout/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
      <!-- AdminLTE -->
      <script src="Master Page layout/dist/js/adminlte.js"></script>
          <!-- OPTIONAL SCRIPTS -->
            <script src="Master Page layout/plugins/chart.js/Chart.min.js"></script>
            <!-- AdminLTE for demo purposes -->
            <script src="Master Page layout/dist/js/demo.js"></script> 
            <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
            <!-- <script src="dist/js/pages/dashboard3.js"></script> -->
    <script src="MessageBox.js"></script>
    <!-- Adding The Active Link On Master Page Nav Links -->
    <script>$("#Purchase").addClass("nav-link active");</script>

</asp:Content>