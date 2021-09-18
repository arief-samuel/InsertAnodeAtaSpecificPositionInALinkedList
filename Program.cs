using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;


namespace InsertAnodeAtaSpecificPositionInALinkedList
{

    class Solution
    {
        public static bool Quit = false;
        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
        {
            while (node != null)
            {
                Console.Write(node.data );

                node = node.next;

                if (node != null)
                {
                    Console.Write(sep);
                }
            }
        }

        class Result
        {
            /*
             * Insert Node into Linked List
             *   Write a function to insert a node in singly-linked list at a given point in the linked list. 
             *   The function should take in two inputs: the value of the node and the position where the node will be inserted.
             *   The position will be a 1-based index meaning that the position of the head node will be 1. 
             *   The position will never be the beginning (the *head) or the end (the tail) of the list.
             *   
             *   List: 1 -> 5 -> 10 -> 3 -> 6
             *   Input: insert(2,4)
             *   Output: 1 -> 5 -> 10 -> 2 -> 3 -> 6
             *   
             *   List: 1 -> 5 -> 10 -> 3 -> 6
             *   Input: insert(3,2)
             *   Output: 1 -> 3 -> 5 -> 10 -> 3 -> 6
             *   
             *   List: 1 -> 5 -> 10 -> 3 -> 6
             *   Input: insert(9,3)
             *   Output: 1 -> 5 -> 9 -> 10 -> 3 -> 6
             */
            public static SinglyLinkedListNode insertNodeAtPosition(int data, int position)
            {
                if (position == 1 || position == 6)
                    throw new ArgumentException(nameof(position),"The position will never be the beginning (the *head) or the end (the tail) of the list.");

                var llist = SeedSinglyLinkedList();
                SinglyLinkedListNode node = new SinglyLinkedListNode(data);
                SinglyLinkedListNode currentNode = llist.head;

                if (llist.head == null)
                {
                    return node;
                }

                for (var i = 1; i < position - 1; i++)
                {
                    currentNode = currentNode.next;
                }

                node.next = currentNode.next;
                currentNode.next = node;

                return llist.head;
            }
            public static SinglyLinkedList SeedSinglyLinkedList()
            {
                SinglyLinkedList llist = new SinglyLinkedList();
                llist.InsertNode(1);
                llist.InsertNode(5);
                llist.InsertNode(10);
                llist.InsertNode(3);
                llist.InsertNode(6);

                return llist;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("#=======================#");
            Console.WriteLine("#        Welcome! #      ");
            Console.WriteLine("#=======================#");
            Console.WriteLine();

            while (!Quit)
            {
                var llist = Result.SeedSinglyLinkedList();
                Console.Write("List: ");
                PrintSinglyLinkedList(llist.head, " -> ");
                Console.WriteLine();
                Console.WriteLine();

                Console.Write("Given the node to add : ");
                int data;
                bool result = int.TryParse(Console.ReadLine(), out data);
                while (!result)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Input a valid number!");
                    Console.WriteLine();

                    Console.Write("Given the node to add : ");
                    result = int.TryParse(Console.ReadLine(), out data);
                }

                Console.Write("Given the position where the node will be inserted : ");
                int position;
                bool result2 = int.TryParse(Console.ReadLine(), out position);
                while (!result2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Input a valid number!");
                    Console.WriteLine();

                    Console.Write("Given the value to add : ");
                    result2 = int.TryParse(Console.ReadLine(), out position);
                }
                Console.WriteLine();

                try
                {
                    SinglyLinkedListNode llist_head = Result.insertNodeAtPosition(data, position);
                    Console.Write($"Input: Insert({data},{position})");
                    Console.WriteLine();
                    Console.Write($"Output: ");
                    PrintSinglyLinkedList(llist_head, " -> ");
                    Console.WriteLine();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine($"Error : {Ex.Message}");
                }

                Console.WriteLine();
                Console.Write("Do you want to continue y/N ? ");
                var command = Console.ReadLine().ToLower();
                Console.WriteLine();
               
                if (command == "y")
                {
                    Quit = false;
                    Console.WriteLine();
                }
                else if (command == "n")
                {
                    Quit = true;
                    Console.WriteLine("#=======================#");
                    Console.WriteLine("Thank you for using this applications!");
                    Console.WriteLine("Have a nice day!");
                    Console.WriteLine("#=======================#");
                    Console.Read();
                }
                else
                {
                    bool check = false;
                    while (!check)
                    {
                        Console.Write($"{command} was not recognized, please try again y/N ? ");
                        command = Console.ReadLine().ToLower();
                        if (command == "y")
                        {
                            Quit = false;
                            break;
                        }
                        else if (command == "n")
                        {
                            Quit = true;
                            Console.WriteLine("#=======================#");
                            Console.WriteLine("Thank you for using this applications!");
                            Console.WriteLine("Have a nice day!");
                            Console.WriteLine("#=======================#");
                            Console.Read();
                            break;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                }
            }
        }
    }

}