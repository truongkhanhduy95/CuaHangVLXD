using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuaHangVLXD.PresentationLayer;
using CuaHangVLXD.BussinessLogicLayer;
using CuaHangVLXD.Model;
using DevComponents.DotNetBar;

namespace CuaHangVLXD.Presenter
{
    public partial class frmLoaiHang : DevComponents.DotNetBar.Office2007RibbonForm
    {
        LoaiHangBLL bll = new LoaiHangBLL();
        public frmLoaiHang()
        {
            InitializeComponent();
        }

        private void buttonItemNhapDuLieu_Click(object sender, EventArgs e)
        {

        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            dgvLoaiHang.DataSource = bll.LoadAll();
            if(dgvLoaiHang.Rows.Count>0)
            {
                LoaiHang lh = bll.GetLoaiHangByID(dgvLoaiHang.Rows[0].Cells[0].Value.ToString());
                txtMaLoai.Text = lh.MaLoai;
                txtTenLoai.Text = lh.TenLoai;
            }
        }
        private void btnLuuVaoDS_Click(object sender, EventArgs e)
        {
            LoaiHang lh = new LoaiHang();
            lh.MaLoai = txtMaLoai.Text;
            lh.TenLoai = txtTenLoai.Text;

            bll.Update(lh);
            dgvLoaiHang.DataSource = bll.LoadAll();
            MessageBoxEx.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvLoaiHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                LoaiHang lh = bll.GetLoaiHangByID(dgvLoaiHang.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtMaLoai.Text = lh.MaLoai;
                txtTenLoai.Text = lh.TenLoai;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAddLoai frm = new frmAddLoai();
            frm.ShowDialog();
            dgvLoaiHang.DataSource = bll.LoadAll();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = dgvLoaiHang.SelectedRows[0].Cells[0].Value.ToString();
            LoaiHang lh = bll.GetLoaiHangByID(id);

            if (MessageBoxEx.Show("Bạn có chắc muốn xóa: " + lh.TenLoai + " không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bll.Delete(lh))
                {
                    dgvLoaiHang.DataSource = bll.LoadAll();
                }
                else
                    MessageBoxEx.Show("Có lỗi xảy ra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvLoaiHang.DataSource = bll.LoadAll();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            dgvLoaiHang.DataSource = bll.SearchByTen(txtTim.Text);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.RemoveCurrentTab();
        }
    }
}
