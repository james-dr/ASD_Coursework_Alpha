using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class Controller {
        public Machine vending;
        public double Change { get; set; }
        public Controller() {
            this.vending = new Machine();
        }
        public string GetSnackData() {
            string snackData = "";
            int snackIndex = 1;
            foreach (Snack snack in this.vending.SnacksForSale) {
                snackData += String.Format("{0, -3} {1}\n", snackIndex.ToString() + ".", snack.ToString());
                snackIndex++;
            }
            return snackData;
        }
        public bool CheckItemAvailability(int itemIndex) {
            if (this.vending.SnacksForSale[itemIndex].SnackQuantity <= 0) {
                return false;
            }
            
            return true;
        }
        public bool PayForItem(int item, Dictionary<string, int> coins) {
            double initial = vending.SnacksForSale[item].SnackPrice;
            Console.WriteLine(initial);
            double totalPaid = CoinTotal(coins);

            if (totalPaid < initial) {
                return false;
            }
            this.Change = totalPaid - initial;
            vending.SnacksForSale[item].SnackPrice--;
            return true;

        }
        private double CoinTotal(Dictionary<string, int> coins) {
            double total = 0;
            foreach (var pair in coins) {
                total += Convert.ToDouble(pair.Key) * pair.Value;
            }
            return total;
        }
        public bool AllocateCoins(Dictionary<string, int> coins) {
            List<string> keys = new List<string>(coins.Keys);
            foreach (var item in keys) {
                vending.ChangeVals[item] += coins[item];
            }
            return true;
        }
        public string GetChange(string[] coinTypes) {
            decimal changeLeft = (decimal)this.Change;
            Dictionary<string, int> coinsChange = new Dictionary<string, int>();

            for(int i = 0; i<coinTypes.Length; i++) {
                
                string type = coinTypes[i];
                decimal coin = Math.Round(Convert.ToDecimal(type),2);
                
                int coinTally = vending.ChangeVals[type];
                coinsChange[type] = 0;

                int coinsGiven = (int)((changeLeft - (changeLeft % coin)) / coin);

                if (coinsGiven >= 1) {
                    Console.WriteLine(coinTally);
                    if (coinsGiven > coinTally) {
                        coinsGiven = coinTally;
                        coinsChange[type] = coinsGiven;
                        changeLeft -= Math.Round(coin * coinsGiven, 2);
                        continue;
                    }
                    coinsChange[type] = coinsGiven;
                    changeLeft -= Math.Round(coin * coinsGiven, 2);
                }
            }
            if (changeLeft > 0) {
                return "Not enough change.";               
            }
            AllocateChange(coinsChange);
            string returnmessage = "Change given:\n";
            for (int i = 0; i<coinTypes.Length; i++) {
                returnmessage += $"{coinsChange[coinTypes[i]]} {String.Format("{0:0.00}", coinTypes[i])} coins given\n";
            }
            returnmessage += "Total: " + String.Format("{0:0.00}", CoinTotal(coinsChange));
            return returnmessage;
            
        }
        private bool AllocateChange(Dictionary<string, int> coins) {
            List<string> keys = new List<string>(coins.Keys);
            foreach (var item in keys) {            
                Console.WriteLine(item);
                int value = coins[item];
                vending.ChangeVals[item] -= value;

            }
            //vending.ChangeVals = newChangeVals;
            return true;
        }
        public void AddSnack(Snack snack) {
            vending.SnacksForSale.Add(snack);
        }
    }
}
