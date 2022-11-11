using File= AppAPI.Domain.Entities;
//namespace costumizing


namespace AppAPI.Application.Repositories
{
    public interface IFileReadRepository : IReadRepository<File::File>
    {
    }
}
