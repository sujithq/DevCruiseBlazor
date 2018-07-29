using System.Collections.Generic;
using System.Linq;
using DevCruise.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevCruise.Blazor.Hosted.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Product> mens_outerwear()
        {
            return JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText("data/mens_outerwear.json"));
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> ladies_outerwear()
        {
            return JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText("data/ladies_outerwear.json"));
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> mens_tshirts()
        {
            return JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText("data/mens_tshirts.json"));
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> ladies_tshirts()
        {
            return JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText("data/ladies_tshirts.json"));
        }

        [HttpGet("[action]/{id}")]
        public Product mens_outerwear([FromRoute]string id)
        {
            return mens_outerwear().FirstOrDefault(f => f.Name == id);
        }

        [HttpGet("[action]/{id}")]
        public Product ladies_outerwear([FromRoute]string id)
        {
            return ladies_outerwear().FirstOrDefault(f => f.Name == id);
        }

        [HttpGet("[action]/{id}")]
        public Product mens_tshirts([FromRoute]string id)
        {
            return mens_tshirts().FirstOrDefault(f => f.Name == id);
        }

        [HttpGet("[action]/{id}")]
        public Product ladies_tshirts([FromRoute]string id)
        {
            return ladies_tshirts().FirstOrDefault(f => f.Name == id);
        }

    }
}