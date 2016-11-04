using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whole_Lotta_Genes {
    public partial class Form1 : Form {
        Settings set;
        Genetic genetic;
        Bitmap targetBmp;

        bool paused;

        Timer formUpdateTimer;

        public Form1() {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            paused = true;

            SelectImage("Mona.png", "Mona.png");
            set = new Settings();
            genetic = new Genetic(targetBmp, set);

            formUpdateTimer = new Timer();
            formUpdateTimer.Interval = 1;
            formUpdateTimer.Tick += UpdateForm;
            formUpdateTimer.Start();
            formUpdateTimer.Enabled = false;
        }

        void UpdateForm(Object sender, EventArgs e) {
            if (genetic != null) {
                labelGeneration.Text = "Generation: " + genetic.generation.ToString();
                
                labelFitBest.Text = genetic.GetIndividual(0).fitness.ToString();
                pictureBoxBest.Image = genetic.GetIndividual(0).GenerateBitmap(targetBmp.Width, targetBmp.Height);
            }
        }

        void SelectImage(string name, string safeName) {
            labelSelectedImage.Text = safeName;
            targetBmp = new Bitmap(Image.FromFile(name));
            pictureBoxOriginal.Image = targetBmp;
        }

        void button1_Click(object sender, EventArgs e) {
            bool wasPaused = paused;
            paused = true;
            if (ofd.ShowDialog() == DialogResult.OK) {
                SelectImage(ofd.FileName, ofd.SafeFileName);
                Pause();
                genetic = new Genetic(targetBmp, set);
            }
            paused = wasPaused;
        }

        private void buttonPause_Click(object sender, EventArgs e) {
            if (paused == false)
                Pause();
            else
                Start();
        }

        void Start() {
            paused = false;
            buttonPause.Text = "Pause";
            formUpdateTimer.Enabled = true;

            genetic.Start();
        }

        void Pause() {
            paused = true;
            buttonPause.Text = "Start";
            formUpdateTimer.Enabled = false;

            genetic.Pause();
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            Bitmap image = genetic.GetIndividual(0).GenerateBitmap(targetBmp.Width, targetBmp.Height);
            image.Save(set.seed.ToString() + " " + genetic.generation.ToString() + ".bmp");
        }
    }
}
