using HMS.Areas.Dashboard.ViewModels;
using HMS.Services;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();

        // GET: Dashboard/AccomodationTypes
        public ActionResult Index(string searchTerm)
        {
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();

            model.SearchTerm = searchTerm;

            model.AccomodationTypes = accomodationTypesService.SearchAccomodationTypes(searchTerm);
            
            return View(model);
        }

        //public ActionResult Listing()
        //{
        //    AccomodationTypesListingModel model = new AccomodationTypesListingModel();

        //    model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();

        //    return PartialView("_Listing", model);
        //}

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypesActionModel model = new AccomodationTypesActionModel();
            
            if(ID.HasValue) // trying to Edit
            {
                var accomodationType = accomodationTypesService.GetAllAccomodationTypeByID(ID.Value);

                model.ID = accomodationType.ID ;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;

            }
                       
            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypesActionModel model)
        {
            var result=false;
            JsonResult json = new JsonResult();

            if (model.ID > 0) // trying to edit
            {
                var accomodationType = accomodationTypesService.GetAllAccomodationTypeByID(model.ID);

                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;
                
                result = accomodationTypesService.UpdateAccomodationType(accomodationType);

            }
            else            // trying to create
            {
                AccomodationType accomodationtype = new AccomodationType();

                accomodationtype.Name = model.Name;
                accomodationtype.Description = model.Description;
                result = accomodationTypesService.SaveAccomodationType(accomodationtype);

            }

            if (result)
            {
                json.Data = new { success = true };
            }
            else
            {
                json.Data = new { success = false, Messsage = "Unable to perform Actions AccomodationType" };
            }

            return json;

        }


        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationTypesActionModel model = new AccomodationTypesActionModel();

            var accomodationType = accomodationTypesService.GetAllAccomodationTypeByID(ID);

            model.ID = accomodationType.ID;
           
            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationTypesActionModel model)
        {
            var result = false;
            JsonResult json = new JsonResult();

            if (model.ID > 0) // trying to delete
            {
                var accomodationType = accomodationTypesService.GetAllAccomodationTypeByID(model.ID);
                result = accomodationTypesService.DeleteAccomodationType(accomodationType);
            }          

            if (result)
            {
                json.Data = new { success = true };
            }
            else
            {
                json.Data = new { success = false, Messsage = "Unable to perform Actions AccomodationType" };
            }

            return json;
            
        }

    }
}