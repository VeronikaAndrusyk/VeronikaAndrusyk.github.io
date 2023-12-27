using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my5Labka.models
{
    public interface IRepository<T>
    {

        IQueryable<T> GetAll();
    }
}
