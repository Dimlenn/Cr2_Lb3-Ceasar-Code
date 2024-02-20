using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public static class FormExtensions
    {
        public static void EncryptCesarChief(this RichTextBox tb1, RichTextBox tb2, IChifer chifer)
        {
            tb1.TextChanged += (c, e) => 
            {
                tb2.Text = chifer.Encrypt(tb1.Text);
            };
        }
    }
}
