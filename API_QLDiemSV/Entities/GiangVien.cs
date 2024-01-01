using System;
using System.Collections.Generic;

namespace API_QLDiemSV.Entities;

public partial class GiangVien
{
    public int MaGv { get; set; }

    public string Ho { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public int MaKhoa { get; set; }

    public int MaQuyen { get; set; }

    public string MatKhau { get; set; } = null!;

    public virtual Khoa MaKhoaNavigation { get; set; } = null!;

    public virtual Quyen MaQuyenNavigation { get; set; } = null!;
}
