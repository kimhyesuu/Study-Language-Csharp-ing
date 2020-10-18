using DemoLibrary;
using DemoLibrary.Utilities;
using System;

namespace DependencyInjectionDemo
{
    public class BetterBusinessLogic : IBusinessLogic
    {
        private ILogger _logger;
        private IDataAccess _dataAccess;
 
        public BetterBusinessLogic(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public void ProcessData()
        {
            _logger.Log("Starting the processing of data");
            Console.WriteLine();
            Console.WriteLine("Processing the data");
            Console.WriteLine();
            _dataAccess.LoadData();
            Console.WriteLine();
            _dataAccess.SaveData("ProcessedInfo");
            Console.WriteLine();
            _logger.Log("Finished processing of the data.");
        }
    }
}
