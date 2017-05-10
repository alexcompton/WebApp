﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repo.DocumentDB;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAll()
        {
            return await DocumentDBRepository<Item>.GetItemsAsync(d => !d.Completed);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task CreateAsync(Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await DocumentDBRepository<Item>.CreateItemAsync(item);
        //    }
        //}

        //[HttpPost]
        //[ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditAsync([Bind("Id,Name,Description,Completed")] Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await DocumentDBRepository<Item>.UpdateItemAsync(item.Id, item);
        //        return RedirectToAction("Index");
        //    }

        //    return View(item);
        //}

        //[ActionName("Edit")]
        //public async Task<ActionResult> EditAsync(string id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }

        //    Item item = await DocumentDBRepository<Item>.GetItemAsync(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(item);
        //}

        //[ActionName("Delete")]
        //public async Task<ActionResult> DeleteAsync(string id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }

        //    Item item = await DocumentDBRepository<Item>.GetItemAsync(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(item);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmedAsync([Bind("Id")] string id)
        //{
        //    await DocumentDBRepository<Item>.DeleteItemAsync(id);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //[ActionName("Details")]
        //public async Task<Item> DetailsAsync(string id)
        //{
        //    return await DocumentDBRepository<Item>.GetItemAsync(id);
        //}
    }
}