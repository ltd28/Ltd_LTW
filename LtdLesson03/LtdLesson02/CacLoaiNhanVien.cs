using System;
namespace LtdLesson02
{
    public class NhanVienChinhThuc : Employee
    {
        public double phuCap { get; set; }

        public NhanVienChinhThuc() : base()
        {
            phuCap = 0;
        }

        public NhanVienChinhThuc(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam, float luongCoBan)
            : base(maNV, hoTen, phongBan, ngayVaoLam, luongCoBan)
        {
            phuCap = 0;
        }
        public override void nhap()
        {
            base.nhap();
            System.Console.WriteLine("Nhap phu cap: ");    phuCap = double.Parse(Console.ReadLine());
        }
        public override double CalculateSalary()
        {
            return luongCoBan + phuCap;
        }
    }
    public class NhanVienThuViec : Employee
    {
        public NhanVienThuViec() : base() { }

        public NhanVienThuViec(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam, float luongCoBan)
        : base(maNV, hoTen, phongBan, ngayVaoLam, luongCoBan)
        {
            
        }
        public override double CalculateSalary()
        {
            return luongCoBan * 0.85;
        }
    }
    public class NhanVienThoiVu : Employee
    {
        public double soGioLam { get; set;}
        public double donGiaGio { get; set;}
        public NhanVienThoiVu() : base()
        {
            soGioLam = 0;
            donGiaGio = 0;
        }

        public NhanVienThoiVu(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam, float luongCoBan): base(maNV, hoTen, phongBan, ngayVaoLam, 0f)
        {
            soGioLam = 0;
            donGiaGio = 0;
        }
        public override void nhap()
        {
            System.Console.WriteLine("Nhap ma: "); maNV = Console.ReadLine();
            System.Console.WriteLine("Nhap ten: "); hoTen = Console.ReadLine();
            System.Console.WriteLine("Nhap phong: "); phongBan = Console.ReadLine();
            System.Console.WriteLine("Nhap ngay vao: "); ngayVaoLam = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            System.Console.WriteLine("Nhap so gio lam: ");   soGioLam = double.Parse(Console.ReadLine());
            System.Console.WriteLine("Nhap don gia gio: "); donGiaGio = double.Parse(Console.ReadLine());
        }
        public override double CalculateSalary()
        {
            return soGioLam * donGiaGio;
        }
    }
    public class NhanVienKinhDoanh : Employee
    {
        public double doanhSo { get; set;}
        public double tyLeHoaHong { get; set;}
        public NhanVienKinhDoanh() : base()
        {
            doanhSo = 0;
            tyLeHoaHong = 0;
        }

        public NhanVienKinhDoanh(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam, float luongCoBan): base(maNV, hoTen, phongBan, ngayVaoLam, luongCoBan)
        {
            doanhSo = 0;
            tyLeHoaHong = 0;
        }
          public override void nhap()
        {
            base.nhap();
            System.Console.WriteLine("Nhap doanh so: ");   doanhSo = double.Parse(Console.ReadLine());
            System.Console.WriteLine("Nhap ty le hoa hong: "); tyLeHoaHong = double.Parse(Console.ReadLine());
        }
        public override double CalculateSalary()
        {
            return luongCoBan + doanhSo * tyLeHoaHong;
        }
    }
}