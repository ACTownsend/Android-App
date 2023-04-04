using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002.Model;

public class WordRow
{
    public WordRow()
    {
        Letters = new Letter[5]
        {   new Letter(),
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter()
        };
    }
    public Letter[] Letters { get; set; }   
    public int Validate(char[] correctAnswer, bool isAWord)
    {
        int count = 0;

        for (int i = 0; i < Letters.Length; i++)
        {  
            var letter = Letters[i];

            if (isAWord == false)
            {
                letter.Color = Colors.Red;
            }
            else
            {
                if (letter.Input == correctAnswer[i])
                {
                    letter.Color = Colors.Green;
                    count++;
                }
                else if (correctAnswer.Contains(letter.Input))
                {
                    letter.Color = Colors.Orange;

                }
                else
                {
                    letter.Color = Colors.Gray;
                }
            }

        }
        if(count == 5)
        {
            return 10;
        }
        else if(isAWord == false)
        {
            return 5;
        }
        else
        {
            return 1;
        }
        
    }
}
public partial class Letter : ObservableObject
{
    public Letter()
    {
        Color = Colors.Black;
    }
    [ObservableProperty]
    private char input;

    [ObservableProperty]
    private Color color;
}
