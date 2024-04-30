using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponentLibrary
{
    public static class CheckKeyPress
    {
        public static void CheckInteger(this Control _, object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && '-' != e.KeyChar)
            {
                e.Handled = true;
                return;
            }
            if ('-' == e.KeyChar && sender is TextBoxBase)
            {
                TextBoxBase box = (TextBoxBase)sender;
                if (box.Text.StartsWith("-") || box.SelectionStart != 0)
                {
                    e.Handled = true;
                    return;
                }

            }
        }

        public static void CheckFloat(this Control _, object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && '.' != e.KeyChar && '-' == e.KeyChar)
            {
                e.Handled = true;
                return;
            }

            if (sender is TextBoxBase)
            {
                TextBoxBase box = (TextBoxBase)sender;
                string text = box.Text;
                if ('-' == e.KeyChar && (text.StartsWith("-") || box.SelectionStart != 0))
                {
                    e.Handled = true;
                    return;
                }
                if ('.' == e.KeyChar && text.Contains('.'))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}
