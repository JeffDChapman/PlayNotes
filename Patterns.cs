using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayNotes
{
    public partial class Patterns : Form
    {
        private MyPiano myParent;

        private struct onePhrase
            { public string genCodeID; public List<MyPiano.NoteStruct> noteList; }

        private List<onePhrase> phraseList = new List<onePhrase>();

        public Patterns(MyPiano parent)
        {
            InitializeComponent();
            myParent = parent;
            myParent.numOfPhrases = 1;
        }

        private void btnPlayPattern_Click(object sender, EventArgs e)
        {
            string playPattern = "";
            if (rbYourOwn.Checked) { PlayPattern(tbCustomPattern.Text); return; }
            if (rbA1A1.Checked) { playPattern = makePatternA1A1(); }
            if (rbA1A1A2.Checked) { playPattern = makePatternA1A1A2(); }
            if (rbA1B1A2B2.Checked) { playPattern = makePatternA1B1A2B2(); }
            PlayPattern(playPattern);
        }

        private string makePatternA1B1A2B2()
        {
            throw new NotImplementedException();
        }

        private string makePatternA1A1A2()
        {
            throw new NotImplementedException();
        }

        private string makePatternA1A1()
        {
            throw new NotImplementedException();
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
                    PlayThePhrase(phraseBack);
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
            PlayThePhrase(myParent.onePhrase);
            onePhrase myPhrase = new onePhrase();
            myPhrase.genCodeID = genCode;
            myPhrase.noteList = new List<MyPiano.NoteStruct>();
            foreach (MyPiano.NoteStruct noteSpec in myParent.onePhrase)
                { myPhrase.noteList.Add(noteSpec); }
            phraseList.Add(myPhrase);
        }

        private void PlayThePhrase(List<MyPiano.NoteStruct> phraseBack)
        {
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
    }
}
