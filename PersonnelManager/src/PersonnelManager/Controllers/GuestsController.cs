using Microsoft.AspNet.Mvc;
using PersonnelManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelManager.Controllers
{
    public class GuestsController : Controller
    {
        private IGuestDomainService _guestService;

        public GuestsController(IGuestDomainService guestService)
        {
            _guestService = guestService;
        }

        public ActionResult Get()
        {
            var guests = _guestService.Get();

            if (guests == null)
            {
                return HttpNotFound("No guests found.");
            }

            return new JsonResult(guests);
        }

        [Route("id")]
        public ActionResult Get(int id)
        {
            //not a valid id, should only allow integer values
            if (id == 0)
            {
                return HttpBadRequest("Guest could not be retreived. Guest id:" + id + " is not a valid Guest id.");
            }

            var guests = _guestService.Get(id);

            if (guests == null)
            {
                return HttpNotFound("No guest found with that id.");
            }

            return new JsonResult(guests);
        }
    }
}
