using System.Text;
using Microsoft.AspNetCore.Components;
using AnovSyntax;

namespace AquaNotes.Pages;

public partial class ReaderBase : ComponentBase
{
    public string output = "";

    public static readonly string initialText =
    """
    - Alice
    [Hi, everyone!]
    
    - Rabbit
    [What's up?]
    
    """;

    public string input = initialText;

    StreamReader sr = new(new MemoryStream(Encoding.UTF8.GetBytes(initialText)));

    public void SubmitButton()
    {
        sr = new(new MemoryStream(Encoding.UTF8.GetBytes(input)));
    }

    public void ReadButton()
    {
        output = "";
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            if (line == "")
                break;
            else if (line is not null)
                output += Anov.Read(line) + "<br />";
        }
    }
}
