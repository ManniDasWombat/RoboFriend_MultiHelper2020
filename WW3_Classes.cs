using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFriend_MultiHelper2020
{
    class WW3_Classes
    {
    }

    
    public class Vocable
    {
        public enum EnumLanguage { English, German }
        public int VocID { get; set; }
        public EnumLanguage VocLanguage { get; set; }
        public string Verb { get; set; }
        public string Noun { get; set; }
        public string Adjective { get; set; }
        public List<int> TL_IDs { get; set; }
    }
}
