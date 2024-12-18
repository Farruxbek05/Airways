namespace Airways.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, Options options) where T : BaseEntity
        {
            if (options.PageNumber < 1)
                options.PageNumber = 1;

            if (options.PageSize < 1)
                options.PageSize = 10;

            var totalCount = await query.Count();

            var items = await query
               .Skip((options.PageNumber - 1) * options.PageSize)
               .Take(options.PageSize)
               .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageSize = options.PageSize,
                PageNumber = options.PageNumber
            };
        }

        public static async Task<PagedResult<TEntityDTO>> ToPagedResultAsync<TEntity, TEntityDTO>(
            this IQueryable<TEntity> query,
            Options options,
            IMapper mapper) where TEntity : BaseEntity
        {
            if (options.PageNumber < 1)
                options.PageNumber = 1;

            if (options.PageSize < 1)
                options.PageSize = 10;

            var totalCount = await query.CountAsync();

            var items = await query
               .Skip((options.PageNumber - 1) * options.PageSize)
               .Take(options.PageSize)
               .ProjectTo<TEntityDTO>(mapper.ConfigurationProvider)
               .ToListAsync();

            return new PagedResult<TEntityDTO>
            {
                Items = items,
                TotalCount = totalCount,
                PageSize = options.PageSize,
                PageNumber = options.PageNumber
            };
        }
    }

}
