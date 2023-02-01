using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProjeKampı.Controllers
{
    

    public class İstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        EfCategoryDal db= new EfCategoryDal();
        // GET: İstatistik
        public ActionResult Ödev2()
        {
            var toplamkategori = cm.GetList().Count();
            ViewBag.ToplamKategori = toplamkategori;

            var yazılımbaslıksayısı = cm.GetList().Where(x=>x.CategoryName=="Yazılım").Count();
            ViewBag.yb = yazılımbaslıksayısı;


            var aharfliyazar = cm.GetList().Where(x => x.CategoryName == "a").Count();
            ViewBag.AharfliYazar=aharfliyazar;

            var enfazlakategoribaslik=cm.GetList().GroupBy(x=>x.CategoryName).OrderByDescending(x=>x.Count()).Select(x=>x.Key).FirstOrDefault();
            ViewBag.EnFazlaKategoriBaslik=enfazlakategoribaslik;

            var kategoritrue=cm.GetList().Where(x=>x.CategoryStatus==true).Count();
            ViewBag.KategoriTrue=kategoritrue;
            return View();
        }
    }
}