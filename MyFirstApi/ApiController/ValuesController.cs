using System.Collections.Generic;
using System.Web.Http;

namespace MyFirstApi.ApiController
{
    [RoutePrefix("api/Values")]
    public class ValuesController: System.Web.Http.ApiController
    {
        private static List<string> _values = new List<string>
        {
            "one",
            "two",
            "three"
        };

        [HttpGet]
        [Route("")]
        public List<string> GetValues()
        {
            return _values;
        }

        [HttpGet]
        [Route("{identifier}")]
        public string GetValue(int identifier)
        {
            return _values[identifier];
        }

        [HttpPost]
        [Route("")]
        public int PostValue(ValuesRequestBody request)
        {
            _values.Add(request.Value);
            return _values.Count - 1;
        }

        [HttpPut]
        [Route("{identifier")]
        public int PutValue([FromUri]int identifier, [FromBody]ValuesRequestBody request)
        {
            _values[identifier] = request.Value;
            return identifier;
        }

        [HttpDelete]
        [Route("{identifier")]
        public void DeleteValue(int identifier)
        {
            _values.RemoveAt(identifier);
        }
    }

    public class ValuesRequestBody
    {
        public string Value { get; set; }
    }
}