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
        private int minBar = 2;
        private int maxBar = 4;
        private float SweepSize = 1.03f;
        private int minBarTime;
        private int BarMult;

        private struct NoteStruct
            { public int NoteTime; public bool NoteRest; public double Notefrequency; }
        private List<NoteStruct> onePhrase;

        public MyPiano()
        {
            InitializeComponent();
            if (Control.ModifierKeys == Keys.Shift)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
                Application.DoEvents();
            }
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

                // If bar sizes have a GCD, set up bar size timings
                BarMult = 0;
                int gcd = 1; int a = minBar; int b = maxBar;
                while (a != 0 && b != 0) 
                {
                    if (a > b) a %= b;
                    else  b %= a;
                }
                gcd = a | b;
                if (gcd != 1) { BarMult = maxBar / gcd; }
                Console.WriteLine("Using BarMult = " + BarMult.ToString());
                minBarTime = minBar * minNoteDuration * 3;

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

            // Wait for the duration of the note

            Console.WriteLine(playTime.ToString());

            System.Threading.Thread.SpinWait(2000);
            System.Threading.Thread.Sleep(playTime);
            Application.DoEvents();
        }

        private void BuildNotePhrase(List<NoteStruct> onePhrase, Random random)
        {
            int playTime;
            bool playRest;
            double frequency;
            if (BarMult == 0)
            {
                int phraseLen = random.Next(3, (3 * maxBar / minBar) + 1);
                for (int i = 0; i < phraseLen; i++)
                {
                    GetAnote(random, out playTime, out playRest, out frequency);
                    NoteStruct myNote = new NoteStruct();
                    myNote.NoteTime = playTime;
                    myNote.NoteRest = playRest;
                    myNote.Notefrequency = frequency;
                    onePhrase.Add(myNote);
                }
                return;
            }
            int totalTime = 0; int thisBarLen = random.Next(1, BarMult + 1) * minBar;
            while (totalTime < thisBarLen * minNoteDuration)
            {
                GetAnote(random, out playTime, out playRest, out frequency);
                NoteStruct myNote = new NoteStruct();
                myNote.NoteTime = playTime;
                myNote.NoteRest = playRest;
                myNote.Notefrequency = frequency;
                onePhrase.Add(myNote);
                totalTime += playTime;
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

        private void tbMinFreq_ValueChanged(object sender, EventArgs e)
        {
            minFrequency = tbMinFreq.Value;
            lblMinFreq.Text = "Min Freq: " + minFrequency.ToString();
        }

        private void tbMaxFreq_ValueChanged(object sender, EventArgs e)
        {
            maxFrequency = tbMaxFreq.Value;
            lblMaxFreq.Text = "Max Freq: " + maxFrequency.ToString();
        }

        private void tbNoteDur_ValueChanged(object sender, EventArgs e)
        {
            minNoteDuration = tbNoteDur.Value;
            lblNoteDur.Text = "Note Dur: " + minNoteDuration.ToString();
        }

        private void tbPhrases_ValueChanged(object sender, EventArgs e)
        {
            numOfPhrases = tbPhrases.Value;
            lblPhrases.Text = "Phrases: " + numOfPhrases.ToString();
        }

        private void tbDensity_ValueChanged(object sender, EventArgs e)
        {
            freqNormalizer = tbDensity.Value;
            lblNoteDensity.Text = "Note Density: " + freqNormalizer.ToString();
        }

        private void tbMinBar_ValueChanged(object sender, EventArgs e)
        {
            minBar = tbMinBar.Value;
            lblMinBar.Text = "Min Bar Len: " + minBar.ToString();
        }

        private void tbMaxBar_ValueChanged(object sender, EventArgs e)
        {
            maxBar = tbMaxBar.Value;
            lblMaxBar.Text = "Max Bar Len: " + maxBar.ToString();
        }

        private void tbSweep_ValueChanged(object sender, EventArgs e)
        {
            SweepSize = (float) tbSweep.Value / 100;
            int sweepPct = (int)(SweepSize * 100);
            lblSweep.Text = "Sweep: " + sweepPct.ToString() + "%";
        }
    }
}

