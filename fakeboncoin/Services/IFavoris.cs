using fakeboncoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeboncoin.Services
{
    public interface IFavoris
    {
        bool AddToFavoris(int id);
        bool RemoveFromFavoris(int id);
        List<Annonce> GetFavoris();
        bool IsFavoris(int id);
    }
}
