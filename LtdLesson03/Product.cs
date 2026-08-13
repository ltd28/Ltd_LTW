using System;
using System.Collections.Generic;
namespace LtdLesson03
{
    public class Product
    {
        public string maSP {get; set;}
        public string tenSP{get; set;}
        public string danhMuc {get; set;} ="";
        public double gia {get; set;}
        public int soLuongTon {get; set;}
        public string nhaCungCap {get; set;} = string.Empty;      
        public HashSet<string> tags {get; set;} = new();
        public DateTime ngayTao {get; set;}
        public override string ToString()
{
    string tagsText = (tags != null && tags.Count > 0) 
        ? string.Join(", ", tags) 
        : "Không có";

    return $"Ma: {maSP} | Ten SP: {tenSP} | Danh Muc: {danhMuc} | Gia: {gia} | So Luong Ton: {soLuongTon} | NCC: {nhaCungCap} | Tags: [{tagsText}] | Ngay Tao: {ngayTao}";
}
    }
    public interface IRespository<T>
    {
        void Add(T entity);
        bool Update(T entity);
        bool Delete(string id);
        T? GetById(String id);
        IReadOnlyList<T> GetAll();
    }
    //
    public class ProductRespository : IRespository<Product>
    {
        //Tạo danh sach lưu trữ sản phẩm
        private  List<Product> products = new();
        //thêm
        public void Add(Product prd)
        {
            products.Add(prd);
        }
        //2.tìm theo mã
        public Product? GetById(string id)
        {
            foreach(var a in products)
            {
                //so sanh ma
                if(a.maSP.ToLower() == id.ToLower())
                {
                    return a;
                }
            }
            return null;
        }

        //3. Cap nhat
        public bool Update(Product prd)
        {
            var oldProduct = GetById(prd.maSP);
            if(oldProduct == null) return false;
            //xoa sp cu
            products.Remove(oldProduct);
            products.Add(prd);
            return true;
        }

        //4.xoa
        public bool Delete(string id)
        {
            var product = GetById(id);
            if(product == null) return false;
            products.Remove(product);
            return true;
        }

        //5. lay all
        public IReadOnlyList<Product> GetAll()
        {
            return products;
        }
    }
}