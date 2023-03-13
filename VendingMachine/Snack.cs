using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class Snack {
        public string SnackName { get; set; }
        public double SnackPrice { get; set; }
        public int SnackQuantity { get; set; }

        public Snack (string SnackName, double SnackPrice) {
            this.SnackName = SnackName;
            this.SnackPrice = SnackPrice;
            this.SnackQuantity = 0;
        }
        public Snack (string SnackName, double SnackPrice, int startingQuantity) {
            this.SnackName = SnackName;
            this.SnackPrice = SnackPrice;
            this.SnackQuantity = startingQuantity;
        }

        
        public override string ToString() {
            return String.Format("{0,-10} -- £{1,-5} -- {2,-5}", 
                this.SnackName, String.Format("{0:0.00}", this.SnackPrice), this.SnackQuantity);
        }


    }
}
