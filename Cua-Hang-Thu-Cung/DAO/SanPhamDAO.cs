using Cua_Hang_Thu_Cung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cua_Hang_Thu_Cung.DAO
{
    public class SanPhamDAO
    {
        DataClasses1DataContext data = new DataClasses1DataContext();


        //Lay tat ca san pham
        public List<tblSanPham> getListAllSanPham()
        {
            var listSanPham = data.tblSanPhams.ToList();
            return listSanPham;
        }

        //Lay Danh_Muc_Cha bang id_danhmuc_cha
        public tblDanhMucCha getDanhMucCha(int id)
        {
            return data.tblDanhMucChas.FirstOrDefault(a => a.id_danhmuc_cha == id);
        }

        //Lay Danh_Muc bang id_danhmuc
        public tblDanhMuc getDanhMuc(int id)
        {
            return data.tblDanhMucs.FirstOrDefault(a => a.id_danhmuc == id);
        }


        //Lay tat ca Danh Muc co chung id_danhmuc_cha
        public List<tblDanhMuc> getListDanhMuc(int id)
        {
            return data.tblDanhMucs.Where(a => a.id_danhmuc_cha == id).ToList();
        }
        


    }
}