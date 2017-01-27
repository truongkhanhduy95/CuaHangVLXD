using CuaHangVLXD.BussinessLogicLayer;
using CuaHangVLXD.Model;
using System;
using DevComponents.DotNetBar;
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
    public partial class frmAddHangHoa : DevComponents.DotNetBar.Office2007RibbonForm
    {
        HangHoaBLL bll = new HangHoaBLL();
        LoaiHangBLL loaiBLL = new LoaiHangBLL();
        HangHoa hangHoa;

        public frmAddHangHoa()
        {
            InitializeComponent();

            cboLoai.DataSource = loaiBLL.LoadAll();
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "ID";
            cboLoai.SelectedIndex = 0;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenHH.Text == "" || txtDonViTinh.Text == "" || txtGiaBan.Text == "" || txtGiaGoc.Text == "" || txtSoLuong.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                    return;
                }
                hangHoa = new HangHoa();
                hangHoa.TenHH = txtTenHH.Text;
                hangHoa.LoaiHang = cboLoai.SelectedValue.ToString();
                hangHoa.SoLuong = int.Parse(txtSoLuong.Text);
                hangHoa.GiaGoc = int.Parse(txtGiaGoc.Text);
                hangHoa.GiaBan = int.Parse(txtGiaBan.Text);
                hangHoa.DonViTinh = txtDonViTinh.Text;

                if (bll.Insert(hangHoa))
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
            catch(FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng số!");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void txtTenHH_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmAddLoai frm = new frmAddLoai();
            frm.ShowDialog();
            cboLoai.DataSource = cboLoai.DataSource = loaiBLL.LoadAll();
        }

        private void frmAddHangHoa_Load(object sender, EventArgs e)
        {

        }
    }
}
