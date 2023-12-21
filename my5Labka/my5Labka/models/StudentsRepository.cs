using my5Labka.models;
using System;
using System.Collections.Generic;
//using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace my5Labka.models
{
    public class StudentsRepository : IRepository<Student>
    {
        private SqlConnection Connection { get; set; }

        public StudentsRepository(SqlConnection _connection)
        {
            this.Connection = _connection;
        }

        
    }
}