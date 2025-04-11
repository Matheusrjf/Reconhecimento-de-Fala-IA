using System.Speech.Recognition;
using System.Speech.Synthesis;

SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
SpeechSynthesizer synthesizer = new SpeechSynthesizer();

Choices commands = new Choices(new string[] { "que horas são", "abrir Google", "me lembre daqui a 5 minutos" });
Grammar grammar = new Grammar(new GrammarBuilder(commands));

recognizer.LoadGrammar(grammar);
recognizer.SetInputToDefaultAudioDevice();

recognizer.SpeechRecognized += (s, e) => {
    string command = e.Result.Text;
    
    if (command == "que horas são") {
        synthesizer.Speak("Agora são " + DateTime.Now.ToShortTimeString());
    }
    else if (command == "abrir Google") {
        System.Diagnostics.Process.Start("https://www.google.com");
        synthesizer.Speak("Abrindo Google");
    }
    else {
        synthesizer.Speak("Comando não reconhecido.");
    }
};

recognizer.RecognizeAsync(RecognizeMode.Multiple);
