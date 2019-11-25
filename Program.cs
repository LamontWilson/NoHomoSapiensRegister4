using System;

namespace NoHomoSapiens {
    class Program {
        static void Main(string[] args) {
            //statements in main for debug purposes
            decimal amt_charged = 60; 
            //need to validate if user has paid negative monies
            decimal user_amt = PromptInt("insert payment");
            Console.WriteLine($"Change Due: {MakeChange(amt_charged, user_amt)}");

        }
        //function to determine how much change to return to user, if kiosk can do so.
        //ARGS: amount due, how much user is paying
        static decimal MakeChange(decimal amt_charged, decimal user_amt) {
            //vars for change, refund, and for kiosk bank
            decimal change = 0;
            decimal refund = user_amt;
            decimal kiosk_bank = 100;

            //kiosk pays out amount of change due            
            change = user_amt - amt_charged;
            kiosk_bank -= change;

            //if user hasn't entered enough to pay, try again
            while (change <= 0 || user_amt <= 0) {
                user_amt = PromptInt("continue to insert payment");                
                change += user_amt;
            }
              
            //if the kiosk has no money, return refunds to user
            while (kiosk_bank <= 0) {
                Console.WriteLine("Unable to give change.");
                return refund;
            }
            //while the kiosk has money to give change, do so.
            return change;
            
        }
        #region PROMPT FUNCTIONS
        static int PromptInt(string messages) {
            Console.WriteLine(messages + " ");
            return int.Parse(Console.ReadLine());
        }// end PromptInt
        static double PromptDouble(string messages) {
            Console.WriteLine(messages + " ");
            return int.Parse(Console.ReadLine());
        }// end PromptDouble
        static string PromptString(string messages) {
            Console.WriteLine(messages + " ");
            return Console.ReadLine();
        }//end PromptString
        #endregion
    }
}
