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
    public void Validate(char[] correctAnswer)
    {

    }
}

public partial class Letter : ObservableObject
{
    public Letter()
    {
        color = Colors.Black;
    }
    [ObservableProperty]
    private char input;

    [ObservableProperty]
    private Color color;
}
