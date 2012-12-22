using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootstrapExample.Models;
using BootstrapExample.ViewModels;

namespace BootstrapExample.Controllers
{
    public class DefaultController : Controller
    {
        private LeagueContext _context;

        public DefaultController()
        {
            _context = new LeagueContext();
        }

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
                {
                    Teams = _context.Teams.ToList(),
                    Positions = _context.Positions.ToList()
                };

            return View(viewModel);
        }

    }
}
