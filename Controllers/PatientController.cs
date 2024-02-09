using hallodoc.dto;
using hallodoc.Models;
using hallodoc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace hallodoc.Controllers
{
    public class PatientController : Controller
    {
        private HallodocContext context;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        public PatientController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }

        [ActivatorUtilitiesConstructor]
        public PatientController(HallodocContext context)
        {
            this.context = context;
            
        }

        [HttpGet]   
        public IActionResult Patientlogin()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Patientlogin(LoginDto model)
        {
          

            var email = model.Email;
            var password=model.Password;
            if (email == null)
            {

            }
            if (email != null || password != null)
            {
                var user =context.AspNetUsers.Where(a => a.Email == email).FirstOrDefault();
           
                if (user != null)
                {
                    return RedirectToAction("SubmitRequest", "Home");

                }
                else
                {

                    ModelState.AddModelError("", "Failed to login");
                    return View(model);

              
                }
            }

            return View(model);
        }

        public IActionResult Forgotpassword()
        {

            return View();
        }
        [HttpGet]
        public IActionResult PatientRequest()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult PatientRequest(Patientrequestdto model)
        {
            
            
            var dob = model.dob;
            int day = dob.Day;
            var mon = dob.ToString("MMMM");
            var year = dob.Year;

            RequestClient insertrequestclient = new RequestClient()
            {
                FirstName = model.Firstname,
                LastName = model.Lastname,
                PhoneNumber = model.Phone,
                Email = model.Email,
                Notes = model.Symptoms,
                Street = model.Street,
                City = model.City,
                State = model.State,
                ZipCode = model.Zipcode,
                IntDate = day,
                StrMonth = mon,
                IntYear = year
            };
            if (model.File != null)
            {
                var uniqueFileName = GetUniqueFileName(model.File.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                model.File.CopyTo(new FileStream(filePath, FileMode.Create));

                string GetUniqueFileName(string fileName)
                {
                    fileName = Path.GetFileName(fileName);
                    return Path.GetFileNameWithoutExtension(fileName)
                              + "_"
                              + Guid.NewGuid().ToString().Substring(0, 4)
                              + Path.GetExtension(fileName);
                }

                RequestWiseFile insertfile = new RequestWiseFile()
                {
                    FileName = uniqueFileName,
                    CreatedDate = DateTime.Now,

                };
                context.RequestWiseFiles.Add(insertfile);
                //to do : Save uniqueFileName  to your db table   
            }




            context.RequestClients.Add(insertrequestclient);

            context.SaveChanges();

            return RedirectToAction("Index", "Home");

           // return RedirectToAction("Patientlogin");

        }
        [HttpGet]
        public IActionResult FamilyRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FamilyRequest(Familyrequestdto model)
        {
            Request insertrequest = new()
            {
                RequestTypeId = 3,
                FirstName = model.F_Firstname,
                LastName = model.F_Lastname,
                PhoneNumber = model.F_Phone,
                Email = model.F_Email,
                RelationName = model.F_relation,
                Status = 1,
                CreatedDate=DateTime.Now,
                IsUrgentEmailSent =new BitArray(new bool[1] {false})

            };
            context.Requests.Add(insertrequest);
            var dob = model.dob;
            int day = dob.Day;
            var mon = dob.ToString("MMMM");
            var year = dob.Year;

            RequestClient insertrequestclient = new RequestClient()
            {
                FirstName = model.P_Firstname,
                LastName = model.P_Lastname,
                PhoneNumber = model.P_Phone,
                Email = model.P_Email,
                Notes = model.P_symp,
                Location = model.P_Location,
                IntDate = day,
                StrMonth = mon,
                IntYear = year

            };
            context.RequestClients.Add(insertrequestclient);
            context.SaveChanges();

            return RedirectToAction("Patientlogin");

        }
        [HttpGet]
        public IActionResult ConciergeRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConciergeRequest(Conciergerequestdto model)
        {
            Request insertrequest = new Request()
            {
                RequestTypeId = 4,
                FirstName = model.C_Firstname,
                LastName = model.C_Lastname,
                PhoneNumber = model.C_Phone,

            };
            context.Requests.Add(insertrequest);

            var dob = model.P_dob;
            int day = dob.Day;
            var mon = dob.ToString("MMMM");
            var year = dob.Year;
         

            var name = model.C_Firstname +" " + model.C_Lastname;
            Concierge insertconcierge = new Concierge()
            {
                ConciergeName= name,
                Address = model.C_Location,
                Street = model.C_Street,
                State= model.C_State,
                City= model.C_City,
                ZipCode= model.C_Zipcode,
                CreatedDate=DateTime.Now,
             };
            context.Concierges.Add(insertconcierge);
            RequestClient insertrequestclient = new RequestClient()
            {
                FirstName = model.P_Firstname,
                LastName = model.P_Lastname,
                PhoneNumber = model.P_phone,
                Email = model.P_email,
                Notes = model.P_symp,
                Location = model.P_Location,
                IntDate = day,
                StrMonth = mon,
                IntYear = year



               
            };
            context.RequestClients.Add(insertrequestclient);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult CreatePatient()
        {
            return View();
        }
        public IActionResult BusinessRequest()
        {
            return View();
        }

        public IActionResult PatientDashboard()
        {
            return View();
        }

    }
}
