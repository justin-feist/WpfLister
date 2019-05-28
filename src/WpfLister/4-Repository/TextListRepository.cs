using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WpfLister.Models;

namespace WpfLister.Repository
{
    public class TextListRepository : IListRepository
    {
        private readonly string _fileToRead;

        public TextListRepository()
        {
            _fileToRead = @".\Data\ListItems.list";
        }

        public async Task<IEnumerable<ListItemDto>> GetListItems(int numberToGet)
        {
            if (numberToGet > 0)
            {
                return await Task.Run(() => _GetListItems(_fileToRead));
            }

            return new List<ListItemDto>();
        }

        private IEnumerable<ListItemDto> _GetListItems(string fileToRead)
        {
            var lines = File.ReadLines(fileToRead);

            int counter = 1;
            var listItems = new List<ListItemDto>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                listItems.Add(new ListItemDto()
                {
                    Id = counter,
                    DisplayValue = line
                });

                counter++;
            }

            var rng = new Random();
            var returnList = listItems.OrderBy(item => rng.Next());

            return returnList;
        }
    }
}
