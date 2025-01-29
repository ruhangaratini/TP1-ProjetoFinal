using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitePDV.Components
{
    class ComboBoxItem<T>
    {
        public string Text { get; set; }
        public T Value { get; set; }

        public ComboBoxItem(string text, T value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString() {
            return Text;
        }

    }
}
