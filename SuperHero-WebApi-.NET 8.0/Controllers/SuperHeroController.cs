﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero_WebApi_.NET_8._0.Data;
using SuperHero_WebApi_.NET_8._0.Entities;

namespace SuperHero_WebApi_.NET_8._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if(hero == null)
                return NotFound("Hero not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);
            if (dbHero == null)
                return NotFound("Hero not found");
            
            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return NotFound("Hero not found");

            _context.SuperHeroes.Remove(hero);
            _context.SaveChanges();
            return Ok("Delete Success");
        }
    }
}
