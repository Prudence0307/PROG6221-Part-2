namespace CyberSecChatbotWPF.Services
{
    public class SentimentAnalyzer
    {
        public string Detect(string input)
        {
            input = input.ToLower();

            if (input.Contains("worried"))
                return "worried";

            if (input.Contains("frustrated"))
                return "frustrated";

            if (input.Contains("curious"))
                return "curious";

            return "neutral";
        }
    }
}
