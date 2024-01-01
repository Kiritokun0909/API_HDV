using System;
using System.Collections.Generic;

namespace API_QLDiemSV.Entities
{
    public class BangDiem1
    {
        public int MaBangDiem { get; set; }

        public int MaLopTc { get; set; }

        public int MaSv { get; set; }

        public double ChuyenCan { get; set; }

        public double BaiTap { get; set; }

        public double KiemTra { get; set; }

        public double ThucHanh { get; set; }

        public double Thi { get; set; }

        public double TongKet { get; set; }

        public virtual LopTinChi1 MaLopTcNavigation { get; set; } = null!;

        public virtual SinhVien1 MaSvNavigation { get; set; } = null!;
    }
}
