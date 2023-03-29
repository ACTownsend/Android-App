using _6002.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002.ViewModel;

public partial class GameViewModel : ObservableObject
{
     int rowIndex;
     int columnIndex;

    char[] correctAnswer;
    public char[] Keyboard1 { get; }
    public char[] Keyboard2 { get; }
    public char[] Keyboard3 { get; }
    [ObservableProperty]
    private WordRow[] rows;

    public GameViewModel()
    {
        rows = new WordRow[6]
        {
            new WordRow(),
            new WordRow(),
            new WordRow(),
            new WordRow(),
            new WordRow(),
            new WordRow()
        };
        correctAnswer = "TESTS".ToCharArray();
        Keyboard1 = "QWERTYUIOP".ToCharArray();
        Keyboard2 = "ASDFGHJKL".ToCharArray();
        Keyboard3 = "<ZXCVBNM^".ToCharArray();
    }

    [RelayCommand]
    async void Back()
    {
        await Shell.Current.GoToAsync("..");
    }
    async public void Enter()
    {

        if(columnIndex != 5)
        {
            return;
        }
        var correct = rows[rowIndex].Validate(correctAnswer);
        if(correct)
        {

            await App.Current.MainPage.DisplayAlert("Correct!", "You win", "Well Done");
            Back();
        }
        if (rowIndex == 5)
        {
            await App.Current.MainPage.DisplayAlert("Uh-Oh!", "You Lose", "Better Luck Next Time");
            Back();
        }
        else
        {
            rowIndex++;
            columnIndex = 0;
        }
    }
    [RelayCommand]
    public void EnterLetter(char letter)
    {
        if (letter == '^')
        {
            Enter();
            return;
        }
        if (letter == '<')
        {   
            if(columnIndex == 0)
            {
                return;
            }
            columnIndex--;
            rows[rowIndex].Letters[columnIndex].Input = ' ';
            return;
        }
        if (columnIndex == 5)
        {
            return;
        }
        rows[rowIndex].Letters[columnIndex].Input = letter;
        columnIndex++;
    }
}
