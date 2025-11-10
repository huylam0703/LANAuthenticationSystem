using LANAuthServer.Data;
using System;
using System.Collections.Generic;

namespace LANAuthServer.Services
{
    internal class BannedWebService
    {
        private readonly BannedWebRepository _bannedRepo = new BannedWebRepository();

        public bool AddBannedWebsite(string url, string description)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("URL không hợp lệ");

            return _bannedRepo.addWebBanned(url, description);
        }

        public bool DeleteBannedWebsite(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("URL không hợp lệ");

            return _bannedRepo.DeleteBannedWebsite(url);
        }

        public List<(string Url, string Reason, DateTime CreatedAt)> GetAllBannedWebsites()
        {
            return _bannedRepo.GetAllBannedWebsites();
        }

    }
}
