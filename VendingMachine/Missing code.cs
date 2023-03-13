//Change the snack prices
/*
//Within Machine:

    public string ChangeSnackPrice(int SnackNum, double NewPrice)
    {
        int SnackPos = SnackNum - 1;
        SnacksForSale[SnackPos].SnackPrice = NewPrice;

        Console.WriteLine(SnacksForSale[SnackPos] + " price changed to " + NewPrice);
    }

//Within Menu:

    case 1:

    //Reprint available snack info
    Console.WriteLine(String.Format("{0,-4}{1,-10} -- {2,-6} -- {3,-10}", "", "Snack", "Price", "QTY"));
    Console.WriteLine(this.controller.GetSnackData());

    //Snack number the user wants to change the price for
    Console.WriteLine("Please enter the number of the snack you wish to change the price for: > ");
    int sNum = Convert.ToInt32(Console.ReadLine());

    //New snack price
    Console.WriteLine("Please enter the new price: > ");
    double sPrice = Math.Round(Console.ReadLine(), 2);

    //Invoke ChangeSnackPrice method from Machine class
    machine.ChangeSnackPrice(sNum, sPrice);

    break;


//See the total amount of money presently in the machine

//Within Menu:

    case 3:

    //Invoke GetTotalChange method from Machine class
    Console.WriteLine("The total amount of money in the machine is: " + machine.GetTotalChange());

    break;





//NOTES:

/*
//Inside Machine... call this code
public double GetTotalChange()
{
    double total = 0;
    foreach (var item in this.ChangeVals)
    {
        total += Convert.ToDouble(item.Key) * item.Value;
    }
    return total;

public List<Snack> SnacksForSale { get; set; } //List of objects of snacks

//Snack Constructor
public Snack (string SnackName, double SnackPrice)
{
    this.SnackName = SnackName;
    this.SnackPrice = SnackPrice;
    this.SnackQuantity = 0;
}
*/