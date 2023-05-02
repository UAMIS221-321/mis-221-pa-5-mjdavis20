namespace mis_221_pa_5_mjdavis20
{
    public class ListingUtility
    {
        public static void SaveListings(Listing[] listings){
            StreamWriter wt = new StreamWriter("listings.txt");
            for (int i = 0; i < listings.Length; i++){
                wt.WriteLine(listings[i].ToFile());
            }
            wt.Close();
        }

        public static Listing[] ReadListings(){
            StreamReader rt = new StreamReader("listings.txt");
            Listing[] listings = new Listing[1000];
            int listingCount = 0;

            string line = rt.ReadLine();
            while (line != null){
                string[] temp = line.Split('#');
                listings[listingCount] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], double.Parse(temp[4]), bool.Parse(temp[5]));
                listingCount++;
                line = rt.ReadLine();
            }
            rt.Close();
            Listing[] result = new Listing[listingCount];
            for (int i = 0; i < listingCount; i++){
                result[i] = listings[i];
            }
            return result;
        } 
        public static void AddListing(Listing listing){
            Listing[] listings = ReadListings();
            int nextListingID = 1;
            for (int i = 0; i < listings.Length; i++){
                if (listings[i].GetListingID() >= nextListingID){
                    nextListingID = listings[i].GetListingID() + 1;
                }
            }

            listing.SetListingID(nextListingID);
            Listing[] newListings = new Listing[listings.Length + 1];
            for (int i = 0; i < listings.Length; i++){
                newListings[i] = listings[i];
            }
            newListings[newListings.Length - 1] = listing;
            SaveListings(newListings);
        }
        public static Listing[] EditListing(Listing[] listings, int listingID, string trainerName, string sessionDate, string sessionTime, double sessionCost, bool isTaken){
            for (int i = 0; i < listings.Length; i++){
                if (listings[i] != null && listings[i].GetListingID() == listingID){
                    listings[i].SetTrainerName(trainerName);
                    listings[i].SetSessionDate(sessionDate);
                    listings[i].SetSessionTime(sessionTime);
                    listings[i].SetSessionCost(sessionCost);
                    listings[i].SetIsTaken(isTaken);
                    break;
                }
            }
            return listings;
        }

        public static Listing[] DeleteListing(Listing[] listings, int listingID){
            for (int i = 0; i < listings.Length; i++){
                if (listings[i] != null && listings[i].GetListingID() == listingID){
                    listings[i] = null;
                    break;
                }
            }
            return listings;
        }
        public static void ManageListingData(){
            // Show sub-menu for managing listings
            int choice;
            do{
                Console.WriteLine("\nListing Management Menu:");
                Console.WriteLine("1. Add a listing");
                Console.WriteLine("2. Edit a listing");
                Console.WriteLine("3. Delete a listing");
                Console.WriteLine("4. Display all listings");
                Console.WriteLine("5. Return to main menu");

                choice = int.Parse(Console.ReadLine());

                switch (choice){
                    case 1:
                        // Add a listing
                        Console.WriteLine("\nEnter the trainer's name:");
                        string trainerName = Console.ReadLine();
                        Console.WriteLine("\nEnter the session date (MM/dd/yyyy):");
                        string sessionDate = Console.ReadLine();
                        Console.WriteLine("\nEnter the session time:");
                        string sessionTime = Console.ReadLine();
                        Console.WriteLine("\nEnter the session cost:");
                        double sessionCost = double.Parse(Console.ReadLine());

                        Listing newListing = new Listing(0, trainerName, sessionDate, sessionTime, sessionCost, false);
                        AddListing(newListing);
                        Console.WriteLine("\nListing added successfully.");
                        break;

                    case 2:
                        // Edit a listing
                        Console.WriteLine("\nEnter the listing ID to edit:");
                        int listingId = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the new trainer's name:");
                        string newTrainerName = Console.ReadLine();
                        Console.WriteLine("\nEnter the new session date (MM/dd/yyyy):");
                        string newSessionDate = Console.ReadLine();
                        Console.WriteLine("\nEnter the new session time:");
                        string newSessionTime = Console.ReadLine();
                        Console.WriteLine("\nEnter the new session cost:");
                        double newSessionCost = double.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the session's taken status (true or false):");
                        bool isTaken = bool.Parse(Console.ReadLine());

                        Listing[] listings = ReadListings();
                        EditListing(listings, listingId, newTrainerName, newSessionDate, newSessionTime, newSessionCost, isTaken);
                        SaveListings(listings);
                        Console.WriteLine("\nListing updated successfully.");
                        break;

                    case 3:
                        // Delete a listing
                        Console.WriteLine("\nEnter the listing ID to delete:");
                        int deleteListingId = int.Parse(Console.ReadLine());
                        Listing[] listingsToDelete = ReadListings();
                        DeleteListing(listingsToDelete, deleteListingId);
                        SaveListings(listingsToDelete);
                        Console.WriteLine("\nListing deleted successfully.");
                        break;

                    case 4:
                        // Display all listings
                        Listing[] allListings = ReadListings();
                        Console.WriteLine("\nListing List:");
                        foreach (Listing listing in allListings)
                        {
                            Console.WriteLine($"{listing.GetListingID()} - {listing.GetTrainerName()} - {listing.GetSessionDate()} - {listing.GetSessionTime()} - ${listing.GetSessionCost():0.00} - {listing.GetIsTaken()}");
                        }
                        break;

                    case 5:
                        // Return to the main menu
                        Console.WriteLine("\nReturning to main menu...");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a valid number between 1 and 5.");
                        break;
                }
            } while (choice != 5);
        }

    }
}