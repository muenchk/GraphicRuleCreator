using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicRuleCreator
{
    public class StringProperty : IComparable<StringProperty>, IComparable
    {
        string _str;
        bool modified = false;

        public StringProperty(string str)
        { this._str = str; }

        public string Content
        {
            get
            {
                return _str;
            }
            set
            {
                _str = value;   
                modified = true;
            }
        }

        public bool Modified
        { get { return modified; } }

        public int CompareTo(StringProperty? other)
        {
            if (other != null)
            {
                return _str.CompareTo(other._str);
            }
            return -1;
        }

        public int CompareTo(object? obj)
        {
            if (!(obj is StringProperty))
                return -1;
            StringProperty? s = obj as StringProperty;
            if (s != null)
            {
                return _str.CompareTo(s._str);
            }
            return -1;
        }

        public void Update(string str)
        { this._str = str; }    

        public static implicit operator string(StringProperty s)
        {
            return s.Content;
        }
    }
}
