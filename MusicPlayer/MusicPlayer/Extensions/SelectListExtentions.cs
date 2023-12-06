using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MusicPlayer.Extensions
{
    public static class SelectListExtentions
    {
        public static IEnumerable<SelectListItem> PopulateSelectList<T>(this IEnumerable<T> data, 
                                                                        Func<T, string> textSelector,
                                                                        Func<T, string> valueSelector,
                                                                        string? defaultText = null,
                                                                        string? defaultValue = null)
        {
            var items = data.Select(item => new SelectListItem
            {
                Text = textSelector(item),
                Value = valueSelector(item)
            });

            if (!string.IsNullOrEmpty(defaultText) || !string.IsNullOrEmpty(defaultValue))
            {
                var defaultItem = new SelectListItem
                {
                    Text = defaultText ?? "Select an option", 
                    Value = defaultValue ?? string.Empty
                };

                items = new[] { defaultItem }.Concat(items);
            }

            return items;
        }
    }
}
