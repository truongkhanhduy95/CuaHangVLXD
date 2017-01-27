using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.Model
{
    public class HoaDon:DonHang
    {
        #region Properties

        private string _maHD;

        public string MaHD
        {
            get { return _maHD; }
            set { _maHD = value; }
        }

        private string _maKH;

        public string MaKH
        {
            get { return _maKH; }
            set { _maKH = value; }
        }
        
        #endregion

        #region Contructor
        public HoaDon():base()
        {
        }

        public HoaDon(System.Data.DataRow item)
        {
            this.MaHD=item["MaHD"].ToString();
            this.MaKH = item["MaKH"].ToString();
            this.NgayLap = Convert.ToDateTime(item["NgayLap"].ToString());
            this.TongTien = int.Parse(item["TongTien"].ToString());
            this.TinhTrang = item["TrangThai"].ToString();
            this.DaTra = int.Parse(item["DaTra"].ToString());
            this.ConLai = int.Parse(item["ConLai"].ToString());
            
        }
        #endregion

    }
}
