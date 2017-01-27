using CuaHangVLXD.BussinessLogicLayer;
using CuaHangVLXD.Model;
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

namespace CuaHangVLXD.PresentationLayer
{
    public partial class frmAddLoai : DevComponents.DotNetBar.Office2007RibbonForm
    {
        LoaiHangBLL bll = new LoaiHangBLL();

        public frmAddLoai()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenHH.Text == "")
            {
                MessageBox.Show("Không được để trống");
                return;
            }
            LoaiHang lh = new LoaiHang();
            lh.TenLoai = txtTenHH.Text;

            if (bll.Insert(lh))
            {
                MessageBoxEx.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("Có lỗi xảy ra, vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
