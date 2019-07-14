using System;
using xpertgroupTestTwo.Dal;
using xpertgroupTestTwo.Model;

namespace xpertgroupTestTwo.Service
{
    public class Factory
    {
        private ConfigurationModel ConfigurationModelConstructor()
        {
            var responseModel = ConfigurationHelper.LoadConfiguration();
            if(!responseModel.Response)
                throw new Exception( message: responseModel.Message );

            var configurationModel = responseModel.Information as ConfigurationModel;
            return configurationModel;
        }

        public IDataService DataServiceConstructor()
        {
            var configurationModel = ConfigurationModelConstructor();
            var dataAccessDal = new DataAccessDal();
            return new DataService(configurationModel, dataAccessDal);
        }
    }
}
