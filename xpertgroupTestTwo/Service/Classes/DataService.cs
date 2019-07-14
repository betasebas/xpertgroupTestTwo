using System;
using System.IO;
using System.Linq;
using xpertgroupTestTwo.Dal;
using xpertgroupTestTwo.Model;

namespace xpertgroupTestTwo.Service
{
    public class DataService : IDataService
    {
        private ConfigurationModel configurationModel;
        private DataAccessDal dataAccessDal;
        private const string NAME_FILE_BOVINOS = "Bovinos";
        private const string NAME_FILE_EQUINOS = "Equinos";

        public DataService(ConfigurationModel configurationModel, DataAccessDal dataAccessDal)
        {
            this.configurationModel = configurationModel;
            this.dataAccessDal = dataAccessDal;
        }
        public ResponseModel DataProcess()
        {
            ResponseModel responseModel = ValidatorHelper.ValidateConfiguracionModel(configurationModel);
            if (!responseModel.Response)
                return responseModel;

            string[] data = LoadFile();
            if(data.Length < 1)
                return ErrorManager.ErrorManagerGeneral(ConstantsMessage.ERROR_NOT_DATA_FILE);
    
            return RegisterPesebrera(data);
        }

        private string[] LoadFile()
        {
            return File.ReadAllLines(configurationModel.DataPath);
        }

        private ResponseModel RegisterPesebrera(string[] data)
        {
            ResponseModel responseModel = new ResponseModel();
            string[] bovinos = data.Where(d => d.Substring(0, 1).ToLower().Equals(configurationModel.LetterBovino.ToLower())).ToArray();
            Register(bovinos, TypePesebrera.BOVINOS, ref responseModel);
            string[] equinos = data.Where(d => !d.Substring(0, 1).ToLower().Equals(configurationModel.LetterBovino.ToLower())).ToArray();
            Register(equinos, TypePesebrera.EQUINOS, ref responseModel);          
            return responseModel;
        }

        private void Register(string[] data, TypePesebrera type, ref ResponseModel responseModel)
        {
            if (data.Length > 0)
            {
                string nameFile = type.Equals(TypePesebrera.BOVINOS) ? NAME_FILE_BOVINOS : NAME_FILE_EQUINOS;
                string path = Path.Combine(configurationModel.BasePath, $"{nameFile }.txt");
                dataAccessDal.SaveData(data, path, type, ref responseModel);

            }
            else
                responseModel.Message = type.Equals(TypePesebrera.BOVINOS) ? ConstantsMessage.NOT_BOVINOS_REGISTER : ConstantsMessage.NOT_EQUINOS_REGISTER;
        }


    }
}
