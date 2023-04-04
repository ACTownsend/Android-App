using _6002.ViewModel;
namespace _6002;

public partial class Game : ContentPage
{
    public Game()
    {
    }

    public Game(GameViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        var frame = new Frame();

    }


}

