using Microsoft.AspNetCore.Http;

namespace LineConstruction.BLa.Utilities
{
	public static class FileManager
	{
		public static async Task<string> SaveAsync(this IFormFile file , string folder)
		{
			string uploadPath = Path.Combine(Path.GetFullPath("wwwroot"), "uploads" , folder);
			if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
			string fileName = Guid.NewGuid().ToString() + file.FileName;
			using (FileStream fs = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
			{
				await file.CopyToAsync(fs);
			}

			return fileName;
		}

		public static bool CheckType(this IFormFile file , string requiredtype) =>file.ContentType.Contains(requiredtype);
	}
}
