using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission13.Models;

namespace Mission13.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBowlerRepository repo { get; set; }
        public TypesViewComponent(IBowlerRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["Team"];

            var types = repo.Bowler
                .OrderBy(x => x);
            return View(types);
        }
    }
}
