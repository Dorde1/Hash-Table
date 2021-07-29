using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace csharpHash
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Hashtable ht = new Hashtable(); //Creating a hashtable
                FileStream fs = new FileStream("file2.txt", FileMode.Open); //Open connection
                StreamReader sr = new StreamReader(fs); //TextReader
                string line = "";

                //n lines in the hash table
                while ((line = sr.ReadLine()) != null) //best O(n) - loops through the file n times
                                                       //worst O(n^2) - but n^2 you can ignore the ^2 as it dose not change the growth curve so it's O(n)
                {
                    if (!ht.Contains(line))
                    {
                        ht.Add(line, 1); //Add strings as a key
                    }
                    else
                    {
                        ht[line] = int.Parse(ht[line].ToString()) + 1; //Update the counter as the value
                    }
                }
                sr.Close(); //Connection close

                int max = 0; //Set max value to 0
                string name = "";
                ICollection key = ht.Keys; //Define size for all nongeneric collection

                //n keys in the hash table
                foreach (string k in key) //best O(1) - because loops through the hash table and checks a single value
                                          //worst O(n) - If too many elements were hashed into the same key: looking inside this key may take O(n) time.
                                          //Once a hash table has passed its load balance - it has to rehash 
                                          //[create a new bigger table, and re-insert each element to the table].
                {
                    if (int.Parse(ht[k].ToString()) > max) //If the value is bigger than the max value (update the value), and store the key
                    {
                        name = k;
                        max = int.Parse(ht[k].ToString());
                    }
                }
                Console.WriteLine("Max repeating element is " + name + " with " + max + " repetitions."); //Printing
                Console.ReadKey();
            }
            catch (Exception ex) //Error catch
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}