using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    internal class CesarClass
    {
        private static Dictionary<char, char> CesarCode;
        public string Str { get; set; }

        public CesarClass(string str)
        {
            this.Str = str;
            CesarCode = CreateCesarCode();
        }

        private int func(char[] text, string text1)
        {
            for (int i = 0; i < text1.Length; i++)
                text[i] = text1[i];
            return 0;
        }

        private Dictionary<char, char> CreateCesarCode()
        {
            string text1 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            char[] text = new char[text1.Length];
            func(text, text1);

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

        private static string CodeCesarCode(string value)
        {
            char[] text = new char[value.Length];
            func(text, value);

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

            return text2;
        }

        static public implicit operator CesarClass(string value)
        {
            return CodeCesarCode(value);
        }

        static public implicit operator string(CesarClass value)
        {
            return CodeCesarCode(value.str);
        }
    }
}
