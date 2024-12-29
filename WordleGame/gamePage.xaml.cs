
namespace WordleGame;

public partial class gamePage : ContentPage
{
    private GameViewModel viewModel;

    public gamePage()
    {
        InitializeComponent();
        viewModel = new GameViewModel();
        BindingContext = viewModel;
        InitializeViewModel();
    }
    private async void InitializeViewModel()
    {
        await viewModel.MakeWordList();
    }
}
   