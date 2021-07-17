using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomTools
{
    
    class ListBoxSearch
    {
        TextBox textBox1 = null;
        ListBox listBox1 = null;
        List<string> removed = new List<string>();

        internal void setListbox(ListBox listBox1)
        {
            this.listBox1 = listBox1;
        }

        internal void setTextField(TextBox textBox1)
        {
            this.textBox1 = textBox1;

            this.textBox1.TextChanged += delegate
            {
                changed();
            };
        }


        public void changed()
        {


            string search = textBox1.Text.ToLower();
            for(int i = listBox1.Items.Count-1; i >= 0; i--)
            {
                var item = listBox1.Items[i];

                if (!item.ToString().ToLower().Contains(search))
                {
                    listBox1.Items.Remove(item);
                    removed.Add(item.ToString());
                }
            }

            for (int i = removed.Count - 1; i >= 0; i--)
            {
                var item = removed[i];
                if (item.ToLower().Contains(search))
                {
                    
                    listBox1.Items.Add(item);
                    removed.Remove(item);
                }
            }

            /*
            var array = new object[listBox1.Items.Count];
            listBox1.Items.CopyTo(array, 0);
            listBox1.Items.Clear();
            var sortedArray = array.Select(n => (object)Convert.ToInt32(n)).OrderBy(n => n).ToArray();
            listBox1.Items.AddRange(sortedArray);
            */

        }
    }
}
