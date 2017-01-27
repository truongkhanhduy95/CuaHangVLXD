using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.Model
{
    public class NhaCungCap:DoiTac
    {
        #region Contructor

        public NhaCungCap()
        {

        }

        public NhaCungCap(System.Data.DataRow item)
        {
            this.Ma=item["MaNCC"].ToString();
            this.Ten = item["TenNCC"].ToString();
            this.DiaChi = item["DiaChi"].ToString();
            this.Email = item["Email"].ToString();
            this.SoDienThoai = item["SoDienThoai"].ToString();

        }

        public NhaCungCap(string ma, string ten, string dchi, string email, string sdt):base(ma,ten,dchi,email,sdt)
        {
        }

        public NhaCungCap(string tenNCC, string diaChi):base(tenNCC,diaChi)
        {
        }

        #endregion
    }
}
