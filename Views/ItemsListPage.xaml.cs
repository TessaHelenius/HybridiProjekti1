using HybridiProjekti.ViewModels;

namespace HybridiProjekti.Views;

public partial class ItemsListPage : ContentPage
{
    public ItemsListPage()
    {
        InitializeComponent();
    }

   

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is ItemViewModel selectedItem)
        {
            App.MainViewModel.SelectedItem = selectedItem; 
            await Navigation.PushAsync(new Views.ItemDetailPage()); 
        }
    }

    private async void Add_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.AddItemPage());
    }

    private async void Save_Button_Clicked(object sender, EventArgs e)
    {
        await App.MainViewModel.SaveItems();
    }

    private void Delete_Button_Clicked(object sender, EventArgs e)
    {
        
        var button = (ImageButton)sender;
        var item = (ViewModels.ItemViewModel)button.CommandParameter;

        
        App.MainViewModel.DeleteItem(item);
    }
    private async void About_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AboutPage());
    }
}