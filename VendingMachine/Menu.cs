using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class Menu {
        public Controller controller;
        private string[] coinTypes = {"2", "1", "0.5", "0.2", "0.1", "0.05"};
        public Menu() {
            this.controller = new Controller();
        }
        public void MainMenu() {
            Console.WriteLine("###############################");
            Console.WriteLine("# Mecachrome Vending Merchant #");
            Console.WriteLine("#     Hawking Edible Wares    #");
            Console.WriteLine(" #############################");
            Console.WriteLine(String.Format("{0,-4}{1,-10} -- {2,-6} -- {3,-10}", "", "Snack", "Price", "QTY"));
            Console.WriteLine(this.controller.GetSnackData());
            Console.Write("Please enter choice: > ");

            int choice = Convert.ToInt32(Console.ReadLine()) - 1;
            if (choice + 1 == 1011) {
                Console.Write("Password: ");
                string passwd = Console.ReadLine();
                if (passwd.Equals("A5144l")) {
                    AdminMenu();
                }
            }
            TransactionMenu(choice);
            MainMenu();
        }
        public void AdminMenu() {
            Console.WriteLine("###############################");
            Console.WriteLine("#         Admin Menu          #");
            Console.WriteLine("###############################");
            Console.WriteLine("1. Change a snack price");
            Console.WriteLine("2. Increase change pool");
            Console.WriteLine("3. See total money in machine");
            Console.WriteLine("4. Return to menu");
            Console.Write("Choose option: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            while (true) {
                if (choice == 4) {
                    break;
                }
                switch (choice) {

                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
        }
        private void TransactionMenu(int choice) {

            // Check item availability

            if ( !controller.CheckItemAvailability(choice)) {
                Console.WriteLine("* out of stock *");
                return;
            }
            // Receive money

            Dictionary<string, int> coinsReceived = new Dictionary<string, int>();
            
            Console.WriteLine("## Enter coins to pay ##");
            bool Paid = false;
            int i = 0;
            while (Paid.Equals(false)) {
                if (i > coinTypes.Length - 1) {
                    Console.WriteLine("Not enough inserted, put in more money.");
                    i = 0;
                }
                Console.WriteLine($"Number of {String.Format("{0:0.00}", coinTypes[i])} coins inserted: ");
                int numInserted = Convert.ToInt32(Console.ReadLine());
                coinsReceived.Add(coinTypes[i], numInserted);
                Paid = controller.PayForItem(choice, coinsReceived);
                i++;
            }
            controller.AllocateCoins(coinsReceived);

            Console.WriteLine(controller.GetChange(coinTypes));

            // Check if enough to purchase
            //
        }
    }
}
