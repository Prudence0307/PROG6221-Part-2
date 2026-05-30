using System.Collections.Generic;

namespace CyberSecChatbotWPF.Services
{
    public static class KnowledgeBase
    {
        public static Dictionary<string, List<string>> Responses =
            new Dictionary<string, List<string>>
        {
            {
                "password",
                new List<string>
                {
                    "Use at least 12 characters.",
                    "Use uppercase, lowercase, numbers and symbols.",
                    "Avoid using personal information."
                }
            },

            {
                "phishing",
                new List<string>
                {
                    "Verify sender addresses.",
                    "Never click suspicious links.",
                    "Check URLs carefully."
                }
            },

            {
                "malware",
                new List<string>
                {
                    "Keep software updated.",
                    "Use antivirus protection.",
                    "Download only from trusted websites."
                }
            }
        };
    }
}
