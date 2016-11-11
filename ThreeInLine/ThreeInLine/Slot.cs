using System;

namespace ThreeInLine
{
    public class Slot
    {
        //private oznacza, ze z kazdej innej klasy nie bedziesz mogl dostac sie 
        //bezposrednio do tych pol poprzez np. slot._characters;
        //readonly - ze REFERENCJA na obiekt jest ustawiana tylko jeden raz. w tym momencie slowo
        //referencja malo Cie obchodzi, mozesz zapamietac, ze ustawiane sa jeden jedyny raz: w konstruktorze
        private readonly string [] _characters;
        private readonly int [] _chances;
        private readonly Random _random;

        public Slot ( string [] characters, int [] chances ) //konstruktor klasy Slot. uzycie widac w Program.cs
        {
            if ( characters.Length != chances.Length ) //wyjatek! nigdy nie powinien poleciec ale, moze jak sie zle ustawi...
                throw new WrongLengthException ( "Length of arrays: characters and chances does not match." );
            //wyjatek powinien byc obsluzony poprzez catch/finally. oczywiscie nigdzie nie jest, wiec jak poleci
            //to bedzie crash - jest to niewlasciwe zachowanie

            _characters = characters;
            _chances = chances;
            _random = new Random ();
            //ustawiam wartosci, by je zapamietac. po "}" zmienne characters i chances nie istnieja, wiec musza byc skopiowane
        }

        public string GetRandomCharacter ( )
        {

            var generatedNr = _random.Next ( 0, _chances [_chances.Length - 1] );
            // .Next returns A 32-bit signed integer greater than or equal to minValue 
            //and less than maxValue; that is, the range of return values includes minValue but not maxValue.
            //If minValue equals maxValue, minValue is returned. - wiec dla tego przypadku generatedNr to liczba
            //od 0 wlacznie do 16 bez tej 16-ki

            for ( var elementNr = 0; elementNr < _characters.Length; elementNr++ )
            {//to jest logika generatora, pewnie wymaga wiekszych wyjasnien, wiec wyjasnie sama
                if ( generatedNr < _chances [elementNr] )
                {
                    return _characters [elementNr];
                }
            }

            return "0"; //te 0 to tak sama sobie wymyslilam, i tak nigdy zwrocone byc nie powinno
        }
    }
}