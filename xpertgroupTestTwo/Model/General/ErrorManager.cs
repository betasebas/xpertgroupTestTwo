using System;

namespace xpertgroupTestTwo.Model
{
    public static class ErrorManager
    {
        public static ResponseModel ErrorManagerGeneral(string error)
        {
            return new ResponseModel { Message = error, Response = false };
        }

        // Los errores del sistema deben ir a un log o por defactoal visor de eventos de windows.
        public static ResponseModel ErrorManagerGeneral(Exception exception)
        {
            return new ResponseModel
            {
                Response = false,
                Message = $"{ ConstantsMessage.ERROR_GENERAL } { exception.Message }"
            };
        }
    }
}
