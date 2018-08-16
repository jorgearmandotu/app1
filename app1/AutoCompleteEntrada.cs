using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    public class AutoCompleteEntrada
    {

        private string[] keywordStrings;
        private string displayString;

        public string[] KeywordStrings
        {
            get
            {
                if (keywordStrings == null)
                {
                    keywordStrings = new string[] { displayString };
                }
                return keywordStrings;
            }
        }

        public string DisplayName
        {
            get { return displayString; }
            set { displayString = value; }
        }

        public AutoCompleteEntrada(string name, params string[] keywords)
        {
            displayString = name;
            keywordStrings = keywords;
        }

        public override string ToString()
        {
            return displayString;
        }

    }
}
