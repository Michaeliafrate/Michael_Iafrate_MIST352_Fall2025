using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // PROMPT user for heroName
            Console.Write("Enter your hero's name: ");
            string heroName = Console.ReadLine();

            // PROMPT user for favoritePlace
            Console.Write("Enter your favorite place: ");
            string favoritePlace = Console.ReadLine();

            // PROMPT user for luckyNumberText (as text)
            Console.Write("Enter your lucky number (as text): ");
            string luckyNumberText = Console.ReadLine();

            // CLEAN heroName by TRIM
            heroName = heroName.Trim();

            // CLEAN favoritePlace by TRIM
            favoritePlace = favoritePlace.Trim();

            // TRY PARSE luckyNumberText into an INTEGER
            bool parsedOkay = int.TryParse(luckyNumberText, out int luckyNumber);

            // BUILD line1 = "Meet " + UPPER(heroName) + "!"
            string line1 = "Meet " + heroName.ToUpper() + "!";

            // BUILD line2 = "Today’s quest starts in " + favoritePlace + "."
            string line2 = "Today’s quest starts in " + favoritePlace + ".";

            // BUILD line3 = "Lucky number: " + luckyNumber
            string line3 = "Lucky number: " + luckyNumber;

            // BUILD nick = first 3 letters of heroName (or fewer if short), UPPERCASE
            string nick = heroName.Length >= 3
                ? heroName.Substring(0, 3).ToUpper()
                : heroName.ToUpper();

            // BUILD code = "#" + nick + "-" + luckyNumber
            string code = "#" + nick + "-" + luckyNumber;

            // BUILD report
            string report = line1 + Environment.NewLine +
                            line2 + Environment.NewLine +
                            line3 + Environment.NewLine +
                            "QuestCode: " + code;

            // PRINT report
            Console.WriteLine();
            Console.WriteLine(report);

            // PRINT "Parse success: " + parsedOkay
            Console.WriteLine("Parse success: " + parsedOkay);

            // PRINT "Hero length: " + LENGTH(heroName)
            Console.WriteLine("Hero length: " + heroName.Length);

            // PRINT "Place contains a space: " + (INDEX_OF(favoritePlace, " ") >= 0)
            Console.WriteLine("Place contains a space: " + (favoritePlace.IndexOf(" ") >= 0));
        }
    }
}
