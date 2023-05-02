namespace mis_221_pa_5_mjdavis20
{
    public class Transaction
    {
        private int sessionID;
        private int trainerID;
        private string customerName;
        private string customerEmail;
        private string trainingDate;
        
        private string trainerName;
        private bool status;
        private double sessionCost;
        static private Transaction[] allTransactions;
        static private int count;
        public Transaction(){

        }
        public Transaction(int sessionID, string customerName, string customerEmail, string trainingDate, int trainerID, string trainerName, bool status, double sessionCost){
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
            this.sessionCost= sessionCost;
        }

        public void SetSessionID(int sessionID){
            this.sessionID = sessionID;
        }
        public int GetSessionID(){
            return this.sessionID;
        }
        public void SetCustomerName(string customerName){
            this.customerName = customerName;
        }
        public string GetCustomerName(){
            return this.customerName;
        }
        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }
        public string GetCustomerEmail(){
            return this.customerEmail;
        }
        public void SetTrainingDate(string trainingDate){
            this.trainingDate = trainingDate;
        }
        public string GetTrainingDate(){
            return this.trainingDate;
        }
        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }
        public int GetTrainerID(){
            return this.trainerID;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public string GetTrainerName(){
            return this.trainerName;
        }
        public void SetStatus(bool status){
            this.status = status;
        }
        public bool GetStatus(){
            return this.status;
        }
        static public void SetTransactions(Transaction[] allTransactions){
            Transaction.allTransactions = allTransactions;
        }
        static public Transaction[] GetTransactions(){
            return Transaction.allTransactions;
        }
        static public void SetCount(int count){
            Transaction.count = count;
        }
        static public int GetCount(){
            return Transaction.count;
        }
        public void SetSessionCost(double sessionCost){
            this.sessionCost = sessionCost;
        }
        public double GetSessionCost(){
            return this.sessionCost;
        }
        public override string ToString(){
            return $"{GetSessionID()} {GetCustomerName()} {GetCustomerEmail()} {GetTrainingDate()} {GetTrainerID()} {GetTrainerName()} {GetStatus()} {GetSessionCost()}";
        }
        public string ToFile(){
            return $"{GetSessionID()}#{GetCustomerName()}#{GetCustomerEmail()}#{GetTrainingDate()}#{GetTrainerID()}#{GetTrainerName()}#{GetStatus()}#{GetSessionCost()}";
        }
    }
}