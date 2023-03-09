using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class Transaction {
        public double TotalPaid { get; set; }
        public double InitialPrice { get; set; }
        public double ToBePaid { get; set; }
        public double Change { get; }

        public Transaction(double initial) { 
            this.InitialPrice = initial;
            this.TotalPaid = 0;
            this.ToBePaid = this.InitialPrice - this.TotalPaid;
            this.Change = this.ToBePaid * -1;
        }

    }
}
