using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaihonConverter
{
    class CharacterData
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public CharacterData(String code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

    }
}
