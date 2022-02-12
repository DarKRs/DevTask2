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
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevTask2.Utilities;

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

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //
            HttpContent responseContent = response.Content;
            var json = await responseContent.ReadAsStringAsync();
            var apps = JsonConvert.DeserializeObject<List<Application>>(json);
            Assert.True(apps.Any());
        }

        [Theory]
        [InlineData(1)]
        public async Task GetApplicationAsync(int? id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/application/status/{id}");
          
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //
            HttpContent responseContent = response.Content;
            var json = await responseContent.ReadAsStringAsync();
            var app = JsonConvert.DeserializeObject<Application>(json);
            Assert.True(app is Application);
            Assert.True(app.ApplicationId == id);
        }

        [Theory]
        [InlineData("Test","BranchBankTest1")]
        public async Task CreateApplicationAsync(string AppNum, string Bank)
        {
            int id;
            //Get Last Id
            using(var request = new HttpRequestMessage(HttpMethod.Get, "api/application/status/"))
            {
                var response = await client.SendAsync(request);
                HttpContent responseContent = response.Content;
                var jsonGet = await responseContent.ReadAsStringAsync();
                var apps = JsonConvert.DeserializeObject<List<Application>>(jsonGet);
                id = apps.Last().ApplicationId;
            }

            //Post
            var json = JsonConvert.SerializeObject(new Application() { AppNum = AppNum + Func.RandStr(10), BranchBank = Bank });

           var responsePost = await client.PostAsync("api/application/create/", new StringContent(json, Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, responsePost.StatusCode);

            //Get new create app
            await GetApplicationAsync(id + 1);
        }
    }
}
