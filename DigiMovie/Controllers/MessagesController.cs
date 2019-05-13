using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiMovie.Data;
using DigiMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigiMovie.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Messages.ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    message.RegisteredTime = DateTime.Now;
                    _context.Add(message);
                    await _context.SaveChangesAsync();
                    TempData["MessageCreateStatus"] = "OK";
                }
                catch (Exception e)
                {
                    TempData["MessageCreateStatus"] = e.Message;
                }

            }
            return RedirectToAction("Contact", "Home");
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var message = await _context.Messages.FindAsync(id);
            if (message == null)
                return NotFound();

            //Make Message As Read
            message.IsRead = true;
            _context.Update(message);
           await  _context.SaveChangesAsync();

            return View(message);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var message = await _context.Messages.FindAsync(id);
            if (message == null)
                return NotFound();

            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDone(int id)
        {
            var message = await _context.Messages.FindAsync(id);

            try
            {
                _context.Remove(message);
                await _context.SaveChangesAsync();
                TempData["MessageDeleteStatus"] = "OK";
            }
            catch (Exception e)
            {
                TempData["MessageDeleteStatus"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType">true = star /// false = read</param>
        /// <param name="status">star , read = true /// unstar , unread = false </param>
        public void ChangeStatus(bool eventType , bool status , int id)
        {
            var message =  _context.Messages.Find(id);
            

            if (eventType)
            {
                //Staring
                if(status)
                {
                    //star
                    message.IsStarred = true;
                }
                else
                {
                    //unstar
                    message.IsStarred = false;
                }
            }
            else
            {
                //Reading
                if (status)
                {
                    //read
                    message.IsRead = true;
                }
                else
                {
                    //unread
                    message.IsRead = false;
                }
            }


            _context.Update(message);
            _context.SaveChanges();
        }



        //public  IActionResult Temp()
        //{
        //    int i = 1;
        //    while(i<=80)
        //    {
        //        var message = new Message() {
        //            Name = "پیام نمونه "  + i,
        //            Email = "email" + i + "@gmail.com" ,
        //            Subject = "موضوع " + i,
        //            Body= "متن پیام " + i,
        //            RegisteredTime = DateTime.Now.AddDays(-i)

        //        };
        //        _context.Add(message);
        //        _context.SaveChanges();
        //        i++;
        //    }
        //    return Content(string.Empty);
        //}

    }
}