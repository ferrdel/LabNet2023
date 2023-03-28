using Lab.EF.WEBApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.WEBApi.Controllers
{
    public class RMEpisodiosController : Controller
    {
        // GET: RMEpisodios
        public async Task<ActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://rickandmortyapi.com/api/episode");

            dynamic listApi = JsonConvert.DeserializeObject(json);

            var result = listApi.results;

            List<RMEpisodiosView> listEpisodio = new List<RMEpisodiosView>();

            foreach (var i in result)
            {
                RMEpisodiosView pokeApi = new RMEpisodiosView()
                {
                    Name = i.name,
                    AirDate = i.air_date,
                    Episode = i.episode
                };
                listEpisodio.Add(pokeApi);
            }
            return View(listEpisodio);
        }
    }
}