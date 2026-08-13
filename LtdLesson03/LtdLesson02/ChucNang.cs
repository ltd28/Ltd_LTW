using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace LtdLesson02
{
    internal class ChucNang
    {
        protected List<Employee> nv = new List<Employee>();
        //them nhan vien theo tung loai
        public void ThemNhanVienTheoTungLoai()
        {
            string loai;
            do
            {
                Console.WriteLine("Nhap loai nhan vien ban muon them:\n 1.Nhan Vien Chinh Thuc\n 2. Nhan Vien Thu Viec\n 3. Nhan Vien Thoi Vu\n 4. Nhan Vien Kinh Doanh\n");
                loai = Console.ReadLine();
                Employee epl = null;
                switch (loai)
                {
                    case "1":
                        // TODO: them Nhan Vien Chinh Thuc
                        Console.WriteLine("Them Nhan Vien Chinh Thuc");
                        epl = new NhanVienChinhThuc();
                        break;
                    case "2":
                        // TODO: them Nhan Vien Thu Viec
                        Console.WriteLine("Them Nhan Vien Thu Viec");
                        epl = new NhanVienThuViec();
                        break;
                    case "3":
                        // TODO: them Nhan Vien Thoi Vu
                        Console.WriteLine("Them Nhan Vien Thoi Vu");
                        epl = new NhanVienThoiVu();
                        break;
                    case "4":
                        // TODO: them Nhan Vien Kinh Doanh
                        Console.WriteLine("Them Nhan Vien Kinh Doanh");
                        epl = new NhanVienKinhDoanh();
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
                if(epl != null)
                {
                    epl.nhap();
                    nv.Add(epl);
                    System.Console.WriteLine("Them nhan vien thanh cong!");
                }
            } while (loai != "1" && loai != "2" && loai != "3" && loai != "4");
        }
        //hien thi danh sach nhan vien
        public void HienThi()
        {
            System.Console.WriteLine("==== DANH SACH NHAN VIEN ====");
            if(nv.Count > 0)
            {
                foreach(var employee in nv)
                {
                    System.Console.WriteLine("Ma: " + employee.maNV);
                    System.Console.WriteLine("Ho ten: " + employee.hoTen);
                    System.Console.WriteLine("Phong ban: " + employee.phongBan);
                    System.Console.WriteLine("Ngay vao: " + employee.ngayVaoLam.ToString("dd/MM/yyyy"));
                    System.Console.WriteLine("Luong: " + employee.CalculateSalary());
                    System.Console.WriteLine("-------------------------------");
                }
            }
            else
            {
                System.Console.WriteLine("Danh sach nhan vien trong!");
            }
        }
        //tinh luong tung nhan vien 
        public void TinhLuong()
        {
            System.Console.WriteLine("Bang luong cua cac nhan vien");
            if(nv.Count > 0)
            {
                foreach(var epl in nv)
                {
                    System.Console.WriteLine("Ma: " + epl.maNV + " Ho ten: " + epl.hoTen + "Luong: " + epl.CalculateSalary());
                }
            }else System.Console.WriteLine("Danh sach nhan vien trong!");
        }
        //tinh tong quy luong
        public void  TongLuong()
        {
            double tong = 0f;
            foreach(var a in nv)
            {
                tong += a.CalculateSalary();
            }
            System.Console.WriteLine("Tong quy luong la: " + tong);
        }
        //tim nhan vien co luong cao nhat
        public void NhanVienLuongCaoNhat()
        {
            List<Employee> b = new List<Employee>();
            double maxValue = double.MinValue;
            if(nv.Count > 0)
            {
                foreach(var a in nv)
                {
                    double salary = a.CalculateSalary();
                    if(maxValue < salary) maxValue = salary;
                }
                foreach(var a in nv)
                {
                    if(Math.Abs(maxValue - a.CalculateSalary()) < 1e-9)
                    {
                        b.Add(a);
                    }
                }
                System.Console.WriteLine("==== DANH SACH NHAN VIEN CO LUONG CAO NHAT ====");
                foreach(var a in b)
                {
                    System.Console.WriteLine("Ma: " + a.maNV + " | Ho ten: " + a.hoTen + " | Phong ban: " + a.phongBan + " | Luong: " + a.CalculateSalary());
                }
            }
            else System.Console.WriteLine("Danh sach nhan vien rong!");
            
        }
        //sap xep nhan vien theo luong
        public void SapXepNhanVienTheoLuong()
        {
           nv.Sort((x,y) => x.CalculateSalary().CompareTo(y.CalculateSalary()));
           foreach(var a in nv)
            {
                System.Console.WriteLine("Ma: " + a.maNV + "Ho ten: " + a.hoTen + "Phong ban: " + a.phongBan + "Luong: " + a.CalculateSalary()); 
            }
        }
        //thong ke luong theo phong ban
        public void ThongKeLuongTheoPhongBan()
        {
            if (nv.Count == 0)
            {
                System.Console.WriteLine("Danh sach nhan vien rong!");
                return;
            }
            var tongTheoPhong = new System.Collections.Generic.Dictionary<string, double>();
            foreach (var e in nv)
            {
                var phongBan = string.IsNullOrEmpty(e.phongBan) ? "(Khong xac dinh)" : e.phongBan;
                if (!tongTheoPhong.ContainsKey(phongBan))
                    tongTheoPhong[phongBan] = 0;
                tongTheoPhong[phongBan] += e.CalculateSalary();
            }
            System.Console.WriteLine("=== THONG KE LUONG THEO PHONG BAN ===");
            foreach (var kv in tongTheoPhong)
            {
                System.Console.WriteLine("Phong ban: " + kv.Key + " | Tong luong: " + kv.Value);
            }
        }

        public void Run()
        {
            while (true)
            {
                System.Console.WriteLine("\n=== QUAN LY NHAN VIEN ===");
                System.Console.WriteLine("1. Them nhan vien");
                System.Console.WriteLine("2. Hien thi danh sach nhan vien");
                System.Console.WriteLine("3. Bang luong cua nhan vien");
                System.Console.WriteLine("4. Tong quy luong");
                System.Console.WriteLine("5. Nhan vien co luong cao nhat");
                System.Console.WriteLine("6. Sap xep nhan vien theo luong");
                System.Console.WriteLine("7. Thong ke luong theo phong ban");
                System.Console.WriteLine("0. Thoat");
                System.Console.Write("Lua chon: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ThemNhanVienTheoTungLoai();
                        break;
                    case "2":
                        HienThi();
                        break;
                    case "3":
                        TinhLuong();
                        break;
                    case "4":
                        TongLuong();
                        break;
                    case "5":
                        NhanVienLuongCaoNhat();
                        break;
                    case "6":
                        SapXepNhanVienTheoLuong();
                        break;
                    case "7":
                        ThongKeLuongTheoPhongBan();
                        break;
                    case "0":
                        System.Console.WriteLine("Thoat chuong trinh.");
                        return;
                    default:
                        System.Console.WriteLine("Lua chon khong hop le. Vui long thu lai.");
                        break;
                }
            }
        }
    }
}
