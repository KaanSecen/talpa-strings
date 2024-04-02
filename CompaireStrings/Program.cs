using System.Text.RegularExpressions;

namespace CompaireStrings
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter first string:");
            string str1 = Console.ReadLine()!;
            Console.WriteLine("Enter second string:");
            string str2 = Console.ReadLine()!;


            double similarity = CompareStrings(str1, str2);
            Console.WriteLine($"Similarity between '{str1}' and '{str2}': {similarity}%");
        }

        public static double CompareStrings(string str1, string str2)
        {
            List<string> pairs1 = WordLetterPairs(str1.ToUpper());
            List<string> pairs2 = WordLetterPairs(str2.ToUpper());

            int intersection = 0;
            int union = pairs1.Count + pairs2.Count;

            foreach (var pair1 in pairs1)
            {
                for (int number = 0; number < pairs2.Count; number++)
                {
                    if (pair1 == pairs2[number])
                    {
                        intersection++;
                        pairs2.RemoveAt(number);
                        break;
                    }
                }
            }

            return (2.0 * intersection * 100) / union;
        }


        private static List<string> WordLetterPairs(string str)
        {
            List<string> allPairs = new List<string>();

            string[] words = Regex.Split(str, @"\s");

            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    String[] pairsInWord = LetterPairs(word);

                    foreach (var pairWord in pairsInWord)
                    {
                        allPairs.Add(pairWord);
                    }
                }
            }
            return allPairs;
        }

        private static string[] LetterPairs(string str)
        {
            var numPairs = str.Length - 1;
            string[] pairs = new string[numPairs];

            for (int number = 0; number < numPairs; number++)
            {
                pairs[number] = str.Substring(number, 2);
            }
            return pairs;
        }
    }
}
