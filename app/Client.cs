using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
public class Client {
    public static void Main(String[] args){

        Grocery g = new Grocery();
          
        // prompt user to enter a username
        Console.WriteLine("Enter your username: ");
        string clientname = Console.ReadLine();
        if(g.AddClient(clientname)){
            Console.WriteLine(clientname+" has entered the server!");
        }
        else{
            Console.WriteLine("unable to add"+clientname+"into server :(");
        }

        Boolean loop = true;

        /**
        * loops to prompt user until x is enterd
        */
        while (loop) {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Buy a Veggie or Fruit at My Market!");
            Console.WriteLine("Items Available: broccoli, carrot, spinach, apple, banana, orange");
            Console.WriteLine("Enter the item you would like to buy :)");
            Console.WriteLine("t Total");
            Console.WriteLine("c Check-Out");
            Console.WriteLine("x Leave Shop");

             string command = Console.ReadLine();


                // when user enters one of the items
                if(command.Equals("broccoli") || command.Equals("carrot") || command.Equals("spinach") || command.Equals("apple")|| command.Equals("banana") || command.Equals("orange")){
                         Console.WriteLine(g.AddToCart(clientname,command));
                }

                // when t is entered to get current total
                if(command.Equals("t"))
                {
                    Console.WriteLine("\nTotal: "+g.Total(clientname));
                }

                // check out will also prompt user if they want to leave
                if(command.Equals("c"))
                {
                    Console.WriteLine(g.CheckOut(clientname));
            
                    Console.WriteLine("\nEnter x to leave shop");
                
                    string message = Console.ReadLine();
                    if (message.Equals("x")){
                        command = "x";
                    }
                }

                // x ot elave shop
                if(command.Equals("x"))
                {
                Console.WriteLine("leaving shop..");
                loop = false;
                }


        }
    }

}