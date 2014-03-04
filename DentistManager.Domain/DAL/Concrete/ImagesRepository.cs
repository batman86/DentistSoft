using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Concrete
{
    public class ImagesRepository : IimagesRepository
    {
        public IEnumerable<ImageCategoryViewModel> getImagesCategoryList()
        {
            using(Entities.Entities ctx=new Entities.Entities ())
            {
                IEnumerable<ImageCategoryViewModel> imageCategoryViewModel;

                var imageCategoryIQ= ctx.ImageCategories;

                imageCategoryViewModel= (from ic in imageCategoryIQ
                                        select new ImageCategoryViewModel{ Name= ic.Name, ImageCategoryID= ic.ImageCategoryID}).ToList();
                return imageCategoryViewModel;
            }
        }

        public string getIMageCategoryNameByID(int ImageCategoryID)
        {
             string imageCategoryName;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                imageCategoryName = ctx.ImageCategories.Find(ImageCategoryID).Name;
            }
            return imageCategoryName;
        }
    }
}
