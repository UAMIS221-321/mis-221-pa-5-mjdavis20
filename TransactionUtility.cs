namespace mis_221_pa_5_mjdavis20
{
    public class TransactionUtility
    {
        public static void WriteTransactions(Transaction [] myTransactions){
            StreamWriter wt = new StreamWriter("transactions.txt");
            for(int i = 0; i < myTransactions.Length; i++){
                wt.WriteLine(myTransactions[i].ToFile());
            }
            wt.Close();
       }
        public static Transaction[] ReadTransactions(){
            StreamReader rt = new StreamReader("transactions.txt");
            Transaction[] myTransactions = new Transaction[1000];
            int transactionCount = 0;

            string line = rt.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');

                myTransactions[transactionCount] = new Transaction(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], bool.Parse(temp[6]), double.Parse(temp[7]));
                transactionCount++;
                line = rt.ReadLine();
            }
            rt.Close();
            Transaction[] result = new Transaction[transactionCount];
            for (int i = 0; i < transactionCount; i++){
                result[i] = myTransactions[i];
            }

        return result;
        }
        public static Transaction[] GetAvailableSessions(){
            Transaction[] allTransactions = ReadTransactions();
            int availableSessionsCount = 0;

            for (int i = 0; i < allTransactions.Length; i++){
                if (!allTransactions[i].GetStatus()){
                    availableSessionsCount++;
                }
            }
            Transaction[] availableSessions = new Transaction[availableSessionsCount];
            int index = 0;
            for (int i = 0; i < allTransactions.Length; i++){
                if (!allTransactions[i].GetStatus()){
                    availableSessions[index] = allTransactions[i];
                    index++;
                }
            }

            return availableSessions;
        }
        public static void BookSession(int sessionID, string customerName, string customerEmail, string trainingDate, int trainerID, string trainerName, double sessionCost){
            Transaction[] allTransactions = ReadTransactions();
            Transaction[] updatedTransactions = new Transaction[allTransactions.Length + 1];
            for (int i = 0; i < allTransactions.Length; i++){
                updatedTransactions[i] = allTransactions[i];
            }

            Transaction newTransaction = new Transaction(sessionID, customerName, customerEmail, trainingDate, trainerID, trainerName, true, sessionCost);
            updatedTransactions[updatedTransactions.Length - 1] = newTransaction;

            WriteTransactions(updatedTransactions);
        }
        public static void CancelBooking(int sessionId){
            Transaction[] allTransactions = ReadTransactions();
            bool found = false;

            for (int i = 0; i < allTransactions.Length; i++){
                if (allTransactions[i].GetSessionID() == sessionId){
                    allTransactions[i].SetStatus(false);
                    found = true;
                    break;
                }
            }

            if (found){
                WriteTransactions(allTransactions);
                Console.WriteLine("\nBooking with session ID {0} has been canceled successfully.", sessionId);
            }
            else{
                Console.WriteLine("\nNo booking found with session ID {0}.", sessionId);
            }
        }
        public static void ManageCustomerBookingData(){
            // Show sub-menu for managing customer bookings
            int choice;
            do{
                Console.WriteLine("\nCustomer Booking Management Menu:");
                Console.WriteLine("1. Book a listing");
                Console.WriteLine("2. Cancel a booking");
                Console.WriteLine("3. Display all bookings");
                Console.WriteLine("4. Return to main menu");

                choice = int.Parse(Console.ReadLine());

                switch (choice){
                    case 1:
                        // Book a session
                        Console.WriteLine("\nEnter customer's name:");
                        string customerName = Console.ReadLine();
                        Console.WriteLine("\nEnter customer's email:");
                        string customerEmail = Console.ReadLine();
                        Console.WriteLine("\nEnter the session ID to book:");
                        int sessionId = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter training date (MM/dd/yyyy):");
                        string trainingDate = Console.ReadLine();
                        Console.WriteLine("\nEnter trainer's ID:");
                        int trainerId = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter trainer's name:");
                        string trainerName = Console.ReadLine();
                        System.Console.WriteLine("\nEnter the session cost:");
                        double sessionCost = double.Parse(Console.ReadLine());

                        TransactionUtility.BookSession(sessionId, customerName, customerEmail, trainingDate, trainerId, trainerName, sessionCost);
                        Console.WriteLine("\nBooking added successfully.");
                        break;

                    case 2:
                        // Cancel a booking
                        Console.WriteLine("\nEnter the session ID to cancel:");
                        int cancelSessionId = int.Parse(Console.ReadLine());

                        TransactionUtility.CancelBooking(cancelSessionId);
                        break;

                    case 3:
                        // Display all bookings
                        Transaction[] bookings = TransactionUtility.ReadTransactions();
                        Console.WriteLine("\nBooking List:");
                        foreach (Transaction booking in bookings){
                            Console.WriteLine($"{booking.GetSessionID()} - {booking.GetCustomerName()} - {booking.GetCustomerEmail()} - {booking.GetTrainingDate()} - {booking.GetTrainerID()} - {booking.GetTrainerName()} - {booking.GetStatus()} - {booking.GetSessionCost()}");
                        }
                        break;

                    case 4:
                        // Return to the main menu
                        Console.WriteLine("\nReturning to main menu...");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a valid number between 1 and 4.");
                        break;
                }
            } while (choice != 4);
        }
    }    
}