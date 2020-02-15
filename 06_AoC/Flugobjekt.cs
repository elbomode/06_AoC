using System;
using System.Collections.Generic;
using System.Text;

namespace _06_AoC
{
    public class Flugobjekt
    {
        public string NameFlugobjekt;
        public Flugobjekt orbitUm;

        // Konstruktor um fertiges Flugobjekt anzulegen // OBSOLET
        public Flugobjekt(string name,Flugobjekt flugobjekt)
        {
            NameFlugobjekt = name;
            orbitUm = flugobjekt;
        }

        // Konstruktor um Flugobjekt anzulegen. Dessen Mittelpunkt wird weggelassen
        public Flugobjekt(string name)
        {
            NameFlugobjekt = name;
            orbitUm = null;
        }

        // Methode um nachträglich den Orbit eines Flugobjektes anzupassen
        public void OrbitHinzufügen(Flugobjekt um)
        {
            this.orbitUm = um;
        }

        // Methode um rekursiv die Anzahl aller Flugobjekte zu zählen
        public int NumberOfOrbits(int anzahlBisherigerOrbits)
        {
            if (this.NameFlugobjekt == "COM")
            {
                return anzahlBisherigerOrbits;
            }
            else
            {
                return orbitUm.NumberOfOrbits(anzahlBisherigerOrbits+1);
            }
        }

        public string[] Pfad(string[] Ziel,int anzahlBisherigerOrbits)
        {
            if (this.NameFlugobjekt == "COM")
            {
                Ziel[Ziel.Length - 1] = "COM";
                return Ziel;
            }
            else
            {
                Ziel[anzahlBisherigerOrbits] = this.NameFlugobjekt;
                return orbitUm.Pfad(Ziel,anzahlBisherigerOrbits+1);
            }
        }

    }
}
