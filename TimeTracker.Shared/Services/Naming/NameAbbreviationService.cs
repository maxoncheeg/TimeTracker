namespace TimeTracker.Shared.Services.Naming;

public class NameAbbreviationService : INameAbbreviationService
{
    public string GetAbbreviation(string name)
    {
        if (string.IsNullOrEmpty(name)) return string.Empty;

        string[] words = name.Split();

        if (words.Length < 2)
            return name.Length == 1 ? new(name[0], 2) : $"{name[0]}{name[1]}";

        string abbreviation = string.Empty;
        foreach (var word in words)
            if (word.Length > 0)
            {
                abbreviation += word[0];
                if (abbreviation.Length >= 2) return abbreviation;
            }
        
        return name.Length == 1 ? new(name[0], 2) : $"{name[0]}{name[1]}";
    }
}