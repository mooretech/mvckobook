using System.Collections.Generic;
using BootstrapExample.Models;

namespace BootstrapExample.ViewModels
{
    public class HomeViewModel
    {
        public IList<Team> Teams { get; set; }
        public IList<Position> Positions { get; set; }
    }
}