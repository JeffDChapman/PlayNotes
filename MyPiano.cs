using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace PlayNotes
{
    public partial class MyPiano : Form
    {
        private bool stopPressed;
        private int minFrequency = 300;
        private int maxFrequency = 1200;
        private int minNoteDuration = 500;
        private int numOfPhrases = 6;
        private int freqNormalizer = 16;
        private float SweepSize = 1.03f;

        private struct NoteStruct
            { public int NoteTime; public bool NoteRest; public double Notefrequency; }
        private List<NoteStruct> onePhrase;

        public MyPiano()
        {
            InitializeComponent();
            if (!this.Visible) { btnGo_Click(this, null);  }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (btnGo.Text == "Go") { btnGo.Text = "Stop"; stopPressed = false; }
            else if (!cbContinuous.Checked)
                { btnGo.Text = "Stop"; stopPressed = true; btnGo.Text = "Go"; return; }

            // Create a new instance of WaveOutEvent
            using (var waveOut = new WaveOutEvent())
            {
                // Create a new instance of SignalGenerator
                var signalGenerator = new SignalGenerator((int)(maxFrequency * 1.5), 1);
                signalGenerator.Type = SignalGeneratorType.Sweep;
                signalGenerator.SweepLengthSecs = 2;

                // Create a new WaveProvider32 with the SignalGenerator
                var waveProvider = signalGenerator.ToWaveProvider();

                // Initiate playback
                waveOut.Init(waveProvider);

                // Random number generator
                Random random = new Random();

                // Generate and play random phrases
                for (int i = 0; i < numOfPhrases; i++)
                {
                    onePhrase = new List<NoteStruct>();
                    BuildNotePhrase(onePhrase, random);

                    for (int k = 0; k < 2; k++)
                    {
                        for (int j = 0; j < onePhrase.Count; j++)
                        { 
                            unpackAndPlay(onePhrase[j], signalGenerator, waveOut);
                            if (stopPressed) { waveOut.Stop(); return; }
                        }
                        Console.WriteLine("----------------");
                        System.Threading.Thread.SpinWait(2000);
                        System.Threading.Thread.Sleep(1000);
                        waveOut.Stop();
                        System.Threading.Thread.SpinWait(2000);
                        System.Threading.Thread.Sleep(1000);
                    }
                }

                if (!cbContinuous.Checked)
                {
                    // Cleanup
                    waveOut.Stop();
                    this.Close();
                    Application.Exit();
                }
                btnGo_Click(this, null);
            }
        }

        private void unpackAndPlay(NoteStruct noteStruct, SignalGenerator signalGenerator, WaveOutEvent waveOut)
        {
            int playTime;
            bool playRest;
            double frequency;
            //GetAnote(random, out playTime, out playRest, out frequency);
            playTime = noteStruct.NoteTime;
            playRest = noteStruct.NoteRest;
            frequency = noteStruct.Notefrequency;

            signalGenerator.Frequency = (double)frequency;
            signalGenerator.FrequencyEnd = frequency * SweepSize;
            Console.Write(signalGenerator.Frequency.ToString() + " ");

            if (playRest)
            {
                waveOut.Stop();
                Console.WriteLine("X");
                Console.Write("Rest ");
            }
            else { waveOut.Play(); }

            //waveOut.Play();

            // Wait for the duration of the note

            Console.WriteLine(playTime.ToString());

            System.Threading.Thread.SpinWait(2000);
            System.Threading.Thread.Sleep(playTime);
            Application.DoEvents();
        }

        private void BuildNotePhrase(List<NoteStruct> onePhrase, Random random)
        {
            int phraseLen = random.Next(3, 9);
            for (int i = 0; i < phraseLen; i++)
            {
                int playTime;
                bool playRest;
                double frequency;
                GetAnote(random, out playTime, out playRest, out frequency);
                NoteStruct myNote = new NoteStruct();
                myNote.NoteTime = playTime;
                myNote.NoteRest = playRest;
                myNote.Notefrequency = frequency;
                onePhrase.Add(myNote);
            }

        }

        private void GetAnote(Random random, out int playTime, out bool playRest, out double frequency)
        {
            // Generate a normalized random frequency within the specified range
            frequency = (double)random.Next(minFrequency, maxFrequency + 1);
            frequency = NormalizeFreq(frequency);

            playTime = minNoteDuration * random.Next(1, 3);
            playRest = false;
            if (random.Next(1, 100) > 85) { playRest = true; }
        }

        private float NormalizeFreq(double frequency)
        {
            double logFreq = Math.Log10(frequency);
            int logFreq10 = Convert.ToInt16(logFreq * freqNormalizer);
            return (float) (Math.Pow(10, ((double)logFreq10 / freqNormalizer)));
        }
    }
}

