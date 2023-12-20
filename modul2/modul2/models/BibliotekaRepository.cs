using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace modul2.models
{
    public class BibliotekaRepository : IRepository<Biblioteka1>
    {
        private SqlConnection Connection { get; set; }

        public BibliotekaRepository(SqlConnection _connection)
        {
            this.Connection = _connection;
        }


    }
}
