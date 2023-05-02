namespace mis_221_pa_5_mjdavis20
{
    public class TrainerUtility
    {
        public static void AddTrainer(Trainer trainer){
            Trainer[] trainers = GetTrainers();
            Trainer[] newTrainers = new Trainer[trainers.Length + 1];
            for (int i = 0; i < trainers.Length; i++){
                newTrainers[i] = trainers[i];
            }
            newTrainers[newTrainers.Length - 1] = trainer;
            SaveTrainers(newTrainers);
        }

        public static void EditTrainer(int trainerId, Trainer updatedTrainer){
            Trainer[] trainers = GetTrainers();
            for (int i = 0; i < trainers.Length; i++){
                if (trainers[i].GetTrainerID() == trainerId){
                    trainers[i] = updatedTrainer;
                    break;
                }
            }
            SaveTrainers(trainers);
        }

        public static void DeleteTrainer(int trainerId){
            Trainer[] trainers = GetTrainers();
            Trainer[] newTrainers = new Trainer[trainers.Length - 1];
            int index = 0;

            for (int i = 0; i < trainers.Length; i++)
            {
                if (trainers[i].GetTrainerID() != trainerId)
                {
                    newTrainers[index] = trainers[i];
                    index++;
                }
            }
            SaveTrainers(newTrainers);
        }

        public static Trainer[] GetTrainers(){
            StreamReader rt = new StreamReader("trainers.txt");
            Trainer[] trainers = new Trainer[1000];
            int trainerCount = 0;

            string line = rt.ReadLine();
            while (line != null){
                string[] temp = line.Split('#');

                trainers[trainerCount] = new Trainer(int.Parse(temp[0]),temp[1],temp[2],temp[3]);
                trainerCount++;
                line = rt.ReadLine();
            }
            rt.Close();
            Array.Resize(ref trainers, trainerCount);
            return trainers;
        }

        public static void SaveTrainers(Trainer[] trainers){
            StreamWriter wt = new StreamWriter("trainers.txt");
            for (int i = 0; i < trainers.Length; i++){
                wt.WriteLine($"{trainers[i].GetTrainerID()}#{trainers[i].GetTrainerName()}#{trainers[i].GetTrainerAddress()}#{trainers[i].GetTrainerEmail()}");
            }
            wt.Close();
        }
        public static void ManageTrainerData() {
            int choice;
            do{
                Console.WriteLine("\nTrainer Management Menu:");
                Console.WriteLine("1. Add a trainer");
                Console.WriteLine("2. Edit a trainer");
                Console.WriteLine("3. Delete a trainer");
                Console.WriteLine("4. Display all trainers");
                Console.WriteLine("5. Return to main menu");

                choice = int.Parse(Console.ReadLine());

                switch (choice){
                    case 1:
                        // Add a trainer
                        Console.WriteLine("\nEnter trainer's name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("\nEnter trainer's address:");
                        string address = Console.ReadLine();
                        Console.WriteLine("\nEnter trainer's email:");
                        string email = Console.ReadLine();

                        Trainer newTrainer = new Trainer(name, address, email); // Assuming the Trainer class assigns a unique ID
                        AddTrainer(newTrainer);
                        Console.WriteLine("\nTrainer added successfully.");
                        break;

                    case 2:
                        // Edit a trainer
                        Console.WriteLine("\nEnter the trainer ID to edit:");
                        int trainerId = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the new trainer's name:");
                        string newName = Console.ReadLine();
                        Console.WriteLine("\nEnter the new trainer's address:");
                        string newAddress = Console.ReadLine();
                        Console.WriteLine("\nEnter the new trainer's email:");
                        string newEmail = Console.ReadLine();

                        Trainer updatedTrainer = new Trainer(trainerId, newName, newAddress, newEmail);
                        EditTrainer(trainerId, updatedTrainer);
                        Console.WriteLine("\nTrainer updated successfully.");
                        break;

                    case 3:
                        // Delete a trainer
                        Console.WriteLine("\nEnter the trainer ID to delete:");
                        int deleteTrainerId = int.Parse(Console.ReadLine());
                        DeleteTrainer(deleteTrainerId);
                        Console.WriteLine("\nTrainer deleted successfully.");
                        break;

                    case 4:
                        // Display all trainers
                        Trainer[] trainers = GetTrainers();
                        Console.WriteLine("\nTrainer List:");
                        foreach (Trainer trainer in trainers){
                            Console.WriteLine($"{trainer.GetTrainerID()} - {trainer.GetTrainerName()} - {trainer.GetTrainerAddress()} - {trainer.GetTrainerEmail()}");
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