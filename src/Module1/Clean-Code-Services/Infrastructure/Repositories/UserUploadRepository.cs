using Clean_Code_Services.Core.Entities.Video;
using Clean_Code_Services.Infrastructure.Contexts;

namespace BooksApi.Infrastructure.Repositories
{
    public class UserUploadRepository(AppDbContext context) : GenericRepository<VideoUpload>(context), IUserUploadRepository
    {

    }
}

