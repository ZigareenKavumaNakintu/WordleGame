namespace WordleGame
{
    public partial class MainPage : ContentPage
    {

        private GameViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();

            viewModel = new GameViewModel();
            BindingContext = viewModel;
           
        }

        private  async void StartGame_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new gamePage());
        }
    }
}
