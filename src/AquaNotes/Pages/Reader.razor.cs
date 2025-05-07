using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;

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
                output += Read(line) + "<br />";
        }
    }

    /// <summary>
    /// Read the text in anov syntax.
    /// </summary>
    /// <param name="str">The text in anov syntax</param>
    public static string Read(string str)
    {
        Match match;
        string _return = "";

        // Read "[conversation-content]"
        match = Regex.Match(str, @"\[(.*?)\]");
        if (match.Success)
            return " \"" + match.Groups[1].Value.Trim() + "\"";

        // Unsupported
        // Read "> place"
        match = Regex.Match(str, @"> (.*)");
        if (match.Success)
            _return += "/ " + match.Groups[1].Value.Trim() + " /";

        // Unsupported
        // Read "bgm: background-music"
        match = Regex.Match(str, @"bgm: (.*)");
        if (match.Success)
            _return += "<bgm>";

        // Unsupported
        // Read "movie: movie"
        match = Regex.Match(str, @"movie: (.*)");
        if (match.Success)
            _return += "<movie>";

        // Read "- people-name / emotion"
        match = Regex.Match(str, @"- (.*?)/");
        if (match.Success)
            _return += match.Groups[1].Value.Trim();
        else
        {
            // Read "- people-name"
            match = Regex.Match(str, @"- (.*)");
            if (match.Success)
                _return += match.Groups[1].Value.Trim();
        }

        // Read "/ emotion"
        match = Regex.Match(str, @"/ (.*)");
        if (match.Success)
            _return += " (" + match.Groups[1].Value.Trim() + ")";

        return _return;
    }
}
