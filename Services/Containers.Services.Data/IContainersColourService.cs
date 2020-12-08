namespace Containers.Services.Data
{
    using System.Collections.Generic;

    public interface IContainersColourService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
