﻿using Microsoft.EntityFrameworkCore;
using TLA.Persistence.Models;
using TLA.Persistence.Repository.Interfaces;
using TLA.Persistence.Repository.Transactor;

namespace TLA.Persistence.Repository.Implementations
{
    public class WordsRepository : IWordsRepository
    {
        private readonly ITransactor<TranslationDb> _transactor;

        public WordsRepository(ITransactor<TranslationDb> transactor)
        {
            _transactor = transactor ?? throw new ArgumentNullException(nameof(transactor));
        }

        public async Task AddSampleWord()
        {
            await _transactor.DoInTransaction(async ctx =>
            {
                await ctx.Words.AddAsync(new Word { InputWord = "InputSample", OutputWord = "OutSample" });
                await ctx.SaveChangesAsync();
            });
        }

        public async Task<IReadOnlyCollection<Word>> GetAll()
        {
            return await _transactor.Query(async (ctx) =>
            {
                return await ctx.Words.ToListAsync();
            });
        }
    }
}