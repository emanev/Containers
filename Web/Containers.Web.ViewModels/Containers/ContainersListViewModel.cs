namespace Containers.Web.ViewModels.Containers
{
    using System.Collections.Generic;

    public class ContainersListViewModel : PagingViewModel
    {
        public IEnumerable<ContainersViewModel> Containers { get; set; }
    }
}
