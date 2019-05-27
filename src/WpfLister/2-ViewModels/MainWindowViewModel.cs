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
            GetDataCommand = new RelayCommand(GetData);
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
                RaisePropertyChanged("ListItems");
            }
        }

        private async void GetData(object parameter)
        {
            ListItems = await _listFacade.GetListItems();
        }

    }
}
