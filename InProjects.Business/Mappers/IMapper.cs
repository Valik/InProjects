namespace InProjects.Business.Mappers
{
    public interface IMapper
    {
        TMap Map<TMap>(object source);
    }
}