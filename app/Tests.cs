using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
public class Client {
    public static void Main(String[] args){
        
        List<string> items = new List<string>(){"broccoli","carrot", "spinach", "apple", "banana", "orange"};
        
        Grocery g = new Grocery();
          
        Console.WriteLine("\n------------------------------------------");
        Console.WriteLine("Test1: 1 client, 10 items ");  
        
        var s1a = new Stopwatch();
        var totTimeA = new Stopwatch();
        
        // prompt user to enter a username
        string clientname = "azi";
        s1a.Start();
        totTimeA.Start();
        if(g.AddClient(clientname)){
            Console.WriteLine(clientname+" has entered the server!");
        }
         else{
                Console.WriteLine("unable to add "+clientname+" into server :(");
            }

        s1a.Stop();
       

        int num = 0;
        var s2a = new Stopwatch();
        s2a.Start();
                
        while(num<10){    
            var r = new Random();
            int index = r.Next(items.Count);
            Console.WriteLine(g.AddToCart(clientname, items[index]));
            num++;
        }
        s2a.Stop();
    

        var s3a = new Stopwatch();
        s3a.Start();
        Console.WriteLine("\nTotal: "+g.Total(clientname));
        s3a.Stop();
        

        Console.WriteLine("\n\n------------------------------------------");
        var s4a = new Stopwatch();
        s4a.Start();
        Console.WriteLine(g.CheckOut(clientname));
        s4a.Stop();
        totTimeA.Stop();
        g.End();

    /////////////////////////////////////////////////////////////////////////////////////////////       
        Console.WriteLine("\n\n\n------------------------------------------");
        Console.WriteLine("\n------------------------------------------");
            
        Console.WriteLine("Test2: 10 clients, 10 items each ");   
        var s1b = new Stopwatch();
        var totTimeB = new Stopwatch();
        long t1b = 0;
        long tB = 0;
        bool s = false;
        for(int x = 1; x<=10;x++){    
            clientname = "client"+x.ToString();
        
            s1b.Start();
            totTimeB.Start();
            if(g.AddClient(clientname)){
                s = true;
            }
            else{
                s = false;
                break;
            }
            s1b.Stop();
            totTimeB.Stop();
            tB = totTimeB.ElapsedMilliseconds;
            t1b = s1b.ElapsedMilliseconds;
        }
        
        if(s == true){Console.WriteLine("10 clients in server!");}
      

        num = 0;
        var s2b = new Stopwatch();
        long t2b = 0;
        
 
        while(num < 10){ 
            for(int x=1;x<=10;x++){
                var r = new Random();
                int index = r.Next(items.Count);
                clientname = "client"+x.ToString();
                s2b.Start();
                totTimeB.Start();
                g.AddToCart(clientname, items[index]);
                totTimeB.Stop();
                s2b.Stop();
                tB = totTimeB.ElapsedMilliseconds;
                t2b = s2b.ElapsedMilliseconds;
            }
            num++;
             
            
        }
       
        Console.WriteLine("Added 10 items to each 10 clients");

        var s3b = new Stopwatch();
        long t3b = 0;
        
        for(int x=1;x<=10;x++){
            clientname = "client"+x.ToString();
            
            s3b.Start();
            totTimeB.Start();
            g.Total(clientname);
            totTimeB.Stop();
            s3b.Stop();
            tB = totTimeB.ElapsedMilliseconds;
            t3b = s3b.ElapsedMilliseconds;
            
        }
        
        Console.WriteLine("got total for each client");

        // Console.WriteLine("\n\n------------------------------------------\n\n");
        var s4b = new Stopwatch();
        
        long t4b = 0;
       
        for(int x=1;x<=10;x++){
            clientname = "client"+x.ToString();
            
            s4b.Start();
            totTimeB.Start();
            g.CheckOut(clientname);
            totTimeB.Stop();
            s4b.Stop();
            tB = totTimeB.ElapsedMilliseconds;
            t4b = s4b.ElapsedMilliseconds;
            
        }
       

        Console.WriteLine("got receipts for each 10 clients");
        g.End();
        /////////////////////////////////////////////////////////////////////////////////////////////  

        Console.WriteLine("\n\n\n------------------------------------------");
        Console.WriteLine("Test3: 20 clients, 50 items each");


        var s1c = new Stopwatch();
        var totTime = new Stopwatch();
       
        long tC = 0;
        long t1c = 0;
        bool c = false;
        for(int x =10;x<31;x++){    
            clientname = "client"+(x+1).ToString();
        
             s1c.Start();
            totTime.Start();
            if(g.AddClient(clientname)){

                 c = true;
            }
            else{
                c = false;
                break;
            }
            s1c.Stop();
            t1c = s1c.ElapsedMilliseconds;
            totTime.Stop();
            tC= totTime.ElapsedMilliseconds;
        }
        
        
        if(c == true){Console.WriteLine("20 clients in server!");}
      

        num = 0;
        var s2c = new Stopwatch();
        long t2c = 0;
        
       
        while(num<50){    
            for(int x=10;x<31;x++){
                var r = new Random();
                int index = r.Next(items.Count);
                clientname = "client"+(x+1).ToString();   
                        
                s2c.Start();
                totTime.Start();
                g.AddToCart(clientname, items[index]);  
                totTime.Stop();
                s2c.Stop(); 
                t2c = s2c.ElapsedMilliseconds;
                tC = totTime.ElapsedMilliseconds;
            }
            num++;
            
        }
              
        
        
       
        Console.WriteLine("Added 50 items to each 20 clients");

        var s3c = new Stopwatch();
        long t3c = 0;
        
        
        for(int x=10;x<31;x++){
            clientname = "client"+(x+1).ToString();
            
            s3c.Start();
            totTime.Start();
            g.Total(clientname);
            totTime.Stop();
            s3c.Stop();
            tC = totTime.ElapsedMilliseconds;
            t3c = s3c.ElapsedMilliseconds;
        }
        
        
         
         
         Console.WriteLine("got total for each client");

       // Console.WriteLine("\n\n------------------------------------------\n\n");
        var s4c = new Stopwatch();
        long t4c = 0;
        
        
        for(int x=10;x<30;x++){
            clientname = "client"+(x+1).ToString();
            s4c.Start();
            totTime.Start();
            g.CheckOut(clientname);
            totTime.Stop();   
            s4c.Stop();
            t4c = s4c.ElapsedMilliseconds;
            tC = totTime.ElapsedMilliseconds;
        }
        
       

       
        
        Console.WriteLine("got receipts for each 20 clients");

        g.End();

        Console.WriteLine("\n------------------------------------------");
        Console.WriteLine("\n------------------------------------------");
            
        Console.WriteLine("Test1: 1 client, 10 items ");  
        
        Console.WriteLine("\nTime to AddClient(): "+s1a.ElapsedMilliseconds);
        Console.WriteLine("\nTime to add 10 items: "+s2a.ElapsedMilliseconds);
        Console.WriteLine("\nTime to get Total: "+s3a.ElapsedMilliseconds);
        Console.WriteLine("\nTime to Check-Out: "+s4a.ElapsedMilliseconds);

        Console.WriteLine("\nTotal Time: "+totTimeA.ElapsedMilliseconds);
        
        Console.WriteLine("\n------------------------------------------\n");
        
        Console.WriteLine("Test2: 10 clients, 10 items each ");   
        Console.WriteLine("\nTime to AddClient(): "+t1b);
        Console.WriteLine("\nTime to add 10 items: "+t2b);
        Console.WriteLine("\nTime to get Total: "+t3b);
        Console.WriteLine("\nTime to Check-Out: "+t4b);

        Console.WriteLine("\nTotal Time: "+tB);

        Console.WriteLine("\n------------------------------------------\n");
        Console.WriteLine("Test3: 20 clients, 50 items each");
        Console.WriteLine("\nTime to AddClient(): "+t1c);
        Console.WriteLine("\nTime to add 50 items: "+t2c);
        Console.WriteLine("\nTime to get Total: "+t3c);
        Console.WriteLine("\nTime to Check-Out: "+t4c);

        Console.WriteLine("\nTotal Time: "+tC);

        Console.WriteLine("\n------------------------------------------");
  
    }
}
  