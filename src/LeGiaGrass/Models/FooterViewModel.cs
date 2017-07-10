using System.Collections.Generic;

namespace LeGiaGrass.Models{
    public class FooterViewModel{
       public CompanyViewModel Company { get; set; }
       public IEnumerable<MenuLineViewModel> LastPost { get; set; }
       public IEnumerable<MenuLineViewModel> Service { get; set; }
    }
}