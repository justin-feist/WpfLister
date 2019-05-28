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
            //We'll read from a file in a "Data" directory
            _fileToRead = @".\Data\ListItems.list";
        }

        public async Task<IEnumerable<ListItemDto>> GetListItems(int numberToGet)
        {
            //If 1 or more items has been requested, read the file, otherwise return an empty list
            if (numberToGet > 0)
            {
                //I didn't actually implement a "limit" or "top" here....
                return await Task.Run(() => _GetListItems(_fileToRead));
            }

            return new List<ListItemDto>();
        }

        private IEnumerable<ListItemDto> _GetListItems(string fileToRead)
        {
            //Read the file into a collection
            var lines = File.ReadLines(fileToRead);

            int counter = 1;
            var listItems = new List<ListItemDto>();
            foreach (var line in lines)
            {
                //If it's a blank line, ignore it
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                //Add the line to the list, along with an ID value
                listItems.Add(new ListItemDto()
                {
                    Id = counter,
                    DisplayValue = line
                });

                counter++;
            }

            //Randomly order the list
            var rng = new Random();
            var returnList = listItems.OrderBy(item => rng.Next());

            return returnList;
        }
    }
}
