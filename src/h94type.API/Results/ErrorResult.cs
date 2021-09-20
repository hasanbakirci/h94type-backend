namespace h94type.API.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool success, string message) : base(false, message)
        {
        }
        public ErrorResult():base(false)
        {
            
        }
    }
}