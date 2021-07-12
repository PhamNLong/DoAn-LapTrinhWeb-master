using Cua_Hang_Thu_Cung.Models;
using Cua_Hang_Thu_Cung.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cua_Hang_Thu_Cung.Controllers
{
    public class SanPhamController : Controller
    {
        //SIMPLE\SQLEXPRESS
        DataClasses1DataContext data = new DataClasses1DataContext();
        SanPhamDAO sanPhamDAO = new SanPhamDAO();

        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }

        /*
        private List<tblSanPham> getAllSanPham()
        {
            var listSanPham = data.tblSanPhams.ToList();
            return listSanPham;
        }
        */

        public ActionResult DanhMucCha(int id)
        {

            List<tblSanPham> listSanPham = new List<tblSanPham>();   //Khoi tao 1 danh sach san pham      
            List<tblDanhMuc> listDanhMuc = sanPhamDAO.getListDanhMuc(id);   //Lay tat ca danh muc chung id_danhmuc_cha
            List<tblSanPham> listAllSP = sanPhamDAO.getListAllSanPham();    //Lay danh sach tat ca san pham

            int iddm;//id danh muc
            foreach (var item in listDanhMuc)
            {
                iddm = item.id_danhmuc;
                foreach (var item1 in listAllSP)
                {
                    if (item1.id_danhmuc == iddm) listSanPham.Add(item1);
                }
            }

            ViewBag.TenDanhMucCha = sanPhamDAO.getDanhMucCha(id).ten_danhmuc_cha;//Lay ten danh muc cha
            ViewBag.ListSanPham = listSanPham;
            ViewBag.SL = listSanPham.Count; // dem so luong san pham 
            return View();
        }


        public ActionResult DanhMuc(int id, int id_dm)
        {
            List<tblSanPham> listSanPham = new List<tblSanPham>();//Khoi tao 1 danh sach san pham    
            List<tblSanPham> listAllSP = sanPhamDAO.getListAllSanPham();//Lay danh sach tat ca san pham

            foreach (var item in listAllSP)
            {
                if (item.id_danhmuc == id_dm) listSanPham.Add(item);
            }

            ViewBag.TenDanhMucCha = sanPhamDAO.getDanhMucCha(id).ten_danhmuc_cha;//Lay ten danh muc cha
            ViewBag.Metaname = sanPhamDAO.getDanhMucCha(id).meta_name;
            ViewBag.ID_DMC = sanPhamDAO.getDanhMucCha(id).id_danhmuc_cha;
            ViewBag.TenDanhMuc = sanPhamDAO.getDanhMuc(id_dm).ten_danhmuc;

            ViewBag.ListSanPham = listSanPham;
            ViewBag.SL = listSanPham.Count;// dem so luong san pham 
            return View();
        }

        public ActionResult SanPham()
        {
            return View();
        }



        [ChildActionOnly]
        public ActionResult Menu(int id)
        {
            ViewBag.ListDanhMucCha = data.tblDanhMucChas.ToList();
            ViewBag.ListDanhMuc1 = data.tblDanhMucs.ToList();
            ViewBag.ID = id; //id danh muc cha hien tai
            return PartialView();
        }


    }
}