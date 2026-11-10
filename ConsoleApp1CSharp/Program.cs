using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1CSharp
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int selection = 0;
            while (selection != -1)
            {
                printMenu();
                Console.Write("\n\n\t\tEnter Number Here: ");
                if (int.TryParse(Console.ReadLine(), out selection))
                {
                    switch (selection)
                    {
                        case 1:
                            arrayOperations();
                            break;
                        case 2:
                            listOperations();
                            break;
                        case 3:
                            Console.WriteLine("\n\n\t\t185 Linked List Created!");
                            Linked185List<int> ourClassList = new Linked185List<int>();
                            linkedListOperations(ourClassList);
                            break;
                        case 4:
                            doubleLinkedOperations();
                            break;
                        case 5:
                            stackOperations();
                            break;
                        case 6:
                            queueOperations();
                            break;
                        case 7:
                            heapOperations();
                            break;
                        case 8:

                            selection = -1;
                            break;
                        default:
                            Console.WriteLine("Incorrect number entered, Please Try again");

                            break;
                    }
                }    
            }
                System.Environment.Exit(1);
        }

        //Main Menu
        private static void printMenu()//done
        {
            //lets build a menu dig baddy
            Console.WriteLine("\n\n\t\t*********************************************");
            Console.WriteLine("\t\t***Welcome to the 244 Data Structures Menu***");
            Console.WriteLine("\t\t*********************************************");
            Console.WriteLine("\t\t***         Please Select An Item         ***");
            Console.WriteLine("\t\t*Lists, Linked List, Arrays, Stacks & Queues*");
            Console.WriteLine("\t\t*********************************************");

            Console.WriteLine("\n\n\t\t1. Create an Array of Random Variables    ");
            Console.WriteLine("\n\t\t2. Create a List     ");
            Console.WriteLine("\n\t\t3. Create a LinkedList ");
            Console.WriteLine("\n\t\t4. Create a Double Linked List ");
            Console.WriteLine("\n\t\t5. Create a Stack ");
            Console.WriteLine("\n\t\t6. Create a Queue  ");
            Console.WriteLine("\n\t\t7. Create and implement a heap   ");
            Console.WriteLine("\n\t\t8. Exit Program");
        }
        #region Array
        //Arrays Stuff
        private static void arrayOperations()
        {
            //Creating an array
            int[] newArray = new int[50];
            Random arrayNumbers = new Random();
            Console.WriteLine("Creating Array");
            bool keepSearching = true;
            int nums = 0;


            Console.WriteLine("Filling with Random Values" );

            //fill automatically with Random numbers
            for (int i = 0; i < newArray.Count(); i++)
            {
                nums = arrayNumbers.Next(0, 201);
                newArray[i] = nums;
                Console.WriteLine("Added number: " + nums);
            }

            //pause
            Console.ReadLine();
            int selection;
            
            bool running = true;
            while (running)
            {
                selection = printArrayOpsMenu();
                switch (selection)
                {
                    case 1:
                        printArray(newArray);
                        break;
                    case 2:
                        newArray = new int[50];
                        break;
                    case 3:
                        Console.WriteLine("Number of Elements: " + newArray.Count());
                        break;
                    case 4:
                        while (keepSearching == true)
                        {
                            Console.WriteLine("Search what number: ");
                            int num = 0;


                            if (int.TryParse(Console.ReadLine(), out num))
                            {
                                //searching
                                Console.WriteLine("Searching for " + num + " in array ");
                                int position = 0;

                                position = searchArray(num, newArray);
                                if (position == -1)
                                {
                                    Console.WriteLine("did not find it!");
                                }
                                else
                                {
                                    Console.WriteLine("Found Item at: " + position);
                                }

                            }
                            Console.WriteLine("Keep searching?");
                            string keepSearchChar = Console.ReadLine();
                            if (keepSearchChar.ToUpper() == "Y")
                            {
                                keepSearching = true;
                            }
                            else
                                keepSearching = false;

                        }

                        break;
                    case 5:
                        int printElement = 0;
                        Console.WriteLine("\n\n\t\tWhich Element");
                        if (int.TryParse(Console.ReadLine(), out printElement))
                            if (printElement >= 0 && printElement < newArray.Count())
                                Console.WriteLine(newArray.ElementAt(printElement));
                            else
                                Console.WriteLine("\n\n\t\tElement out of range");
                        else
                            Console.WriteLine("\n\n\t\tBad Data Entered");
                        break;
                    case 6:
                        sortArray(newArray);
                        break;
                    case 7:
                        int addElement = 0;
                        Console.WriteLine("\n\n\t\tWhat number would you like to add? ");
                        if (int.TryParse(Console.ReadLine(), out addElement))
                            newArray.Append(addElement);
                        else
                            Console.WriteLine("\n\n\t\tBad Data Entered");
                        break;
                    case 8:
                        int deleteElement = 0;
                        Console.WriteLine("\n\n\t\tWhich Element");
                        if (int.TryParse(Console.ReadLine(), out deleteElement))
                            if (deleteElement >= 0 && deleteElement < newArray.Count())
                                newArray[deleteElement] = 0;
                            else
                                Console.WriteLine("\n\n\t\tElement out of range");
                        else
                            Console.WriteLine("\n\n\t\tBad Data Entered");
                        break;
                    case 9:
                        int prependElement = 0;
                        Console.WriteLine("\n\n\t\tWhat number would you like to add? ");
                        if (int.TryParse(Console.ReadLine(), out prependElement))
                            newArray.Append(prependElement);
                        else
                            Console.WriteLine("\n\n\t\tBad Data Entered");
                        break;
                    case 10:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\n\n\t\tWrong Data Entered ");
                        break;

                }
            }
            //search the array find the number 

            Console.WriteLine("Press any key to continue . . . To return to menu.");
            Console.ReadLine();
        }
        //Menu
        private static int printArrayOpsMenu()
        {
            //lets build a menu dig baddy
            Console.WriteLine("\n\n\t\t*********************************************");
            Console.WriteLine("\t\t***          Array Operations Menu         ***");
            Console.WriteLine("\t\t*********************************************");
            Console.WriteLine("\t\t***         Please Select An Item         ***");
            Console.WriteLine("\t\t*********************************************");

            Console.WriteLine("\n\t\t1. Print Array");
            Console.WriteLine("\n\t\t2. Delete Array");
            Console.WriteLine("\n\t\t3. Get Number of Elements");
            Console.WriteLine("\n\t\t4. Search Array");
            Console.WriteLine("\n\t\t5. Print an Element");
            Console.WriteLine("\n\t\t6. Bubble Sort Array");
            Console.WriteLine("\n\t\t7. Append item to end of Array");
            Console.WriteLine("\n\t\t8. Delete Element from Array");
            Console.WriteLine("\n\t\t9. Prepend Element");
            Console.WriteLine("\n\t\t10. Exit Program");
            Console.Write("\n\n\t\tEnter Number Here: ");
            int selection;
            if (int.TryParse(Console.ReadLine(), out selection))
            { 
                //good to go
            }
            else
            {
                Console.WriteLine("Invalid Data: Try again. 11 to End.");
                printArrayOpsMenu();
            }
            return selection;

        }

        private static void printArray(int[] searchArray)
        {
            //print Array
            Console.WriteLine("Printing array numbers: ");
            for (int i = 0; i < searchArray.Count(); i++)
            {
                Console.WriteLine(searchArray[i]);
            }
        }
        private static int searchArray(int num, int[] searchArray)
        {
            int foundAt = -1;
            for (int i = 0; i < searchArray.Count(); i++)
            {
                if (searchArray.ElementAt(i) == num)
                {
                    Console.WriteLine("Found it");
                    foundAt = i;
                }

            }
            return foundAt;
        }
        //sorting
        private static void sortArray(int[] arrayToSort)
        {
            int length = arrayToSort.Count();
            bool flip=true;
            while (flip){
                flip = false;
                for (int i = 1; i < length; i++)
                {
                    //compare elements that are next to each other
                    if (arrayToSort[i - 1] > arrayToSort[i])
                    {
                        int temp = arrayToSort[i - 1];
                        arrayToSort[i - 1] = arrayToSort[i];
                        arrayToSort[i] = temp;
                        flip = true;//we swapped
                    }
                }
                length--;//make the length smaller
            }
            Console.WriteLine("\n\n\t\tSorted Array: ");
            printArray(arrayToSort);
        }
        
        
        //done
        #endregion

        #region List
        //List Stuff
        //Menu
        private static void printListOpsMenu()
        {
            //lets build a menu dig baddy
            Console.WriteLine("\n\n\t\t*********************************************");
            Console.WriteLine("\t\t***          List Operations Menu         ***");
            Console.WriteLine("\t\t*********************************************");
            Console.WriteLine("\t\t***         Please Select An Item         ***");
            Console.WriteLine("\t\t*********************************************");

            Console.WriteLine("\n\t\t1. Create the List     ");
            Console.WriteLine("\n\t\t2. Fill the List ");
            Console.WriteLine("\n\t\t3. Add to List");
            Console.WriteLine("\n\t\t4. Insert into List");
            Console.WriteLine("\n\t\t5. Search List");
            Console.WriteLine("\n\t\t6. Delete Element from List");
            Console.WriteLine("\n\t\t7. Remove Last Element");
            Console.WriteLine("\n\t\t8. Print List");
            Console.WriteLine("\n\t\t9. Exit Program");
        }

        private static void listOperations()
        {
            printListOpsMenu();
            Random autofillVals = new Random();
            List<int> arrayList = new List<int>();
            // Create a List<int> to store integers
            Console.Write("\n\t\tHow Many Numbers would you like in this List? (-1 to Quit): ");
            int numForList = 0;
            if (int.TryParse(Console.ReadLine(), out numForList) && numForList >= 0)
            {

                int values = 0;
                Console.Write("\n\t\tEnter the vals: (-1 to autofill): ");

                while (arrayList.Count() < numForList && int.TryParse(Console.ReadLine(), out values))
                {

                    if (values == -1)
                    {
                        for (int i = arrayList.Count(); i < numForList; i++)
                        {
                            Console.WriteLine("\n\t\tAutofilling");
                            arrayList.Add(autofillVals.Next());
                        }
                    }
                    else
                        arrayList.Add(values);
                    Console.Write("\t\tPlease enter a number: (-1 to autofill): ");

                }
                int printCount = 0;
                //Printing list
                Console.WriteLine("\n\n\t\tPrinting list");

                foreach (int item in arrayList)
                {
                    printCount++;
                    Console.WriteLine("\t\tArraylist Item: " + printCount + " is: " + item);
                }
            }
            else if (numForList == -1)
            {
                Console.WriteLine("\t\t......Quitting!");
            }
            Console.WriteLine("\n\n\t\tBack to Menu ");

            int deleteItem = 0;
            int deleteIndex = 0;
            int numberToSearch = 0;
            searchList(numberToSearch, arrayList);
            deleteThingFromList(deleteItem, arrayList);
            deleteItemFromList(deleteIndex, arrayList);
        }
        private static void deleteThingFromList(int deleteItem, List<int> arrayList)//done
        {
            //lol you think i'm going to do work? no
            int index = 0;
            index = searchList(deleteItem, arrayList);
            deleteItemFromList(index, arrayList);
        }
        private static int searchList(int numberToSearch, List<int> arraySearchList)//done
        {
            int i = 0;//index
            foreach (int item in arraySearchList)
            {
                if (item == numberToSearch)
                {
                    Console.WriteLine("\t\tArraylist Item Found at position" + i + " is: " + item);
                }
                i++;
            }
            return i;
        }
        private static void deleteItemFromList(int index, List<int> list)//done
        {
            list.RemoveAt(index);
        }

        #endregion

        #region
        //Linked List Stuff
        //Menu
        private static int printLinkedOpsMenu()
        {
            Console.WriteLine("\n\n\t\t*********************************************");
            Console.WriteLine("\t\t***   Linked List Operations Menu         ***");
            Console.WriteLine("\t\t*********************************************");
            Console.WriteLine("\t\t***         Please Select An Item         ***");
            Console.WriteLine("\t\t*********************************************");

            Console.WriteLine("\n\t\t1. Add to List     ");
            Console.WriteLine("\n\t\t2. Delete Element from List ");
            Console.WriteLine("\n\t\t3. Print List");
            Console.WriteLine("\n\t\t4. Exit Program");
            Console.Write("\n\n\t\tEnter Number Here: ");

            int choice = 0;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                //
                Console.WriteLine("\n\n\t\tThank you for your input!");

            }
            else
            {
                Console.WriteLine("\n\n\t\tIncorrect Data Entered. Try Again");

                choice = -1;

            }
            return choice;


        }//done

        //Operations
        private static void linkedListOperations(Linked185List<int> ourClassList)//done
        {
            int choice = printLinkedOpsMenu();

            while (choice != 4)
            {
                switch (choice)
                {
                    case 1:
                        addToLinkedList(ourClassList);
                        break;
                    case 2:
                        deleteItemFromLinked(ourClassList);
                        break;
                    case 3:
                        printLinkedList(ourClassList);
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("\n\n\t\tWrong Data Entered Try Again>>>>>>>>");

                        break;
                }
            }
            Console.WriteLine("\n\n\t\tExiting>>>>>>>>");


        }

                //Add
        private static void addToLinkedList(Linked185List<int> myList)
        {
            int numberToAdd = 0;
            Console.Write("\n\t\tPlease enter a number to add to linked list: (-1 to stop)");

            while (int.TryParse(Console.ReadLine(), out numberToAdd) && numberToAdd != -1)
            {

                //adding numbers to linked list and bulding list on the fly
                Console.Write("\n\t\tPlease enter a number to add to linked list: (-1 to stop)");
                myList.Add(numberToAdd);

            }
            Console.Write("\n\t\t..... Done adding returning to menu: ");
            linkedListOperations(myList);
        }//done

                //Delete
        private static void deleteItemFromLinked(Linked185List<int> ourClassList)
        {
            int removeThis = 0;
            Console.Write("\n\t\tPlease enter a number to remove from linked list: (-1 to stop)");

            if (int.TryParse(Console.ReadLine(), out removeThis))
                if (ourClassList.RemoveWhat(removeThis))
                    Console.WriteLine("\n\t\tItem Removed");
                else
                    Console.WriteLine("\n\t\tThere is no item matching " + removeThis + " the data entered to be removed");

            else
                Console.WriteLine("\n\t\tWrong data entered:  Exiting");
            linkedListOperations(ourClassList);

        }//done

                //Print
        private static void printLinkedList(Linked185List<int> ourClassList)
        {
            Console.WriteLine("\n\n\t\tBuilding Pretty Linked List:   ");
            ourClassList.Print();
            linkedListOperations(ourClassList);

        }//done



        #endregion

        #region DoublyLinkedLists

        //Doube Linked List Stuff
        private static void doubleLinkedOperations()
        {

        }
        #endregion

        //Stack
        private static void stackOperations()
        {

        }

        //Queue Stuff
        private static void queueOperations()
        {

        }

        //Heap Stuff
        private static void heapOperations()
        {
            
        }















        //sort
    }

    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
    class Linked185List<T>
    {
        private Node<T> head;

        public void Add(T data)
        {
            Node<T> newNodePosition = new Node<T>(data);
            //add item to the end of the list, if its nothing here, add it to the first thing.
            if(head == null)
            {
                head = newNodePosition;
            }
            else
            {
                Node<T> current = head;
                while(current.Next!=null)
                {
                    current = current.Next;

                }
                current.Next = newNodePosition;
            }
        }
        //Delete item from our list
        public bool RemoveWhat(T data)
        {
            if(head==null)
            {
                return false;
            }

            if (head.Data.Equals(data))
            {
                head = head.Next;
                return true;
            }

            Node<T> current = head;
            while (current.Next != null)
            {
                if (current.Next.Data.Equals(data))
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
        public void Print()
        {
            Node<T> current = head;
            while (current!= null)
            {
                Console.Write(current.Data + "  =>=>  ");
                current = current.Next;
            }
            Console.WriteLine(" \t\t There is nothing here brother. ");
        }
    }


}
