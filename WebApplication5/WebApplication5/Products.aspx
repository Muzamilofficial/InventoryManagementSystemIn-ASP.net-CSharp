<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebApplication5.Products" %>
<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Welcome To Products Section</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
              <li class="breadcrumb-item active">Products</li>
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
          <h3 class="card-title">Add Products</h3>
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
                    <label for="exampleInputEmail1">Category</label>
                    <asp:DropDownList id="drpdowncatID" runat="server" type="text" class="form-control" />
                  </div>
                  <div class="form-group">
                    <label for="exampleInputEmail1">Company</label>
                    <asp:DropDownList id="drpdowncomID" runat="server" type="text" class="form-control" />
                  </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">Product Name</label>
                    <asp:Textbox id="txtprodname" runat="server"  type="text" class="form-control" placeholder="Enter name" AutoCompleteType="Disabled" />
                    </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">Model</label>
                    <asp:Textbox id="txtmodel" runat="server"  type="text" class="form-control" placeholder="Enter model" AutoCompleteType="Disabled" />
                    </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">IMI 1</label>
                    <asp:Textbox id="txtimi1" runat="server"  type="text" class="form-control" placeholder="Enter IMI 1" AutoCompleteType="Disabled" TextMode="Number" />
                    </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">IMI 2</label>
                    <asp:Textbox id="txtimi2" runat="server"  type="text" class="form-control" placeholder="Enter IMI 2" AutoCompleteType="Disabled" TextMode="Number" />
                    </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">IMI 3</label>
                    <asp:Textbox id="txtimi3" runat="server"  type="text" class="form-control" placeholder="Enter IMI 3" AutoCompleteType="Disabled" TextMode="Number" />
                    </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">IMI 4</label>
                    <asp:Textbox id="txtimi4" runat="server"  type="text" class="form-control" placeholder="Enter IMI 4" AutoCompleteType="Disabled" TextMode="Number" />
                    </div>
                    <asp:Label runat="server" ID="txtvalid" text=""  style="color:#ff0000; font-weight: bold;" />
                    </div>
                <!-- /.card-body -->
                <div class="card-footer">
                  <asp:Button runat="server" id="submitbtn" type="button" class="btn btn-primary" Text="Submit" OnClick="submitbtn_Click" CausesValidation="False"  />
                    <asp:Button runat="server" Visible="false" id="btnupdate" type="button" class="btn btn-default" Text="Update" CausesValidation="False" OnClick="btnupdate_Click" style="background: #007BFF; color: white;" />
                <br />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
                      </div>
        <script type="text/javascript">
            <%--window.onload = function () {
                var seconds = 5;
                setTimeout(function () {
                    document.getElementById("<%=displaymessage.ClientID %>").style.display = "none";
        }, seconds * 1000);
            };--%>
            function alertme() {
                Swal.fire(

'Record Inserted!',
'Mobile Shop Management System',
'success'

)

            }
            function duplicateme() {
                Swal.fire('Company name already exist!')
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
          <h3 class="card-title">My Products</h3>

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
                    <label for="exampleInputName">Search by name</label>
                    <asp:Textbox id="txtsearchname" AutoPostBack="true" runat="server" type="text" class="form-control" placeholder="Enter vendor name" AutoCompleteType="Disabled" OnTextChanged="txtsearchname_TextChanged" />
                  </div>
            <asp:Label runat="server" Visible="false" ID="displaymessage" text=""  style="color:#ff0000; font-weight: bold;" />
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                <HeaderTemplate>
           <table class="table table-bordered">
    <thead>
        <tr>
            <th>Product ID</th>
            <th>Category ID</th>
            <th>Company ID</th>
            <th>Product Name</th>
            <th>Model</th>
            <th>IMEI 1</th>
            <th>IMEI 2</th>
            <th>IMEI 3</th>
            <th>IMEI 4</th>
        </tr>
    </thead>
               </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ProductID") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("CategoryID") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("CompanyID") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("Model") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("IMEI1") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("IMEI2") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("IMEI3") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("IMEI4") %>'></asp:Label></td>
                            <td>
                                <asp:LinkButton class="btn btn-warning" Text="Edit" ID="btnEdit"  CommandName="EDIT"  CommandArgument='<%#Eval("ProductID") %>' ToolTip="Edit Record"  runat="server" style="color: #ffffff; background: #04AA60; Border: none;" />

                            </td>
                            <td>
                                <asp:LinkButton class="btn btn-warning" OnClientClick="return confirm('Are You Want To Delete This Record?')" Text="Delete" ID="btnDelete" CommandName="delete"  CommandArgument='<%#Eval("ProductID") %>' ToolTip="Edit Record"  runat="server" style="color: #ffffff; background:#D9534F; Border: none;" />
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
    <strong>Copyright &copy; 2021 <a href="#">Mobile Mnagement System</a></strong> All rights reserved.
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
    <script>$("#Products").addClass("nav-link active");</script>

</asp:Content>
