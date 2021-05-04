// C:\Users\Jorge\Documents\Visual Studio 2010\Projects\C#
//   \TestSBTlib\Program.cs
//
// Program to test the SBT library.
//
// Programmer:  Jorge L. Orejel
//
// Last update: 04/09/2021

using System;

using SBTlib;

namespace TestSBTlib
{
   class Program
   {
      static void Main( string[] args )
      {
         SBTree tree = new SBTree();
         Results results;

         results = tree.Approximate( 3.14159265359, 6 );
         results.Display( 6 );

         tree.Reset();

         results = tree.Approximate( 0.56, 6 );
         results.Display( 6 );

         tree.Reset();
         results = tree.Approximate( 0.0, 6 );
         results.Display( 6 );
         tree.Reset();
         results = tree.Approximate( -5.67, 6 );
         results.Display( 6 );
      }
   }
}
