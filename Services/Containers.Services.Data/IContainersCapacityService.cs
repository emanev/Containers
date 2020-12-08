namespace Containers.Services.Data
{
    using System.Collections.Generic;

    public interface IContainersCapacityService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
