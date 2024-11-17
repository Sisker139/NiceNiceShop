using System;
using System.Collections.Generic;

namespace NNShop.Data;

public partial class HangHoa
{
    public string MaHh { get; set; } = null!;

    public string TenHh { get; set; } = null!;

    public int MaLoaiHh { get; set; }

    public string? MoTa { get; set; }

    public string? ChiTietHh { get; set; }

    public double? DonGia { get; set; }

    public string? Hinh { get; set; }

    public double GiamGia { get; set; }

    public int SoLuong { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual LoaiHh MaLoaiHhNavigation { get; set; } = null!;
}
