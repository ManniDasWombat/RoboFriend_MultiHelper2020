using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RoboFriend_MultiHelper2020
{
    public class WW3_Classes
    {
        public string ListHeading { get; set; }         // TestAttribut für Label Bindings
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


    // Unterricht Vererbung: 
    abstract class Person           // durch abstract kann ich keine new instanz dieser klasse erschaffen. Nutzt man, falls von dieser klasse ausschließlich geerbt werden soll
    {
        public string Vorname { get; private set; }
        public DateTime Geburtstag { get; private set; }

        //Konstruktor
        public Person(string VornameP, DateTime GebP)       // so kann ich die Klasse von außen erreichen ohne sie public zu machen
        {
            Vorname = VornameP;
            Geburtstag = GebP;
        }
    }

    class Kunde : Person
    {

        public int KundeID { get; set; }

        public Kunde(string VornameP, DateTime GebP)
            : base(VornameP, GebP)
        {
            KundeID = 23423;
        }
    }
}

