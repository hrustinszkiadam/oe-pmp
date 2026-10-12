namespace ZH01D;

class Program
{
    static void Main(string[] args)
    {
        // 1.
        List<int> TransactionIds = new List<int>();
        List<string> InvoiceNumbers = new List<string>();
        List<string> ItemCategories = new List<string>();
        List<int> Quantities = new List<int>();
        List<double> TotalAmounts = new List<double>();
        List<DateTime> Dates = new List<DateTime>();
        List<string> PaymentMethods = new List<string>();

        string[] salesLines = File.ReadAllLines("../../../assets/ABC_Clothing_Store_Sales_Data_reduced.csv");

        for (int i = 1; i < salesLines.Length; i++)
        {
            string[] parts = salesLines[i].Split(';');
            TransactionIds.Add(int.Parse(parts[0]));
            InvoiceNumbers.Add(parts[1]);
            ItemCategories.Add(parts[2]);
            Quantities.Add(int.Parse(parts[3]));
            TotalAmounts.Add(double.Parse(parts[4]));
            Dates.Add(DateTime.Parse(parts[5]));
            PaymentMethods.Add(parts[6].Replace(" ", ""));
        }

        // 2.
        Console.Write("Adj meg egy termékkategóriát: ");
        string category = Console.ReadLine();

        Console.WriteLine("A megadott termékkategóriába tartozó vásárlások:");
        for (int i = 0; i < TransactionIds.Count; i++)
        {
            if(ItemCategories[i].Equals(category, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine($"\tTransId: {TransactionIds[i]}, Mennyiség: {Quantities[i]}, Végösszeg: {TotalAmounts[i]}");
            }
        }

        // 3.
        double creditCardsum = 0, onlinePaymentSum = 0, debitCardSum = 0;

        for (int i = 0; i < TransactionIds.Count; i++)
        {
            switch (PaymentMethods[i])
            {
                case "CreditCard":
                    creditCardsum += TotalAmounts[i];
                    break;
                case "OnlinePayment":
                    onlinePaymentSum += TotalAmounts[i];
                    break;
                case "DebitCard":
                    debitCardSum += TotalAmounts[i];
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine($"CreditCard-dal fizetett eladások összértéke: {creditCardsum:F2}");
        Console.WriteLine($"OnlinePayment-tel fizetett eladások összértéke: {onlinePaymentSum:F2}");
        Console.WriteLine($"DebitCard-dal fizetett eladások összértéke: {debitCardSum:F2}");

        // 4.
        string itemCategory = "Shoes";
        int sumCategoryQuantity = 0, allCategoryTransactions = 0;

        for (int i = 0; i < TransactionIds.Count; i++)
        {
            if(ItemCategories[i] == itemCategory)
            {
                sumCategoryQuantity += Quantities[i];

                allCategoryTransactions++;
            }
        }

        double avgCategoryQuantityPerTransaction = (double) sumCategoryQuantity / allCategoryTransactions;

        Console.WriteLine($"A 'Shoes' termékkategóriához kapcsolódó eladások esetén átlagosan ennyit adtak el: {avgCategoryQuantityPerTransaction:F2}");

        // 5.
        StreamWriter writer = new StreamWriter("../../../magas_koltsegu_eladasok.txt");

        for (int i = 0; i < TransactionIds.Count; i++)
        {
            if(TotalAmounts[i] > 500)
            {
                writer.WriteLine($"{TransactionIds[i]}#{Dates[i]}#{TotalAmounts[i]}");
            }
        }

        writer.Close();


        Console.ReadLine();
    }
}
