using System;
using System.IO;

namespace _06_AoC
{
    class Program
    {
        

        static void Main(string[] args)
        {
            // Counter für mehrere Schleifen später
            int counter = 0;
            // String für jede Zeile der Quelldatei
            string line;
            // Array der alle Zeilen der input.txt enthält
            string[] readText = System.IO.File.ReadAllLines("input.txt");
            // Anzahl der Zeilen in der input.txt
            int i = readText.Length;
            // Es werden Arrays angelegt für die Flugobjekte, Planetennamen und "Flugzentren" in Höhe der Zeilen der Input.txt + 1 für das ZENTRUM DES UNIVERSUMS
            Flugobjekt[] Galaxie = new Flugobjekt[i+1];
            string[] planetennamen = new string[i+1];
            string[] um = new string[i+1];

            // StreamReader um die Zeilen auszulesen
            System.IO.StreamReader file = new System.IO.StreamReader("input.txt");
            // Schleife die durch die einzelnen Zeilen geht
            while ((line = file.ReadLine()) != null)
            {
                // Array der das Flugobjekt und das Ding worum es fliegt enthält
                string[] Planeten = line.Split(')');
                // Bei COM)B wir B in den Planetennamen-Array geschrieben und COM in den Um-Array
                planetennamen[counter] = Planeten[1];
                um[counter] = Planeten[0];
                // Nächste Zeile
                counter++;
            }

            // Counter für die nächste Zeile wieder auf 0 gesetzt
            counter = 0;
            // Schleife um die Objekte des Typs Flugobjekte anzulegen
            foreach (string planetenname in planetennamen)
            {
                Galaxie[counter] = new Flugobjekt(planetenname);
                counter++;
            }
            // Einmal händisch das Flugobjekt ZENTRUM DES UNIVERSUMS an letzter Stelle des Arrays anlegen
            Galaxie[i] = new Flugobjekt("COM");
            // Counter für die nächste Zeile wieder auf 0 gesetzt
            counter = 0;

            // Schleife um jeden Flugobjekt sein Zentrum per Methode zuzuweisen um das es fliegt
            foreach (Flugobjekt planetenname in Galaxie)
            {
                // Prüfen an welcher Stelle des Arrays mit den Planetennamen das Objekt steckt um welches das aktuelle Objekt der Schleife kreist
                int blub = Array.IndexOf(planetennamen,um[counter]);
                // Wenn blub -1 ist, dann handelt es sich um COM weil es im Array der Planetennamen nicht enthalten ist weil es auf der rechten Seite der input.txt war
                if (blub == -1)
                {
                    planetenname.OrbitHinzufügen(Galaxie[i]);
                }
                else
                {
                    planetenname.OrbitHinzufügen(Galaxie[blub]);
                }
                // Für Debugzwecke
                //Console.WriteLine("Index ist " + blub);
                counter++;
            }

            // Für Debugzwecke
            foreach (Flugobjekt planetenname in Galaxie)
            {
                Console.WriteLine("Name ist " + planetenname.NameFlugobjekt);
                Console.WriteLine("Dreht um " + planetenname.orbitUm.NameFlugobjekt);
            }

            // Anlegen der Variable in der der Zielwert für Aufgabe 1 landen soll
            int anzahlOrbits = 0;
            // Temporäre Variable
            int temp = 0;

            // For-Schleife um alle Orbits mit der Methode NumberOfOrbits zu ermitteln
            foreach (Flugobjekt planetenname in Galaxie)
            {
                temp = planetenname.NumberOfOrbits(0);
                anzahlOrbits = anzahlOrbits + temp;
            }

            Console.WriteLine("Anzahl aller Orbits " + anzahlOrbits);

            ////// Zweiter Teil //////
            ///

            int You_Array = Array.IndexOf(planetennamen, "YOU");
            int Santa_Array = Array.IndexOf(planetennamen, "SAN");
            Flugobjekt You = Galaxie[You_Array];
            Flugobjekt Santa = Galaxie[Santa_Array];
            Console.WriteLine("Dein Planet heißt " + You.NameFlugobjekt);
            Console.WriteLine("Santa Planet heißt " + Santa.NameFlugobjekt);
            anzahlOrbits = 0;
            int anzahlDeinerOrbits = You.NumberOfOrbits(anzahlOrbits);
            Console.WriteLine("Du hast " + anzahlDeinerOrbits + " Orbits");
            String[] deinPfad = new string[anzahlDeinerOrbits+1];
            deinPfad = You.Pfad(deinPfad,0);
            anzahlOrbits = 0;
            int anzahlSantasOrbits = Santa.NumberOfOrbits(anzahlOrbits);
            Console.WriteLine("Santa hat " + anzahlSantasOrbits + " Orbits");
            String[] SantasPfad = new string[anzahlSantasOrbits+1];
            SantasPfad = Santa.Pfad(SantasPfad, 0);

            int v = 0;
            bool checker = false;
            string GemeinsamerKnoten;
            foreach(string Station in SantasPfad)
            {
                while (checker == false & v<deinPfad.Length)
                {
                    if(Station == deinPfad[v])
                    {
                        Console.WriteLine("Erster gemeinsamer Knoten ist " + Station);
                        GemeinsamerKnoten = Station;
                        checker = true;

                    }
                    else
                    {
                        v++;
                    }
                }
                if (checker == true)
                {
                    break;
                }
                v = 0;
            }
            int GemeinsamerKnoten_Array = Array.IndexOf(planetennamen, "CCB");
            Flugobjekt GemeinsamerKnotenObjekt = Galaxie[GemeinsamerKnoten_Array];
            int anzahlOrbitsGemeinsamerKnoten = GemeinsamerKnotenObjekt.NumberOfOrbits(0);
            Console.WriteLine(GemeinsamerKnotenObjekt.NameFlugobjekt + " hat " + anzahlOrbitsGemeinsamerKnoten + " Orbits");
        }
    }
}