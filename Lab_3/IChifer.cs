using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public interface IChifer
    {
        string Encrypt(string input);
        string Decrypt(string input);
    }
}
