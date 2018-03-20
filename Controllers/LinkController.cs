using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webdev.Interfaces;
using webdev.Models;
using System;

namespace webdev.Controllers
{
    public class LinkController : Controller
    {
        private ILinksRepository _repository;
        
        public LinkController(ILinksRepository linksRepository)
        {
            _repository = linksRepository;
        }
        [HttpGet("[controller]/[action]")]
        [HttpGet("")]
        public IActionResult Index()
        {
            var links = _repository.GetLinks();
            return View(links);
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult Create(Link link)
        {
            _repository.AddLink(link);
            return Redirect("Index");
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Delete(Link link)
        {
            _repository.Delete(link);
            return Redirect("Index");
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Edit(Link link) 
        {
            return View(link);
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult Update(Link link) 
        {
            _repository.Update(link);
            return Redirect("Index");
        }
        [HttpGet("{encoded}")]
        public IActionResult Decode(string encoded)
        {
            string link =_repository.Decode(encoded);
            Uri uriResult;
            bool result = Uri.TryCreate(link, UriKind.Absolute, out uriResult)
    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result) return Redirect(uriResult.AbsoluteUri);
            else return View("Bad");
        }
    }
}