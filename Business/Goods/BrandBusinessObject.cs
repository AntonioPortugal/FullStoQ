using Recodme.RD.FullStoQ.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.RD.FullStoQ.Business.Goods
{
    public class BrandBusinessObject : NamedEntity
    {
        private BrandDataAccessObject _dao;
        public BookingBusinessObject()
        {
            _dao = new BookingDataAccessObject();
        }
    }
}
