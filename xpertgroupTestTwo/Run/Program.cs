using System;
using xpertgroupTestTwo.Model;
using xpertgroupTestTwo.Service;

namespace xpertgroupTestTwo.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            RunService();
        }

        private static void RunService()
        {
            try
            {
                var Factory = new Factory();
                IDataService dataService = Factory.DataServiceConstructor();
                var responseModel = dataService.DataProcess();
                Console.Write(responseModel.Message);
                Console.Read();
            }
            catch (Exception exception)
            {
                // Se muestra informacion. Deberia ir a un log o el visor de eventos de windows
                var responseModel = ErrorManager.ErrorManagerGeneral(exception);
                Console.Write(responseModel.Message);
            }
            
        }
    }
}
