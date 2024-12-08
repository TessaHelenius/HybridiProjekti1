using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace HybridiProjekti.ViewModels
{
    public class ItemListViewModel : ObservableObject
    {
        private ItemViewModel _selectedItem;

        public ItemViewModel SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public ObservableCollection<ItemViewModel> Items { get; set; }

        public ItemListViewModel() => Items = [];

        public async Task RefreshItems()
        {

            IEnumerable<Models.Item> itemsData = await Models.ItemsDatabase.GetItems();
            foreach (Models.Item item in itemsData)
                Items.Add(new ItemViewModel(item));
        }

        public void DeleteItem(ItemViewModel item) => Items.Remove(item);

        public void AddItem(ItemViewModel newItem) => Items.Add(newItem);

        public async Task SaveItems()
        {
            await Models.ItemsDatabase.WriteItems(Items);
        }
    }
}