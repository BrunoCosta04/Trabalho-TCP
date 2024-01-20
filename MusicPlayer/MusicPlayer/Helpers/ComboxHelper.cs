using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MusicPlayer.Extensions
{
    public class ComboBoxEntity
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public ComboBoxEntity(int value, string text)
        {
            this.Value = value;
            this.Text = text;
        }
    }

    public static class ComboBoxHelper
    {
        public static List<ComboBoxEntity> BindComboBox<T>(this IEnumerable<T> data,
                                                           Func<T, string> textSelector,
                                                           Func<T, int> valueSelector,
                                                           bool defaultValue)
        {
            List<ComboBoxEntity> comboBoxEntities = new List<ComboBoxEntity>();

            foreach (var item in data)
            {
                comboBoxEntities.Add(new ComboBoxEntity(valueSelector(item), textSelector(item)));
            }

            if (defaultValue)
                comboBoxEntities.Insert(0, new ComboBoxEntity(-1, "SELECT"));

            return comboBoxEntities;
        }
    }
}
