using Microsoft.AspNet.Mvc;
using PersonnelManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelManager.Controllers
{
    [Route("api/administrators")]
    public class AdministratorsController : Controller
    {
        private IAdministratorDomainService _administratorService;

        public AdministratorsController(IAdministratorDomainService administratorService)
        {
            _administratorService = administratorService;
        }

        public ActionResult Get()
        {
            var administrators = _administratorService.Get();

            if (administrators == null)
            {
                return HttpNotFound("No administrators found.");
            }

            return new JsonResult(administrators);
        }

        [Route("id")]
        public ActionResult Get(int id)
        {
            //not a valid id, should only allow integer values
            if (id == 0)
            {
                return HttpBadRequest("Administrator could not be retreived. Administrator id:" + id + " is not a valid administrator id.");
            }

            var administrators = _administratorService.Get(id);

            if (administrators == null)
            {
                return HttpNotFound("No administrator found with that id.");
            }

            return new JsonResult(administrators);
        }
    }
}
