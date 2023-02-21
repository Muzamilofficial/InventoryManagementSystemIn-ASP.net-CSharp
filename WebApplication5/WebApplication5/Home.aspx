<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication5.WebForm1" %>
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
            <h1>Welcome To Dashboard Section</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
              <%--<li class="breadcrumb-item active">Vendor</li>--%>
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
          <h3 class="card-title">Title</h3>

          <div class="card-tools">
            <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
              <i class="fas fa-minus"></i>
            </button>
<%--            <button type="button" class="btn btn-tool" data-card-widget="remove" title="Remove">--%>
              <i class="fas fa-times"></i>
            </button>
          </div>
        </div>
        <div class="card-body">
          <!-- Small boxes (Stat box) -->
        <div class="row">
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-info">
              <div class="inner">
                <asp:Label runat="server" Text="" ID="lblvendors" style="font-weight: bold; font-size: 30px;"></asp:Label>
                <p style="margin-top: 2%;">Total Vendors</p>
              </div>
              <div class="icon">
                <i class="ion ion-person-add"></i>
              </div>
              <a href="Vendor.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-success">
              <div class="inner">
                <asp:Label runat="server" Text="" ID="lblcompanies" style="font-weight: bold; font-size: 30px;"></asp:Label>
                  <p>Companies</p>
              </div>
              <div class="icon">
                <i class="nav-icon fas fa-chart-pie"></i>
              </div>
              <a href="Company.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <!-- ./col -->
            <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-warning">
              <div class="inner">
                <asp:Label runat="server" Text="" ID="lblproducts" style="font-weight: bold; font-size: 30px;"></asp:Label>
                <p>Total Products</p>
              </div>
              <div class="icon">
                <i class="fa fa-shopping-cart"></i>
              </div>
              <a href="Products.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-danger">
              <div class="inner">
                <asp:Label runat="server" Text="" ID="lbltotalpurchase" style="font-weight: bold; font-size: 30px;"></asp:Label>
                <p>Total Purchases</p>
              </div>
              <div class="icon">
                <i class="ion ion-pie-graph"></i>
              </div>
              <a href="Purchase.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
            <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-info">
              <div class="inner" style="background: #4F4846;">
                <asp:Label runat="server" Text="" ID="lblstock" style="font-weight: bold; font-size: 30px;"></asp:Label>
                <p style="margin-top: 2%;">Total Stock</p>
              </div>
              <div class="icon">
                <i class="ion ion-stats-bars"></i>
              </div>
              <a href="#" class="small-box-footer" style="background: #6F6257;">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
            <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-info">
              <div class="inner" style="background: #9a1750;">
                <asp:Label runat="server" Text="" ID="lblcustomer" style="font-weight: bold; font-size: 30px;"></asp:Label>
                <p>Total Customers</p>
              </div>
              <div class="icon">
                <i class="fas fa-users"></i>
              </div>
              <a href="formCustomer.aspx" class="small-box-footer" style="background: #9f3960;">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <!-- ./col -->
        </div>
        <!-- /.row -->
        </div>
        <!-- /.card-body -->
    </section>
    <!-- /.content -->
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
</div>
<!-- ./wrapper -->

    <!-- REQUIRED SCRIPTS -->
      <!-- jQuery -->
      <script src="Master Page layout/plugins/jquery/jquery.min.js"></script>
      <!-- Bootstrap -->
      <script src="Master Page layout/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
      <!-- AdminLTE -->
      <script src="Master Page layout/dist/js/adminlte.js"></script
          <!-- OPTIONAL SCRIPTS -->
            <script src="Master Page layout/plugins/chart.js/Chart.min.js"></script>
            <!-- AdminLTE for demo purposes -->
            <script src="Master Page layout/dist/js/demo.js"></script> 
            <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
            <!-- <script src="dist/js/pages/dashboard3.js"></script> -->

    <!-- Adding The Active Link On Master Page Nav Links -->
    <script>$("#home").addClass("nav-link active");</script>


</asp:Content>
