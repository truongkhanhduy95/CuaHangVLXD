using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CuaHangVLXD.Model;

namespace UnitTesting
{
    [TestClass]
    public class HoaDonTest
    {
        /// <summary>
        /// Test case add same Product into Order
        /// Return 1
        /// </summary>
        [TestMethod]
        public void Test_HoaDon_AddHangHoa_CungLoai()
        {
            //test logical
            HoaDon hd=new HoaDon();
            for (int i = 0; i < 9; i++)
            {
                hd.AddHangHoa(new HangHoa());
            } 
            //check test
            Assert.AreEqual(1,hd.DSHangHoa.Count);
        }

        [TestMethod]
        public void Test_HoaDon_AddHangHoa_KhacLoai()
        {
            HoaDon hd = new HoaDon();
            for (int i = 0; i < 9; i++)
            {
                hd.AddHangHoa(new HangHoa());
            }
            Assert.AreEqual(1, hd.DSHangHoa.Count);
        }


        /// <summary>
        /// Test case remove Product from Order
        /// Return 0
        /// </summary>
        [TestMethod]
        public void Test_HoaDon_RemoveHangHoa()
        {
            HoaDon hd = new HoaDon();    
            hd.AddHangHoa(new HangHoa());
            hd.RemoveHanghoa(new HangHoa());
            Assert.AreEqual(0, hd.DSHangHoa.Count);
        }


        /// <summary>
        /// Test case calculate total price
        /// Return 81000
        /// </summary>
        [TestMethod]
        public void Test_HoaDon_GetTongTien()
        {
            HoaDon hd = new HoaDon();
            for (int i = 0; i < 9; i++)
            {
                hd.AddHangHoa(new HangHoa(i.ToString(), "", "", 0, 3000, 3, ""));
            }
            Assert.AreEqual(81000, hd.GetTotalPrice());
        }

        [TestMethod]
        public void Test_HoaDon_TongHop()
        {
            HoaDon hd = new HoaDon();
            for (int i = 0; i < 9; i++)
            {
                hd.AddHangHoa(new HangHoa());
            }
            Assert.AreEqual(1, hd.DSHangHoa.Count);
        }
    }
}
