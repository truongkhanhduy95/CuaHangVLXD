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
    public partial class frmAddDonNhapHang : DevComponents.DotNetBar.Office2007RibbonForm
    {
        DonNhapHangBLL donnhaphangBLL = new DonNhapHangBLL();
        HangHoaBLL hangBLL = new HangHoaBLL();
        LoaiHangBLL loaiBLL = new LoaiHangBLL();
        NhaCungCapBLL nccBLL = new NhaCungCapBLL();

        DonNhapHang donNhapHang;

        public frmAddDonNhapHang()
        {
            InitializeComponent();
        }

        public frmAddDonNhapHang(NhaCungCap ncc)
        {
            InitializeComponent();
            txtDiaChi.Text = ncc.DiaChi;
            txtEmail.Text = ncc.Email;
            txtSDT.Text = ncc.SoDienThoai;
            txtTenKH.Text = ncc.Ten;
        }

        private void frmAddDonNhapHang_Load(object sender, EventArgs e)
        {
            donNhapHang = new DonNhapHang();
            dgvHangHoa.DataSource = hangBLL.LoadDanhSachHHCungCap();
            cboLoaiHang.DataSource = loaiBLL.LoadAll();
            cboLoaiHang.DisplayMember = "TenLoai";
            cboLoaiHang.ValueMember = "ID";
            cboLoaiHang.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = hangBLL.SearchByTen(txtTenHH.Text);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            txtTenHH.ResetText();
            dgvHangHoa.DataSource = hangBLL.LoadDanhSachHHCungCap();
            cboLoaiHang.SelectedIndex = -1;
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            HangHoa hh = hangBLL.GetHangHoaByID(dgvHangHoa.SelectedRows[0].Cells[0].Value.ToString());
            hh.SoLuong = nmSoLuong.Value;
            donNhapHang.AddHangHoa(hh);
            ShowDanhSachHangHoa();
            txtTotalPrice.Text = donNhapHang.TongTien.ToString();
            nmSoLuong.Value = 1;
        }

        public void ShowDanhSachHangHoa()
        {
            dgvHangMua.Rows.Clear();
            dgvHangMua.Refresh();
            foreach (HangHoa hh in donNhapHang.DSHangHoa)
            {
                DataGridViewRow row = (DataGridViewRow)dgvHangMua.Rows[0].Clone();
                row.Cells[0].Value = hh.MaHH;
                row.Cells[1].Value = hh.TenHH;
                row.Cells[2].Value = hh.LoaiHang;
                row.Cells[3].Value = hh.GiaGoc;
                row.Cells[4].Value = hh.SoLuong;
                int thanhtien = hh.GiaGoc * hh.SoLuong;
                row.Cells[5].Value = thanhtien.ToString();

                dgvHangMua.Rows.Add(row);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int traTruoc = int.Parse(txtTraTruoc.Text);
                if (txtTenKH.Text == "")
                {
                    MessageBox.Show("Chưa điền thông tin nhà cung cấp");
                    return;
                }
                NhaCungCap nhaCungCap = nccBLL.Contains(new NhaCungCap(txtTenKH.Text, txtDiaChi.Text));

                if (nhaCungCap.Ma == null)    //TH1: Tìm không thấy => nhà cung cấp này là mới
                {
                    //Tạo 1record nhà cung cấp mới
                    nhaCungCap.Ten = txtTenKH.Text;
                    nhaCungCap.DiaChi = txtDiaChi.Text;
                    nhaCungCap.Email = txtEmail.Text;
                    nhaCungCap.SoDienThoai = txtSDT.Text;

                    //add nhà cung cấp
                    nccBLL.Insert(nhaCungCap);
                    //Lấy lại mã mới tạo
                    nhaCungCap = nccBLL.Contains(new NhaCungCap(txtTenKH.Text, txtDiaChi.Text));
                }
                //Tạo đơn nhập hàng với mã nhà cung cấp vừa lấy
                donNhapHang.MaNCC = nhaCungCap.Ma;
                donNhapHang.NgayLap = DateTime.Now;
                donNhapHang.DaTra = traTruoc;
                if (donnhaphangBLL.AddNewHoaDon(donNhapHang))
                {
                    MessageBoxEx.Show("Đã lập đơn nhập hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(FormatException)
            {
                MessageBoxEx.Show("Nhập sai!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            HangHoa hh = hangBLL.GetHangHoaByID(dgvHangMua.SelectedRows[0].Cells[0].Value.ToString());
            donNhapHang.RemoveHanghoa(hh);
            ShowDanhSachHangHoa();
            txtTotalPrice.Text = donNhapHang.TongTien.ToString();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmAddHangHoa frm = new frmAddHangHoa();
            frm.ShowDialog();
            dgvHangHoa.DataSource = hangBLL.LoadDanhSachHH(false);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.RemoveCurrentTab();
        }
    }
}
