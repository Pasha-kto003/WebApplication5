﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Index()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            ViewData["content"] = $"Теперь ваша роль {role}";
            return View(await db.Users.ToListAsync());
        }
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Users()
        {
            return View(await db.Users.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.ID == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete"), Authorize(Roles = "admin")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.ID == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpPost]
        [ActionName("Delete"), Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Phone phone = new Phone { ID = id.Value };
                db.Entry(phone).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.ID == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }
        [HttpPost, ActionName("Edit"), Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(Phone phone)
        {
            db.Phones.Update(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(Phone phone)
        {
          
            db.Phones.Add(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult About()
        {
            return View();
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Contacts()
        {
            return View();
        }

        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Phone()
        {
            return View(await db.Phones.ToListAsync());
        }

        public IActionResult AddBuy(int? id)
        {
            var email = User.Identity.Name;
            if(id != null)
            {
                User user = db.Users.FirstOrDefault(p => p.Email == email);
                Phone phone = db.Phones.FirstOrDefault(p => p.ID == id);
                Buy buy = new Buy { PhoneID = phone.ID, UserID = user.Id };
                db.Buys.Add(buy);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
            
        }
        [Authorize(Roles ="admin")]
        public IActionResult Buy()
        {
            List<Phone> Phones = db.Phones.ToList();
            List<User> Users = db.Users.ToList();
            return View(db.Buys.ToList());
        }


        public IActionResult Information()
        {
            return View();
        }
    }
}
