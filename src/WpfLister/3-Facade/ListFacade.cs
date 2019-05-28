using System.Collections.Generic;
using System.Threading.Tasks;
using WpfLister.Models;
using WpfLister.Repository;

namespace WpfLister
{
    public class ListFacade : IListFacade
    {
        private readonly IListRepository _listRepository;

        public ListFacade(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<IEnumerable<ListItemDto>> GetListItems()
        {
            //Get the specified number of items from the repository
            return await _listRepository.GetListItems(999);
        }
    }
}
