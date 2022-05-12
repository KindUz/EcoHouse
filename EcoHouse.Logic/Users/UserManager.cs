using EcoHouse.Storage;

namespace EcoHouse.Logic.Users;
public class UserManager : IUserManager
{
    private readonly UniversityContext _context;

    public UserManager(UniversityContext context)
    {
        _context = context;
    }
    public async Task<IList<User>> GetAll() => await _context.Users.ToListAsync();

    public async Task Create(string name)
    {
        var user = new User { Name = name};

        _context.Users.Add(user);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int ID)
    {
        var user = _context.Users.FirstOrDefault(g => g.Id == ID);

        if (user != null)
        {
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
