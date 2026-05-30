using System;

using System.IO;

using System.Media;

using System.Net.NetworkInformation;

using System.Windows;



namespace CyberSecChatbotWPF.Services

{

    public class AudioPlayerService

    {

        private SoundPlayer player;



        internal void Play(string v)

        {

            

        }



        public static class AudioPlayer

        {

            public static void PlayGreeting(string filePath)

            {

                string audioFilePath = @"""C:\Users\seduma kholofelo\source\repos\CyberSecChatbotWPF\CyberSecChatbotWPF\Greeting.wav"""; // Make sure the file is in the output folder



                // Use the default audio path when a short name or null is provided

                if (string.IsNullOrEmpty(filePath) || filePath == "Audio.wav")

                {

                    filePath = audioFilePath;

                }



                // Makes sure the audio file exists first

                if (!File.Exists(filePath))

                {

                    MessageBox.Show("Audio file missing: " + filePath);

                    return;

                }



                try

                {

                    // Loads and plays the greeting

                    SoundPlayer player = new SoundPlayer(filePath);

                    player.Play();

                }

                catch (Exception ex)

                {

                    MessageBox.Show("Audio playback failed: " + ex.Message);

                }

            }

        }

    }

}

