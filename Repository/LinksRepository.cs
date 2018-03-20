using System.Collections.Generic;
using System.Linq;
using webdev.Controllers;
using webdev.Interfaces;
using webdev.Models;

namespace webdev.Repository
{
    public class LinksRepository : ILinksRepository
    {
        private List<Link> _links;

        public LinksRepository()
        {
            _links = new List<Link>();
        }

        public void AddLink(Link link) 
        {
            link.Id = _links.Count;
            link.Short_link = LinkOperationController.Encode(link.Id);
            _links.Add(link);
        }

        public List<Link> GetLinks() 
        {
            return _links;
        }

        public void Delete(Link link) 
        {
            var linkToDelete = _links
                .SingleOrDefault(element => element.Long_link == link.Long_link && element.Short_link == link.Short_link);
            _links.Remove(linkToDelete);
        }

        public void Update(Link link) 
        {
            link.Short_link = LinkOperationController.Encode(link.Id);
            var linkToUpdateIndex = _links.FindIndex(element => element.Id == link.Id);
            if(linkToUpdateIndex != -1) 
                _links[linkToUpdateIndex] = link;
        }
        public string Decode(string encoded)
        {
            int id = LinkOperationController.Decode(encoded);

            var link = _links.SingleOrDefault(element => element.Id == id);
            return link.Long_link;
        }

    }
}