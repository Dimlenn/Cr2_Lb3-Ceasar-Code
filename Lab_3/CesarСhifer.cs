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
            CreateCesarChief(CesarChief);
        }
        private void CreateCesarChief(Dictionary<char, char> CesarChief)
        {
            //запись алфавита в массив чаров
            List<char> mixedAlphabet = new List<char>();
            CreateAlphabetCharList(mixedAlphabet);


            Random random = new Random();
            //написать всё одним циклом for
            for (int i = alphabet.Length - 1; i >= 0; i--)
            {
                int rand = random.Next(i + 1);
                CesarChief[alphabet[i]] = mixedAlphabet[rand];
                mixedAlphabet.RemoveAt(rand);
            }
        }
        public void CreateAlphabetCharList(List<char> list)
        {
            //запись алфавита в массив чаров
            for (int i = 0; i < alphabet.Length; i++)
                list.Add(alphabet[i]);
        }
        public string Decrypt(string input)
        {
            string result = "";
            char value;
            foreach (char c in input)
            {
                CesarChief.TryGetValue(c, out value);
                result += value;
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
