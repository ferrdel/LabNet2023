
using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CustomersLogic: BaseLogic,IABMLogic<Customers>
    {
        public void Add(Customers newT)
        {
            throw new NotImplementedException();
        }

        public void Delete(int idT)
        {
            throw new NotImplementedException();
        }

        public List<Customers> GetAll()
        {
            return northContext.Customers.ToList();
        }

        public void Update(Customers newT)
        {
            throw new NotImplementedException();
        }
    }
}
