using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Enigma
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            int[] arr = new [] {0,1,2};
            string[] rotors = new string[5];
            char[] value = new char[5];
            char[] start = new char[3];

            rotors[0] = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
            rotors[1] = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
            rotors[2] = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
            rotors[3] = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
            rotors[4] = "VZBRGITYUPSDNHLXAWMJQOFECK";

            string plugboard = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            value[0] = 'Q';
            value[1] = 'E';
            value[2] = 'V';
            value[3] = 'J';
            value[4] = 'Z';

            DateTime startTime = DateTime.Now;
            int combos = 0;
            for (int rep = 0; rep < 26; rep++)
            {
                StringBuilder builder = new StringBuilder();
                for (int build = 0; build < 26; build++)
                {
                    builder.Append((build == rep) ? 'K' : ((build == (int)('K' - 'A')) ? (char)('A' + rep) : (char)('A' + build)));
                }
                arr = new[] { 0, 2, 1 };
                //while (!NextPermutation(arr))
                {
                    //File.AppendAllText("output.txt", string.Format("Trying: {0} {1} {2}\r\n", arr[0], arr[1], arr[2]));
                    for (int x = 0; x < 17576; x++)
                    {
                        combos++;

                        Rotor[] rr = new Rotor[3];
                        Rotor reflector;

                        //Rotor plugboardR = new Rotor(builder.ToString(), '\0');
                        Rotor plugboardR = new Rotor(plugboard, '\0');
                        
                        rr[0] = new Rotor(rotors[arr[0]], value[arr[0]]);
                        rr[1] = new Rotor(rotors[arr[1]], value[arr[1]]);
                        rr[2] = new Rotor(rotors[arr[2]], value[arr[2]]);
                        reflector = new Rotor("YRUHQSLDPXNGOKMIEBFZCWVJAT", '\0');

                        for (int a = 0; a < 23; a++)
                            reflector.Move();

                        //plugboardR.SetNextRotor(rr[2]);
                        rr[2].SetNextRotor(rr[1]);
                        rr[1].SetNextRotor(rr[0]);
                        rr[0].SetNextRotor(reflector);
                        //rr[2].SetPreviousRotor(plugboardR);
                        rr[1].SetPreviousRotor(rr[2]);
                        rr[0].SetPreviousRotor(rr[1]);
                        reflector.SetPreviousRotor(rr[0]);

                        // preset settings
                        for (int a = 0; a < x; a++)
                            rr[2].Move();

                        //var rawData = "uxyny mouey swfbd qwdnv naoen cxsdd ekzn".Replace(" ", "").ToUpper();// @"AHCJWVFEYGHWCSVGXUGQOYXGXABERMDORDVSCIMPNBRXHWLNLCUSLFCSLXIPNMYXIQJIXZIGFXRGQEXTNMSVSBOGUURDOCL";
                        var rawData = @"AHCJWVFEYGHWCSVGXUGQOYXGXABERMDORDVSCIMPNBRXHWLNLCUSLFCSLXIPNMYXIQJIXZIGFXRGQEXTNMSVSBOGUURDOCL".Replace("W", "");
                        var rawLength = rawData.Length;

                        start[0] = rr[0].GetLetter();
                        start[1] = rr[1].GetLetter();
                        start[2] = rr[2].GetLetter();

                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < rawLength; i++)
                        {
                            rr[2].Move();
                            rr[2].PutDataIn(rawData[i]);
                            sb.Append(rr[2].GetDataOut());
                            //plugboardR.PutDataIn(rawData[i]);
                            //sb.Append(plugboardR.GetDataOut());
                        }


                        if (sb.ToString().Contains("VIRU"))
                            File.AppendAllText("output.txt", string.Format("{0} {1} {2}\t{3} {4} {5}\t{6}\t{7}\r\n", arr[0], arr[1], arr[2], start[0], start[1], start[2], x, sb.ToString()));
                    }
                }
            }
            Console.WriteLine(DateTime.Now - startTime);
            Console.WriteLine(combos);
            Console.ReadLine();
        }

        public static bool NextPermutation<T>(T[] elements) where T : IComparable<T>
        {
            // More efficient to have a variable instead of accessing a property
            var count = elements.Length;

            // Indicates whether this is the last lexicographic permutation
            var done = true;

            // Go through the array from last to first
            for (var i = count - 1; i > 0; i--)
            {
                var curr = elements[i];

                // Check if the current element is less than the one before it
                if (curr.CompareTo(elements[i - 1]) < 0)
                {
                    continue;
                }

                // An element bigger than the one before it has been found,
                // so this isn't the last lexicographic permutation.
                done = false;

                // Save the previous (bigger) element in a variable for more efficiency.
                var prev = elements[i - 1];

                // Have a variable to hold the index of the element to swap
                // with the previous element (the to-swap element would be
                // the smallest element that comes after the previous element
                // and is bigger than the previous element), initializing it
                // as the current index of the current item (curr).
                var currIndex = i;

                // Go through the array from the element after the current one to last
                for (var j = i + 1; j < count; j++)
                {
                    // Save into variable for more efficiency
                    var tmp = elements[j];

                    // Check if tmp suits the "next swap" conditions:
                    // Smallest, but bigger than the "prev" element
                    if (tmp.CompareTo(curr) < 0 && tmp.CompareTo(prev) > 0)
                    {
                        curr = tmp;
                        currIndex = j;
                    }
                }

                // Swap the "prev" with the new "curr" (the swap-with element)
                elements[currIndex] = prev;
                elements[i - 1] = curr;

                // Reverse the order of the tail, in order to reset it's lexicographic order
                for (var j = count - 1; j > i; j--, i++)
                {
                    var tmp = elements[j];
                    elements[j] = elements[i];
                    elements[i] = tmp;
                }

                // Break since we have got the next permutation
                // The reason to have all the logic inside the loop is
                // to prevent the need of an extra variable indicating "i" when
                // the next needed swap is found (moving "i" outside the loop is a
                // bad practice, and isn't very readable, so I preferred not doing
                // that as well).
                break;
            }

            // Return whether this has been the last lexicographic permutation.
            return done;
        }
    }
}
