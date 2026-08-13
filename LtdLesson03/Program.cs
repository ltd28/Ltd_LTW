using System;
using System.Collections.Generic;

namespace LtdLesson03
{
    internal class Program
    {
        private static ProductRespository repo = new ProductRespository();

        static void Main(string[] args)
        {
        
            List<Product> danhSachMau = new List<Product>()
            {
                new Product { maSP = "P01", tenSP = "Laptop Dell", danhMuc = "Laptop", gia = 15000, soLuongTon = 10, nhaCungCap = "Dell", tags = new HashSet<string> { "Laptop", "Moi" }, ngayTao = DateTime.Now },
                new Product { maSP = "P02", tenSP = "Chuot Logitech", danhMuc = "Phu Kien", gia = 500, soLuongTon = 3, nhaCungCap = "Logitech", tags = new HashSet<string> { "Chuot", "Giare" }, ngayTao = DateTime.Now },
                new Product { maSP = "P03", tenSP = "Ban Phim Co", danhMuc = "Phu Kien", gia = 1200, soLuongTon = 2, nhaCungCap = "Keychron", tags = new HashSet<string> { "BanPhim", "Moi" }, ngayTao = DateTime.Now }
            };

            // Nạp từng sản phẩm mẫu vào repo
            foreach (var p in danhSachMau)
            {
                repo.Add(p);
            }
        
            string choice;
            do
            {
                ChucNang();
                Console.Write("Nhap lua chon cua ban: ");
                choice = Console.ReadLine() ?? "";
                Console.WriteLine("---------------------------------------------");

                switch (choice)
                {
                    case "1": ThemSanPham(); break;
                    case "2": KiemTraMaTrung(); break;
                    case "3": CapNhatSanPham(); break;
                    case "4": XoaSanPham(); break;
                    case "5": TimTheoMa(); break;
                    case "6": TimGanDungTheoTen(); break;
                    case "7": LocTheoDanhMuc(); break;
                    case "8": LocSapHetHang(); break;
                    case "9": SapXepTheoGia(); break;
                    case "10": TinhTongTonKho(); break;
                    case "11": ThongKeTheoDanhMuc(); break;
                    case "12": QuanLyTag(); break;
                    case "13":
                        Console.WriteLine("Cam on ban da su dung chuong trinh!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                if (choice != "13")
                {
                    Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (choice != "13");
        }

        static void ChucNang()
        {
            Console.WriteLine("==== QUẢN LÝ SẢN PHẨM ====");
            Console.WriteLine("1.  Thêm sản phẩm.");
            Console.WriteLine("2.  Kiểm tra mã trùng.");
            Console.WriteLine("3.  Cập nhật sản phẩm.");
            Console.WriteLine("4.  Xóa sản phẩm.");
            Console.WriteLine("5.  Tìm theo mã (Dùng Dictionary).");
            Console.WriteLine("6.  Tìm gần đúng theo tên.");
            Console.WriteLine("7.  Lọc theo danh mục.");
            Console.WriteLine("8.  Lọc sản phẩm sắp hết hàng.");
            Console.WriteLine("9.  Sắp xếp theo giá.");
            Console.WriteLine("10. Tính tổng giá trị tồn kho.");
            Console.WriteLine("11. Thống kê số lượng theo danh mục (SortedDictionary).");
            Console.WriteLine("12. Quản lý tag sản phẩm (HashSet).");
            Console.WriteLine("13. Thoát");
        }

        // 1. Thêm sản phẩm
        static void ThemSanPham()
        {
            Console.Write("Nhap ma SP: ");
            string ma = Console.ReadLine() ?? "";

            if (repo.GetById(ma) != null)
            {
                Console.WriteLine("Loi: Ma san pham da ton tai!");
                return;
            }

            Product p = NhapThongTinSanPham(ma);
            repo.Add(p);
            Console.WriteLine("Them san pham thanh cong!");
        }

        // 2. Kiểm tra mã trùng
        static void KiemTraMaTrung()
        {
            Console.Write("Nhap ma can kiem tra: ");
            string ma = Console.ReadLine() ?? "";

            if (repo.GetById(ma) != null)
                Console.WriteLine($"Ma '{ma}' DA TON TAI!");
            else
                Console.WriteLine($"Ma '{ma}' CHUA TON TAI (Co the dung).");
        }

        // 3. Cập nhật sản phẩm
        static void CapNhatSanPham()
        {
            Console.Write("Nhap ma SP can cap nhat: ");
            string ma = Console.ReadLine() ?? "";

            if (repo.GetById(ma) == null)
            {
                Console.WriteLine("Khong tim thay san pham!");
                return;
            }

            Product pMoi = NhapThongTinSanPham(ma);
            repo.Update(pMoi);
            Console.WriteLine("Cap nhat san pham thanh cong!");
        }

        // 4. Xóa sản phẩm
        static void XoaSanPham()
        {
            Console.Write("Nhap ma SP can xoá: ");
            string ma = Console.ReadLine() ?? "";

            if (repo.Delete(ma))
                Console.WriteLine("Xoa san pham thanh cong!");
            else
                Console.WriteLine("Khong tim thay san pham de xoa!");
        }

        // 5. Tìm theo mã (Dùng Dictionary)
        static void TimTheoMa()
        {
            Console.Write("Nhap ma SP can tim: ");
            string ma = Console.ReadLine() ?? "";

            Dictionary<string, Product> dict = new Dictionary<string, Product>();
            foreach (var item in repo.GetAll())
            {
                dict[item.maSP.ToLower()] = item;
            }

            if (dict.ContainsKey(ma.ToLower()))
                Console.WriteLine("Ket qua: " + dict[ma.ToLower()]);
            else
                Console.WriteLine("Khong tim thay san pham!");
        }

        // 6. Tìm gần đúng theo tên
        static void TimGanDungTheoTen()
        {
            Console.Write("Nhap tu khoa ten SP: ");
            string tuKhoa = Console.ReadLine() ?? "";

            int count = 0;
            foreach (var item in repo.GetAll())
            {
                if (item.tenSP.ToLower().Contains(tuKhoa.ToLower()))
                {
                    Console.WriteLine(item);
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("Khong tim thay san pham nao!");
        }

        // 7. Lọc theo danh mục
        static void LocTheoDanhMuc()
        {
            Console.Write("Nhap ten danh muc: ");
            string dm = Console.ReadLine() ?? "";

            int count = 0;
            foreach (var item in repo.GetAll())
            {
                if (item.danhMuc.ToLower() == dm.ToLower())
                {
                    Console.WriteLine(item);
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("Khong co san pham nao!");
        }

        // 8. Lọc sản phẩm sắp hết hàng (<= 5)
        static void LocSapHetHang()
        {
            Console.WriteLine("--- Sản phẩm sắp hết hàng (<= 5) ---");
            int count = 0;
            foreach (var item in repo.GetAll())
            {
                if (item.soLuongTon <= 5)
                {
                    Console.WriteLine(item);
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("Tat ca san pham deu con nhieu hang.");
        }

        // 9. Sắp xếp theo giá
        static void SapXepTheoGia()
        {
            Console.WriteLine("1. Tang dan | 2. Giam dan");
            Console.Write("Chon kieu sap xep: ");
            string opt = Console.ReadLine() ?? "1";

            List<Product> list = new List<Product>(repo.GetAll());
            list.Sort((p1, p2) => opt == "1" ? p1.gia.CompareTo(p2.gia) : p2.gia.CompareTo(p1.gia));

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        // 10. Tính tổng giá trị tồn kho
        static void TinhTongTonKho()
        {
            double tongTien = 0;
            foreach (var item in repo.GetAll())
            {
                tongTien += (item.gia * item.soLuongTon);
            }
            Console.WriteLine($"Tong gia tri hang ton kho: {tongTien:N0} VNĐ");
        }

        // 11. Thống kê theo danh mục (Dùng SortedDictionary)
        static void ThongKeTheoDanhMuc()
        {
            SortedDictionary<string, List<Product>> nhom = new SortedDictionary<string, List<Product>>();

            foreach (var item in repo.GetAll())
            {
                if (!nhom.ContainsKey(item.danhMuc))
                {
                    nhom[item.danhMuc] = new List<Product>();
                }
                nhom[item.danhMuc].Add(item);
            }

            foreach (var kvp in nhom)
            {
                Console.WriteLine($"\n[Danh muc: {kvp.Key}] - So luong: {kvp.Value.Count} SP");
                foreach (var p in kvp.Value)
                {
                    Console.WriteLine($"  + {p.tenSP} | Gia: {p.gia} | Ton: {p.soLuongTon}");
                }
            }
        }

        // 12. Quản lý tag (Dùng HashSet)
        static void QuanLyTag()
        {
            HashSet<string> tatCaTags = new HashSet<string>();

            foreach (var item in repo.GetAll())
            {
                foreach (var tag in item.tags)
                {
                    tatCaTags.Add(tag.ToLower());
                }
            }

            Console.WriteLine($"Tong so Tag duy nhat: {tatCaTags.Count}");
            Console.WriteLine("Danh sach cac Tag: " + string.Join(", ", tatCaTags));
        }

        // Nhập thông tin SP từ bàn phím
        static Product NhapThongTinSanPham(string ma)
        {
            Product p = new Product();
            p.maSP = ma;

            Console.Write("Ten SP: ");
            p.tenSP = Console.ReadLine() ?? "";

            Console.Write("Danh muc: ");
            p.danhMuc = Console.ReadLine() ?? "";

            Console.Write("Gia: ");
            double.TryParse(Console.ReadLine(), out double gia);
            p.gia = gia;

            Console.Write("So luong ton: ");
            int.TryParse(Console.ReadLine(), out int ton);
            p.soLuongTon = ton;

            Console.Write("Nha cung cap: ");
            p.nhaCungCap = Console.ReadLine() ?? "";

            Console.Write("Nhap cac tag (cach nhau bang dau phay): ");
            string chuoiTag = Console.ReadLine() ?? "";
            string[] mangTag = chuoiTag.Split(',');

            p.tags = new HashSet<string>();
            foreach (var t in mangTag)
            {
                if (!string.IsNullOrWhiteSpace(t))
                {
                    p.tags.Add(t.Trim());
                }
            }

            p.ngayTao = DateTime.Now;
            return p;
        }
    }
}