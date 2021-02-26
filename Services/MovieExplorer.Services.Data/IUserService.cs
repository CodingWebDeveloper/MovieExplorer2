using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface IUserService
    {
        Task AddToUser(int id);
    }
}
