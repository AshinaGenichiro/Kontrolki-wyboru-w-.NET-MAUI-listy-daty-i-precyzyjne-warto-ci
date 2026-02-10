
using System.ComponentModel;

namespace MauiApp4;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
        _viewModel = new OrderViewModel();
        BindingContext = _viewModel;
    }
    private OrderViewModel _viewModel;
    public class OrderViewModel : INotifyPropertyChanged
    {
        private string _selectedPacket;
        public string selectedPacket
        {
            get => _selectedPacket;
            set
            {
                _selectedPacket = value;
                OnPropertyChanged(nameof(selectedPacket));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    private void Register(object sender, EventArgs e)
	{
		if(!string.IsNullOrEmpty(nameSurnameEntry.Text) && !string.IsNullOrEmpty(emailEntry.Text) && itemPicker.SelectedIndex >= 0)
		{ 
			DisplayAlert("Rejestracja", $"Zarejestrowano: {nameSurnameEntry.Text} ({emailEntry.Text}) na {itemPicker.SelectedItem.ToString()}", "OK");
		}else
		{
            DisplayAlert("Rejestracja nieudana ", $"Proszê o wype³nienie ka¿dego pola", "OK");
        }
    }
	private void calculatePrice(object sender, EventArgs e)
	{   int basePrice = 0;
        int pricePerAdittionalPerson = 100;
		int numberOfAdditionalPeople = (int)additionalPepole.Value;
        switch (_viewModel.selectedPacket)
        {
            case "Basic":
                basePrice = 200;
                break;
            case "Standard":
                basePrice = 350;
                break;
            case "Premium":
                basePrice = 500;
                break;
        }
        int totalPrice= basePrice + (pricePerAdittionalPerson * numberOfAdditionalPeople);

        resultLabel.Text = $"Cena ca³kowita: {totalPrice} z³";

    }
}