using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Models;

namespace UserManagementAPI.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<User>().HasData(
        //        new User
        //        {
        //            TCKN = "12345678912",
        //            Name = "Mert",
        //            Surname = "OĞUZ",
        //            Address = "mertoguz Adresi",
        //            LastModifiedDate = DateTime.Now,
        //            Birthday = Convert.ToDateTime("08/12/1995"),
        //            CreateTime = DateTime.Now,

        //        },
        //        new User
        //        {
        //            TCKN = "12345678913",
        //            Name = "123Mert",
        //            Surname = "OĞUZ",
        //            Address = "1234mertoguz Adresi",
        //            LastModifiedDate = DateTime.Now,
        //            Birthday = Convert.ToDateTime("09/12/1995"),
        //            CreateTime = DateTime.Now,
        //        }
        //        );
        //}

        public DbSet<User> Users { get; set; }
    }
}
