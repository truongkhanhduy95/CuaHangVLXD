using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.Model
{
    public class HangHoa
    {
        #region Properties
        private string _maHH;

        public string MaHH
        {
            get { return _maHH; }
            set { _maHH = value; }
        }

        private string _tenHH;

        public string TenHH
        {
            get { return _tenHH; }
            set { _tenHH = value; }
        }
        private string _loaiHang;

        public string LoaiHang
        {
            get { return _loaiHang; }
            set { _loaiHang = value; }
        }

        private int _giaGoc;

        public int GiaGoc
        {
            get { return _giaGoc; }
            set { _giaGoc = value; }
        }

        private int _giaBan;

        public int GiaBan
        {
            get { return _giaBan; }
            set { _giaBan = value; }
        }

        private int _soLuong;

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        private string _donViTinh;

        public string DonViTinh
        {
            get { return _donViTinh; }
            set { _donViTinh = value; }
        }

        #endregion

        #region Contructor

        public HangHoa()
        {

        }

        public HangHoa(string id, string tenHH, string loai,
                        int giagoc, int giaban, int soluong, string donvitinh)
        {
            this._maHH = MaHH;
            this._soLuong = soluong;
            this._loaiHang = loai;
            this._giaGoc = giagoc;
            this._giaBan = giaban;
            this._soLuong = soluong;
            this._donViTinh = donvitinh;
        }

        public HangHoa(System.Data.DataRow item)
        {
            this._maHH = item["MaHH"].ToString();
            this._tenHH = item["TenHH"].ToString();
            this._loaiHang = item["LoaiHang"].ToString();
            this._giaGoc = int.Parse(item["GiaGoc"].ToString());
            this._giaBan = int.Parse(item["GiaBan"].ToString());
            this._soLuong = int.Parse(item["SoLuong"].ToString());
            this._donViTinh = item["DonViTinh"].ToString();
        }


        #endregion

    }
}
