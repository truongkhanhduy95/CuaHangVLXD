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
    public partial class frmThongKeMatHang : DevComponents.DotNetBar.Office2007RibbonForm
    {
        ThongKeBLL bll = new ThongKeBLL();
        public frmThongKeMatHang()
        {
            InitializeComponent();
        }

        private void frmThongKeMatHang_Load(object sender, EventArgs e)
        {
            chart1.DataSource = bll.ThongKePhanTramLoai();
            chart1.Text = "Thống kê loại vật liệu";
            chart1.Series["Series4"].XValueMember = "TenLoai";
            chart1.Series["Series4"].YValueMembers = "PhanTram";
            chart1.Series["Series4"].IsValueShownAsLabel = true;

            chart2.DataSource = bll.ThongKeTop10HangHoa();
            chart2.ChartAreas["ChartArea1"].AxisX.Title = "Vật liệu";
            chart2.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng bán";

            chart2.Series["Mặt hàng"].XValueMember = "TenHH";
            chart2.Series["Mặt hàng"].YValueMembers = "SoLuong";

            lblTongHH.Text = bll.ThongKeTongHangHoa().ToString();
            lblLoai.Text = bll.ThongKeTongLoai().ToString();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.RemoveCurrentTab();
        }
    }
}
