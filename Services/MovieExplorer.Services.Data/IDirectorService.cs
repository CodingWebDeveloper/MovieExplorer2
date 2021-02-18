using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Services.Data
{
    public interface IDirectorService
    {
        void CreateDirector(string firstName, string lastName);
    }
}
