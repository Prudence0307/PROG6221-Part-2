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
Step 3: Populate the Code Files
Create the Models and Services folders in your Solution Explorer, then copy your respective .cs and .xaml file contents into the folders as indicated in the Project Directory Structure blueprint above.

Step 4: Build and Run
Press Ctrl + Shift + B to build the solution and ensure there are no compilation errors.

Press F5 (or click the green Start button at the top) to launch the chatbot application.

💬 How to Interact with the Bot
Once the application launches, type a message into the input field at the bottom and click Send (or press Enter if configured). Try these triggers to test features:

Keyword Help: Type "Tell me about phishing" or "How can I secure my wifi?"

Sentiment Responses: Type "I am worried about my accounts" or "I'm frustrated with hackers."

Memory Recall: Ask a question about a specific topic first (e.g., "passwords"), then type: "What was my favourite topic?"
