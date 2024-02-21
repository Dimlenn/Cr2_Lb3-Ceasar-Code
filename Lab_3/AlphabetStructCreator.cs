using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class AlphabetStructCreator
    {
        public void ToCharList(List<char> list, string alphabet)
        {
            //запись алфавита в массив чаров
            for (int i = 0; i < alphabet.Length; i++)
                list.Add(alphabet[i]);
        }
    }
}
