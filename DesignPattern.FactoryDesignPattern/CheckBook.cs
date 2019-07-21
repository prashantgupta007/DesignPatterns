using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryDesignPattern
{
    public class CheckBook
    {
        protected decimal _Amount;
        public decimal getExpense()
        {
            return _Amount;
        }
    }
}
