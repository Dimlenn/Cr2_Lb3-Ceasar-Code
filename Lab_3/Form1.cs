using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.MakeCesarCode(richTextBox2);
        }
    }

    public static class FormsExtensions
    {

        public static Dictionary<char, char> CreateCesarCode()
        {
            string text1 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            char[] text = new char[text1.Length];
            for (int i = 0; i < text1.Length; i++)
                text[i] = text1[i];

            Random random = new Random();

            for (int i = text.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                char temp = text[j];
                text[j] = text[i];
                text[i] = temp;
            }

            Dictionary<char, char> CesarCode = new Dictionary<char, char>(text1.Length);

            for (int i = 0; i < text1.Length; i++)
                CesarCode.Add(text1[i], text[i]);

            return CesarCode;
        }

        public static Dictionary<char, char> CesarCode = CreateCesarCode();

        public static void MakeCesarCode(this RichTextBox richTextBox1, RichTextBox richTextBox2)
        {
            string text1 = richTextBox1.Text;

            char[] text = new char[text1.Length];
            for (int i = 0; i < text1.Length; i++)
                text[i] = text1[i];

            

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLower(text[i]))
                    text[i] = CesarCode[text[i]];
                else
                {
                    string temp = Convert.ToString(Char.ToLower(text[i]));
                    text[i] = Char.ToUpper(CesarCode[temp[0]]);
                }
            }

            string text2 = "";
            foreach (char c in text)
                text2 += c;

            richTextBox2.Text = text2;
        }
    }
}
