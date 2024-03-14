using NewsletterApplicationMVC.Models;
using NewsletterApplicationMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterApplicationMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                var signups = db.SignUps.Where(x => x.Removed == null).ToList();
                var signUpVMs = new List<SignUpVM>();
                foreach (var signup in signups)
                {

                    var signUpVM = new SignUpVM();
                    signUpVM.Id = signup.Id;
                    signUpVM.FirstName = signup.FirstName;
                    signUpVM.LastName = signup.LastName;
                    signUpVM.EmailAddress = signup.EmailAddress;
                    signUpVMs.Add(signUpVM);
                }


                return View(signUpVMs);

            }
        }

    public ActionResult Unsubscribe(int Id)
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                
                  var signup = db.SignUps.Find(Id);
                  signup.Removed = DateTime.Now;
                  db.SaveChanges();
            }
               return RedirectToAction("Index");
            }
        }
    }


    
