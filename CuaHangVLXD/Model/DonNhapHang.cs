using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.Model
{
    public class DonNhapHang:DonHang
    {
        #region Properties

        private string _maDNH;

        public string MaDNH
        {
            get { return _maDNH; }
            set { _maDNH = value; }
        }

        private string _maNCC;

        public string MaNCC
        {
            get { return _maNCC; }
            set { _maNCC = value; }
        }
        
        #endregion

        #region Contructor
        public DonNhapHang():base()
        {
        }

        public DonNhapHang(System.Data.DataRow item)
        {
            this.MaDNH =item["MaDNH"].ToString();
            this.MaNCC = item["MaNCC"].ToString();
            this.NgayLap = Convert.ToDateTime(item["NgayNhap"].ToString());
            this.TongTien = int.Parse(item["TongTien"].ToString());
            this.TinhTrang = item["TrangThai"].ToString();
            this.DaTra = int.Parse(item["DaTra"].ToString());
            this.ConLai = int.Parse(item["ConLai"].ToString());          
        }

        #endregion
    }
}
