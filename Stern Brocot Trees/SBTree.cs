// C:\Users\Jorge\Documents\Visual Studio 2010\Projects\C#
//   \LIB\SBTlib\SBTree.cs
//
// Library implementing Stern-Brocot Trees
//
// Programmer:  Jorge L. Orejel
//
// Last update: 04/29/2021 : Original coding based on the C++ code by Mircea Neacsu.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace SBTlib
{
   /// <summary>Class to implement Stern-Brocot trees for rational approximations
   ///          of floating-point (double) numbers.
   /// </summary>
   public class SBTree
   {
      SBTnode root;

      public SBTree()
      {
         Reset();
      }// SBTree (constructor)

      /// <summary>Initialize the root node and its children. 
      /// </summary>
      public void Reset()
      {
         root = new SBTnode( null );

         root._p = root._q = 1;
         Grow( root );
      }// Reset

      /// <summary>Add left and right children to a node. 
      /// </summary>
      /// <param name="node">Node to which the children will be added.
      /// </param>
      private void Grow( SBTnode node )
      {
         // Add left child.

         SBTnode left = new SBTnode( node );

         node.left = left;
         if ( node._p == 1 ) // Node on left tree boundary == 1 / (n + 1).
         {
            left._p = 1;
            left._q = node._q + 1;
         }
         else // Node is mediant of parent and previous node.
         {
            SBTnode previous = Previous( node );

            left._p = node._p + previous._p;
            left._q = node._q + previous._q;
         }

         // Add right child.

         SBTnode right = new SBTnode( node );

         node.right = right;
         if ( node._q == 1 ) // Node on right tree boundary == (n + 1) / 1.
         {
            right._q = 1;
            right._p = node._p + 1;
         }
         else // Node is mediant of parent and next node.
         {
            SBTnode next = Next( node );

            right._p = node._p + next._p;
            right._q = node._q + next._q;
         }
      }// Grow

      /// <summary>Return node to the left. 
      /// </summary>
      /// <param name="node">An SBTnode.
      /// </param>
      /// <returns>Node to the left.
      /// </returns>
      private SBTnode Previous( SBTnode node )
      {
         Debug.Assert( node.parent != null );

         while ( node.parent.right != null && node.parent.right != node )
         {
            node = node.parent;
         }
         return node.parent;
      }// Previous

      /// <summary>Return node to the right. 
      /// </summary>
      /// <param name="node">An SBTnode.
      /// </param>
      /// <returns>Node to the right.
      /// </returns>
      private SBTnode Next( SBTnode node )
      {
         Debug.Assert( node.parent != null );

         while ( node.parent.left != null && node.parent.left != node )
         {
            node = node.parent;
         }
         return node.parent;
      }// Next

      // The following function must return the numerator and
      // denominator of the rational approximation.

      /// <summary>Approximate a number with a given precision. 
      /// </summary>
      /// <param name="x">Number to approximate.</param>
      /// <param name="n">Precision in number of decimal places.
      /// </param>
      /// <returns>An instance of {Results}.
      /// </returns>
      public Results Approximate( double x, int n )
      {
         if ( NotPositive( x ) )
         {
            MessageBox.Show( 
               String.Format( "SBTree.Approximate: argument 'x' (== {0}) must be positive.", 
                              x ) );

            return new Results( 0, 1, x, 0.0, new List<Tuple<int,int,double>>() );
         }
         else
         {
            double epsilon = Math.Pow( (double)10.0, (double)( -n ) );
            double approx = (double)1.0;
            List<Tuple<int, int, double>> sequence = new List<Tuple<int, int, double>>();

            // Call {Reset} if this function is to be used repeatedly.

            SBTnode current = root; // Starting point is the tree root.

            do
            {
               // Record current approximation.
               sequence.Add( new Tuple<int, int, double>( current._p, current._q, approx ) );

               // Move left or right.
               if ( x > approx )
               {
                  current = current.right;
               }
               else
               {
                  current = current.left;
               }
               // Grow the children of {current} node.
               Grow( current );

               // Update the approximation.
               approx = (double)current._p / (double)current._q;

            } while ( Math.Abs( x - approx ) > epsilon );

            return new Results( current._p, current._q, x, approx, sequence );
         }
      }// Approximate

      private bool NotPositive( double x )
      {
         string str = x.ToString();

         return str.StartsWith( "-" ) || str.Equals( "0" );
      }// NotPositive
   }// SBTree (class)
}// SBTlib (namespace)
