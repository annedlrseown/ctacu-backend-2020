using System.Collections.Generic;
using System.Web.Http;
using MyFirstApi.Domain.Interfaces;
using MyFirstApi.Domain.Services;
using MyFirstApi.Domain.Services.Requests;

namespace MyFirstApi.ApiController
{
    [RoutePrefix("api/Values")]
    public class ValuesController: System.Web.Http.ApiController
    {
        private readonly IValueService _valueService;

        public ValuesController(IValueService valueService)
        {
            _valueService = valueService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetValues()
        {
            return Ok(_valueService.GetValues());
        }

        [HttpGet]
        [Route("{identifier}")]
        public string GetValue(int identifier)
        {
            return _valueService.GetValue(identifier);
        }

        [HttpPost]
        [Route("")]
        public int PostValue(ValuesRequestBody request)
        {
            var serviceRequest = new CreateValueRequest
            {
                Value = request.Value
            };

            var response = _valueService.CreateValue(serviceRequest);
            return response.Id;
        }

        [HttpPut]
        [Route("{identifier")]
        public int PutValue([FromUri]int identifier, [FromBody]ValuesRequestBody request)
        {
            var serviceRequest = new UpdateValueRequest
            {
                Id = identifier,
                Value = request.Value
            };

            var response = _valueService.UpdateValue(serviceRequest);
            return response.Id;
        }

        [HttpDelete]
        [Route("{identifier")]
        public void DeleteValue(int identifier)
        {
            _valueService.RemoveValue(identifier);
        }
    }

    public class ValuesRequestBody
    {
        public string Value { get; set; }
    }
}