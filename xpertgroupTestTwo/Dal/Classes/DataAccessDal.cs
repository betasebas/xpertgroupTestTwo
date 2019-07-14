using System.IO;
using System.Linq;
using xpertgroupTestTwo.Model;

namespace xpertgroupTestTwo.Dal
{
    public class DataAccessDal
    {
        public ResponseModel SaveData(string[] data, string path, TypePesebrera typePesebrera, ref ResponseModel responseModel)
        {
            responseModel.Message += "\n";
            responseModel.Message += typePesebrera.Equals(TypePesebrera.BOVINOS) ? ConstantsMessage.REGISTER_BOVINOS 
                : ConstantsMessage.REGISTER_EQUINOS;

            string[] dataContainer = File.Exists(path) ? File.ReadAllLines(path) : new string[0];
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                foreach (var item in data)
                {
                    WriteLine(dataContainer, item, streamWriter, ref responseModel);
                }
                streamWriter.Close();


            }
            return responseModel;
        }

        private void WriteLine(string[] dataContainer, string item, StreamWriter streamWriter, ref ResponseModel responseModel)
        {
            if (!dataContainer.Any(d => d.Equals(item)))
            {
                streamWriter.WriteLine(item);
                responseModel.Message += $"{item} => REGISTRO NUEVO\n";
            }
            else
            {
                responseModel.Message += $"{item} => REGISTRO YA EXISTE\n";
            }
        }
    }
}
