using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainTicketShop.Controllers.REST.SearchHints {
    [Route("api/search/hints")]
    public class SearchHintsController : Controller {
        private HttpClient _httpClient;

        public SearchHintsController(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        [HttpGet]
        public JsonResult Get([FromQuery] string input) {
            return new JsonResult(GetHintsFromWeb(input));
        }

        private object GetHintsFromWeb(string input) {
            var body = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("broker", "PbUa" ),
                    new KeyValuePair<string, string>("lang", "RU"),
                    new KeyValuePair<string, string>("prefix", input)
                });
            var result = _httpClient.PostAsync("https://bilet.privatbank.ua/sm/train/stations.json", body).Result;
            return JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
        }

        /*// GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
