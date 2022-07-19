using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero{Id=1, Name="Spider Man", Location="New York"},
                new SuperHero{Id=2, Name="Thor", Location="Asgard"}
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(hero => hero.Id == id);
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(hero => hero.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero Not Found");

            hero.Name = request.Name;
            hero.Location = request.Location;

            return Ok(heroes);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = heroes.Find(hero => hero.Id == id);
            if (hero == null)
                return BadRequest("Hero Not Found");

            heroes.Remove(hero);
            return Ok(hero);
        }
    }
}
