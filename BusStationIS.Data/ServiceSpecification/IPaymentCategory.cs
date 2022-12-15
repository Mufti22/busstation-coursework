using BusStationIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.ServiceSpecification
{
    public interface IPaymentCategory
    {
        public IEnumerable<PaymentCategory> GetAll();
        public PaymentCategory GetByName(string categoryName);
    }
}
