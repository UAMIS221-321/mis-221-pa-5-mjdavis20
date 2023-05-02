using mis_221_pa_5_mjdavis20;

TrainerUtility.GetTrainers();
ListingUtility.ReadListings();
TransactionUtility.ReadTransactions();
int choice;
do{
    System.Console.WriteLine("Please choose what you would like to do:\n1. Manage Trainer data\n2. Manage Listing data\n3. Manage customer booking data\n4. Run Reports\n5. Leave a review\n6. Exit the application");

    try{
        choice = int.Parse(Console.ReadLine());
    }
    catch(FormatException){
        System.Console.WriteLine("Invalid Input. Please enter a valid number between 1 and 6.");
        choice = 0;
    }

    switch(choice){
        case 1:
            // manage trainer data
            TrainerUtility.ManageTrainerData();
            break;
        case 2:
            // manage listing data
            ListingUtility.ManageListingData();
            break;
        case 3:
            // manage customer booking data
            TransactionUtility.ManageCustomerBookingData();
            break;
        case 4:
            // run reports
            ReportUtility.RunReports();
            break;
        case 5:
            // leave a review
            ReviewUtility.ManageReviewData();
            break;
        case 6:
            // exit the application
            System.Console.WriteLine("Exiting Application... \nThank you for using the Train Like A Champion - Personal Fitness App");
            break;
        default:
            break;
    }
}
while(choice != 6);