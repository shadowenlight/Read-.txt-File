using System.Text.RegularExpressions;

namespace WordFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\isiko\\source\\repos\\ReadtxtFile\\txt\\TextFile1.txt";
            string text = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                text = reader.ReadToEnd();
            }

            Regex regex = new Regex(@"\b\p{L}+\b", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(text);

            string[] words = matches.Cast<Match>().Select(match => match.Value.ToLower()).ToArray();

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                    wordCounts[word]++;
                else
                    wordCounts.Add(word, 1);
            }

            var topWords = wordCounts.OrderByDescending(pair => pair.Value).Take(10);

            Console.WriteLine("Top 10 most frequent words:");
            foreach (var pair in topWords)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}