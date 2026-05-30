using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HomeChat.Models
{
    class Program
    {
        private static readonly List<ChatMessage> chatHistory = new List<ChatMessage>();
        private static readonly Dictionary<string, List<string>> knowledgeBase = new Dictionary<string, List<string>>();
        private static bool isRunning = true;
        private static string userName = "User";

        static void Main(string[] args)
        {
            InitializeKnowledgeBase();
            DisplayWelcomeScreen();
            ChatLoop();
        }

        static void InitializeKnowledgeBase()
        {
            knowledgeBase["password"] = new List<string>
            {
                "Use passwords with at least 12 characters including uppercase, lowercase, numbers, and symbols.",
                "Never reuse passwords across different sites.",
                "Use a password manager to generate and store complex passwords.",
                "Enable two-factor authentication (2FA) wherever possible.",
                "Avoid using personal information (birthdays, names, etc.) in passwords."
            };

            knowledgeBase["phishing"] = new List<string>
            {
                "Never click links in unsolicited emails - hover to check the real URL.",
                "Verify sender email addresses carefully.",
                "Look for spelling/grammar errors in suspicious messages.",
                "Don't download attachments from unknown sources.",
                "Use antivirus software with real-time protection."
            };

            knowledgeBase["malware"] = new List<string>
            {
                "Keep your operating system and software updated.",
                "Use reputable antivirus/antimalware software.",
                "Avoid downloading software from untrusted sources.",
                "Don't enable macros in Microsoft Office documents from unknown sources.",
                "Regularly scan your system for malware."
            };

            knowledgeBase["social"] = new List<string>
            {
                "Don't share personal information on social media.",
                "Adjust privacy settings to limit who sees your posts.",
                "Be cautious of friend requests from strangers.",
                "Think before posting - once online, it's permanent.",
                "Avoid sharing location information in real-time."
            };

            knowledgeBase["wifi"] = new List<string>
            {
                "Avoid public WiFi for sensitive activities (banking, shopping).",
                "Use a VPN on public networks.",
                "Verify WiFi network names before connecting.",
                "Forget networks after use to prevent auto-reconnection.",
                "Enable WPA3 encryption on your home router."
            };

            knowledgeBase["backup"] = new List<string>
            {
                "Follow the 3-2-1 rule: 3 copies, 2 different media, 1 offsite.",
                "Use encrypted backups.",
                "Test your backups regularly to ensure they work.",
                "Automate backup schedules.",
                "Consider cloud backup services with strong encryption."
            };

            knowledgeBase["ransomware"] = new List<string>
            {
                "Regular backups are your best defense.",
                "Never pay ransom - it funds criminals.",
                "Keep software updated to patch vulnerabilities.",
                "Disable macros in email attachments.",
                "Use antivirus with ransomware protection."
            };

            knowledgeBase["2fa"] = new List<string>
            {
                "Enable 2FA on all accounts that support it.",
                "Use app-based authenticators (Google Authenticator, Authy) over SMS.",
                "Hardware keys (YubiKey) provide the highest security.",
                "Backup your 2FA recovery codes securely.",
                "Never share 2FA codes or recovery keys."
            };
        }

        static void DisplayWelcomeScreen()
        {
            Console.Clear();

            // ASCII cybersecurity logo
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@" 
   _____       _               ____        _   
  / ____|     | |             |  _ \\      | |  
 | |     _   _| |__   ___ _ __| |_) | ___ | |_ 
 | |    | | | | '_ \\ / _ \\ '__|  _ < / _ \\| __|
 | |____| |_| | |_) |  __/ |  | |_) | (_) | |_ 
  \\_____|\\__,_|_.__/ \\___|_|  |____/ \\___/ \\__|
");
            Console.WriteLine("   CYBERSECURITY AWARENESS BOT\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║          🛡️ CYBERSEC AWARENESS CHATBOT 🛡️           ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║     Your friendly guide to staying safe online!      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n💬 Hi! I'm CyberBot, your cybersecurity assistant.");
            Console.WriteLine("🔒 Ask me about: passwords, phishing, malware, social media, WiFi, backups, ransomware, 2FA, and more!");
            Console.ResetColor();

            Console.Write("\n👤 What's your name? ");
            userName = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(userName)) userName = "User";

            Console.WriteLine($"\n🎉 Nice to meet you, {userName}! Type 'help' for commands or 'quit' to exit.\n");
            Console.Write("💬 You: ");
        }

        // Typing effect utility
        static void TypeText(string message, int delayMs = 5)
        {
            if (message == null) return;

            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
        }

        static void ChatLoop()
        {
            while (isRunning)
            {
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(userInput))
                    continue;

                ProcessCommand(userInput);

                if (isRunning)
                {
                    Console.Write("\n💬 You: ");
                }
            }
        }

        static void ProcessCommand(string input)
        {
            ChatMessage userMessage = new ChatMessage { Sender = userName, Message = input, Timestamp = DateTime.Now, IsUser = true };
            chatHistory.Add(userMessage);

            switch (input)
            {
                case "quit":
                case "exit":
                    ShowGoodbye();
                    return;

                case "help":
                case "commands":
                    ShowHelp();
                    break;

                case "clear":
                    Console.Clear();
                    DisplayChatHeader();
                    break;

                case "history":
                    ShowChatHistory();
                    break;

                case "quiz":
                    StartQuiz();
                    break;

                case "topics":
                    ShowTopics();
                    break;

                default:
                    string response = GetResponse(input);
                    DisplayBotResponse(response);
                    break;
            }
        }

        static string GetResponse(string input)
        {
            // Keyword matching with fuzzy logic
            foreach (var kvp in knowledgeBase)
            {
                if (kvp.Key.Any(word => input.Contains(word)))
                {
                    var responses = kvp.Value;
                    return responses[new Random().Next(responses.Count)];
                }
            }

            // Fallback responses
            string[] fallbacks = {
                "That's an interesting question! Could you be more specific about passwords, phishing, malware, or another cybersecurity topic?",
                "I can help with topics like strong passwords, phishing detection, malware protection, and more. What would you like to learn?",
                "Great question! Try asking about 'passwords', 'phishing', '2FA', 'malware', 'backups', or type 'topics' to see all subjects.",
                "I'm here to help with cybersecurity best practices. What specific area interests you most?"
            };

            return fallbacks[new Random().Next(fallbacks.Length)];
        }

        static void DisplayBotResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n🤖 CyberBot: {message}");
            Console.ResetColor();

            ChatMessage botMessage = new ChatMessage
            {
                Sender = "CyberBot",
                Message = message,
                Timestamp = DateTime.Now,
                IsUser = false
            };
            chatHistory.Add(botMessage);
        }

        static void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n📋 Available Commands:");
            Console.WriteLine("• 'help' or 'commands' - Show this help");
            Console.WriteLine("• 'topics' - List all cybersecurity topics");
            Console.WriteLine("• 'quiz' - Test your knowledge");
            Console.WriteLine("• 'history' - View chat history");
            Console.WriteLine("• 'clear' - Clear screen");
            Console.WriteLine("• 'quit' or 'exit' - Exit chatbot");
            Console.ResetColor();
        }

        static void ShowTopics()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📚 Available Topics:");
            Console.WriteLine("• passwords - Create strong passwords");
            Console.WriteLine("• phishing - Spot phishing attacks");
            Console.WriteLine("• malware - Protect against viruses");
            Console.WriteLine("• social - Social media safety");
            Console.WriteLine("• wifi - Secure WiFi usage");
            Console.WriteLine("• backup - Data backup strategies");
            Console.WriteLine("• ransomware - Ransomware defense");
            Console.WriteLine("• 2fa - Two-factor authentication");
            Console.ResetColor();
        }

        static void StartQuiz()
        {
            Console.Clear();
            DisplayChatHeader();

            string[] questions = {
                "What's the minimum length for a strong password? A) 6 B) 8 C) 12",
                "Should you click links in unsolicited emails? A) Yes B) No C) Sometimes",
                "What's better than SMS 2FA? A) Nothing B) App-based C) Email",
                "Follow which backup rule? A) 1-1-1 B) 2-1-1 C) 3-2-1"
            };

            string[] answers = { "C", "B", "B", "C" };
            string[] explanations = {
                "12+ characters with mixed case, numbers, and symbols!",
                "Always verify before clicking suspicious links.",
                "App-based authenticators are more secure than SMS.",
                "3 copies, 2 media types, 1 offsite location."
            };

            int score = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🎯 CYBERSEC QUIZ TIME! 🎯");
            Console.WriteLine("Answer A, B, or C for each question.\n");
            Console.ResetColor();

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {questions[i]}");
                Console.Write("Your answer: ");
                string userAnswer = Console.ReadLine()?.ToUpper().Trim();

                if (userAnswer == answers[i])
                {
                    score++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("✅ Correct!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ Wrong! Correct answer: {answers[i]}");
                }
                Console.WriteLine($"💡 {explanations[i]}\n");
                Console.ResetColor();
                Thread.Sleep(1000);
            }

            double percentage = (double)score / questions.Length * 100;
            Console.ForegroundColor = percentage >= 75 ? ConsoleColor.Green : ConsoleColor.Yellow;
            Console.WriteLine($"🏆 Final Score: {score}/{questions.Length} ({percentage:F0}%)");
            Console.ResetColor();

            if (percentage >= 75)
                Console.WriteLine("🎉 Excellent! You're cybersecurity savvy!");
            else
                Console.WriteLine("📚 Keep learning! You're on the right track!");

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        static void ShowChatHistory()
        {
            Console.Clear();
            DisplayChatHeader();

            Console.WriteLine("\n📜 Chat History:");
            Console.WriteLine(new string('=', 60));

            foreach (var msg in chatHistory.Take(20))
            {
                Console.ForegroundColor = msg.IsUser ? ConsoleColor.Cyan : ConsoleColor.Yellow;
                Console.WriteLine($"{msg.Timestamp:HH:mm:ss} | {msg.Sender}: {msg.Message}");
            }
            Console.ResetColor();

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        static void ShowGoodbye()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("👋 Thanks for chatting, {userName}!");
            Console.WriteLine("🛡️ Stay safe online!");
            Console.WriteLine("\n💡 Quick reminder:");
            Console.WriteLine("• Use strong, unique passwords");
            Console.WriteLine("• Enable 2FA everywhere");
            Console.WriteLine("• Keep software updated");
            Console.WriteLine("• Backup regularly");
            Console.ResetColor();
            Thread.Sleep(2000);
            isRunning = false;
        }

        static void DisplayChatHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🛡️ CYBERSEC CHATBOT | Type 'help' for commands");
            Console.WriteLine(new string('═', 50));
            Console.ResetColor();
        }
    }

    class ChatMessage
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsUser { get; set; }
    }
}
