using LANAuthServer.Data;
using System;
using System.Collections.Generic;

namespace LANAuthServer.Services
{
    internal class BannedWebService
    {
        private readonly BannedWebRepository _bannedRepo = new BannedWebRepository();

        /// <summary>
        /// Thêm website vào danh sách cấm
        /// </summary>
        public bool AddBannedWebsite(string url, string description)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("URL không hợp lệ");

            return _bannedRepo.addWebBanned(url, description);
        }

        /// <summary>
        /// Xóa website khỏi danh sách cấm
        /// </summary>
        public bool DeleteBannedWebsite(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("URL không hợp lệ");

            return _bannedRepo.DeleteBannedWebsite(url);
        }

        /// <summary>
        /// Lấy danh sách tất cả website bị cấm
        /// </summary>
        public List<(string Url, string Reason, DateTime CreatedAt)> GetAllBannedWebsites()
        {
            return _bannedRepo.GetAllBannedWebsites();
        }
    }
}