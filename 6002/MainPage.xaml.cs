using _6002.ViewModel;

namespace _6002;

public partial class MainPage : ContentPage
{


	public MainPage(GameViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}


}

