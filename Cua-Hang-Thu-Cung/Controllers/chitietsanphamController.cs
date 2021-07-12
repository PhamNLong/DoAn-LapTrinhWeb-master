using Cua_Hang_Thu_Cung.DAO;
using Cua_Hang_Thu_Cung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cua_Hang_Thu_Cung.Controllers
{
    public class chitietsanphamController : Controller
    {
        // GET: chitietsanpham
        // DataClasses1DataContext data = new DataClasses1DataContext();
        // SanPhamDAO sanPhamDAO = new SanPhamDAO();
     //   DataClasses1DataContext data = new DataClasses1DataContext();
     //   SanPhamDAO sanPhamDAO = new SanPhamDAO();
        public ActionResult chitietSP()
        {
            //var SanPhamDao = new SanPhamDAO(); 
            
           //ViewBag.tblSanPham
            return View();
        }
    }
}