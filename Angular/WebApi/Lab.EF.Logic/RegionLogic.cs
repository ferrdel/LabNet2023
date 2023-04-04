using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class RegionLogic: BaseLogic,IABMLogic<Region>
    {
        public List<Region> GetAll()
        {
            return northContext.Region.ToList();
        }

        public void Add(Region newRegion)
        {
            northContext.Region.Add(newRegion);

            northContext.SaveChanges();
        }

        public void Update(Region region)
        {
            var regionUpdate = northContext.Region.Find(region.RegionID);

            regionUpdate.RegionDescription = region.RegionDescription;

            northContext.SaveChanges();
        }

        public void Delete(int idRegion)
        {
            var regionDelete = northContext.Region.Find(idRegion);

            northContext.Region.Remove(regionDelete);

            northContext.SaveChanges();
            
        }
    }
}
