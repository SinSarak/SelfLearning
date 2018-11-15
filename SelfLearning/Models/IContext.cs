using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SelfLearning.Models
{
    public interface IContext
    {
        IDbSet<Student> Students { get; set; }
        IDbSet<Subject> Subjects { get; set; }
        IDbSet<RegisterTicket> RegisterTickets { get; set; }
        IDbSet<Ticket> Tickets { get; set; }
        IDbSet<DepartmentTrack> DepartmentTracks { get; set; }
        IDbSet<DepartmentTicket> DepartmentTickets { get; set; }
        int SaveChanges();
    }
    public class DataContext : DbContext, IContext
    {
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Subject> Subjects { get; set; }
        public IDbSet<RegisterTicket> RegisterTickets { get; set; }
        public IDbSet<Ticket> Tickets { get; set; }
        public IDbSet<DepartmentTrack> DepartmentTracks { get; set; }
        public IDbSet<DepartmentTicket> DepartmentTickets { get; set; }

        public DataContext() : base("name=learning") { }
        public DataContext(string connectionString): base(connectionString){}
    }

    public interface IAsyncDbSet<T> : IDbSet<T>
    where T : class
    {
        Task<T> FindAsync(params Object[] keyValues);
    }
}