using CyberSecChatbotWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecChatbotWPF.Services
{
    public class ChatbotEngine
    {
        private Random random = new Random();

        private SentimentAnalyzer sentiment =
            new SentimentAnalyzer();

        private MemoryManager memory =
            new MemoryManager();

        public string ProcessInput(string input)
        {
            try
            {
                string mood = sentiment.Detect(input);

                if (mood == "worried")
                {
                    return "I understand your concern. Scammers can be convincing. Always verify links and sender details.";
                }

                if (input.StartsWith("my name is"))
                {
                    string name =
                        input.Replace("my name is", "").Trim();

                    memory.Remember("username", name);

                    return $"Nice to meet you {name}. I'll remember your name.";
                }

                if (input.Contains("what is my name"))
                {
                    string name =
                        memory.Recall("username");

                    return name == null
                        ? "I don't know your name yet."
                        : $"Your name is {name}.";
                }

                foreach (var item in KnowledgeBase.Responses)
                {
                    if (input.ToLower()
                        .Contains(item.Key))
                    {
                        return item.Value[
                            random.Next(item.Value.Count)];
                    }
                }

                return "I'm not sure I understand. Can you try rephrasing?";
            }
            catch
            {
                return "An unexpected error occurred. Please try again.";
            }
        }
    }
}
