using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data.Seeds
{
    public static class UserSeeder
    {
        public static void SeedUser(this ModelBuilder modelBuilder){
            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "Admin",
                    Email = "admin@admin.com",
                    Password = "$%&/(=PŠČŽĐ?)(=?)=(T%RWSR"
                },
                new User
                {
                    Id = 2,
                    UserName = "Biggie",
                    Email = "biggie@smalls.com",
                    Password = "%EEASTZFGOJOBVTZE%$#&/=("
                },
                new User
                {
                    Id = 3,
                    UserName = "BrankoKos",
                    Email = "brk@os.com",
                    Password = "E$%#&/%&)=OHFD%/ER()/())PN"
                }
            );
        }
    }
}