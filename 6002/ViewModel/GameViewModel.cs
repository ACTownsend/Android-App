using _6002.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using Microsoft.Maui.Controls;
namespace _6002.ViewModel;

public partial class GameViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
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
        Keyboard2 = "ASDFGHJKL".ToCharArray();
        Keyboard3 = ">ZXCVBNM<".ToCharArray();
        // Load the words from the text file
        string rawdata = File.ReadAllText("../Resouces/Raw/words.txt");
        Word = LoadWords(rawdata);

        // Initialize the random number generator
        _random = new Random();
        string word = Word[_random.Next(Word.Count)];
        correctAnswer = word.ToCharArray();
    }
    private List<string> _words;
    private Random _random;

    public List<string> Word
    {
        get { return _words; }
        set { SetProperty(ref _words, value); }
    }


    private List<string> LoadWords(string filename)
    {
        // Read all the lines from the text file
        string[] lines = File.ReadAllLines(filename);

        // Filter out any empty lines or lines that start with a comment character (#)
        IEnumerable<string> filteredLines = lines.Where(line => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"));

        // Convert the filtered lines to a list of strings
        List<string> words = filteredLines.ToList();

        return words;
    }

    [RelayCommand]
    async void Back()
    {
        await Shell.Current.GoToAsync("..");
    }
    async public void Enter()
    {

        if (columnIndex != 5)
        {
            return;
        }
        var correct = rows[rowIndex].Validate(correctAnswer);
        if (correct)
        {

            await App.Current.MainPage.DisplayAlert("Correct!", "You win", "Back To Main Menu");
            Back();
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
