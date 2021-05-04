// C:\Users\Jorge\Documents\Visual Studio 2010\Projects\C#
//   \LIB\SBTlib\Results.cs
//
// Library implementing Stern-Brocot Trees
//
// Programmer:  Jorge L. Orejel
//
// Last update: 04/30/2021.

using System;
using System.Collections.Generic;

namespace SBTlib
{
   /// <summary>Class to encapsulate the results of a rational appproximation. 
   /// </summary>
   public class Results
   {
      int numerator, denominator;

      double number, approx, error;

      List<Tuple<int,int,double>> sequence;

      public Results( int p, int q, double x, double _approx, 
                      List<Tuple<int,int,double>> _sequence )
      {
         numerator = p;
         denominator = q;
         number = x;
         approx = _approx;
         error = x - _approx;
         sequence = _sequence;
      }// Results (constructor)

      public int Numerator { get { return numerator; } }
      public int Denominator { get { return denominator; } }

      public void Display( int decPlaces )
      {
         if ( sequence.Count > 0 )
         {
            Console.WriteLine( "\nRational approximation to {0}\nwith {1} decimal places:\n",
                               number, decPlaces );

            string formatStr
               = "{0,4}/{1,4} == {2," 
                 + ( decPlaces + 5 ).ToString() + ":F" + decPlaces.ToString() + "}";

            foreach ( Tuple<int, int, double> tuple in sequence )
            {
               Console.WriteLine( formatStr, tuple.Item1, tuple.Item2, tuple.Item3 );
            }

            Console.WriteLine( "\nFinal result:\n" );
            Console.WriteLine( formatStr, numerator, denominator, approx );
            Console.WriteLine();
         }
      }// Display
   }// Results (class)
}// SBTlib (namespace)
