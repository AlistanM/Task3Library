using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Task3Library.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task3Library.Tests
{
    public abstract class TestsBase
    {
        protected readonly DataContext _context;
        public TestsBase() {

            Connection connection = new Connection();
            var data = File.ReadAllText("appsettings.json");
            connection = JsonSerializer.Deserialize<Connection>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            _context = new DataContext(connection.ConnectionStrings.FirstOrDefault().Value);
        }
    }
}
