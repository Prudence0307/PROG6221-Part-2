using System.Speech.Synthesis;

namespace CyberSecChatbotWPF.Services
{
    public class SpeechService
    {
        private SpeechSynthesizer speaker =
            new SpeechSynthesizer();

        public void Speak(string text)
        {
            speaker.SpeakAsync(text);
        }
    }
}