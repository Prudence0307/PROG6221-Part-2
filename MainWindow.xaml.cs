using CyberSecChatbotWPF.Services;
using System.Windows;

namespace CyberSecChatbotWPF
{
    public partial class MainWindow : Window
    {
        private AudioPlayerService audioPlayer =
    new AudioPlayerService();

        public MainWindow()
        {
            InitializeComponent();

            ChatList.Items.Add(
                "🤖 CyberBot: Welcome to Cyber Security Awareness Bot!");

            audioPlayer.Play(@"""C:\Users\seduma kholofelo\source\repos\CyberSecChatbotWPF\CyberSecChatbotWPF\Greeting.wav""");
        }
        private ChatbotEngine bot =
            new ChatbotEngine();

        private SpeechService speech =
            new SpeechService();
        

        private void btnSend_Click(object sender,
            RoutedEventArgs e)
        {
            string userInput = txtInput.Text.Trim();

            if (string.IsNullOrEmpty(userInput))
                return;

            ChatList.Items.Add(
                $"👤 You: {userInput}");

            string response =
                bot.ProcessInput(userInput);

            ChatList.Items.Add(
                $"🤖 CyberBot: {response}");

            speech.Speak(response);

            txtInput.Clear();
        }
    }
}

