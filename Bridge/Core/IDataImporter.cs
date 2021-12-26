using System.Collections.Generic;
using Bridge.DAL.Entities;

namespace Bridge.Core
{
    public interface IDataImporter
    {
        IErrorLogger ErrorLogger {get; set;}
        void Import(List<Customer> data);
    }
}