namespace Vives.Services.Model
{
    public class ServiceResult<T>(T? data = default) : ServiceResult
    {
        public T? Data { get; set; } = data;
    }
}
