using BusStationIS.Data;
using BusStationIS.Data.Models;
using BusStationIS.Data.ServiceSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusStationIS.Service
{
    public class PaymentCategoryService : IPaymentCategory
    {
        private readonly ApplicationDBContext _context;

        public PaymentCategoryService(ApplicationDBContext context)
        {
            _context = context;
        }
        public IEnumerable<PaymentCategory> GetAll()
        {
            return _context.PaymentCategories;
        }

        public PaymentCategory GetByName(string categoryName)
        {
            return GetAll()
                .FirstOrDefault(pc => pc.Name == categoryName);
        }
    }
}
