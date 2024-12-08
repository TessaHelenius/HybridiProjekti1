namespace HybridiProjekti
{
    public partial class App : Application
    {

        public static ViewModels.ItemListViewModel MainViewModel { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();


            MainViewModel = new ViewModels.ItemListViewModel();

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await MainViewModel.RefreshItems();
        }
    }
}
