// See https://aka.ms/new-console-template for more information
using System.Linq;
public interface ICashier
{
    double sum(int[] numbers);
}

public interface ITaxable
{
    double TAXDATBITCH(ICashier cashier);
}

public class Cashier : ICashier
{
    public double sum(int[] numbers)
    {
        return numbers.Sum();
    }
}

public class SeniorCashier : ICashier
{
    public double sum(int[] numbers)
    {
        return numbers.Sum(x => x / 2);
    }
}

public class Tax : ITaxable
{
    public double TAXDATBITCH(ICashier cashier)
    {
        double sum = cashier.sum([9, 25, 30, 2, 5]);
        return sum + (sum * .12);
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        Cashier cashier = new Cashier();
        var lola = new SeniorCashier();
        var taxable = new Tax();

        int[] numArr = [9, 25, 30, 2, 5];

        Console.WriteLine(cashier.sum(numArr));
        Console.WriteLine(lola.sum(numArr));
        Console.WriteLine(taxable.TAXDATBITCH(cashier));
        Console.WriteLine(taxable.TAXDATBITCH(lola));
    }
}
