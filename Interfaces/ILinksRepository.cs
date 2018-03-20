using System.Collections.Generic;
using webdev.Models;

namespace webdev.Interfaces
{
    public interface ILinksRepository
    {
         List<Link> GetLinks();
         void AddLink(Link link);
         void Delete(Link link);
         void Update(Link link);
         string Decode(string encoded);
    }
}