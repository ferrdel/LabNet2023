using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class OrdersLogic : BaseLogic, IABMLogic<Orders>
    {
        public void Add(Orders newT)
        {
            throw new NotImplementedException();
        }

        public void Delete(int idT)
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetAll()
        {
            return northContext.Orders.ToList();
        }

        public void Update(Orders newT)
        {
            throw new NotImplementedException();
        }
    }
}
