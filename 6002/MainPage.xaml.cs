﻿namespace _6002;
public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    private async void Button_Clicked_1(object sender, EventArgs e)
    {

       await Shell.Current.GoToAsync("Game");
    }
}