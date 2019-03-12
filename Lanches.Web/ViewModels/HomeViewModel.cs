using System.Collections.Generic;
using Lanches.Web.Models;

namespace Lanches.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}