using System;
using Xunit;
using DevTask2.Controllers;
using DevTask2.Models;
using DevTask2;
using DevTask2.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Text.Json;

namespace DevTask2_Tests
{
    public class ApplicationControllerTest
    {
        /*ApplicationContext context;
        ApplicationController ac;
        ScoringController sc;*/
        HttpClient client;
        public ApplicationControllerTest()
        {
            /* var options = new DbContextOptionsBuilder<ApplicationContext>()
             .UseInMemoryDatabase(databaseName: "TestDB")
             .Options;
             context = new ApplicationContext(options);
             sc = new ScoringController(context);
             ac = new ApplicationController(context,sc);
             context.applications.Add(new Application());
             context.applications.Add(new Application());
             context.applications.Add(new Application());
             context.SaveChanges();*/

            var server = new TestServer(new WebHostBuilder()
                    .UseStartup<StartupTests>());
            client = server.CreateClient();

        }

    /*    [Fact]
        public async Task GetApplicationsAsync() {
            var apps_contr = await ac.Get();
            var apps_db = await context.applications.ToListAsync();
            var viewResult = Assert.IsType<Application>(apps_contr);
            Assert.NotNull(apps_contr);
            
        }*/

        [Fact]
        public async Task GetApplicationsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/application/status/");
            //request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetApplicationAsync(int? id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/application/status/{id}");
          
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            HttpContent responseContent = response.Content;
            var json = await responseContent.ReadAsStringAsync();
            var app = JsonSerializer.Deserialize<Application>(json);
            int a = 0;
        }
    }
}
