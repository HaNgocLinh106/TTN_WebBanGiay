using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiay_285.Models
{
    [Serializable]
    public class GioHangIT
    {
        //đối tượng Giay
        public Giay Giay { get; set; }
        public long SoLuong { get; set; }
    }
}