using System;
using System.IO;
using xpertgroupTestTwo.Model;

namespace xpertgroupTestTwo.Service
{
    public static class ValidatorHelper
    {
        public static ResponseModel ValidateConfiguracionModel(ConfigurationModel configurationModel)
        {
            if (!File.Exists(configurationModel.DataPath))
                return ErrorManager.ErrorManagerGeneral($"{ConstantsMessage.ERROR_GENERAL} {ConstantsMessage.FILE_DATA_NOT_EXISTS}");

            if(string.IsNullOrEmpty(configurationModel.LetterBovino))
                return ErrorManager.ErrorManagerGeneral($"{ConstantsMessage.ERROR_GENERAL} {ConstantsMessage.IDENTIFIER_BOVINO}");


            if (!Directory.Exists(configurationModel.BasePath))
                Directory.CreateDirectory(configurationModel.BasePath);

            return new ResponseModel { Response = true };
        }
    }
}
