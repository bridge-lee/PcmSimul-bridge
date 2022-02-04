using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcmSimul.MVVM.Model
{
    public class DataModel
    {
        private string _type;

        public string TYPE
        {
            get { return _type; }
        }

        private string _value;

        public string VALUE
        {
            get { return _value; }
        }

        private string _label;

        public string LABEL
        {
            get { return _label; }
        }

        private string _option;

        public string OPTION
        {
            get { return _option; }
        }

        public override string ToString()
        {
            return _label;
        }

        public DataModel(string type, string value, string label, string option)
        {
            _type = type;
            _value = value;
            _label = label;
            _option = option;
        }
    }
}
