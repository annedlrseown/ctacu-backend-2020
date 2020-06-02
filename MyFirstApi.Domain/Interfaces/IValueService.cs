using System.Collections.Generic;
using MyFirstApi.Domain.Services.Requests;
using MyFirstApi.Domain.Services.Response;

namespace MyFirstApi.Domain.Interfaces
{
    public interface IValueService
    {
        List<string> GetValues();
        string GetValue(int id);
        CreateValueResponse CreateValue(CreateValueRequest request);
        UpdateValueResponse UpdateValue(UpdateValueRequest serviceRequest);
        void RemoveValue(int id);
    }
}