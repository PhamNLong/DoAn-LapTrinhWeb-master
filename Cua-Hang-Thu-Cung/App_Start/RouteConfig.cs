using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cua_Hang_Thu_Cung
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");




            //dang ky
            routes.MapRoute(
                name: "DangKy",
                url: "dang-ky/",
                defaults: new { controller = "User", action = "DangKy", id = UrlParameter.Optional },
                namespaces: new[] { "Cua-Hang-Thu-Cung.Controllers" }
            );


            //hien thi san pham theo danh muc cha
            routes.MapRoute(
                name: "SanPhamDMC",
                url: "danh-muc/{meta-name}-{id}",
                defaults: new { controller = "SanPham", action = "DanhMucCha", id = UrlParameter.Optional },
                namespaces: new[] { "Cua-Hang-Thu-Cung.Controllers" }
            );

            //hien thi san pham theo danh muc
            routes.MapRoute(
                name: "DanhMuc",
                url: "danh-muc/{meta-name}-{id}/{meta-name-dm}-{id_dm}",
                defaults: new { controller = "SanPham", action = "DanhMuc", id = UrlParameter.Optional },
                namespaces: new[] { "Cua-Hang-Thu-Cung.Controllers" }
            );

            //trang chu 
            routes.MapRoute(
                 name: "TrangChu",
                 url: "trang-chu/",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "Cua-Hang-Thu-Cung.Controllers" }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Cua-Hang-Thu-Cung.Controllers" }
            );
        }
    }
}
