namespace HybridiProjekti.Views;

public partial class AddItemPage : ContentPage
{
    string enteredName;
    int enteredQuantity;
    string selectedCategory;

    string imageFilePath;

    public AddItemPage()
    {
        InitializeComponent();

        var categories = new List<string>

            {
                "Elintarvike",
                "Herkut",
                "Meikit",
                "Hygienia"
            };
        // Set pickers items source
        categoryPicker.ItemsSource = categories;
    }


    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        enteredName = ((Entry)sender).Text;
    }
    private void Entry_Completed(object sender, EventArgs e)
    {
        enteredName = ((Entry)sender).Text;
    }
    private void QuantityEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
       
        if (int.TryParse(e.NewTextValue, out int quantity))
        {
            enteredQuantity = quantity;
        }
        else
        {
            enteredQuantity = 0;
        }
    }
    private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (categoryPicker.SelectedIndex != -1)
        {
            selectedCategory = categoryPicker.ItemsSource[categoryPicker.SelectedIndex]?.ToString();
        }
    }

    private async void Add_Button_Clicked(object sender, EventArgs e)
    {

        // Validating entered data
        if (string.IsNullOrWhiteSpace(enteredName)) 
        {
            await DisplayAlert("Virhe", "Lis‰‰ tuotteen nimi", "OK");
            return;
        }

        if (!int.TryParse(quantityEntry.Text, out enteredQuantity) || enteredQuantity <= 0) 
        {
            await DisplayAlert("Virhe", "Tarkista tuotteen lukum‰‰r‰ (1 tai suurempi)", "OK");
            return;
        }

        if (categoryPicker.SelectedItem == null) 
        {
            await DisplayAlert("Virhe", "Valitse kategoria", "OK");
            return;
        }

        selectedCategory = categoryPicker.SelectedItem.ToString();

        // Add new item to main view model
        var newItem = new Models.Item(
            App.MainViewModel.Items.Count + 1, 
            enteredName, 
            imageFilePath ?? string.Empty, 
            enteredQuantity,
            selectedCategory 
        );

        // Add itm to main view model
        App.MainViewModel.AddItem(new ViewModels.ItemViewModel(newItem));

        
        await Navigation.PopAsync();
     
    }
    private async void Photo_Button_Clicked(object sender, EventArgs e)
    {
        //Check that devive support is there
        if (MediaPicker.Default.IsCaptureSupported)
        {
            //Launch the camera and save the photo
            FileResult image = await MediaPicker.Default.CapturePhotoAsync();

            if (image != null)
            {
                //get images file path
                imageFilePath = Path.Combine(FileSystem.AppDataDirectory, image.FileName);

                //save the image to the file path
                using Stream sourceStream = await image.OpenReadAsync();
                using (FileStream localFileStream = File.OpenWrite(imageFilePath))
                {
                    await sourceStream.CopyToAsync(localFileStream);
                }
                PhotoImage.Source = ImageSource.FromFile(imageFilePath);


            }
        }
    }
}
