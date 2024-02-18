﻿using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;

namespace PlayNotes
{
    public partial class MyPiano : Form
    {
        #region Private Variables
        private bool stopPressed;
        private int minFrequency = 300;
        private int maxFrequency = 1200;
        private int minNoteDuration = 300;
        private int numOfPhrases = 3;
        private int freqNormalizer = 16;
        private int minBar = 2;
        private int maxBar = 4;
        private float SweepSize = 1.03f;
        private int minBarTime;
        private int BarMult;
        private int oldUpDown = 20;
        private string playKey = "A";
        private bool prevRest = false;
        private DataTable mySettings = new DataTable("saveSettings");
        private string setDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        #endregion

        private struct NoteStruct
            { public int NoteTime; public bool NoteRest; public double Notefrequency; }
        private List<NoteStruct> onePhrase;

        private struct settingsStruct
        {
            public int minFrequency;
            public int maxFrequency ;
            public int minNoteDuration;
            public int numOfPhrases;
            public int freqNormalizer;
            public int minBar;
            public int maxBar;
            public float SweepSize;
            public string playKey;
        }
        private List<settingsStruct> keySettings = new List<settingsStruct>();

        public MyPiano()
        {
            InitializeComponent();

            mySettings.Columns.Add("minFrequency");
            mySettings.Columns.Add("maxFrequency");
            mySettings.Columns.Add("minNoteDuration");
            mySettings.Columns.Add("numOfPhrases");
            mySettings.Columns.Add("freqNormalizer");
            mySettings.Columns.Add("minBar");
            mySettings.Columns.Add("maxBar");
            mySettings.Columns.Add("SweepSize");
            mySettings.Columns.Add("playKey");
            GetSettings();

            if (Control.ModifierKeys == Keys.Shift)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
                Application.DoEvents();
            }

            if (!this.Visible) { btnGo_Click(this, null); }
        }

        private void SaveSettings()
        {
            mySettings.Clear();
            DataRowCollection allRows = mySettings.Rows;
            foreach (settingsStruct oneKey in keySettings)
            {
                allRows.Add(oneKey.minFrequency, oneKey.maxFrequency, oneKey.minNoteDuration, 
                    oneKey.numOfPhrases, oneKey.freqNormalizer, oneKey.minBar, oneKey.maxBar, 
                    oneKey.SweepSize, oneKey.playKey);
            }
            mySettings.WriteXml(setDir + "\\Notes_Settings.xml");
        }

        private void GetSettings()
        {
            mySettings.Clear();
            try { mySettings.ReadXml(setDir + "\\Notes_Settings.xml"); } catch { return; }
            DataRowCollection allRows = mySettings.Rows;

            keySettings.Clear();
            foreach (DataRow oneRow in allRows)
            {
                DataRow theSettings = oneRow;
                minFrequency = Convert.ToInt16(theSettings["minFrequency"]);
                maxFrequency = Convert.ToInt16(theSettings["maxFrequency"]);
                minNoteDuration = Convert.ToInt16(theSettings["minNoteDuration"]);
                numOfPhrases = Convert.ToInt16(theSettings["numOfPhrases"]);
                freqNormalizer = Convert.ToInt16(theSettings["freqNormalizer"]);
                minBar = Convert.ToInt16(theSettings["minBar"]);
                maxBar = Convert.ToInt16(theSettings["maxBar"]);
                SweepSize = (float)Convert.ToDouble(theSettings["SweepSize"]);
                playKey = theSettings["playKey"].ToString();
                AddKeyToSettingsList();
            }
            
            tbMinFreq.Value = minFrequency;
            tbMaxFreq.Value = maxFrequency;
            tbNoteDur.Value = minNoteDuration;
            tbPhrases.Value = numOfPhrases;
            tbDensity.Value = freqNormalizer;
            tbMinBar.Value = minBar;
            tbMaxBar.Value = maxBar;
            tbSweep.Value = (int)((SweepSize + .01) * 100);
            tbKey.Text = playKey;
            BumpKey();
        }

        private void AddKeyToSettingsList()
        {
            settingsStruct keySaver = new settingsStruct();
            keySaver.minFrequency = minFrequency; keySaver.maxFrequency = maxFrequency;
            keySaver.minNoteDuration = minNoteDuration;
            keySaver.numOfPhrases = numOfPhrases;
            keySaver.freqNormalizer = freqNormalizer;
            keySaver.minBar = minBar; keySaver.maxBar = maxBar;
            keySaver.SweepSize = SweepSize;
            keySaver.playKey = playKey;
            keySettings.Add(keySaver);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (btnGo.Text == "Go") { btnGo.Text = "Stop"; stopPressed = false; }
            else if (!cbContinuous.Checked)
            {
                stopPressed = true;
                btnGo.Text = "Go";
                SaveSettings();
                return;
            }

            MakeMusic();
        }

        private void MakeMusic()
        {
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
                Random random = new Random(Guid.NewGuid().GetHashCode());

                ComputeBarTime();

                // Generate and play random phrases
                for (int i = 0; i < numOfPhrases; i++)
                {
                    onePhrase = new List<NoteStruct>();
                    BuildNotePhrase(onePhrase, random);
                    PlayPhraseTwice(waveOut, signalGenerator);
                }

                waveOut.Stop();
                SaveSettings();

                if (stopPressed) { return; }

                if (!cbContinuous.Checked)
                    { this.Close(); Application.Exit(); }

                btnGo_Click(this, null);
            }
        }

        private void PlayPhraseTwice(WaveOutEvent waveOut, SignalGenerator signalGenerator)
        {
            for (int k = 0; k < 2; k++)
            {
                bool nearEnd = false;
                for (int j = 0; j < onePhrase.Count; j++)
                {
                    if (j == onePhrase.Count - 1) { nearEnd= true; }
                    unpackAndPlay(onePhrase[j], signalGenerator, waveOut, nearEnd);
                    if (stopPressed) { break; }
                }
                if (stopPressed) { break; }
                Console.WriteLine("----------------");
                System.Threading.Thread.SpinWait(2000);
                System.Threading.Thread.Sleep(1000);
                waveOut.Stop();
                System.Threading.Thread.SpinWait(2000);
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void ComputeBarTime()
        {
            // If bar sizes have a GCD, set up bar size timings
            BarMult = 0;
            int gcd = 1; int a = minBar; int b = maxBar;
            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }
            gcd = a | b;
            if (gcd != 1) { BarMult = maxBar / gcd; }
            Console.WriteLine("Using BarMult = " + BarMult.ToString());
            minBarTime = minBar * minNoteDuration * 3;
        }

        private void unpackAndPlay(NoteStruct noteStruct, SignalGenerator signalGenerator, 
            WaveOutEvent waveOut, bool towardsEnd)
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

            bool okayToRest = false;
            if ((!towardsEnd) || prevRest) { okayToRest = true; }

            if (playRest && okayToRest)
            {
                waveOut.Stop();
                Console.WriteLine("X");
                Console.Write("Rest ");
                prevRest = true;
            }
            else { waveOut.Play(); prevRest = false; }

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
            if (BarMult == 0) { PlayByLength(); }
                else { PlayByTime(); }

            void PlayByLength()
            {
                int phraseLen = random.Next(2 * minBar, (2 * maxBar) + 1);
                for (int i = 0; i < phraseLen; i++)
                {
                    GetAnote(random, out playTime, out playRest, out frequency);
                    NoteStruct myNote = new NoteStruct();
                    myNote.NoteTime = playTime;
                    myNote.NoteRest = playRest;
                    myNote.Notefrequency = frequency;
                    onePhrase.Add(myNote);
                }
            }

            void PlayByTime()
            {
                int totalTime = 0; int thisBarLen = random.Next(1, BarMult + 1) * minBar;
                while (totalTime < thisBarLen * minNoteDuration * 2)
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

        private void upDownKey_ValueChanged(object sender, EventArgs e)
        {
            int newVal = (int)upDownKey.Value;
            int oldLowFreq = tbMinFreq.Value;
            int oldHighFreq = tbMaxFreq.Value; 
            int newFreq;

            try
            {
                if (newVal > oldUpDown) { newFreq = ComputeNewFreq(oldLowFreq, "higher"); }
                else { newFreq = ComputeNewFreq(oldLowFreq, "lower"); }
                tbMinFreq.Value = newFreq;
                if (newVal > oldUpDown) { newFreq = ComputeNewFreq(oldHighFreq, "higher"); }
                else { newFreq = ComputeNewFreq(oldHighFreq, "lower"); }
                tbMaxFreq.Value = newFreq;
            }
            catch
            {
                tbMinFreq.Value = oldLowFreq;
                tbMaxFreq.Value = oldHighFreq;
            }

            oldUpDown = newVal;
            return;

            int ComputeNewFreq(int freqIn, string direction)
            {
                double logFreq = Math.Log10(freqIn);
                double logFreq10;
                if (direction == "higher")
                    { logFreq10 = Convert.ToDouble(logFreq * freqNormalizer) + .5; }
                else
                    { logFreq10 = Convert.ToDouble(logFreq * freqNormalizer) - .5; }
                int freqBack = (int)(Math.Pow(10, ((double)logFreq10 / freqNormalizer)));
                return freqBack;
            }
        }

        private void btnSaveKey_Click(object sender, EventArgs e)
        {
            AddKeyToSettingsList();
            BumpKey();
        }

        private void BumpKey()
        {
            int priorKeyNum = (int)(tbKey.Text.ToCharArray()[0]);
            string newKey = char.ConvertFromUtf32(priorKeyNum + 1);
            tbKey.Text = newKey;
            playKey = newKey;
        }
    }
}

