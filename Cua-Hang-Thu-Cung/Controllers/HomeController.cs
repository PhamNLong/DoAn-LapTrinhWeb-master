using Cua_Hang_Thu_Cung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cua_Hang_Thu_Cung.Controllers
{
    public class HomeController : Controller
    {
        //SIMPLE\SQLEXPRESS
        DataClasses1DataContext data = new DataClasses1DataContext();

        private List<tblSlider> getSlider()
        {
            return data.tblSliders.ToList(); ;
        }

        private List<tblSanPham> getAllSanPham()
        {
            var listSanPham = data.tblSanPhams.ToList();
            return listSanPham;
        }

        private List<tblSanPham> get8SanPham()
        {
            var listRandomSanPham = data.tblSanPhams.OrderBy(x => Guid.NewGuid()).Where(a => a.noibat == 0 && a.sanphammoi == 0).Take(4).ToList();
            return listRandomSanPham;
        }

        private List<tblSanPham> get8SP_Hot()
        {
            var listRandomSanPham = data.tblSanPhams.OrderBy(x => Guid.NewGuid()).Where(a => a.noibat == 1).Take(8).ToList();
            return listRandomSanPham;
        }

        private List<tblSanPham> get8SP_New()
        {
            var listRandomSanPham = data.tblSanPhams.OrderBy(x => Guid.NewGuid()).Where(a => a.sanphammoi == 1).Take(8).ToList();
            return listRandomSanPham;
        }


        public ActionResult Index()
        {
            //
            ViewBag.ListSlider = getSlider();
            ViewBag.List8SanPham = get8SanPham();
            ViewBag.ListSP_Hot = get8SP_Hot();
            ViewBag.ListSP_New = get8SP_New();
            return View();
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            ViewBag.ListDmucCho = data.tblDanhMucChas.Where(a => a.ten_danhmuc_cha.Contains("chó")).OrderBy(n => n.ten_danhmuc_cha).ToList();
            ViewBag.ListDmucMeo = data.tblDanhMucChas.Where(a => a.ten_danhmuc_cha.Contains("mèo")).OrderBy(n => n.ten_danhmuc_cha).ToList();
            return PartialView();
        }

    }
}