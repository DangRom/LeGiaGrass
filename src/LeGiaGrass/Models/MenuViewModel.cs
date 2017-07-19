using System.Collections.Generic;

namespace LeGiaGrass.Models{
    public class MenuViewModel{
       public IEnumerable<MenuHeadViewModel> MenuHeads { get; set; }
       public IEnumerable<MenuLineViewModel> MenuLines { get; set; }
    }
}