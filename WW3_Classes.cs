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
        public List<string> Language { get; set; }
        public string ThisVocsLanguage { get; set; }
        public int VocID { get; set; }
        public string Verb { get; set; }
        public string Noun { get; set; }
        public string Adjective { get; set; }
        public List<int> TL_IDs { get; set; }
    }


    // Unterricht Vererbung: 
    abstract class Person           // durch abstract kann ich keine Instanz/new Object dieser klasse erschaffen. Nutzt man, falls von dieser klasse ausschließlich geerbt werden soll
    {
        public string Vorname { get; private set; }
        public string Nachname { get; private set; }
        public DateTime Geburtstag { get; private set; }

        //Konstruktor
        public Person(string VornameP, string NachnameP, DateTime GebP)       // so kann ich die Klasse von außen erreichen ohne sie public zu machen
        {
            Vorname = VornameP;
            Nachname = NachnameP;
            Geburtstag = GebP;
        }
    }

    class Kunde : Person
    {
        public string KundeID { get; set; }        // kommt zusätzlich hinzu zu dem, was geerbt wird

        public Kunde(string VP, string NP, DateTime GP)
            : base(VP, NP, GP)                              // mit : base wird der Konstruktor der Basisklasse aufgerufen
        {
            KundeID = Guid.NewGuid().ToString("N").Substring(0, 20);        // zusätzlich
        }
    }
}

