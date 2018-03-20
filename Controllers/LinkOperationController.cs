using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webdev.Interfaces;
using webdev.Models;
using HashidsNet;
using System;

namespace webdev.Controllers
{
    public class LinkOperationController : Controller
    {
        private static string salt = "moj sol";

        public static string GetSalt()
        {
            return salt;
        }

        public static string Encode(int link)
        {
            var hashids = new Hashids(salt);

            var encoded = hashids.Encode(link);
            return encoded;
        }
        public static int Decode(string encoded)
        {
            var hashids = new Hashids(salt);
            var link = hashids.Decode(encoded);
            return link[0];
        }


    }
}