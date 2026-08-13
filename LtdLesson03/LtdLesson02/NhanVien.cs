using System;
using System.Collections.Generic;

namespace LtdLesson02
{
    public abstract class Employee
    {
        internal string maNV { get; set; }
        internal string hoTen { get; set; }
        internal string phongBan { get; set; }
        internal DateTime ngayVaoLam { get; set; }
        internal float luongCoBan { get; set; }

        //constructor k doi
        public Employee() : this("","","", default, 0f){}

        //constructor co doi so
        public Employee(string maNV = "001", string hoTen = " ", string phongBan = " ", DateTime ngayVaoLam = default, float luongCoBan = 0f)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.phongBan = phongBan;
            this.ngayVaoLam = ngayVaoLam;
            this.luongCoBan = luongCoBan;
        }
        
        public abstract double CalculateSalary();
        //so nam lam viec
        public double SoNamLamViec()
        {
            return (DateTime.Now - ngayVaoLam).TotalDays/365;
        }
        public virtual void nhap(){
            System.Console.WriteLine("Nhap ma: "); maNV = Console.ReadLine();
            System.Console.WriteLine("Nhap ten: "); hoTen = Console.ReadLine();
            System.Console.WriteLine("Nhap phong: "); phongBan = Console.ReadLine();
            System.Console.WriteLine("Nhap ngay vao: "); ngayVaoLam = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            System.Console.WriteLine("Nhap luong co ban: "); luongCoBan = float.Parse(Console.ReadLine());
        }
    }
}