using System;
using System.Speech.Synthesis;

namespace SampleSynthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            test2();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void test1()
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output.   
            synth.SetOutputToDefaultAudioDevice();

            // 同步
            // Speak a string.  
            synth.Speak("This example demonstrates a basic use of Speech Synthesizer");
            //synth.Speak("锄禾日当午，汗滴禾下土，谁知盘中餐，粒粒皆辛苦。");
        }

        static void test2()
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            SpeechSynthesizer speech = new SpeechSynthesizer();
            
            speech.Rate = -5; // 语速(-10 ~ 10)
            speech.Volume = 100; // 音量
            //speech.SelectVoice("Microsoft Lili"); //设置播音员（中文），需要安装语音包
            //speech.SelectVoice("Microsoft Anna"); //英文

            speech.SpeakAsync("Hello world.");//异步模式
            speech.SpeakAsync("锄禾日当午，汗滴禾下土，谁知盘中餐，粒粒皆辛苦。");//语音阅读方法
            speech.SpeakCompleted += speech_SpeakCompleted;//绑定事件

        }

        static void speech_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            Console.WriteLine("speech_SpeakCompleted.");
        }
    }
}