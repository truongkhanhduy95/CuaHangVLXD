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
    public partial class frmCapNhatCongNo : DevComponents.DotNetBar.Office2007RibbonForm
    {
        CongNoKhachHangBLL bll = new CongNoKhachHangBLL();
        CongNoNhaCungCapBLL nccBLL = new CongNoNhaCungCapBLL();

        HoaDon hoaDon;
        DonNhapHang donNhapHang;

        public frmCapNhatCongNo(HoaDon hoaDon,string tenKH)
        {
            InitializeComponent();
            this.hoaDon = hoaDon;
            lblMaHD.Text = hoaDon.MaHD;
            lblTen.Text = tenKH;
            lblNgayLap.Text = hoaDon.NgayLap.ToString();
            lblTongTien.Text = hoaDon.TongTien.ToString();
            lblConNo.Text = hoaDon.ConLai.ToString();
            lblConLai.Text = hoaDon.ConLai.ToString();
        }

        public frmCapNhatCongNo(DonNhapHang donNhapHang, string tenNCC)
        {
            InitializeComponent();
            this.donNhapHang = donNhapHang;
            lblMaHD.Text = donNhapHang.MaDNH;
            lblTen.Text = tenNCC;
            lblNgayLap.Text = donNhapHang.NgayLap.ToString();
            lblTongTien.Text = donNhapHang.TongTien.ToString();
            lblConNo.Text = donNhapHang.ConLai.ToString();
            lblConLai.Text = donNhapHang.ConLai.ToString();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkTraHet_CheckedChanged(object sender, EventArgs e)
        {
            if(chkTraHet.Checked)
            {
                txtTraThem.Text = lblConNo.Text;        
            }
            else
            {
                txtTraThem.Text = "0";
            }
        }

        private void txtTraThem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTraThem.Text != "")
                {
                    int traThem = int.Parse(txtTraThem.Text);
                    if (traThem > int.Parse(lblConNo.Text))
                    {
                        txtTraThem.Text = lblConNo.Text;
                        return;
                    }
                    if (traThem == int.Parse(lblConNo.Text))
                        chkTraHet.Checked = true;
                    else
                        chkTraHet.Checked = false;
                    if (hoaDon != null) lblConLai.Text = (hoaDon.ConLai - traThem).ToString();
                    if (donNhapHang != null) lblConLai.Text = (donNhapHang.ConLai - traThem).ToString();

                }
                else
                    txtTraThem.Text = "0";
            }
            catch (FormatException)
            {
                MessageBox.Show("Nhập sai!");
            }
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (hoaDon != null)
            {
                if (bll.CapNhatCongNo(hoaDon, int.Parse(txtTraThem.Text)))
                {
                    if (MessageBoxEx.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            if (donNhapHang != null)
            {
                if (nccBLL.CapNhatCongNo(donNhapHang, int.Parse(txtTraThem.Text)))
                {
                    if (MessageBoxEx.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
