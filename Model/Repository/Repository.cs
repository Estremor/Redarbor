
using System.Data.SqlClient;

namespace Model.Repository
{
    public abstract class Repository
    {
        protected SqlConnection _context { get; set; }
        protected SqlCommand command;
        protected SqlCommand CreateCommand(string query)
        {
            if (_context.State == System.Data.ConnectionState.Closed)
            {
                _context.Open();
            }
            command = new SqlCommand(query, _context);
            return command;
        }

        public void Close()
        {
            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }
            if (command != null)
            {
                command.Connection.Close();
                command.Dispose();
            }

        }
    }
}
