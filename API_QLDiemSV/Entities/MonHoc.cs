using System;
using System.Collections.Generic;

namespace API_QLDiemSV.Entities;

public partial class MonHoc
{
    public int MaMh { get; set; }

    public string TenMh { get; set; } = null!;

    public int TschuyenCan { get; set; }

    public int TsbaiTap { get; set; }

    public int TskiemTra { get; set; }

    public int TsthucHanh { get; set; }

    public int Tsthi { get; set; }

    public int SoTc { get; set; }

    public virtual ICollection<LopTinChi> LopTinChis { get; set; } = new List<LopTinChi>();
}
