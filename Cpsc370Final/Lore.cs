namespace Cpsc370Final;
using System;
using System.Threading;

public static class GameLore
    {
        public static void PrintWithTypewriterEffect(string text, int delay = 22)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        public static void ShowIntro()
        {
            string intro = "Three cowboy brothers, Grog, Brog, and Crog, were playing near a mysterious dungeon.\n" +
                           "They laughed and ran, their boots kicking up dust under the golden sun.\n" +
                           "Suddenly, a mighty bull, wild and enraged, charged at them with full force!\n" +
                           "Before they could react, its powerful impact sent them tumbling into the darkness below...\n";
            PrintWithTypewriterEffect(intro);
        }

        public static void ShowLosingEnding()
        {
            string losingEnding = "The dungeon was merciless. No light, no hope, just the echoes of his own breathing.\n" +
                                  "Each step deeper brought new horrors, until at last, exhaustion took hold.\n" +
                                  "As his vision faded, he realized... he would never leave this place.\n" +
                                  "Darkness consumed him, and with it, his story ended...\n";
            PrintWithTypewriterEffect(losingEnding);
        }

        public static void ShowWinningEnding()
        {
            string winningEnding = "With his last ounce of strength, he reached a grand chamber filled with arcane energy.\n" +
                                   "Before him stood Wither, a towering figure cloaked in shadows, eyes burning with ancient power.\n" +
                                   "But as he braced for battle, Wither extended a hand. \"Friend...\" he muttered, struggling to speak.\n" +
                                   "With a surge of magic, light engulfed the room. The dungeon crumbled around them, and in an instant, he was teleported back to the surface. " +
                                   "Wither was his friend all along... but lost for words.\n";
            PrintWithTypewriterEffect(winningEnding);
        }
    }