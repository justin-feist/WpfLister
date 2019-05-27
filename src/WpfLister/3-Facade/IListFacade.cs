using System.Collections.Generic;
using System.Threading.Tasks;
using WpfLister.Models;

namespace WpfLister
{
    public interface IListFacade
    {
        Task<IEnumerable<ListItemDto>> GetListItems();
    }
}
