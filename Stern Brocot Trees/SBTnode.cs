// C:\Users\Jorge\Documents\Visual Studio 2010\Projects\C#
//   \LIB\SBTlib\SBTnode.cs
//
// Library implementing Stern-Brocot Trees
//
// Programmer:  Jorge L. Orejel
//
// Last update: 04/29/2021 : Original coding based on the C++ code by Mircea Neacsu.

using System;

namespace SBTlib
{
   /// <summary>Class to implement a node in a Stern-Brocot tree. 
   /// </summary>
   public class SBTnode
   {
      public int _p, _q;
      public SBTnode left, right, parent;

      public SBTnode( SBTnode _parent )
      {
         _p = _q = 0;
         left = right = null;
         parent = _parent;
      }// SBTnode (constructor)
   } // SBTnode (class)
}// SBTlib (namespace)
