using LeGiaGrass.Models;
using System.Linq;

namespace LeGiaGrass.Commons{
    public class Backlink{
        public static BacklinkViewModel GetBacklinkFromCate(string catealias){
            var cate = SystemVariables.Categorys.FirstOrDefault(a => a.Alias == catealias);
            var bk = new BacklinkViewModel(){
                Name = cate.Name,
                Alias = cate.Alias
            };
            return bk;
        }

        public static BacklinkViewModel GetBacklinkFromPost(string postalias){
            var postid = SystemVariables.Services.FirstOrDefault(a => a.Alias == postalias).HeadId;
            var cate = SystemVariables.Categorys.FirstOrDefault(c => c.Id == postid);
            var bk = new BacklinkViewModel(){
                Name = cate.Name,
                Alias = cate.Alias
            };
            return bk; 
        }
    }
}