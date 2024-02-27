using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace PlayNotes
{
    public partial class Patterns : Form
    {
        private MyPiano myParent;

        private struct onePhrase
            { public string genCodeID; public List<MyPiano.NoteStruct> noteList; }

        private List<onePhrase> phraseList = new List<onePhrase>();
        private string MRUfile; 

        public Patterns(MyPiano parent)
        {
            InitializeComponent();
            myParent = parent;
            if (myParent.mySettings.Rows.Count > 1) { rbA1B1A2B2.Enabled = true; }
            MRUfile = myParent.setDir + "\\PatternsMRU.txt";
            LoadMRUlist();
        }

        private void LoadMRUlist()
        {
            ComboBox.ObjectCollection MRUitems = cbMRU.Items;
            try 
            { 
                var lines = File.ReadLines(MRUfile);
                foreach (var oneLine in lines)
                    { MRUitems.Add(oneLine.ToString());  }
            } 
            catch { cbMRU.Enabled = false; return; }
        }

        private void btnPlayPattern_Click(object sender, EventArgs e)
        {
            tbCustomPattern.Text = tbCustomPattern.Text.ToUpper();
            string playPattern = tbCustomPattern.Text;
            if (rbYourOwn.Checked) 
            {
                try { cbMRU.Items.Remove(playPattern); } catch { }
                cbMRU.Items.Insert(0, playPattern);
                PlayPattern(tbCustomPattern.Text); 
                return; 
            }
            if (rbA1A1.Checked) { playPattern = makePatternA1A1(); }
            if (rbA1A1A2.Checked) { playPattern = makePatternA1A1A2(); }
            if (rbA1B1A2B2.Checked) { playPattern = makePatternA1B1A2B2(); }
            PlayPattern(playPattern);
        }

        private string makePatternA1B1A2B2()
        {
            string playPattern = "";
            for (int i = 0; i < myParent.numOfPhrases; i++)
            {
                playPattern += "A" + (i + 1).ToString();
                playPattern += "B" + (i + 1).ToString();
            }
            return playPattern;
        }

        private string makePatternA1A1A2()
        {
            string playPattern = "";
            for (int i = 0; i < myParent.numOfPhrases; i++)
            {
                int j = i * 2;
                if (j + 2 > 9) { break; }
                playPattern += "A" + (j + 1).ToString();
                playPattern += "A" + (j + 1).ToString();
                playPattern += "A" + (j + 2).ToString();
            }
            return playPattern;
        }

        private string makePatternA1A1()
        {
            string playPattern = "";
            for (int i = 0; i < myParent.numOfPhrases; i++)
            {
                playPattern += "A" + (i + 1).ToString();
                playPattern += "A" + (i + 1).ToString();
            }
            return playPattern;
        }

        private void PlayPattern(string patternText)
        {
            string genCode = "";
            for (int i = 0; i < patternText.Length; i++)
            {
                string playChar = patternText.Substring(i, 1);
                Console.WriteLine(playChar);
                if (playChar == " ") { continue; }
                if (Char.IsNumber(playChar,0))
                {
                    genCode += playChar;
                    List<MyPiano.NoteStruct> phraseBack = FindExistingNotes(genCode);
                    if (phraseBack == null)
                        { CreateAndPlay(genCode); continue; }
                    // play the existing phrase
                    PlayThePhrase(phraseBack, genCode);
                    continue;
                }
                genCode = playChar;
            }
        }

        private void CreateAndPlay(string genCode)
        {
            Console.WriteLine("Will create music for new code: " + genCode);
            myParent.tbKey.Text = genCode.Substring(0, 1);
            Application.DoEvents();
            myParent.onePhrase.Clear();
            myParent.BuildNotePhrase(myParent.onePhrase, myParent.random);
            PlayThePhrase(myParent.onePhrase, genCode);
            onePhrase myPhrase = new onePhrase();
            myPhrase.genCodeID = genCode;
            myPhrase.noteList = new List<MyPiano.NoteStruct>();
            foreach (MyPiano.NoteStruct noteSpec in myParent.onePhrase)
                { myPhrase.noteList.Add(noteSpec); }
            phraseList.Add(myPhrase);
        }

        private void PlayThePhrase(List<MyPiano.NoteStruct> phraseBack, string genCode)
        {
            string Generator = genCode.ToUpper().Substring(0, 1);
            myParent.tbKey.Text = Generator;
            // locate the settings for this key and implement them
            DataRow[] theSettings = myParent.mySettings.Select("Generator = '" + Generator + "'");
            myParent.SettingsFromDatarow(theSettings[0]);
            myParent.SetTheSliders();
            Application.DoEvents();

            using (var waveOut = new WaveOutEvent())
            {
                // Create a new WaveProvider32 with the SignalGenerator
                var waveProvider = myParent.signalGenerator.ToWaveProvider();
                waveOut.Init(waveProvider);

                bool nearEnd = false;
                for (int j = 0; j < phraseBack.Count; j++)
                {
                    if (j == phraseBack.Count - 1) { nearEnd = true; }
                    myParent.unpackAndPlay(phraseBack[j], myParent.signalGenerator, waveOut, nearEnd);
                }
            }
            System.Threading.Thread.SpinWait(2000);
            System.Threading.Thread.Sleep(1000);
        }

        private List<MyPiano.NoteStruct> FindExistingNotes(string genCode)
        {
            Console.WriteLine("Searching For " + genCode);
            foreach (onePhrase myPhrase in phraseList)
            {
                string chkGenCode = myPhrase.genCodeID;
                if (chkGenCode == genCode) 
                {
                    Console.Write("Found: ");
                    foreach (MyPiano.NoteStruct noteSpec in myPhrase.noteList)
                        { Console.Write(noteSpec.Notefrequency.ToString() + " "); }
                    Console.WriteLine();
                    return myPhrase.noteList;
                }
            }
            return null;
        }

        private void tbCustomPattern_TextChanged(object sender, EventArgs e)
        {
            rbYourOwn.Checked = true;
        }

        private void Patterns_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter mruWriter = File.CreateText(MRUfile);
            foreach (var oneItem in cbMRU.Items)
                { mruWriter.WriteLine(oneItem.ToString()); }
            mruWriter.Flush();
            mruWriter.Close();
        }

        private void cbMRU_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemSel = cbMRU.SelectedIndex;
            tbCustomPattern.Text = cbMRU.Items[itemSel].ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            phraseList.Clear();
        }
    }
}
