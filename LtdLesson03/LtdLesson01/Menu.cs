using System;
using System.Collections.Generic;
using static LtdLesson01.Program;
namespace LtdLesson01{
    internal class MeNu {
        
        //ham main
        static void Main(string[] args){
            Console.WriteLine("Ltd Lesson01");
            string choice;
            List<SinhVien> students = new List<SinhVien>()
            {
                new SinhVien { maSV = "SV001", hoTen = "Nguyen Van A", ngaySinh = new DateTime(2000, 1, 1), gioiTinh = true, eMail = "nguyenvana@example.com", sDT = "0123456789", nganhHoc = "CNTT", dTB = 8.5f, trangThai = true } ,
                new SinhVien { maSV = "SV002", hoTen = "Tran Thi B", ngaySinh = new DateTime(2001, 2, 2), gioiTinh = false, eMail = "Chungtrinhj@gmaii.com", sDT = "0987654321", nganhHoc = "Kinh te", dTB = 7.2f, trangThai = true }
            };
            do
            {
                // menu
                ChucNang();
                Console.Write("Nhập lựa chọn của bạn: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Nhập thông tin sinh viên
                        ThemSinhVien(students);
                        break;
                    case "2":
                        // Hiển thị thông tin sinh viên
                        HienThi(students);
                        break;
                    case "3":
                         // Tìm theo mã
                         TimTheoMa(students);
                         break;
                    case "4":
                         //Tìm gần đúng theo tên
                         TimGanDung(students);
                         break;
                    case "5":
                         CapNhatSinhVien(students);
                         break;
                    case "6":
                         XoaSinhVien(students);
                         break;
                    case "7":
                         SapXepTheoHoTen(students);
                        break;
                    case "8":
                         SapXepTheoDiemTrungBinh(students);
                        break;
                    case "9":
                         SinhVienCoDiemTu8(students);
                        break;
                    case "10":
                         SinhVienCoDiemTBCaoNhat(students);
                        break;
                    case "11":
                         DiemTBToanBoSV(students);
                        break;
                    case "12":
                         ThongKeTheoNganh(students);
                        break;
                    case "13":
                         TheoTrangThai(students);
                        break;
                    case "14":
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

            } while (choice != "14");

        }
         static void ChucNang()
        {
            Console.WriteLine("==== MENU ====");
            Console.WriteLine("1. Nhập thông tin sinh viên");
            Console.WriteLine("2. Hiển thị thông tin sinh viên");
            Console.WriteLine("3. Tìm sinh viên theo mã");
            Console.WriteLine("4. Tìm gần đúng theo tên");
            Console.WriteLine("5. Cập nhật thông tin sinh viên");
            Console.WriteLine("6. Xóa sinh viên theo mã");
            Console.WriteLine("7. Sắp xếp theo họ tên");
            Console.WriteLine("8. Sắp xếp theo điểm trung bình");
            Console.WriteLine("9. Hiển thị sinh viên có điểm từ 8 trở lên.");
            Console.WriteLine("10. Hiển thị sinh viên có điểm cao nhất.");
            Console.WriteLine("11. Hiển thị sinh viên có điểm cao nhất.");
            Console.WriteLine("12. Thống kê sinh viên theo ngành.");
            Console.WriteLine("13. Thống kê sinh viên theo trạng thái.");
            Console.WriteLine("14. Thoát");
        }
    }
}