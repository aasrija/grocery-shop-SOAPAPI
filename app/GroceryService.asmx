
<%@ WebService Language="C#" Class="Grocery.Grocery" %>

using System;
using System.Web.Services;
using System.Collections;
using System.Collections.Generic;

namespace Grocery{

    [WebService (Namespace = "http://tempuri.org/GroceryService")]
    public class Grocery : WebService
    {
        public static List<string> clients = new List<string>();
        public static List<string> cart;
        public static double cost;
        public static Dictionary<string, List<string>> info = new Dictionary<string,List<string>>();
        public static Dictionary<string,int> itemCount;
        public static Dictionary<string,double> catalogue = new Dictionary<string, double>()
        {
            {"broccoli",3.99},
            {"carrot",2.99},
            {"spinach",1.99},
            {"apple",0.99},
            {"banana",0.99},
            {"orange",0.99}
        };
        
        [WebMethod]
        public bool AddClient(string clientname)
        {
        
            bool success = false;
            try{
              
                clients.Add(clientname);
                cart = new List<string>();
                info.Add(clientname, cart);
                cost = 0.0;
        
                if(info.ContainsKey(clientname)){
                
                    success = true;
                }              
            }
            catch (ArgumentException e){
                Console.WriteLine("ERROR: client " +clientname+ " alrdy exists");
                success = false;
            }

            return success;
        }
        
       
        [WebMethod]
        public string AddToCart(string clientname,string item){
            try{
                if(!info.ContainsKey(clientname)){
                    cart = new List<string>();
                    cart.Add(item);
                    info.Add(clientname, cart);
   
                }
                else{
                    cart = info[clientname];
                    cart.Add(item);
                    info[clientname] = cart;
                }
                
                return item+" added to cart";
                    
            }
            catch (ArgumentException e){
                return "Unable to add "+item+" to cart";
            }
        
        }
       
       
        
        [WebMethod]
        public double Total(string clientname){
            
            double total = 0.0;
            
            try{
                cart = info[clientname];
                foreach(var item in cart){
                    total += catalogue[item];
                }
                
                return total;
            }
            catch (ArgumentException e){
                return total;
            }
        
        }
        
        
        [WebMethod]
        public string CheckOut(string clientname){
            string receipt = "";
            cart = info[clientname];
            if(cart.Count>0){
                receipt = "\n------------------------------------------";
                receipt = "Thank you for shopping with us "+clientname+"! Here is your receipt:\n";
                cost = Total(clientname);
                itemCount = new Dictionary<string, int>();
                foreach(var i in cart){
                    int c = 0;
                    for(int x=0;x<cart.Count;x++){
                        
                        if(i == cart[x]){
                            c +=1;
                          
                    
                    }
                      itemCount[i] = c;
                }}
                foreach(var item in itemCount.Keys){
                    receipt = receipt+item+" x"+itemCount[item]+"\n";;
                }
                 receipt = receipt+"\n" +cost+ "\n------------------------------------------";
                
            }
            else{
                receipt = "cart is empty! \n\n\nEnter < to go back to shopping";    
            }
            return receipt;
        }
        
        [WebMethod]
        public void End(){
            info.Clear();
            itemCount.Clear();
            cart.Clear();
            clients.Clear();
        }
        
    }
    }
    
    
