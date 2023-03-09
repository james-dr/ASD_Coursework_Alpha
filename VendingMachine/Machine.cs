using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class Machine {
        public Dictionary<string, int> ChangeVals { get; set; }
        public List<Snack> SnacksForSale { get; set; }
        public Machine() {
            this.SnacksForSale = new List<Snack>();
            this.ChangeVals = new Dictionary<string, int>() {
                {"2", 2 },
                {"1", 3 },
                {"0.5", 4 },
                {"0.2", 5 },
                {"0.1", 10 },
                {"0.05", 20 }
            };
        }
        public Machine(Dictionary<string, int> changeVals) {
            this.ChangeVals = changeVals;
            this.SnacksForSale = new List<Snack>();
        }
        public Machine(Dictionary<string, int> changeVals, List<Snack> snacks) {
            this.ChangeVals = changeVals;
            this.SnacksForSale = snacks;
        }
        public double GetTotalChange() {
            double total = 0;
            foreach (var item in this.ChangeVals) {
                total += Convert.ToDouble(item.Key) * item.Value;
            }
            return total;
        }
    }
}
