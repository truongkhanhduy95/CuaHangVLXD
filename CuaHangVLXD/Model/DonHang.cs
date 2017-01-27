using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.Model
{
    public abstract class DonHang:IOrderable
    {
        #region Properties
        private DateTime _ngayLap;

        public DateTime NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; }
        }

        private int _tongTien;

        public int TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }

        private int _daTra;

        public int DaTra
        {
            get { return _daTra; }
            set { _daTra = value; }
        }

        private int _conLai;

        public int ConLai
        {
            get { return _conLai; }
            set { _conLai = value; }
        }

        private string _tinhTrang;

        public string TinhTrang
        {
            get { return _tinhTrang; }
            set { _tinhTrang = value; }
        }

        private List<HangHoa> _listHH;

        public List<HangHoa> DSHangHoa
        {
            get { return _listHH; }
            set { _listHH = value; }
        }
        #endregion

        #region Contructor
        public DonHang()
        {
            this._listHH = new List<HangHoa>();
        }
        #endregion
        
        #region Methods
        public void AddHangHoa(HangHoa hanghoa)
        {
            int index = this.DSHangHoa.FindIndex(x => x.MaHH == hanghoa.MaHH);
            if (index == -1)//new HangHoa
                this.DSHangHoa.Add(hanghoa);
            else
            {
                this.DSHangHoa[index].SoLuong += hanghoa.SoLuong;
            }
            this.TongTien = GetTotalPrice();
        }

        public void RemoveHanghoa(HangHoa hanghoa)
        {
            this._listHH.Remove(this._listHH.Find(x => x.MaHH == hanghoa.MaHH));
            this.TongTien = GetTotalPrice();
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;
            foreach (var hang in this.DSHangHoa)
            {
                totalPrice += hang.GiaBan * hang.SoLuong;
            }

            return totalPrice;
        }
        #endregion
    }
}
