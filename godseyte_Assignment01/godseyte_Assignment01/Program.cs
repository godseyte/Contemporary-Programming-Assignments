using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Tucker Godsey
9/3/2018
Contemporary Programming IT3045C
Converting a Java Project to a C# project

Originally by nicholdw@ucmail.uc.edu (Delmer Nicholson)


Original Text:
The primes 3, 7, 109, and 673, are quite remarkable. 
By taking any two primes and concatenating them in any order the result will always be prime.
For example, taking 7 and 109, both 7109 and 1097 are prime. 
The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property.

Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.

Solution = 26033    is 23 + 1493 + 16451 + 23003 + 33647 

 */

public class Problem060
{

    public static void Main(string[] args)
    {

        Problem060 p = new Problem060();

       Console.WriteLine("Problem 060...");
        int result = p.Solve();
        Console.WriteLine(result);
    }

    public int Solve()
    {
        const int limit = 50000;
        int result = int.MaxValue;
        ArrayList primeList = new ArrayList();
        ArrayList primeListString = new ArrayList();
        // Don't use '1' as a prime. Start with 2.
        for (long i = 3; i <= limit; i++)
        {
            if (isPrime(i))
            {
                primeList.Add(i);
                primeListString.Add(Convert.ToString(i));
            }
        }
        //		results: 74617 = 23 (7), 1493 (236), 16451 (1905), 23003 (2563), 33647 (3605)

        //		int iStart = 0, jStart = 1, kStart = 2, lStart = 3, mStart = 4;	
        int listLimit = primeList.Count;
        Console.WriteLine("Prime list computed. " + listLimit + " primes in list...");
        // Set of 5 primes for which any two concatenated will be prime.
        // We need all the possible sets of 5 primes out of the list in primeList
        for (int i = 0; i < listLimit; i++)
        {
            String s1 = (string)primeListString[i];                         // String.valueOf(primeList.get(i));
                                                                        //System.out.print(s1 + " ");
            for (int j = i + 1; j < listLimit; j++)
            {
                String s2 = (string)primeListString[j];                 //String.valueOf(primeList.get(j));
                if (isPrime(long.Parse(s1 + s2)) && isPrime(long.Parse(s2 + s1)))
                {
                    for (int k = j + 1; k < listLimit; k++)
                    {
                        String s3 = (string)primeListString[k];             // String.valueOf(primeList.get(k));
                        if (isPrime(long.Parse(s1 + s3)) && isPrime(long.Parse(s3 + s1)) && isPrime(long.Parse(s3 + s2)) && isPrime(long.Parse(s2 + s3)))
                        {
                            for (int l = k + 1; l < listLimit; l++)
                            {
                                String s4 = (string)primeListString[l];         // String.valueOf(primeList.get(l));
                                if (isPrime(long.Parse(s1 + s4)) && isPrime(long.Parse(s4 + s1)) && isPrime(long.Parse(s2 + s4)) && isPrime(long.Parse(s4 + s2)) && isPrime(long.Parse(s3 + s4)) && isPrime(long.Parse(s4 + s3)))
                                {
                                    for (int m = l + 1; m < listLimit; m++)
                                    {
                                        String s5 = (string)primeListString[m];     // String.valueOf(primeList.get(m));
                                                                                //s5="";
                                                                                //System.out.println(s1 + ", " + s2 + ", " +  s3 + ", " + s4 + ", " + s5);
                                                                                //							if (s1.equals("3") &&  s2.equals("7") && s3.equals("109") && s4.equals("673")  ) {
                                                                                //								System.out.println("hi");
                                                                                //							}
                                        if ((isPrime(long.Parse(s1 + s5))) && (isPrime(long.Parse(s2 + s5))) && (isPrime(long.Parse(s3 + s5))) && (isPrime(long.Parse(s4 + s5))) && (isPrime(long.Parse(s5 + s1))) && (isPrime(long.Parse(s5 + s2))) && (isPrime(long.Parse(s5 + s3))) && (isPrime(long.Parse(s5 + s4))))
                                        {

                                            //								System.out.println("Bingo: " + s1 + ", " + s2 + ", " + s3 + ", " + s4 + ", " + s5);
                                            //								result = Integer.valueOf(s1) + Integer.valueOf(s2) + Integer.valueOf(s3) + Integer.valueOf(s4) + Integer.valueOf(s5);
                                            int tmp = int.Parse(s1) + int.Parse(s2) + int.Parse(s3) + int.Parse(s4) + int.Parse(s5);
                                            Console.WriteLine("results: " + tmp + " = " + s1 + " (" + i + ")" + ", " + s2 + " (" + j + ")" + ", " + s3 + " (" + k + ")" + ", " + s4 + " (" + l + ")" + ", " + s5 + " (" + m + ")");
                                            if (result > tmp)
                                            {
                                                result = tmp;
                                            }
                                            Console.WriteLine("Lowest is " + result);
                                            //return result;		// Ouch.
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return result;
    }

    private bool isPrime(long num)
    {
        bool status = true;
        long limit = (long)Math.Sqrt(num);
        for (int i = 2; i <= limit; i++)
        {
            if (num % i == 0)
            {
                status = false;
                break;
            }
        }
        return status;
    }
}
