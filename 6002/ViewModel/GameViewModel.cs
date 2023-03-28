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
        correctAnswer = "tests".ToCharArray();

    }

    [RelayCommand]
    public void Enter()
    {

        if(columnIndex != 5)
        {
            return;
        }
        var valid = true;
        if(valid)
        {
            if(rowIndex == 5)
            {

            }
            else
            {
                rowIndex++;
                columnIndex = 0;
            }
        }
    }
    [RelayCommand]
    public void EnterLetter(char letter)
    {
        if (columnIndex == 5)
        {
            return;
        }
    }
}
