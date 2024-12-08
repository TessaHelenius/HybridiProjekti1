using CommunityToolkit.Mvvm.ComponentModel;
using HybridiProjekti.Models;

namespace HybridiProjekti.ViewModels
{
    public class ItemViewModel : ObservableObject
    {
        int _id;
        string _name;
        string _imagePath;
        int _quantity;
        string _category;

        public int Id
        {
            get { return _id; }
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get { return _name; }
            set => SetProperty(ref _name, value);
        }
        public string ImagePath
        {
            get { return _imagePath; }
            set => SetProperty(ref _imagePath, value);
        }
        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        public string Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        public ItemViewModel(Item item)
        {
            _id = item.Id;
            _name = item.Name;
            _imagePath = item.ImagePath;
            _quantity = item.Quantity;
            _category = item.Category;
        }
    }
}