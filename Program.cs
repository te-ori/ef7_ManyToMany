using M2m;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var ctx = new EfContext();

        var users = ctx.Users.Include(u => u.Roles).ToList();

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id} {user.Name}");
            Console.WriteLine("Roles:");
            foreach (var role in user.Roles)
            {
                Console.WriteLine($"{role.Id} {role.Name}");
            }
        }
    }
}