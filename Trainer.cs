namespace mis_221_pa_5_mjdavis20
{
    public class Trainer
    {
        private int trainerID;
        private string trainerName;
        private string trainerAddress;
        private string trainerEmail;
        private static int nextTrainerID = 1;
        private static Trainer[] trainers;

        public Trainer(){

        }

        public Trainer(string trainerName, string trainerAddress, string trainerEmail){
            this.trainerID = nextTrainerID;
            nextTrainerID++;
            this.trainerName = trainerName;
            this.trainerAddress = trainerAddress;
            this.trainerEmail = trainerEmail;
        }
        public Trainer(int trainerID, string trainerName, string trainerAddress, string trainerEmail){
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.trainerAddress = trainerAddress;
            this.trainerEmail = trainerEmail;

            // Update the nextTrainerID if the current trainerID is greater or equal
            if (trainerID >= nextTrainerID){
                nextTrainerID = trainerID + 1;
            }
        }

        public int GetTrainerID(){
            return trainerID;
        }
        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public string GetTrainerAddress(){
            return trainerAddress;
        }
        public void SetTrainerAddress(string trainerAddress){
            this.trainerAddress = trainerAddress;
        }
        public string GetTrainerEmail(){
            return trainerEmail;
        }
        public void SetTrainerEmail(string trainerEmail){
            this.trainerEmail = trainerEmail;
        }
        
        public static void SetTrainers(Trainer[] trainers){
            Trainer.trainers = trainers;
        }
        public static Trainer[] GetTrainers(){
            return Trainer.trainers;
        }

    }
}