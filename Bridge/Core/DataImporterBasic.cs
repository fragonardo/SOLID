using System;
using Bridge.Core;
using System.Collections.Generic;
using Bridge.DAL.Entities;
using Bridge.DAL.Contexts;

namespace Bridge.Core
{
    public class DataImporterBasic : IDataImporter
    {
        public IErrorLogger ErrorLogger {get; set;}

        protected NorthwindContext context;

        public DataImporterBasic(IErrorLogger logger, NorthwindContext context)
        {
            this.ErrorLogger = logger;
            this.context = context;
        }

        public void Import(List<Customer> data)
        {
            try
            {
                foreach(var customer in data)
                {
                    this.context.Customers.Add(customer);
                }
                this.context.SaveChanges();
            }
            catch(Exception ex)
            {
                this.ErrorLogger.Log(ex.Message);
            }
        }

    }
}