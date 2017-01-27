using CuaHangVLXD.PresentationLayer;
using CuaHangVLXD.Presenter;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangVLXD
{
    public partial class Form1 : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool CheckOpenTabs(string name)
        {
            for (int i = 0; i < tabControl1.Tabs.Count; i++)
            {
                if (tabControl1.Tabs[i].Text == name)
                {
                    tabControl1.SelectedTabIndex = i;
                    return true;
                }
            }
            return false;
        }

        public void RemoveCurrentTab()
        {
            tabControl1.Tabs.RemoveAt(tabControl1.Tabs.Count - 1);
        }

        public void AddNewTab(string tabname,Form frm)
        {
            if (CheckOpenTabs(tabname))
            {
                for (int i = 0; i < tabControl1.Tabs.Count; i++)
                {
                    if (tabControl1.Tabs[i].Text == tabname)
                    {
                        tabControl1.Tabs.RemoveAt(i);
                    }
                }
            }
            TabItem t = tabControl1.CreateTab(tabname);
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            t.AttachedControl.Controls.Add(frm);
            frm.Show();
            tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
        }

        private void tabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            AddNewTab("Danh Mục Hàng",new frmHangHoa());
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            AddNewTab("Danh Mục Loại",new frmLoaiHang());
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            AddNewTab("Khách Hàng", new frmKhachHang());
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            AddNewTab("Đơn mới", new frmAddHoaDon());
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            AddNewTab("Đơn hàng", new frmDSHoaDon());
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            AddNewTab("Nhà Cung cấp", new frmNhaCungCap());
        }

        private void buttonItem4_Click_1(object sender, EventArgs e)
        {
            AddNewTab("Đơn nhập mới", new frmAddDonNhapHang());
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            AddNewTab("Đơn nhập", new frmDSDonNhapHang());
        }

        private void ribbonTabItem5_Click(object sender, EventArgs e)
        {
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            AddNewTab("Công nợ KH", new frmCongNoKhachHang());
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            AddNewTab("Tổng quan", new frmThongKe());
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            AddNewTab("Thống kê", new frmThongKeMatHang());
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            AddNewTab("Công nợ NCC", new frmCongNoNhaCungCap());
        }
    }
}
