using System.Collections.Generic;
using LeGiaGrass.Models;

namespace LeGiaGrass.Commons{
    public class SystemVariables{
        public static IEnumerable<MenuHeadViewModel> Categorys { get; set; }
        public static IEnumerable<MenuLineViewModel> Services { get; set; }
    }
}