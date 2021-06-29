using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.DataAccess.EntityFramework
{
    class SingletonContext<TContext> where TContext : DbContext, new()
    {
        private static TContext _context;

        private SingletonContext()
        {

        }
        internal static TContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new TContext();
                }
                return _context;
            }

        }
    }
}
