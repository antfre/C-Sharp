using System;

namespace Villkor_och_loopar
{

    /// <summary>


    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar variabler
            int startNumber;
            int bestNumber = 0;
            int bestHour = 0;
            int bestMin = 0;
            int bestSec = 0;
            int bestTime = 0;
            int participants = 0;

            // Skapar bool för while loop
            bool loop = true; 

            while (loop)
            {
                Console.WriteLine("\nAnge startnummer(under 1 för att avsluta): ");
                startNumber = int.Parse(Console.ReadLine());

                // Om startnummer är under 1 ska loopen brytas
                if (startNumber <= 0)
                {
                    break;
                }

                // Räknar deltagare
                participants++;

                // Hämtar data för starttid samt sluttid
                Console.WriteLine("\nAnge starttimme(00-23): ");
                int startHour = int.Parse(Console.ReadLine());

                Console.WriteLine("\nAnge startminut(00-59): ");
                int startMin = int.Parse(Console.ReadLine());

                Console.WriteLine("\nAnge startsekund(00-59):  ");
                int startSec = int.Parse(Console.ReadLine());

                Console.WriteLine("\nAnge timme för målgång(00-23):  ");
                int finishHour = int.Parse(Console.ReadLine());

                Console.WriteLine("\nAnge minut för målgång(00-59):  ");
                int finishMin = int.Parse(Console.ReadLine());

                Console.WriteLine("\nAnge sekund för målgång(00-59): ");
                int finishSec = int.Parse(Console.ReadLine());

                // Räknar ut totala sekunder för både start och sluttid
                int startTotalSec = (startHour * 3600) + (startMin * 60) + startSec;
                int finishTotalSec = (finishHour * 3600) + (finishMin * 60) + finishSec;

                // Om midnatt passeras 
                if (startTotalSec > finishTotalSec)
                {
                    finishTotalSec = 86400 + finishTotalSec;
                }

                // Totala sekunder för tiden
                int totalSec = finishTotalSec - startTotalSec;

                // Kollar om tiden är bäst eller om det är första deltagaren, tilldelar värden om stämmer
                if (totalSec < bestTime || participants == 1)
                {
                    bestTime = totalSec;
                    bestNumber = startNumber;
                    bestHour = bestTime / 3600;
                    bestMin = (bestTime % 3600) / 60;
                    bestSec = (bestTime % 60);
                }
            }

            // Om ingen deltog
            if (participants == 0)
            {
                Console.WriteLine("\nIngen deltagare, avslutar programmet!");
            }

            // Om vi har en vinnare
            else
            {
                Console.WriteLine("\nVi har fått en vinnare!");
                Console.WriteLine($"\nAntal deltagare: {participants}");
                Console.WriteLine($"\nVinnare: {bestNumber}");
                Console.WriteLine($"\nTid: {bestHour} timmar {bestMin} minuter {bestSec} sekunder.");
                Console.WriteLine("\nAvslutar programmet.");
            }

            // Avslutas
            Console.WriteLine("\nTryck på en valfri tangent...");
            Console.ReadKey();
        }
    }
}
