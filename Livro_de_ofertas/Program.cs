using System.Collections.Generic;
using System.Globalization;

namespace Livro_de_Ofertas 
{
class Program 
{
    static void Main()
    {
        string command = "12/n1,0,15.4,50/n2,0,15.5,50/n2,2,0,0/n2,0,15.4,10/n3,0,15.9,30/n3,1,0,20/n4,0,16.50,200/n5,0,17.00,100/n5,0,16.59,20/n6,2,0,0/n1,2,0,0/n2,1,15.6,0";
        List<string> number_commands = new List<string>(command.Split("/n"));
        string number = number_commands[0];
        List<string> commands = number_commands.GetRange(1,int.Parse(number));
        List<Offer> offers = new List<Offer>();
        foreach (string line in commands)
        {
            List<string> numbers = new List<string>(line.Split(","));
            Action action = new Action
            (
                int.Parse(numbers[0]),
                int.Parse(numbers[1]),
                double.Parse(numbers[2],CultureInfo.InvariantCulture),
                int.Parse(numbers[3])
            );

            switch (action.Type)
            {
                case 0:
                    if(action.Position == offers.Count + 1)
                    {
                        offers.Add(new Offer(action.Value,action.Quantity));
                    }
                    else if(action.Position <= offers.Count)
                    {
                        offers.Insert(action.Position - 1, new Offer(action.Value,action.Quantity));
                    }
                    else throw new Exception();
                    break;
                case 1:
                    if(action.Value > 0 && action.Quantity > 0)
                    {
                        Offer offer = offers.ElementAt(action.Position - 1);
                        offer.Quantity = action.Quantity;
                        offer.Value = action.Value;
                    }
                    else if(action.Value > 0)
                    {
                        Offer offer = offers.ElementAt(action.Position - 1);
                        offer.Value = action.Value;
                    }
                    else if(action.Quantity > 0)
                    {
                        Offer offer = offers.ElementAt(action.Position - 1);
                        offer.Quantity = action.Quantity;                        
                    }
                    else throw new Exception();
                    break;
                case 2:
                    offers.RemoveAt(action.Position - 1);
                    break;
                default:
                    throw new Exception();
            }
        }

        int i = 1;

        foreach (Offer offer in offers)
        {
            string sValue = offer.Value.ToString(CultureInfo.InvariantCulture);
            Console.WriteLine(i + "," + sValue + "," + offer.Quantity);
            i++;
        }
    }
}

class Action
{
    private int position;
    private int type;
    private double value;
    private int quantity;

    public int Position
    {
        get { return position; }
    }
    public int Type
    {
        get { return type; }
    }
    public double Value
    {
        get { return value; }
    }
    public int Quantity
    {
        get { return quantity; }
    }

    public Action(int position, int type, double value, int quantity)
    {
        this.position = position;
        this.type = type;
        this.value = value;
        this.quantity = quantity;
    }
}

class Offer
{
    private double value;
    private int quantity;

    public double Value
    {
        get { return value; }
        set { this.value = value;}
    }
    public int Quantity
    {
        get { return quantity;}
        set { quantity = value;}
    }

    public Offer(double value, int quantity)
    {
        this.value = value;
        this.quantity = quantity;
    }
}

}
