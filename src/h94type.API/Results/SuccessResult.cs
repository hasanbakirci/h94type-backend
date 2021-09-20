namespace h94type.API.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool success, string message) : base(true, message)
        {
        }
        public SuccessResult():base(true)
        {
            
        }
    }
}