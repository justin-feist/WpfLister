using System.Collections.Generic;
using System.Threading.Tasks;
using WpfLister.Models;

namespace WpfLister.Repository
{
    public interface IListRepository
    {

        Task<IEnumerable<ListItemDto>> GetListItems(int numberToGet);

    }
}
