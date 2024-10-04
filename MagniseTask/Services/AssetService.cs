using MagniseTask.Data;
using MagniseTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagniseTask.Services
{
    public class AssetService
    {
        private readonly MagniseContext _context;

        public AssetService(MagniseContext context)
        {
            _context = context;
        }

        public async Task<List<MarketAsset>> GetSupportedAssetsAsync()
        {
            return await _context.MarketAssets.ToListAsync();
        }
    }
}
