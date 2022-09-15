using Imperfect.API.Data;
using Imperfect.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gremlin.Net.Driver;
using Gremlin.Net.Driver.Exceptions;
using Gremlin.Net.Structure.IO.GraphSON;
using Newtonsoft.Json;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Imperfect.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private static string hostname = "imperfect-gremlindb.gremlin.cosmos.azure.com";
        private static int port = 443;
        private static string authKey = "ComGj44MS4UMeoAaPeQeAWkfWmaEjco2Zy5ysYzR3ZaFftqrEZrShAfM3TIqrknCvBHpBYbzeM0EWStnn2fb0w==";
        private static string database = "Profile";
        private static string collection = "Profile";
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }
        private static Task<ResultSet<dynamic>> SubmitRequest(GremlinClient gremlinClient, string query)
        {
            try
            {
                return gremlinClient.SubmitAsync<dynamic>(query);
            }
            catch (ResponseException e)
            {
                Console.WriteLine("\tRequest Error!");
                Console.WriteLine($"\tStatusCode: {e.StatusCode}");
                PrintStatusAttributes(e.StatusAttributes);
                Console.WriteLine($"\t[\"x-ms-retry-after-ms\"] : {GetValueAsString(e.StatusAttributes, "x-ms-retry-after-ms")}");
                Console.WriteLine($"\t[\"x-ms-activity-id\"] : {GetValueAsString(e.StatusAttributes, "x-ms-activity-id")}");

                throw;
            }
        }
        private static void PrintStatusAttributes(IReadOnlyDictionary<string, object> attributes)
        {
            Console.WriteLine($"\tStatusAttributes:");
            Console.WriteLine($"\t[\"x-ms-status-code\"] : {GetValueAsString(attributes, "x-ms-status-code")}");
            Console.WriteLine($"\t[\"x-ms-total-request-charge\"] : {GetValueAsString(attributes, "x-ms-total-request-charge")}");
        }

        public static string GetValueAsString(IReadOnlyDictionary<string, object> dictionary, string key)
        {
            return JsonConvert.SerializeObject(GetValueOrDefault(dictionary, key));
        }

        public static object GetValueOrDefault(IReadOnlyDictionary<string, object> dictionary, string key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }

            return null;
        }

        [HttpGet(Name = "GetProfile")]
        public Profile Get(string Id)
        {
            var gremlinServer = new GremlinServer(hostname, port, enableSsl: true,
                                                    username: "/dbs/" + database + "/colls/" + collection,
                                                    password: authKey);
            var returnProfile = new Profile();
            using (var gremlinClient = new GremlinClient(gremlinServer, new GraphSON2Reader(), new GraphSON2Writer(), GremlinClient.GraphSON2MimeType))
            {
                var resultSet = SubmitRequest(gremlinClient, $"g.V().hasLabel('profile').has('id', '{Id}')").Result;
                Console.WriteLine(resultSet.GetType());
                string output = JsonConvert.SerializeObject(resultSet);
                Console.WriteLine($"\t{output}");
                List<Profile> test = JsonConvert.DeserializeObject<List<Profile>>(output);
                return test[0];
            }
        }

        [HttpPost(Name = "PostProfile")]
        public async Task Post(string id, string firstName, string lastName, string description, string profilePicture)
        {
            var gremlinServer = new GremlinServer(hostname, port, enableSsl: true,
                                                    username: "/dbs/" + database + "/colls/" + collection,
                                                    password: authKey);

            using (var gremlinClient = new GremlinClient(gremlinServer, new GraphSON2Reader(), new GraphSON2Writer(), GremlinClient.GraphSON2MimeType))
            {
                await gremlinClient.SubmitAsync<dynamic>($"g.addV('profile').property('id', '{id}').property('firstName', '{firstName}').property('lastName', '{lastName}').property('profilePicture', '{profilePicture}').property('description','{description}').property('profile', 'pk')");
            }
        }
    }
}
