
using System;
using System.Collections.Generic;

namespace LtdLesson01 {
  public static class Program {
//them sinh vien
    public static void ThemSinhVien(List<SinhVien> student){
       SinhVien sv = new SinhVien();
       System.Console.WriteLine("Nhap ma sinh vien: ");
       sv.maSV = System.Console.ReadLine();
       System.Console.WriteLine("Nhap ten sinh vien: ");
       sv.hoTen = System.Console.ReadLine();
       System.Console.WriteLine("Nhap ngay sinh: ");
       sv.ngaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
       System.Console.WriteLine("Nhap gioi tinh: ");
       sv.gioiTinh = bool.Parse(System.Console.ReadLine());
       System.Console.WriteLine("Nhap email: ");
       sv.eMail = System.Console.ReadLine();
       System.Console.WriteLine("Nhap so dien thoai: ");
       sv.sDT = System.Console.ReadLine();
       System.Console.WriteLine("Nhap nganh hoc: ");
       sv.nganhHoc = System.Console.ReadLine();
       System.Console.WriteLine("Nhap diem trung binh: ");
       sv.dTB = float.Parse(System.Console.ReadLine());
       System.Console.WriteLine("Nhap trang thai: ");
       sv.trangThai = bool.Parse(System.Console.ReadLine());
       student.Add(sv);
    }

//hien thi danh sach sinh vien
    public static void HienThi(List<SinhVien> student)
    {
      System.Console.WriteLine("----Danh sach sinh vien---");
      foreach(var sv in student)
      {
        System.Console.WriteLine("MaSV: " + sv.maSV);
        System.Console.WriteLine("Ho ten: " + sv.hoTen);
        System.Console.WriteLine("Ngay sinh: " + sv.ngaySinh);
        System.Console.WriteLine("Gioi tinh: " + sv.gioiTinh);
        System.Console.WriteLine("Email: " + sv.eMail);
        System.Console.WriteLine("SDT: " + sv.sDT);
        System.Console.WriteLine("Nganh hoc: " + sv.nganhHoc);
        System.Console.WriteLine("Diem trung binh: " + sv.dTB);
        System.Console.WriteLine("Trang thai: " + sv.trangThai);
      }
    }

//Tim sinh vien theo ma
    public static void TimTheoMa(List<SinhVien> student)
    {
      string ma = System.Console.ReadLine();
      SinhVien sinhVienTimThay = null;
      foreach(var sv in student)
      {
        if(sv.maSV == ma)
        {
          sinhVienTimThay = sv;
          break;
        }
      }
      if(sinhVienTimThay != null)
      {
        System.Console.WriteLine("Thong tin sinh vien co ma: " + ma);
        System.Console.WriteLine("MaSV: " + sinhVienTimThay.maSV);
        System.Console.WriteLine("Ho ten: " + sinhVienTimThay.hoTen);
        System.Console.WriteLine("Ngay sinh: " + sinhVienTimThay.ngaySinh);
        System.Console.WriteLine("Gioi tinh: " + sinhVienTimThay.gioiTinh);
        System.Console.WriteLine("Email: " + sinhVienTimThay.eMail);
        System.Console.WriteLine("SDT: " + sinhVienTimThay.sDT);
        System.Console.WriteLine("Nganh hoc: " + sinhVienTimThay.nganhHoc);
        System.Console.WriteLine("Diem trung binh: " + sinhVienTimThay.dTB);
        System.Console.WriteLine("Trang thai: " + sinhVienTimThay.trangThai);
      
      }
      else System.Console.WriteLine("Khong co sinh vien nao co ma: " + ma);
    }


// tim gan dung theo ho ten
public static void TimGanDung(List<SinhVien> student)
    {
      string ten = System.Console.ReadLine();
      List<SinhVien> kq = new List<SinhVien>();
      foreach(var sv in student)
      {
        if(sv.hoTen.Contains(ten)){
        kq.Add(sv);
        }
      }
      if(kq.Count > 0)
      {
        System.Console.WriteLine("Cac sinh vien tim thay: ");
        foreach(var sv in kq)
        {
          System.Console.WriteLine("MaSV: " + sv.maSV);
          System.Console.WriteLine("Ho ten: " + sv.hoTen);
          System.Console.WriteLine("Ngay sinh: " + sv.ngaySinh);
          System.Console.WriteLine("Gioi tinh: " + sv.gioiTinh);
          System.Console.WriteLine("Email: " + sv.eMail);
          System.Console.WriteLine("SDT: " + sv.sDT);
          System.Console.WriteLine("Nganh hoc: " + sv.nganhHoc);
          System.Console.WriteLine("Diem trung binh: " + sv.dTB);
          System.Console.WriteLine("Trang thai: " + sv.trangThai);
        }
      } else System.Console.WriteLine("Khong co sinh vien nao co ten gan giong");
    }

//cap nhat sinh vien
    public static void CapNhatSinhVien(List<SinhVien> student)
    {
      string ma = System.Console.ReadLine();
      Boolean check = false;
      SinhVien  svCanSua = null;
      foreach(var sv in student)
      {
        if(sv.maSV == ma)
        {
          check = true;
          svCanSua = sv;
          break;
        }
      }
      if(!check) {
        System.Console.WriteLine("Khong tim thay sinh vien co ma: "+ma);
      }else //tim thay
      {
        Console.WriteLine("Nhap thong tin moi:");

        Console.Write("Nhap ten sinh vien: ");
        svCanSua.hoTen = Console.ReadLine();

        Console.Write("Nhap ngay sinh: ");
        svCanSua.ngaySinh = DateTime.Parse(Console.ReadLine());

        Console.Write("Nhap gioi tinh: ");
        svCanSua.gioiTinh = bool.Parse(Console.ReadLine());

        Console.Write("Nhap email: ");
        svCanSua.eMail = Console.ReadLine();

        Console.Write("Nhap so dien thoai: ");
        svCanSua.sDT = Console.ReadLine();

        Console.Write("Nhap nganh hoc: ");
        svCanSua.nganhHoc = Console.ReadLine();

        Console.Write("Nhap diem trung binh: ");
        svCanSua.dTB = float.Parse(Console.ReadLine());

        Console.Write("Nhap trang thai: ");
        svCanSua.trangThai = bool.Parse(Console.ReadLine());

        Console.WriteLine("Cap nhat thanh cong!");
      }
    }


//xoa sinh vien
public static void XoaSinhVien(List<SinhVien> student)
    {
      string ma = Console.ReadLine();
      Boolean check = false;
      SinhVien svCanXoa = null;
      foreach(var sv in student)
      {
        if(sv.maSV == ma)
        {
          check = true;
          svCanXoa = sv;
          break;
        }
      }
      if (!check)
      {
        System.Console.WriteLine("Khong tim thay sinh vien nao co ma: " + ma);
      }else
      {
        student.Remove(svCanXoa);
        System.Console.WriteLine("Da xoa thanh cong!");
      }
    }


//sap xep theo ho ten
public static void SapXepTheoHoTen(List<SinhVien> student)
    {
      student.Sort((x, y) => x.hoTen.CompareTo(y.hoTen));
      Console.WriteLine("Da sap xep danh sach theo ho ten tang dan!");
      HienThi(student);
    }
//sap xep theo diem trung binh
public static void SapXepTheoDiemTrungBinh(List<SinhVien> student)
    {
      student.Sort((x, y) => x.dTB.CompareTo(y.dTB));
      Console.WriteLine("Da sap xep danh sach theo diem trung binh tang dan!");
      HienThi(student);
    }
//hien thi sinh vien co diem tu 8 tro len
public static void SinhVienCoDiemTu8(List<SinhVien> student){
  List<SinhVien> tu8 = new List<SinhVien>();
  Boolean check1 = false;
  foreach(var sv in student){
    if(sv.dTB >= 8)
        {
          tu8.Add(sv);
          check1 = true;
        }
  }
  System.Console.WriteLine("====Danh sach sinh vien co diem tren 8 la=====");
  if(!check1) System.Console.WriteLine("Khong co sinh vien nao co diem tren 8\n");
  else {
    HienThi(tu8);
  }
}
//hien thi sinh vien co diem cao nhat
public static void SinhVienCoDiemTBCaoNhat(List<SinhVien> student){
  System.Console.WriteLine("====DANH SACH SINH VIEN CO DIEM TRUNG BINH CAO NHAT=====");
   if (student.Count == 0)
    {
        Console.WriteLine("Danh sach sinh vien dang rong!");
        return;
    }
  List<SinhVien> max = new List<SinhVien>();
  float maxValue = float.MinValue;
  foreach(var sv in student){
    if(sv.dTB >= maxValue){
      maxValue = sv.dTB;
    }
  }
  foreach(var sv in student){
    if(sv.dTB == maxValue)
    max.Add(sv);
  }
  HienThi(max);
}
//tinh diem trung binh toan bo sinh vien
public static void DiemTBToanBoSV(List<SinhVien> student)
{
    if (student.Count == 0)
    {
        Console.WriteLine("Danh sach sinh vien dang rong!");
        return;
    }

    float tongDiem = 0;

    foreach (var sv in student)
    {
        tongDiem += sv.dTB;
    }

    float diemTrungBinh = tongDiem / student.Count;

    Console.WriteLine($"Diem TB toan bo sinh vien la: {diemTrungBinh:F2}");
}
//thong ke sinh vien theo nganh
public static void ThongKeTheoNganh(List<SinhVien> student){
List<string> nganh = new List<string>();
foreach(var sv in student){
  if(!nganh.Contains(sv.nganhHoc)){
    nganh.Add(sv.nganhHoc);
  }
}
foreach(var n in nganh){
  Console.WriteLine("====DANH SACH SINH VIEN THEO NGANH: " + n + " ====");
  foreach(var sv in student){
    if(sv.nganhHoc == n){
      Console.WriteLine("MaSV: " + sv.maSV);
      Console.WriteLine("Ho ten: " + sv.hoTen);
      Console.WriteLine("Diem trung binh: " + sv.dTB);
    }
  }
}
}
//thong ke sinh vien theo trang thai
public static void TheoTrangThai(List<SinhVien> student){
   Console.WriteLine("====DANH SACH SINH VIEN DANG HOC=====");
   foreach(var sv in student){
    if(sv.trangThai){
      Console.WriteLine(sv.maSV + " - " + sv.hoTen);
    }
   }
   Console.WriteLine("====DANH SACH SINH VIEN DA NGHI=====");
   foreach(var sv in student){
    if(!sv.trangThai){
      Console.WriteLine(sv.maSV + " - " + sv.hoTen);
    }
   }
}
}
}
