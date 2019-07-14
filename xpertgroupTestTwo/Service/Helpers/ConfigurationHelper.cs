using System;
using System.Configuration;
using xpertgroupTestTwo.Model;

namespace xpertgroupTestTwo.Service
{
    public static class ConfigurationHelper
    {
        public static ResponseModel LoadConfiguration()
        {
            try
            {
                if (ConfigurationManager.AppSettings != null && ConfigurationManager.AppSettings.Count > 0)
                {
                    return LoadConfigurationSettings();
                }
                else
                    return ErrorManager.ErrorManagerGeneral(ConstantsMessage.NOT_APPSETTINGS);


            }
            catch (Exception exception)
            {
                return ErrorManager.ErrorManagerGeneral(exception);
            }
        }

        private static ResponseModel LoadConfigurationSettings()
        {
            var configurationModel = new ConfigurationModel
            {
                BasePath = ConfigurationManager.AppSettings["BasePath"],
                LetterBovino = ConfigurationManager.AppSettings["LetterBovinos"],
                DataPath = ConfigurationManager.AppSettings["DataPath"]
            };

            return new ResponseModel
            {
                Information = configurationModel,
                Response = true
            };
        }
    }
}
