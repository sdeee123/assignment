using System;
using System.Text.RegularExpressions;

while (true)
{
    Console.Write("Enter a date in mm/dd/yyyy format: ");
    string input = Console.ReadLine();

    if (IsValidDate(input))
    {
        try
        {
            string result = ReverseDateFormat(input);
            Console.WriteLine("Converted date: " + result);
        }
        catch (RegexMatchTimeoutException ex)
        {
            Console.WriteLine("Regex operation timed out. Returning original date: " + input);
        }
    }
    else
    {
        Console.WriteLine("Invalid date. Please try again.");
    }
}

bool IsValidDate(string input)
{
    DateTime date;
    return DateTime.TryParseExact(input, "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out date);
}

string ReverseDateFormat(string input)
{
    TimeSpan timeout = TimeSpan.FromSeconds(1);
    Regex regex = new Regex(@"^(?<mon>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})$", RegexOptions.None, timeout);
    Match match = regex.Match(input);
    if (match.Success)
    {
        return $"{match.Groups["year"].Value}-{match.Groups["mon"].Value}-{match.Groups["day"].Value}";
    }
    else
    {
        throw new FormatException("Invalid date format");
    }
}
