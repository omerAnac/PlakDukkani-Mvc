using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlakDukkani.BLL.Abstract;
using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.Model.Entities;
using PlakDukkani.ViewModel.AdminViewModels;
using PlakDukkani.ViewModel.Constraints;
using System.Collections.Generic;


namespace PlakDukkani.UI.MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        IAlbumBLL albumService;
        public AdminController(IAlbumBLL albumService)
        {
          this.albumService = albumService;
        }
        public ActionResult Index()
        {
            
            
            ResultService<List<AdminAlbumVM>> albumResult = albumService.GetAlbums();
            if (!albumResult.HasError)
            {
                return View(albumResult.Data);
            }
            else
            {
                ViewBag.Message = albumResult.Errors[0].ErrorMessage;
                return View();
            }
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            ResultService<AdminAlbumVM> albumResult = albumService.GetAlbumByIdForAdmin(id);
            if (albumResult.HasError)
            {
                ViewBag.Message = AlbumMessage.idHatasi;
                return View();
            }
            return View(albumResult.Data);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        
        public ActionResult Edit(AdminAlbumVM result)
        {
            if (ModelState.IsValid)
            {
               bool albumResult = albumService.EditAlbum(result);
                if (albumResult) return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Edit));
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            bool albumResult = albumService.DeleteAlbumById(id);
            if (!albumResult)
            {
                ViewBag.Message = AlbumMessage.idHatasi;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        //POST: AdminController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{


        //}
    }
}
