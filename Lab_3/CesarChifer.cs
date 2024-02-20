using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class CesarChifer : IChifer
    {
        private readonly Dictionary<char, char> CesarChief;
        private const string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public CesarChifer()
        {
            CesarChief = new Dictionary<char, char>();

            //запись алфавита в массив чаров
            char[] mixedAlphabet = new char[alphabet.Length];
            for (int i = 0; i < alphabet.Length; i++)
                mixedAlphabet[i] = alphabet[i];

            Random random = new Random();

            //рандомное перемешивание алфавита
            for (int i = mixedAlphabet.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                char temp = mixedAlphabet[j];
                mixedAlphabet[j] = mixedAlphabet[i];
                mixedAlphabet[i] = temp;
            }

            //создание словаря из алфавита и перемешенного алфавита ключ/значение
            for (int i = 0; i < alphabet.Length; i++)
                CesarChief[alphabet[i]] = mixedAlphabet[i];
        }
        public string Decrypt(string input)
        {
            string result = "";
            foreach (char c in input)
            {
                result += CesarChief[c];
            }
            return result;
        }

        public string Encrypt(string input)
        {
            string result = "";
            foreach (char c in input)
            {
                result += CesarChief[c];
            }
            return result;
        }
    }
}
