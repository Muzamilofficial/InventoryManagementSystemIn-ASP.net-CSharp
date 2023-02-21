<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="formCustomer.aspx.cs" Inherits="WebApplication5.formCustomer" %>
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
            <h1>Welcome To Customer Section</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
              <li class="breadcrumb-item active">Customer</li>
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
          <h3 class="card-title">Add Customer Record</h3>
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
                    <label for="exampleInputEmail1">First Name</label>
                    <asp:Textbox id="txtfirstname" runat="server" type="text" class="form-control" placeholder="Enter name" AutoCompleteType="Disabled" />
                  </div>
                      <div class="form-group">
                    <label for="exampleInputEmail1">Last Name</label>
                    <asp:Textbox id="txtlastname" runat="server" type="text" class="form-control" placeholder="Enter name" AutoCompleteType="Disabled" />
                  </div>
                      <div class="form-group">
                    <label for="exampleInputEmail1">Father Name</label>
                    <asp:Textbox id="txtfathername" runat="server" type="text" class="form-control" placeholder="Enter name" AutoCompleteType="Disabled" />
                  </div>
                  <div class="form-group">
                    <label for="exampleInputEmail1">Email</label>
                    <asp:Textbox id="txtemail" runat="server" type="email" class="form-control" placeholder="Enter email" AutoCompleteType="Disabled" />
                  </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">Contact No</label>
                    <asp:Textbox id="txtcontactno" runat="server"  type="text" class="form-control" placeholder="Enter contact no" AutoCompleteType="Disabled" />
                    </div>
                    <div class="form-group">
                    <label for="exampleInputEmail1">CNIC</label>
                    <asp:Textbox id="txtcnic" runat="server" type="text" class="form-control" placeholder="Enter CNIC" AutoCompleteType="Disabled" />
                  </div>
                      <div class="form-group">
                       <label for="exampleInputEmail1">Browse Image</label>
                      <div class="input-group">
                      <div class="custom-file">
                          <asp:FileUpload ID="FileUpload1"  runat="server" />
                        <%--<asp:Textbox runat="server" type="file" class="custom-file-input" id="txtimage" />
                        <asp:Label runat="server" text="Choose file" class="custom-file-label" for="exampleInputFile" />
                          <asp:Button ID="Button1" runat="server" Text="Upload" />
                      </div>
                      <%--<div class="input-group-append">
                        <asp:Button runat="server" class="input-group-text" Text="Upload" />
                      </div>--%>
                    </div>
                          <div class="form-group">
                              <%--<asp:Image ID="Image1" runat="server" />--%>
                          </div>
                      </div>
                      <div class="form-group">
                    <%--<label for="exampleInputEmail1">MK</label>--%>
                    
                  </div>
                    <asp:Label runat="server" ID="txtvalid" text=""  style="color:#ff0000; font-weight: bold;" />
 
                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                  <asp:Button runat="server" id="submitbtn" OnClientClick="stoprefreshbtnclick()" type="button" class="btn btn-primary" Text="Submit" OnClick="submitbtn_Click" CausesValidation="False"  />
                    <asp:Button runat="server" Visible="false" id="btnupdate" type="button" class="btn btn-default" Text="Update" CausesValidation="False" OnClick="btnupdate_Click" style="background: #007BFF; color: white;" />
                    <br />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                </div>
        </div>
        <script type="text/javascript">
            window.onload = function () {
                var seconds = 5;
                setTimeout(function () {
                    document.getElementById("<%=displaymessage.ClientID %>").style.display = "none";
                }, seconds * 1000);
            }
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
          <h3 class="card-title">Customer Data</h3>

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
                    <label for="exampleInputName">Enter Customer CNIC</label>
                    <asp:Textbox id="txtsearchcnic" AutoPostBack="true" runat="server" type="text" class="form-control" placeholder="Enter CNIC" AutoCompleteType="Disabled" OnTextChanged="txtsearchcnic_TextChanged" />
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
            <th>Customer ID</th>
            <th>Picture</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Father Name</th>
            <th>Email</th>
            <th>Contact no</th>
            <th>CNIC</th>
            <%--<th>Picture Name</th>--%>
        </tr>
    </thead>
               </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("CustomerID") %>'></asp:Label></td>
                             <td>
                                <asp:Image ID="Image1" Height="140" Width="140" runat="server" ImageUrl='<%# Eval("U_FilePath") %>' /></td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("LastName") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("FatherName") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("Email") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("ContactNo") %>'></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("CNIC") %>'></asp:Label></td>
                            <%--<td>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("U_FileName") %>'></asp:Label></td>--%>
                             <%-- <td>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("U_FilePath") %>'></asp:Label></td>--%>
                            <td>
                                <asp:LinkButton class="btn btn-warning" Text="Edit" ID="btnEdit"  CommandName="EDIT"  CommandArgument='<%#Eval("CustomerID") %>' ToolTip="Edit Record"  runat="server" style="color: #ffffff; background: #04AA60; Border: none;" />

                            </td>
                            <td>
                                <asp:LinkButton class="btn btn-warning" OnClientClick="return confirm('Are You Want To Delete This Record?')" Text="Delete" ID="btnDelete" CommandName="delete"  CommandArgument='<%#Eval("CustomerID") %>' ToolTip="Edit Record"  runat="server" style="color: #ffffff; background:#D9534F; Border: none;" />
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
    <script>$("#customer").addClass("nav-link active");</script>

</asp:Content>

