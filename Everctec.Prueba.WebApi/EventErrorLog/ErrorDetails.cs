using Newtonsoft.Json;

namespace Evertec.Prueba.WebApi.EventErrorLog
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
    