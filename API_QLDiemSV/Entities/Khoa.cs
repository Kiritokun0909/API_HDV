using System;
using System.Collections.Generic;

namespace API_QLDiemSV.Entities;

public partial class Khoa
{
    public int MaKhoa { get; set; }

    public string TenKhoa { get; set; } = null!;

    public virtual ICollection<GiangVien> GiangViens { get; set; } = new List<GiangVien>();

    public virtual ICollection<LopSv> LopSvs { get; set; } = new List<LopSv>();
}
