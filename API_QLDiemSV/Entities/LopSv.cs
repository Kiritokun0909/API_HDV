using System;
using System.Collections.Generic;

namespace API_QLDiemSV.Entities;

public partial class LopSv
{
    public int MaLopSv { get; set; }

    public string TenLopSv { get; set; } = null!;

    public int MaKhoa { get; set; }

    public virtual Khoa MaKhoaNavigation { get; set; } = null!;

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
