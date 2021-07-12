using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cua_Hang_Thu_Cung.Models;
using Cua_Hang_Thu_Cung.DAO;
using System.Web.Security;

namespace Cua_Hang_Thu_Cung.Controllers
{
    public class UserController : Controller
    {

        DataClasses1DataContext data = new DataClasses1DataContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection, tblUser user)
        {
            var hoten = collection["txtHoTen"];
            var email = collection["txtEmail"];
            var makhau = collection["psw"];
            var pswordagain = collection["pswagain"];
            var ngaysinh = string.Format("{0:MM/dd/yyyy}", collection["date"]);
            var sodienthoai = collection["sdt"];
            var diachi = collection["txtAddress"];
            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được để trống";
            }
            else if (string.IsNullOrEmpty(email))
            {
                ViewData["Loi2"] = "email không được để trống";
            }
            else if (string.IsNullOrEmpty(makhau))
            {
                ViewData["Loi3"] = "mật khẩu không được để trống";
            }
            return this.DangKy();
        }





        [HttpGet]
        public ActionResult DangNhap()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            tblUser kh = data.tblUsers.SingleOrDefault(n => n.email == tendn && n.pw == matkhau);

            if (kh != null)
            {
                ViewBag.Thongbao = "Dang nhap thanh cong";
                Session["Taikhoan"] = kh;
                return RedirectToAction("Index", "Home");
            }
            else
                ViewBag.Thongbao = "ten dang nhap hoac mat khua khong dung";

            return View();
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DangNhap(LoginDAO model)
        //{
        //    var result = new AccountDAO().Login(model.Email, model.Password);
        //    if (result == true)
        //    {
        //        if (Membership.ValidateUser(model.Email, model.Password) && ModelState.IsValid)
        //        {
        //            FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
        //    }
        //    return View(model);
        //}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
        //public static string GetMD5(string str)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] fromData = Encoding.UTF8.GetBytes(str);
        //    byte[] targetData = md5.ComputeHash(fromData);
        //    string byte2String = null;

        //    for (int i = 0; i < targetData.Length; i++)
        //    {
        //        byte2String += targetData[i].ToString("x2");

        //    }
        //    return byte2String;
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DangNhap(string email, string password)
        //{
        //    if (ModelState.IsValid)
        //    {



        //        var user = data.tblUsers.SingleOrDefault(s => s.email == email && s.pw == password);
        //        if (user != null)
        //        {
        //            //add session
        //            Session["FullName"] = user.ho_ten;
        //            Session["Email"] = user.email;
        //            Session["idUser"] = user.id_user;
        //            return RedirectToAction("Index","Home");
        //        }
        //        else
        //        {
        //            ViewBag.error = "Login failed";
        //            return RedirectToAction("DangKy", "User");
        //        }
        //    }
        //    return View();
        //}

    }
}