using System;
using System.Collections.Generic;

namespace API_SinhVien.Entities;

public partial class SinhVien
{
    public int MaSv { get; set; }

    public string Ho { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public virtual ICollection<BangDiem> BangDiems { get; set; } = new List<BangDiem>();
}
