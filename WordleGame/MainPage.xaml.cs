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
      

    }
}
