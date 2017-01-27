using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangVLXD.Model
{
    interface IOrderable
    {
        void AddHangHoa(HangHoa hanghoa);
        int GetTotalPrice();
        void RemoveHanghoa(HangHoa hanghoa);
    }
}
