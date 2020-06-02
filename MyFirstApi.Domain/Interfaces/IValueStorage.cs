using System.Collections.Generic;

namespace MyFirstApi.Domain.Interfaces
{
    public interface IValueStorage
    {
        List<string> GetValues();
    }
}