namespace HybridiProjekti.Views;

public partial class ItemDetailPage : ContentPage
{
    public ItemDetailPage()
    {
        InitializeComponent();

        BindingContext = App.MainViewModel.SelectedItem;
    }
}