namespace MauiApp4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyDatePicker.MaximumDate = DateTime.Today.AddDays(30);
        }
        private void OnButtonClicked(object sender, EventArgs e)
        {

            if (itemPicker.SelectedIndex >= 0)
            {
                string selectedItem = itemPicker.SelectedItem.ToString();
                var selectedDate = MyDatePicker.Date;
                var selectedTime = MyTimePicker.Time;

                ResultLabel.Text = $"Wybrano: {selectedItem} na dzień {selectedDate:dd.MM.yyyy} o godzinie {selectedTime}";
            }
            else
            {
                ResultLabel.Text = "Proszę o wybranie specjalisty, dnia i godziny";
            }
        }
    }
}
