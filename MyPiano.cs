using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;

namespace PlayNotes
{
    // Copyright 2024 J.D. Chapman -- All Rights Reserved

    public partial class MyPiano : Form
    {
        #region Private Variables
        private bool stopPressed;
        private int minFrequency = 300;
        private int maxFrequency = 1200;
        private int minNoteDuration = 300;
        private int freqNormalizer = 16;
        private int maxJump = 6;
        private int minBar = 2;
        private int maxBar = 4;
        private float SweepSize = 1.03f;
        private int minBarTime;
        private int BarMult;
        private int oldUpDown = 20;
        private string Generator = "A";
        private bool keyMatchesExisting;
        private string highestUnusedKey = "A";
        private bool prevRest = false;
        private bool stillLoading = true;
        private bool firstTimeFlag = false;
        private bool disableCascade;
        private int priorLogFreq10 = 0;
        private string setDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        #endregion

        public DataTable mySettings = new DataTable("saveSettings");
        public int numOfPhrases = 3;
        public Random random = new Random(Guid.NewGuid().GetHashCode());

        public struct NoteStruct
            { public int NoteTime; public bool NoteRest; public double Notefrequency; }
        public List<NoteStruct> onePhrase = new List<NoteStruct>();
        public SignalGenerator signalGenerator = new SignalGenerator(2500, 1);

        private struct settingsStruct
        {
            public int minFrequency;
            public int maxFrequency ;
            public int minNoteDuration;
            public int numOfPhrases;
            public int freqNormalizer;
            public int maxJump;
            public int minBar;
            public int maxBar;
            public float SweepSize;
            public string Generator;
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
            mySettings.Columns.Add("maxJump");
            mySettings.Columns.Add("minBar");
            mySettings.Columns.Add("maxBar");
            mySettings.Columns.Add("SweepSize");
            mySettings.Columns.Add("Generator");
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
                    oneKey.numOfPhrases, oneKey.freqNormalizer, oneKey.maxJump,
                    oneKey.minBar, oneKey.maxBar, oneKey.SweepSize, oneKey.Generator);
            }
            DataTable xmlOut = null;
            mySettings.DefaultView.Sort = "Generator";
            xmlOut = mySettings.DefaultView.ToTable();
            xmlOut.WriteXml(setDir + "\\Notes_Settings.xml");
        }

        private void GetSettings()
        {
            mySettings.Clear();
            try { mySettings.ReadXml(setDir + "\\Notes_Settings.xml"); } 
            catch 
            {
                firstTimeFlag = true; 
                return; 
            }
            DataRowCollection allRows = mySettings.Rows;

            keySettings.Clear();
            foreach (DataRow oneRow in allRows)
            {
                DataRow theSettings = oneRow;
                SettingsFromDatarow(theSettings);
                Generator = theSettings["Generator"].ToString();
                AddKeyToSettingsList();
            }

            SetTheSliders();
            tbKey.Text = Generator;
            int thisKeyNum = (int)(Generator.ToCharArray()[0]);
            string nextKey = char.ConvertFromUtf32(thisKeyNum + 1);
            highestUnusedKey = nextKey;
            btnNewKey.Visible = true;
            stillLoading = false;
        }

        public void SettingsFromDatarow(DataRow theSettings)
        {
            minFrequency = Convert.ToInt16(theSettings["minFrequency"]);
            maxFrequency = Convert.ToInt16(theSettings["maxFrequency"]);
            minNoteDuration = Convert.ToInt16(theSettings["minNoteDuration"]);
            numOfPhrases = Convert.ToInt16(theSettings["numOfPhrases"]);
            freqNormalizer = Convert.ToInt16(theSettings["freqNormalizer"]);
            maxJump = Convert.ToInt16(theSettings["maxJump"]);
            minBar = Convert.ToInt16(theSettings["minBar"]);
            maxBar = Convert.ToInt16(theSettings["maxBar"]);
            SweepSize = (float)Convert.ToDouble(theSettings["SweepSize"]);
        }

        public void SetTheSliders()
        {
            tbMinFreq.Value = minFrequency;
            tbMaxFreq.Value = maxFrequency;
            tbNoteDur.Value = minNoteDuration;
            tbPhrases.Value = numOfPhrases;
            tbDensity.Value = freqNormalizer;
            tbMaxJump.Value = maxJump;
            tbMinBar.Value = minBar;
            tbMaxBar.Value = maxBar;
            tbSweep.Value = (int)((SweepSize + .01) * 100);
        }

        private void AddKeyToSettingsList()
        {
            settingsStruct keySaver = new settingsStruct();
            keySaver.minFrequency = minFrequency; keySaver.maxFrequency = maxFrequency;
            keySaver.minNoteDuration = minNoteDuration;
            keySaver.numOfPhrases = numOfPhrases;
            keySaver.freqNormalizer = freqNormalizer;
            keySaver.maxJump = maxJump;
            keySaver.minBar = minBar; keySaver.maxBar = maxBar;
            keySaver.SweepSize = SweepSize;
            keySaver.Generator = Generator;
            keySettings.Add(keySaver);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            (btnGo.BackColor, btnGo.ForeColor) = (btnGo.ForeColor, btnGo.BackColor);
            if (btnGo.Text == "Play Phrase") { btnGo.Text = "Stop"; stopPressed = false; }
                else if (!cbContinuous.Checked)
                {
                    stopPressed = true;
                    btnGo.Text = "Play Phrase";
                    SaveSettings();
                    return;
                }

            if (firstTimeFlag) { btnSaveKey_Click(this, null); firstTimeFlag = false; }
            MakeMusic();
        }

        public void MakeMusic()
        {
            // Create a new instance of WaveOutEvent
            using (var waveOut = new WaveOutEvent())
            {
                // Create a new instance of SignalGenerator
                //var signalGenerator = new SignalGenerator((int)(maxFrequency * 1.5), 1);
                signalGenerator.Type = SignalGeneratorType.Sweep;
                signalGenerator.SweepLengthSecs = 2;

                // Create a new WaveProvider32 with the SignalGenerator
                var waveProvider = signalGenerator.ToWaveProvider();

                // Initiate playback
                waveOut.Init(waveProvider);

                ComputeBarTime();

                // Generate and play random phrases
                for (int i = 0; i < numOfPhrases; i++)
                {
                    onePhrase.Clear();
                    BuildNotePhrase(onePhrase, random);
                    PlayPhraseTwice(waveOut, signalGenerator);
                }

                waveOut.Stop();
                SaveSettings();

                if (stopPressed) { return; }

                if ((!cbContinuous.Checked) && (!this.Visible))
                    { this.Close(); Application.Exit(); }

                if (cbContinuous.Checked) { btnGo_Click(this, null); }
                else { btnGo.Text = "Play Phrase"; }
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

        public void unpackAndPlay(NoteStruct noteStruct, SignalGenerator signalGenerator, 
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

        public void BuildNotePhrase(List<NoteStruct> onePhrase, Random random)
        {
            int playTime;
            bool playRest;
            double frequency;
            random = new Random(Guid.NewGuid().GetHashCode());
            priorLogFreq10 = 0;

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
                if (thisBarLen > maxBar) { thisBarLen = maxBar; }
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
            if (priorLogFreq10 != 0)
            {
                if (logFreq10 > priorLogFreq10 + maxJump) { logFreq10 = priorLogFreq10 + maxJump; }
                if (logFreq10 < priorLogFreq10 - maxJump) { logFreq10 = priorLogFreq10 - maxJump; }
            }
            priorLogFreq10 = logFreq10;
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
            int holdJump = maxJump;
            tbMaxJump.Value = 2;
            tbMaxJump.Maximum = freqNormalizer;
            Application.DoEvents();
            if (holdJump > freqNormalizer) { holdJump = freqNormalizer; }
            tbMaxJump.Value = holdJump;
            Application.DoEvents();
        }

        private void tbMaxJump_ValueChanged(object sender, EventArgs e)
        {
            maxJump = tbMaxJump.Value;
            lblMaxJump.Text = "Max Jump: " + maxJump.ToString();
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
            // if key doesn't already exists, add it
            keyMatchesExisting = false;
            int KeyNum = (int)(tbKey.Text.ToUpper().ToCharArray()[0]);
            int hUK = (int)(highestUnusedKey.ToCharArray()[0]);
            if (KeyNum < hUK) { keyMatchesExisting = true; }
            if (!keyMatchesExisting)
            {
                AddKeyToSettingsList();
                BumpGen(); return;
            }
            // find matching key and replace it
            foreach (settingsStruct oneKey in keySettings)
            {
                if (oneKey.Generator != Generator) { continue; }
                keySettings.Remove(oneKey);
                AddKeyToSettingsList();
                break;
            }
        }

        private void BumpGen()
        {
            int priorKeyNum = (int)(tbKey.Text.ToCharArray()[0]);
            string newKey = char.ConvertFromUtf32(priorKeyNum + 1);
            tbKey.Text = newKey;
            Generator = newKey;
            highestUnusedKey = newKey;
            btnNewKey.Visible = false;
        }

        private void tbKey_TextChanged(object sender, EventArgs e)
        {
            if (stillLoading) return;
            if (disableCascade) { disableCascade = false; return; }
            if (tbKey.Text.Length == 0) { return; }
            int KeyNum = (int)(tbKey.Text.ToUpper().ToCharArray()[0]);
            int hUK = (int)(highestUnusedKey.ToCharArray()[0]);
            if (KeyNum >= hUK) 
            {
                disableCascade = true;
                tbKey.Text = highestUnusedKey; 
                return; 
            }
            tbKey.Text = tbKey.Text.ToUpper().Substring(0, 1);
            Generator = tbKey.Text;
            // locate the settings for this key and implement them
            DataRow[] theSettings = mySettings.Select("Generator = '" + Generator + "'");
            SettingsFromDatarow(theSettings[0]);
            SetTheSliders();
        }

        private void btnNewKey_Click(object sender, EventArgs e)
        {
            tbKey.Text = highestUnusedKey;
            Generator = highestUnusedKey;
            btnNewKey.Visible = false;
        }

        private void btnPatterns_Click(object sender, EventArgs e)
        {
            Patterns myPatterns = new Patterns(this);
            myPatterns.ShowDialog();
        }

        private void MyPiano_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
    }
}
