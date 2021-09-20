namespace h94type.API.Results
{
    public interface IDataResult<T>: IResult
    {
        T Data {get;}
    }
}