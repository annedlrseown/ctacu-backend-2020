using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstApi.Domain.Interfaces;
using MyFirstApi.Domain.Services.Requests;
using MyFirstApi.Domain.Services.Response;

namespace MyFirstApi.Services
{
    public class ValueService: IValueService
    {
        private readonly IValueStorage _valueStorage;

        public ValueService(IValueStorage valueStorage)
        {
            _valueStorage = valueStorage;
        }

        public List<string> GetValues()
        {
            var values = _valueStorage.GetValues();
            if (values.Count <= 0)
            {
                throw new Exception("No values found");
            }

            values = values
                .Select(x => x.ToUpper())
                .ToList();

            return values;
        }

        public string GetValue(int id)
        {
            throw new NotImplementedException();
        }

        public CreateValueResponse CreateValue(CreateValueRequest request)
        {
            throw new NotImplementedException();
        }

        public UpdateValueResponse UpdateValue(UpdateValueRequest serviceRequest)
        {
            throw new NotImplementedException();
        }

        public void RemoveValue(int id)
        {
            throw new NotImplementedException();
        }
    }
}
