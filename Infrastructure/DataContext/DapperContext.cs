using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Infrastructure.DataContext
{
    public class DapperContext
    { 
        private readonly string _connectionString=
             $"Server=localhost;port=5432;database=APISimpleCrudDB;User Id=postgres;password=909662643;"; 
        public NpgsqlConnection Connection()
        {
            return new NpgsqlConnection(_connectionString);
        }

    }
}
