# PROG6221-Part-2
My poe part 2
# CyberSecChatbotWPF 

A modern, desktop-based cybersecurity awareness chatbot built using C# and WPF (Windows Presentation Foundation). The application leverages keyword recognition, sentiment detection, memory recall, and built-in speech synthesis to educate users on critical security topics like phishing, passwords, malware, and public Wi-Fi safety.

##  Features

* **Cybersecurity Knowledge Base:** Instant tips and best practices regarding passwords, phishing, malware, Wi-Fi, and 2FA.
* **Sentiment Detection:** Dynamically recognizes user emotions (worried, frustrated, curious) and adjusts its tone.
* **Contextual Memory:** Remembers the last topic you discussed and recalls it when asked.
* **Text-to-Speech (TTS):** Uses `System.Speech` to read responses out loud for improved accessibility.
* **Modern ASCII GUI:** A dark-themed, sleek user interface featuring styled borders and a custom ASCII art header.

---

## Project Directory Structure

Ensure your project files are arranged exactly as follows within your solution directory:

CyberSecChatbotWPF/
│
├── CyberSecChatbotWPF.csproj
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
│
├── Models/
│   ├── ChatMessage.cs
│   └── UserProfile.cs
│
└── Services/
    ├── AudioPlayerService.cs
    ├── ChatbotEngine.cs
    ├── KnowledgeBaseService.cs
    ├── MemoryService.cs
    ├── SentimentService.cs
    └── SpeechService.cs

---

## Prerequisites

Before running the application, make sure you have:
1.  **Windows OS** (Required for WPF and `System.Speech`).
2.  **Visual Studio 2022** (with the *.NET Desktop Development* workload installed).
3.  **.NET 6.0 / 7.0 / 8.0 SDK** (depending on your target framework configuration).

---

##  Setup and Installation Instructions

Follow these steps to build and run the chatbot from scratch:

### Step 1: Open Visual Studio and Create the Project
1. Open Visual Studio and select **Create a new project**.
2. Search for **WPF Application** (make sure to select the C# template, not the .NET Framework one if you want modern .NET).
3. Name the project `CyberSecChatbotWPF` and click **Next**.
4. Select your preferred target framework (e.g., .NET 8.0 or .NET 6.0) and click **Create**.

### Step 2: Install NuGet Packages
The speech synthesis functionality relies on a Windows-specific assembly. Open the **Package Manager Console** (`Tools > NuGet Package Manager > Package Manager Console`) and run:
```bash
Install-Package System.Speech
