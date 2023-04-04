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
    public bool Validate(char[] correctAnswer)
    {
        int count = 0;

        
        for (int i = 0; i < Letters.Length; i++)
        {  
            var letter = Letters[i];
            

            if(letter.Input == correctAnswer[i])
            {
                letter.Color = Colors.Green;
                count++;
            }
            else if(correctAnswer.Contains(letter.Input))
            {
                letter.Color = Colors.Orange;
                
            }
            else
            {
                letter.Color = Colors.Gray;
            }
        }
        return count == 5;
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
