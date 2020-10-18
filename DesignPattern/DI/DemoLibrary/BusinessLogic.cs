using DemoLibrary.Utilities;
using System;

namespace DemoLibrary
{
    public class BusinessLogic : IBusinessLogic
    {
        //라이브러리끼리는 인터페이스로 다 만들어서 하는구나
        private ILogger _logger;
        private IDataAccess _dataAccess;
        public BusinessLogic(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public void ProcessData()
        {
            //Logger logger = new Logger();
            //DataAccess dataAccess = new DataAccess();
            //빌드 하고 초기화를 시켜줘야 injection할 때 업데이트합니다.
            //어차피 고정값이기때문에 굳이 runtime때 생성할 필요없이 builder를 
            //하면 되지

            
            _logger.Log("Starting the processing of data");
            Console.WriteLine();
            Console.WriteLine("Processing the data");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            _logger.Log("Finished processing of the data.");
        }

    }
}
