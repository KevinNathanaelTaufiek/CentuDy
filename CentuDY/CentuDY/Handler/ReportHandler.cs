using CentuDY.Model;
using CentuDY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handler
{
    public class ReportHandler
    {

        public static List<HeaderTransaction> GetTransactions()
        {
            return ReportRepository.GetTransactions();
        }
    }
}