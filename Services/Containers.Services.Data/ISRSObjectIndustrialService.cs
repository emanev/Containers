namespace Containers.Services.Data
{
    using System.Collections.Generic;

    using Containers.Services.Data.Models;

    public interface ISRSObjectIndustrialService
    {
        IEnumerable<SRSObjectIndustrialViewModel> GetAll();
    }
}
