namespace _6002;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Game), typeof(Game));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}
