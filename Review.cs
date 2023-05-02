namespace mis_221_pa_5_mjdavis20
{
    public class Review
    {
    public int Id;
    public int TrainerId;
    public int CustomerId;
    public string CustomerName;
    public double Rating;
    public string Comment;

    public Review(int id, int trainerId, int customerId, string customerName, double rating, string comment){
        Id = id;
        TrainerId = trainerId;
        CustomerId = customerId;
        CustomerName = customerName;
        Rating = rating;
        Comment = comment;
    }
    public int GetId(){
        return Id;
    }
    public void SetId(int Id){
        this.Id = Id;
    }
    public int GetTrainerId(){
        return TrainerId;
    }
    public void SetTrainerId(int trainerId){
        TrainerId = trainerId;
    }
    public int GetCustomerId(){
        return CustomerId;
    }
    public void SetCustomerId(int customerId){
        CustomerId = customerId;
    }
    public string GetCustomerName(){
        return CustomerName;
    }
    public void SetCustomerName(string customerName){
        CustomerName = customerName;
    }
    public double GetRating(){
        return Rating;
    }
    public void SetRating(double rating){
        Rating = rating;
    }
    public string GetComment(){
        return Comment;
    }
    public void SetComment(string comment){
        Comment = comment;
    }
    public string ToFile(){
        return $"{Id}#{TrainerId}#{CustomerId}#{CustomerName}#{Rating}#{Comment}";
    }



    }
}