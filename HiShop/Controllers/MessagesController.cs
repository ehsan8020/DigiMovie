using HiShop.Data;
using HiShop.Helpers.Enums;
using HiShop.Models;
using HiShop.Services.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HiShop.Controllers
{
    [Authorize(Roles = "مدیر پیام ها ")]
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISiteEmailSender _emailSender;

        public MessagesController(ApplicationDbContext context , ISiteEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
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

                    //TODO: Send Email To Helpdesk
                    await _emailSender.SendAsync(Helpers.EmailTypes.Info,
                        "ehsan8020@gmail.com",
                        "پیامی از صفحه ارتباط با ما",
                        message.Body,
                        cc: "ne3mer@gmail.com"
                        );
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
            await _context.SaveChangesAsync();

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

        public void ChangeStatus(int id, byte changeCode)
        {
            var message = _context.Messages.Find(id);
            switch (changeCode)
            {
                case (byte)MessageChangeStatus.UnStar:
                    message.IsStarred = false;
                    break;
                case (byte)MessageChangeStatus.Star:
                    message.IsStarred = true;
                    break;
                case (byte)MessageChangeStatus.UnRead:
                    message.IsRead = false;
                    break;
                case (byte)MessageChangeStatus.Read:
                    message.IsRead = true;
                    break;
            }
            _context.Update(message);
            _context.SaveChanges();
        }
    }
}