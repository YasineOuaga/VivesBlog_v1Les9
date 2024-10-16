namespace Vives.Services.Model.Extensions
{
    public static class ServiceResultExtensions
    {
        public static TServiceResult NotEmpty<TServiceResult>(this TServiceResult serviceResult, string propertyName)
        where TServiceResult: ServiceResult
        {
            serviceResult.Messages.Add(new ServiceMessage
            {
                Code = "NotEmpty",
                Message = $"{propertyName} cannot be empty",
                Type = ServiceMessageType.Error
            });

            return serviceResult;
        }

        public static TServiceResult NotDefault<TServiceResult>(this TServiceResult serviceResult, string propertyName)
            where TServiceResult : ServiceResult
        {
            serviceResult.Messages.Add(new ServiceMessage
            {
                Code = "NotDefault",
                Message = $"{propertyName} cannot be the default value",
                Type = ServiceMessageType.Error
            });

            return serviceResult;
        }

        public static TServiceResult NotFound<TServiceResult>(this TServiceResult serviceResult, string entityName, int id, ServiceMessageType type = ServiceMessageType.Warning)
            where TServiceResult : ServiceResult
        {
            serviceResult.Messages.Add(new ServiceMessage
            {
                Code = "NotFound",
                Message = $"Could not find {entityName} with Id {id}",
                Type = type
            });

            return serviceResult;
        }

        public static TServiceResult Deleted<TServiceResult>(this TServiceResult serviceResult, string entityName)
            where TServiceResult : ServiceResult
        {
            serviceResult.Messages.Add(new ServiceMessage
            {
                Code = "Deleted",
                Message = $"{entityName} was successfully deleted.",
                Type = ServiceMessageType.Info
            });

            return serviceResult;
        }

        public static TServiceResult LoginFailed<TServiceResult>(this TServiceResult serviceResult)
            where TServiceResult : ServiceResult
        {
            serviceResult.Messages.Add(new ServiceMessage
            {
                Code = "LoginFailed",
                Message = "The login failed.",
                Type = ServiceMessageType.Info
            });

            return serviceResult;
        }
    }
}
