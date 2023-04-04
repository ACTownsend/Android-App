using _6002.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using Microsoft.Maui.Controls;
namespace _6002.ViewModel;

public partial class GameViewModel : ObservableObject
{
    int rowIndex;
    int columnIndex;

    private string _currentWord;
    public string CurrentWord
    {
        get { return _currentWord; }
        set { SetProperty(ref _currentWord, value); }
    }

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
       
        Keyboard1 = "QWERTYUIOP".ToCharArray();
        Keyboard2 = "ASDFGHJKL<".ToCharArray();
        Keyboard3 = "ZXCVBNM>".ToCharArray();
        // Load the words from the text file

        var repo = new Repo();
        String word = repo.RandomWord();
        correctAnswer = word.ToCharArray();
        
        App.Current.MainPage.DisplayAlert("1",word,"2");
       
    }

    [RelayCommand]
    async void Back()
    {
        await Shell.Current.GoToAsync("Game");
    }
    async public void Enter()
    {

        if (columnIndex != 5)
        {
            return;
        }
        var repo = new Repo();
        string poop = string.Join("", rows[rowIndex].Letters.Select(w => w.Input));
        bool isAWord = repo.isWord(poop);
        var correct = rows[rowIndex].Validate(correctAnswer, isAWord);
        //App.Current.MainPage.DisplayAlert("1", word, "2");

        if (correct == 10)
        {

            await App.Current.MainPage.DisplayAlert("Correct!", "You win", "Play Again");
            Back();
        }
        else if(correct == 5)
        {
            await App.Current.MainPage.DisplayAlert("Error!", "Please enter a real word", "Try Again");

            for (int i = 0; i < 5; i++)
            {
                columnIndex--;
                rows[rowIndex].Letters[columnIndex].Input = ' ';
                rows[rowIndex].Letters[columnIndex].Color = Colors.Black;
                
            }
            return;
            
        }
        if (rowIndex == 5)
        {
            await App.Current.MainPage.DisplayAlert("Uh-Oh!", "You Lose", "Back To Main Menu");
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
        if (letter == '>')
        {
            Enter();
            return;
        }
        if (letter == '<')
        {
            if (columnIndex == 0)
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
