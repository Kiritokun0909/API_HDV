using System;
using System.Collections.Generic;

namespace API_SinhVien.Entities;

public partial class MonHoc
{
    public int MaMh { get; set; }

    public string TenMh { get; set; } = null!;

    public int TsChuyenCan { get; set; }

    public int TsBaiTap { get; set; }

    public int TsKiemTra { get; set; }

    public int TsThucHanh { get; set; }

    public int TsThi { get; set; }

    public int SoTc { get; set; }

    public virtual ICollection<LopTinChi> LopTinChis { get; set; } = new List<LopTinChi>();
}
