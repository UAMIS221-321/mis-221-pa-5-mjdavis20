namespace mis_221_pa_5_mjdavis20
{
    public class ReviewUtility
    {
        public static void WriteReviews(Review[] reviews){
        StreamWriter writer = new StreamWriter("reviews.txt");
        for (int i = 0; i < reviews.Length; i++){
            writer.WriteLine(reviews[i].ToFile());
        }
        writer.Close();
    }

        public static Review[] ReadReviews(){
            StreamReader reader = new StreamReader("reviews.txt");
            Review[] reviews = new Review[1000];
            int reviewCount = 0;

            string line = reader.ReadLine();
            while (line != null){
                string[] temp = line.Split('#');
                reviews[reviewCount] = new Review(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), temp[3], double.Parse(temp[4]), temp[5]);
                reviewCount++;
                line = reader.ReadLine();
            }
            reader.Close();

            Review[] result = new Review[reviewCount];
            for (int i = 0; i < reviewCount; i++){
                result[i] = reviews[i];
            }

            return result;
        }

        public static void AddReview(int trainerId, int customerId, string customerName, double rating, string comment){
            Review[] allReviews = ReadReviews();
            // Find the highest ID among the existing reviews
            int highestId = 0;
            for (int i = 0; i < allReviews.Length; i++){
                if (allReviews[i].GetId() > highestId){
                    highestId = allReviews[i].GetId();
                }
            }
            // Calculate the next available review ID
            int nextReviewId = highestId + 1;
            // Create the new Review object with the correct ID
            Review newReview = new Review(nextReviewId, trainerId, customerId, customerName, rating, comment);
            // Add the new review to the array of all reviews
            Review[] updatedReviews = new Review[allReviews.Length + 1];
            for (int i = 0; i < allReviews.Length; i++){
                updatedReviews[i] = allReviews[i];
            }
            updatedReviews[updatedReviews.Length - 1] = newReview;
            // Save the updated array of reviews to the file
            WriteReviews(updatedReviews);
        }

        public static Review[] GetReviewsByTrainerId(int trainerId){
            Review[] allReviews = ReadReviews();
            List<Review> trainerReviews = new List<Review>();

            for (int i = 0; i < allReviews.Length; i++){
                if (allReviews[i].TrainerId == trainerId){
                    trainerReviews.Add(allReviews[i]);
                }
            }
            return trainerReviews.ToArray();
        }

        public static double GetAverageRatingByTrainerId(int trainerId){
            Review[] trainerReviews = GetReviewsByTrainerId(trainerId);

            if (trainerReviews.Length == 0) return 0;

            double totalRating = 0;
            for (int i = 0; i < trainerReviews.Length; i++){
                totalRating += trainerReviews[i].Rating;
            }
            return totalRating / trainerReviews.Length;
        }
        public static void ManageReviewData(){
            int choice;
            do{
                System.Console.WriteLine("Please choose what you would like to do:\n1. Add a review\n2. View trainer reviews\n3. Go back to the main menu");
                try{
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException){
                    System.Console.WriteLine("Invalid Input. Please enter a valid number between 1 and 3.");
                    choice = 0;
                }

                switch (choice){
                    case 1:
                        // Add a review
                        System.Console.WriteLine("Enter the trainer ID:");
                        int trainerId = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Enter the customer ID:");
                        int customerId = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Enter the customer name:");
                        string customerName = Console.ReadLine();
                        System.Console.WriteLine("Enter the rating (1-5):");
                        double rating = double.Parse(Console.ReadLine());
                        System.Console.WriteLine("Enter your review comment:");
                        string comment = Console.ReadLine();

                        ReviewUtility.AddReview(trainerId, customerId, customerName, rating, comment);
                        System.Console.WriteLine("Review added successfully.");
                        break;
                    case 2:
                        // View trainer reviews
                        System.Console.WriteLine("Enter the trainer ID:");
                        int viewTrainerId = int.Parse(Console.ReadLine());
                        Review[] trainerReviews = GetReviewsByTrainerId(viewTrainerId);
                        double averageRating = GetAverageRatingByTrainerId(viewTrainerId);

                        System.Console.WriteLine("Reviews:");
                        System.Console.WriteLine($"Average Rating: {averageRating}");
                        foreach (Review review in trainerReviews){
                            System.Console.WriteLine($"{review.CustomerName}: {review.Rating} - {review.Comment}");
                        }
                        break;
                    case 3:
                        // Go back to the main menu
                        System.Console.WriteLine("Returning to the main menu...");
                        break;
                    default:
                        break;
                }
            }
            while (choice != 3);
        }
    }
}