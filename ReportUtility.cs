namespace mis_221_pa_5_mjdavis20
{
    public class ReportUtility
    {
        public static void IndividualCustomerSessions(Transaction[] transactions, string customerEmail){
            Console.WriteLine("Individual Customer Sessions");
            Console.WriteLine("----------------------------");
            Console.WriteLine("SessionID | Customer Name | Customer Email | Training Date | Trainer ID | Trainer Name | Status");

            int customerSessionCount = 0;
            for (int i = 0; i < transactions.Length; i++){
                if (transactions[i].GetCustomerEmail() == customerEmail){
                    Transaction transaction = transactions[i];
                    Console.WriteLine($"{transaction.GetSessionID()} | {transaction.GetCustomerName()} | {transaction.GetCustomerEmail()} | {transaction.GetTrainingDate()} | {transaction.GetTrainerID()} | {transaction.GetTrainerName()} | {transaction.GetStatus()}");
                    customerSessionCount++;
                }
            }
            if (customerSessionCount == 0){
                    Console.WriteLine("No sessions found for this customer.");
                }else{
                    Console.WriteLine($"Total sessions for customer with email {customerEmail}: {customerSessionCount}");
                }
        }
        public static void HistoricalCustomerSessions(Transaction[] transactions){
            for (int i = 0; i < transactions.Length - 1; i++){
                for (int j = 0; j < transactions.Length - 1 - i; j++)
                {
                    int comparisonResult = string.Compare(transactions[j].GetCustomerName(), transactions[j + 1].GetCustomerName());
                    if (comparisonResult > 0 || (comparisonResult == 0 && DateTime.Parse(transactions[j].GetTrainingDate()) > DateTime.Parse(transactions[j + 1].GetTrainingDate())))
                    {
                        Transaction temp = transactions[j];
                        transactions[j] = transactions[j + 1];
                        transactions[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Historical Customer Sessions");
            Console.WriteLine("----------------------------");
            Console.WriteLine("SessionID | Customer Name | Customer Email | Training Date | Trainer ID | Trainer Name | Status");

            string previousCustomer = null;
            int sessionCount = 0;
            foreach (Transaction transaction in transactions){
                if (previousCustomer != null && previousCustomer != transaction.GetCustomerName()){
                    Console.WriteLine($"Total sessions for {previousCustomer}: {sessionCount}");
                    sessionCount = 0;
                }
                previousCustomer = transaction.GetCustomerName();
                sessionCount++;

                Console.WriteLine($"{transaction.GetSessionID()} | {transaction.GetCustomerName()} | {transaction.GetCustomerEmail()} | {transaction.GetTrainingDate()} | {transaction.GetTrainerID()} | {transaction.GetTrainerName()} | {transaction.GetStatus()}");
            }
            if (previousCustomer != null){
                Console.WriteLine($"Total sessions for {previousCustomer}: {sessionCount}");
            }
        }
        public static double[] MonthlyRevenue(Transaction[] transactions){
            double[] monthlyRevenue = new double[12];

            for (int i = 0; i < transactions.Length; i++){
                if (transactions[i].GetStatus()){ // Only count completed sessions
                    DateTime trainingDate = DateTime.Parse(transactions[i].GetTrainingDate());
                    int monthIndex = trainingDate.Month - 1;
                    double sessionPrice = transactions[i].GetSessionCost(); 
                    monthlyRevenue[monthIndex] += sessionPrice;
                }
            }

            return monthlyRevenue;
        }

        public static double YearlyRevenue(Transaction[] transactions){
            double[] monthlyRevenue = MonthlyRevenue(transactions);
            double yearlyRevenue = 0;

            for (int i = 0; i < 12; i++){
                yearlyRevenue += monthlyRevenue[i];
            }

            return yearlyRevenue;
        }
        public static void RunReports(){
            while (true){
                Console.WriteLine("\nReports Menu");
                Console.WriteLine("1. Display individual customer sessions");
                Console.WriteLine("2. Display all historical bookings");
                Console.WriteLine("3. Display income report");
                Console.WriteLine("4. Return to main menu");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                Transaction[] allTransactions = TransactionUtility.ReadTransactions();

                switch (choice)
                {
                    case 1:
                    System.Console.WriteLine("Enter the email that you would like to search for:");
                    string customerEmail = Console.ReadLine();
                        IndividualCustomerSessions(allTransactions, customerEmail);
                        break;
                    case 2:
                        HistoricalCustomerSessions(allTransactions);
                        break;
                    case 3:
                        DisplayIncomeReport(allTransactions);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        public static void DisplayIncomeReport(Transaction[] transactions){
            double[] monthlyRevenue = MonthlyRevenue(transactions);
            double yearlyRevenue = YearlyRevenue(transactions);

            Console.WriteLine("\nIncome Report");
            Console.WriteLine("Month\tRevenue");
            for (int i = 0; i < 12; i++){
                Console.WriteLine("{0}\t{1}", (i + 1), monthlyRevenue[i].ToString("C"));
            }
            Console.WriteLine("\nYearly Revenue: {0}", yearlyRevenue.ToString("C"));
        }

    }
}