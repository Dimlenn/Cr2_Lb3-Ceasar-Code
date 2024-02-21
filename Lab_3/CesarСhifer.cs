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
        private AlphabetStructCreator alphabetCreator = new AlphabetStructCreator();

        public CesarChifer()
        {
            CesarChief = new Dictionary<char, char>();
            CreateCesarChief(CesarChief);
        }
        private void CreateCesarChief(Dictionary<char, char> CesarChief)
        {
            //запись алфавита в массив чаров
            List<char> alphabetList = new List<char>();
            alphabetCreator.ToCharList(alphabetList, alphabet);


            Random random = new Random();
            //написать всё одним циклом for
            for (int i = alphabet.Length - 1; i >= 0; i--)
            {
                int rand = random.Next(i + 1);
                CesarChief[alphabet[i]] = alphabetList[rand];
                alphabetList.RemoveAt(rand);
            }
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
