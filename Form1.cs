using System.IO;
using static System.Windows.Forms.AxHost;

namespace TastaturSpiel
{
    public partial class Form1 : Form
    {
        public int count = 0;

        public Random random = new Random();
        string typedText = "";


        public Form1()
        {
            int count = 0;
            int xOffset = 0;
            int randomNumber = random.Next(0, 51);
            string text = File.ReadAllText("C:\\VS\\50 DE Wörter.txt");
            string[] s = text.Split(',');
            InitializeComponent();
            textBoxInput.TextChanged += TextBoxInput_TextChanged;
            for (int i = 0; i < 25; i++)
            {
                Label label = new Label();
                label.Name = "label_" + i;
                if (i == 25)
                {
                    /*label.Location = new System.Drawing.Point(75 + xOffset, 345);
                    xOffset += 10;
                    label.Text = s[random.Next(0, 51)] + ".";
                    label.ForeColor = Color.Black;
                    label.Size = new System.Drawing.Size(0, 25);
                    label.BringToFront();
                    label.Visible = true;*/
                    label1.Text = label1.Text + s[random.Next(0, 50)] + ".";
                }
                else
                {
                    /*label.Location = new System.Drawing.Point(75 + xOffset, 345);
                    xOffset += 10;
                    label.Text = s[random.Next(0, 51)] + " ";
                    label.ForeColor = Color.Black;
                    label.Size = new System.Drawing.Size(0, 25);
                    label.BringToFront();
                    label.Visible = true;*/
                    label1.Text = label1.Text + s[random.Next(0, 50)] + " ";
                }
            }
            string[] inputText = textBoxInput.Text.Split(" ");
            while (inputText.Length < 25)
            {
                inputText = textBoxInput.Text.Split(" ");
            }
            if (inputText.Length == 25)
            {
                WPMCounter();
            }
        }

        public int sek = 0;
        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            string inputText = textBoxInput.Text;
            string ganeratedText = label1.Text;
            bool hasError = ErrorCkeck(inputText, ganeratedText);

            if (hasError)
            {
                textBoxInput.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                textBoxInput.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private bool ErrorCkeck(string inputText, string ganeratedText)
        {
            int inputLength = inputText.Length;
            char lastChar = inputText[inputLength - 1];
            if (lastChar == ' ')
            {
                count++;
            }

            string[] stringsInput = inputText.Split(" ");
            string[] stringsGanerated = ganeratedText.Split(" ");

            if (stringsInput[count] == stringsGanerated[count])
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void WPMCounter()
        {
            timer1.Enabled = false;
            int wpm = (25 / sek) * 60;
            label2.Text = "WPM = " + wpm.ToString();
            WPMMenu();
        }

        private void WPMMenu()
        {
            label2.Visible = true;
            labelSek.Visible = false;
            label1.Visible = false;
            textBoxInput.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sek++;
            labelSek.Text = sek.ToString();
        }
    }
}