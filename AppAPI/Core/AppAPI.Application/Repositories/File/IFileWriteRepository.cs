using File = AppAPI.Domain.Entities;


namespace AppAPI.Application.Repositories
{
    public interface IFileWriteRepository : IWriteRepository<File::File>
    {
    }
}
