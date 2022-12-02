using System;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using TechJobsPersistentAutograded;
using Xunit;


namespace TaskOne.Tests
{
    public class TaskOne
    {
        private readonly IConfiguration _configuration;

        public TaskOne()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();
        }


        [Fact]
        public void TestDefaultConnectionString()
        {
            string mysqlConnectionString = _configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            Boolean mysqlConnectionURL = mysqlConnectionString.Contains("server=localhost");
            Assert.True(mysqlConnectionURL, "Server is not localhost");

            Boolean mySqlConnectionDatabase = mysqlConnectionString.Contains("database=techjobspersistent");
            Assert.True(mySqlConnectionDatabase, "Database is not named techjobspersistent");

            Boolean mySqlConnectionUsername = mysqlConnectionString.Contains("userid=techjobspersistent");
            Assert.True(mySqlConnectionUsername, "Username is not techjobspersistent");

            Boolean mySqlConnectionPassword = mysqlConnectionString.Contains("password=Learn2Code!");
            Assert.True(mySqlConnectionPassword, "Password is not Learn2Code!");
        }
    }
}
