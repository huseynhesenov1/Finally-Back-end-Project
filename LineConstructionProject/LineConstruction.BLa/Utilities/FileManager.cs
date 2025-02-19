﻿using Microsoft.AspNetCore.Http;

namespace LineConstruction.BLa.Utilities
{
	public static class FileManager
	{

        private static readonly string[] AllowedFileTypes = { ".jpg", ".jpeg", ".png" };
        private const long MaxFileSize = 2 * 1024 * 1024; 

        public static bool IsValidFile(this IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            return file.Length <= MaxFileSize && Array.Exists(AllowedFileTypes, ext => ext == fileExtension);
        }

        public static async Task<string> SaveAsync(this IFormFile file, string folder)
        {
            if (!file.IsValidFile())
                throw new Exception("Invalid file type or size");

            string uploadPath = Path.Combine(Path.GetFullPath("wwwroot"), "uploads", folder);
            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            using (FileStream fs = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return fileName;
        }
    }
}
