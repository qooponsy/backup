using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaihonConverter
{
    class FontSizeData
    {
        public String Code { get; set; }
        public String Size { get; set; }

        public FontSizeData(string code, string size)
        {
            this.Code = code;
            this.Size = size;
        }

        public static List<FontSizeData> GetFontSizeList(String CodeName)
        {
            var list = new List<FontSizeData>();

            var sizeArray = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            foreach (var size in sizeArray)
            {
                list.Add(new FontSizeData(CodeName, size.ToString()));
            }

            return list;

        }
    }
}
