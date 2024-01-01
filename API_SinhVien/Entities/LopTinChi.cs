using System;
using System.Collections.Generic;

namespace API_SinhVien.Entities;

public partial class LopTinChi
{
    public int MaLopTc { get; set; }

    public int MaMh { get; set; }

    public int Nam { get; set; }

    public int Ky { get; set; }

    public virtual ICollection<BangDiem> BangDiems { get; set; } = new List<BangDiem>();

    public virtual MonHoc MaMhNavigation { get; set; } = null!;
}
