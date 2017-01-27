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
    public partial class frmInHoaDon : Form
    {
        HoaDonBLL bll = new HoaDonBLL();
        string maHD;

        public frmInHoaDon(string maHD)
        {
           InitializeComponent();
           this.maHD = maHD;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            CrystalReportHD cr = new CrystalReportHD();
            cr.SetDataSource(bll.TableInHoaDon(maHD));
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
