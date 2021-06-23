using ModelEF;
using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;
using PagedList;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserAccountController : BaseController
    {

        // GET: Admin/UserAccount
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        // GET: Admin/UserAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/UserAccount/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        // POST: Admin/UserAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAccount user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                    long id = dao.Insert(user);
                    if (id > 0)
                        return RedirectToAction("Index","UserAccount");
                    else
                    {
                        ModelState.AddModelError("", "Thêm user mới thành công.");
                    }
                }
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/UserAccount/Edit/5
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        // POST: Admin/UserAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserAccount user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    if(!string.IsNullOrEmpty(user.Password))
                    {
                        var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                        user.Password = encryptedMd5Pas;
                    }
                    var result = dao.Update(user);
                    if (result)
                        return RedirectToAction("Index", "UserAccount");
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật thành công.");
                    }
                }
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/UserAccount/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Admin/UserAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
