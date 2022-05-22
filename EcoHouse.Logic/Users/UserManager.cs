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
    public async Task Create(string name, string Lastname, string email, string phone, string login, string password)
    {
        var user = new User { Name = name, LastName = Lastname, Email = email, Phone = phone, Login = login, Password = password};

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

    public User CheckPassAndLog(string email, string pass)
    {
        var user = _context.Users.FirstOrDefault(g => g.Email == email && g.Password == pass);
        
        if (user != null)
        {
            return user;
            //object p =  _context.Entry(user.Password);
            //return (Task<object>)p;
        }
        else
            return null;
        //await _context.SaveChangesAsync();

    }



    public async Task RePassword(string newPassword, int Id)
    {
        var user = _context.Users.FirstOrDefault(g => g.Id == Id);

        user.Password = newPassword;

        await _context.SaveChangesAsync();
    }
}
