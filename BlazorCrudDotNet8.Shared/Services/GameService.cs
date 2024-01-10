﻿using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Shared.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext _context; 
        public GameService(DataContext context)
        {
            _context = context;
        }

        public async Task<Game> AddGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> DeleteGame(int id)
        {
            var dbGame =  await _context.Games.FindAsync(id);
            if(dbGame != null)
            {
                _context.Games.Remove(dbGame);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<List<Game>> GetAllGames()
        {
            await Task.Delay(1000);
            var games = await _context.Games.ToListAsync();
            return games;
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<Game> UpdateGame(int id, Game game)
        {
            var dbGame = await _context.Games.FindAsync(id);
            if (dbGame != null)
            {
                dbGame.Name = game.Name;
                await _context.SaveChangesAsync();
                return dbGame;
            }
            throw new Exception("Game not found");
        }
    }
}
