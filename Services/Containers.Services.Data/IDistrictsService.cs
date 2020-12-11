namespace Containers.Services.Data
{
    using System.Collections.Generic;

    public interface IDistrictsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
