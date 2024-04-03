using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task3Library.Data;
using Task3Library.Data.Models;
using Task3Library.Repositories;

var connectionString = "server=localhost;database=Task3;user=alistan;password=artshest124;TrustServerCertificate=True";

var user = new UserDataModel() { Name = "Ivan", Password = "Pivan", State="Online"};


var context = new DataContext(connectionString);

var userRepository = new UserRepository(context);
Console.WriteLine(await userRepository.AddUser(user));