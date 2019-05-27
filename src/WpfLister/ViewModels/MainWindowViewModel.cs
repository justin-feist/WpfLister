using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using WpfLister.Base;
using WpfLister.Models;
using WpfLister.Repository;

namespace WpfLister.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ICommand _getDataCommand;
        private readonly IListRepository _listRepository;
        private IEnumerable<string> _listItems2;

        public MainWindowViewModel()
        {
            _getDataCommand = new RelayCommand(new Action<object>(GetData));
            _listRepository = new TextListRepository();
            ListItems = new List<ListItemDto>();
        }

        public ICommand GetDataCommand { get { return _getDataCommand; } }

        public IEnumerable<ListItemDto> ListItems { get; set; }

        public IEnumerable<string> ListItems2
        {
            get { return _listItems2; }
            set
            {
                _listItems2 = value;
                RaisePropertyChanged("ListItems");
            }
        }



        private async void GetData(object o)
        {
            var items = await _listRepository.GetListItems(999);
            
            ListItems = items;

            List<string> sList = new List<string>();
            sList.Add("Hello");
            sList.Add("Moto");
            ListItems2 = sList;
        }

    }
}
