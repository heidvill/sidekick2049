using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            string polku = @"C:\Users\marko\Documents\Academy\Final Project\SideKick2049\Hahmolista.txt";
            List<string> suomi = new List<string>();
            string[] hahmot = File.ReadAllLines(polku);
            foreach (var item in hahmot)
            {
                string nimi = item.Split("^fi^")[1].Split('^')[0];
                suomi.Add(nimi);           
            }           
            File.WriteAllLines(@"C:\Users\marko\Documents\Academy\Final Project\SideKick2049\Epäillyt.txt", suomi);
        }
    }
}
