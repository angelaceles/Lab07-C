using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business
{
    public class BInvoice
    {
        public List<Invoice> GetByDate(DateTime date)
        {
            DInvoice data = new DInvoice();
            var invoices = data.Get();
            var result = invoices.Where(x => x.Date == date).ToList();
            return result;
        }
    }
}
