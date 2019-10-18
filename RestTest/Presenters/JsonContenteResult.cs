using Microsoft.AspNetCore.Mvc;

namespace RestTest.Api.Presenters
{
    public class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}