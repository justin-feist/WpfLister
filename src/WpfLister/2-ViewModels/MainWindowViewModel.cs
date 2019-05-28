using System.Collections.Generic;
using System.Windows.Input;
using WpfLister.Base;
using WpfLister.Models;
using WpfLister.Repository;

namespace WpfLister.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IListFacade _listFacade;
        private IEnumerable<ListItemDto> _listItems;

        public MainWindowViewModel()
        {
            //Wire up the "Load Data" button
            GetDataCommand = new RelayCommand(GetData);

            //We'll use a text file for our list of reasons
            _listFacade = new ListFacade(new TextListRepository());

            ListItems = new List<ListItemDto>();
        }

        public ICommand GetDataCommand { get; }

        public IEnumerable<ListItemDto> ListItems
        {
            get => _listItems;
            set
            {
                _listItems = value;

                //Let the UI know the backing list of items changed
                RaisePropertyChanged("ListItems");
            }
        }

        private async void GetData(object parameter)
        {
            //Fetch the items
            ListItems = await _listFacade.GetListItems();
        }

    }
}
