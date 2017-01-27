using CuaHangVLXD.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangVLXD.PresentationLayer
{
    public partial class frmThongKe : DevComponents.DotNetBar.Office2007RibbonForm
    {
        ThongKeBLL bll = new ThongKeBLL();
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            InitChart();
            ThongKeLoiNhuan();
            ThongKeChung();
        }

        private void ThongKeChung()
        {
            lblTongKH.Text = bll.ThongKeTongKhachHang().ToString();
            lblTongNCC.Text = bll.ThongKeTongNhaCungCap().ToString();

            lblTongNoHoaDon.Text = bll.TongNoHoaDon().ToString();
            lblTongNoDNH.Text = bll.TongNoDonNhapHang().ToString();
        }

        private void ThongKeLoiNhuan()
        {
            lblTongDNH.Text = bll.ThongKeTongHoaDonNhap().ToString();
            lblTongDonXuat.Text = bll.ThongKeTongHoaDonBan().ToString();
        }

        private void InitChart()
        {
            //Chart Hoa Don
            chart1.DataSource = bll.ThongKeHoaDonByMonth();
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Tổng tiền";

            chart1.Series["Nhập"].XValueMember = "Thang";
            chart1.Series["Nhập"].YValueMembers = "DonNhap";

            chart1.Series["Xuất"].XValueMember = "Thang";
            chart1.Series["Xuất"].YValueMembers = "DonXuat";

            //Chart Doanh Thu
            chart2.DataSource = bll.ThongKeDoanhThuByMonth();
            chart2.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
            chart2.ChartAreas["ChartArea1"].AxisY.Title = "Doanh thu";

            chart2.Series["DoanhThu"].XValueMember = "Thang";
            chart2.Series["DoanhThu"].YValueMembers = "DoanhThu";
        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.RemoveCurrentTab();
        }
    }
}
