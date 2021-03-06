﻿using System;
using System.ComponentModel;
using System.Text;

namespace q11
{
    class Program
    {
        static int?[] GetT1()
        {
            //return new int?[] {0, 1, 2, 3, 4, null, null, null, null, null, 10, null, null, null, null };
            // Duplicate values
            return new int?[] {0, 1, 2, 3, 4, null, 15, null, null, null, 10, null, null, null, 15};
        }

        // T2 is a subtree of T1
        static int?[] GetT2()
        {
            return new int?[] {1, 3, 4, null, null, null, 10};
        }

        // T3 is not a subtree of T1
        // This invalidates InOrder traversal of T1
        static int?[] GetT3()
        {
            return new int?[] {4, 3, 10, 1};
        }

        // T4 is not a subtree of T1
        // This invalidates PostOrder traversal of T1
        static int?[] GetT4()
        {
            return new int?[] {1, null, 4, null, null, null, 10, null, null, null, null, null, null, null, 3};
        }

        // T5 is not a subtree of T1
        // This invalidates PreOrder traversal of T1
        static int?[] GetT5()
        {
            return new int?[] {1, 3, null, 4, null, null, null, 10 };
        }

        // T6 has duplicate values
        static int?[] GetT6()
        {
            return new int?[] { 15, null, 15 };
        }

        static void GetInOrder(int?[] t, int current, StringBuilder sb)
        {
            if (current < t.Length)
            {
                GetInOrder(t, (2 * current) + 1, sb);
                if (t[current].HasValue)
                {
                    sb.Append(t[current] + " "); // spacing caters for {1, 2, 2, 2} and {1, 22, 2} .etc
                }
                else
                {
                    sb.Append("NULL ");  // cater for duplicate values
                }
                GetInOrder(t, (2 * current) + 2, sb);
            }
        }

        static void GetPostOrder(int?[] t, int current, StringBuilder sb)
        {
            if (current < t.Length)
            {
                GetPostOrder(t, (2*current) + 1, sb);
                GetPostOrder(t, (2*current) + 2, sb);
                if (t[current].HasValue)
                {
                    sb.Append(t[current] + " ");
                }
                else
                {
                    sb.Append("NULL ");
                }
            }
        }

        static void GetPreOrder(int?[] t, int current, StringBuilder sb)
        {
            if (current < t.Length)
            {
                if (t[current].HasValue)
                {
                    sb.Append(t[current] + " ");
                }
                else
                {
                    sb.Append("NULL ");
                }
                GetPreOrder(t, (2*current) + 1, sb);
                GetPreOrder(t, (2*current) + 2, sb);
            }
        }

        static bool IsT2SubtreeOfT1(int?[] t1, int?[] t2)
        {
            var t1InOrder = new StringBuilder();
            GetInOrder(t1,0, t1InOrder);
            var t1PreOrder = new StringBuilder();
            GetPreOrder(t1,0, t1PreOrder);
            var t1PostOrder = new StringBuilder();
            GetPostOrder(t1,0, t1PostOrder);

            var t2InOrder = new StringBuilder();
            GetInOrder(t2, 0, t2InOrder);
            var t2PreOrder = new StringBuilder();
            GetPreOrder(t2, 0, t2PreOrder);
            var t2PostOrder = new StringBuilder();
            GetPostOrder(t2, 0, t2PostOrder);

            return t1InOrder.ToString().Contains(t2InOrder.ToString()) &&
                   t1PreOrder.ToString().Contains(t2PreOrder.ToString()) &&
                   t1PostOrder.ToString().Contains(t2PostOrder.ToString());
        }

        static void Main(string[] args)
        { 
            var t1 = GetT1();
            var t2 = GetT6();

            var result = false;
            if (t1.Length > 0 || t2.Length > 0)
            {
                result = IsT2SubtreeOfT1(t1, t2);
            }

            Console.WriteLine(result);
        }
    }
}