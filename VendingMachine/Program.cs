using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class Program {
        static void Main(string[] args) {
            //double test = Math.Floor((double)1);
            var change = new Dictionary<double, int>() {
                {2, 2 },
                {1, 3 },
                {0.5, 4 },
                {0.2, 5 },
                {0.1, 10 },
                {0.05, 20 }
            };
            Snack s1 = new Snack("Cola", 1.5, 10);
            Snack s2 = new Snack("Choc Bar", 1.25, 10);
            Snack s3 = new Snack("Skittles", 1.7, 10);
            Snack s4 = new Snack("Bikkies", 1.7, 10);
            Machine m1 = new Machine();
            Console.WriteLine(m1.GetTotalChange());
            Menu menu = new Menu();
            menu.controller.AddSnack(s1);
            menu.controller.AddSnack(s2);
            menu.controller.AddSnack(s3);
            menu.controller.AddSnack(s4);
            Console.WriteLine(menu.controller.vending.SnacksForSale[0].SnackName);
            menu.MainMenu();

        }
    }
}
