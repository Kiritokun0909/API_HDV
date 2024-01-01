using System;
using System.Collections.Generic;

namespace API_QLDiemSV.Entities;

public partial class SinhVien
{
    public int MaSv { get; set; }

    public string Ho { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public int MaLopSv { get; set; }

    public string MatKhau { get; set; } = null!;

    public virtual ICollection<BangDiem> BangDiems { get; set; } = new List<BangDiem>();

    public virtual LopSv MaLopSvNavigation { get; set; } = null!;
}
