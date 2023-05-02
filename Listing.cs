namespace mis_221_pa_5_mjdavis20
{
    public class Listing{
        private int listingID;
        private string trainerName;
        private string sessionDate;
        private string sessionTime;
        private double sessionCost;
        private bool isTaken;

        public Listing() { 
            
        }

        public Listing(int listingID, string trainerName, string sessionDate, string sessionTime, double sessionCost, bool isTaken)
        {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.sessionCost = sessionCost;
            this.isTaken = isTaken;
        }
        // getters and setters
        public int GetListingID(){
            return listingID;
        }
        public void SetListingID(int listingID){
            this.listingID = listingID;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public string GetSessionDate(){
            return sessionDate;
        }
        public void SetSessionDate(string sessionDate){
            this.sessionDate = sessionDate;
        }
        public string GetSessionTime(){
            return sessionTime;
        }
        public void SetSessionTime(string sessionTime){
            this.sessionTime = sessionTime;
        }
        public double GetSessionCost(){
            return sessionCost;
        }
        public void SetSessionCost(double sessionCost){
            this.sessionCost = sessionCost;
        }
        public bool GetIsTaken(){
            return isTaken;
        }
        public void SetIsTaken(bool isTaken){
            this.isTaken = isTaken;
        }
        public string ToFile(){
        return $"{listingID}#{trainerName}#{sessionDate}#{sessionTime}#{sessionCost}#{isTaken}";
        }
    }
}