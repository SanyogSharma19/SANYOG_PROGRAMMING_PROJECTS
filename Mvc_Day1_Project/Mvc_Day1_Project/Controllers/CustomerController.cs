using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Day1_Project.Models;

namespace Mvc_Day1_Project.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        customermodel customermodelObj;
        CustomerDataModel customerDataModelObj;

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public CustomerController()
        {
            customermodelObj = new customermodel();

            customerDataModelObj = new CustomerDataModel();
        }

        [HttpGet]
        public ActionResult RegisterPage()
        {
            return View();
        }
    

        [HttpPost]
        public ActionResult RegisterPage(customermodel customer)
        {
            try
            { int RegisterStatus = customerDataModelObj.RegisterCustomers(customer);

                if (RegisterStatus > 0)
                {

                   // ViewBag.RegisterStatus = "Customer Registered";

                    return RedirectToAction("Details Page");

                }
                else
                {

                    ViewBag.RegisterStatus = "Customer Not Registered,Please Check";
                }




            }catch(Exception ex) { 
            ViewBag.ExceptionMessage=ex.Message;    
            
            }

            return View();
        }

        [HttpPost]


        public ActionResult Register(FormCollection forms)
        {
            try
            {
                customermodelObj = new customermodel()
                {
                    CustomerId = Convert.ToInt32(forms["txtCustomerId"]),

                    CustomerName = forms["txtCustomerName"],

                    EmailId = forms["txtEmailId"],

                    ContactNumber = Convert.ToInt32(forms["txtContactNumber"])

                };

                ViewBag.something = "test";
                int status = customerDataModelObj.RegisterCustomers(customermodelObj);

                if(status>0) { 
                ViewBag.registerStatus ="Customer Registered";
                }
                else
                {
                    ViewBag.registerStatus = "customer not registered properly";
                }
                

            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage=ex;
            }

            return View();
        }

        public ActionResult DetailsAll()
        {
            try {
            var customers= customermodelObj.GetAllCustomers();   

                return View(customers);
            }

            catch(Exception ex) { 
            ViewBag.ExceptionMessage=ex.Message;
            
            }

            return View();
        }


        public ActionResult Details()
        {
            try
            {

                customermodelObj = customermodelObj.GetCustomer();
                return View(customermodelObj);

            }
            catch (Exception ex)
            {

                ViewData["Exception Message"] = ex.Message;
            }

            //pass customermodel to view model object
            return View();



        }


        public ActionResult DetailsPage()
        {
            try
            {
                var customers = customerDataModelObj.GetCustomers();
                return View(customers);
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
            }
            return View();
        }
    }
}