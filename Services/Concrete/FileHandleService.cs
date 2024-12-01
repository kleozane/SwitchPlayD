using SwitchPlayD.Services.Abstract;
using System.Net.Http.Headers;

namespace SwitchPlayD.Services.Concrete
{
	public class FileHandleService : IFileHandleService
	{
		private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment;

		public FileHandleService(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
		{
			_hostingEnvironment = hostingEnvironment;
		}

		public async Task<List<string>> UploadAsync(IFormFileCollection files, string uploadDir)
		{
			var usedFileName = default(string);
			List<string> imagesName = new List<string>();
			foreach (var Image in files)
			{
				if (Image != null && Image.Length > 0)
				{
					var file = Image;

					var uploads = Path.Combine(_hostingEnvironment.WebRootPath, uploadDir);

					if (file.Length > 0)
					{
						var fileName = ContentDispositionHeaderValue.Parse
							(file.ContentDisposition).FileName.Trim('"');

						System.Console.WriteLine(fileName);
						using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
						{
							await file.CopyToAsync(fileStream);
							usedFileName = file.FileName;
						}
					}
					imagesName.Add(usedFileName);
				}
			}
			return imagesName;
		}

		public async Task<string> UploadAndRenameFileAsync(IFormFile file, string uploadDir, string fileName)
		{
			var usedFileName = default(string);
			if (file != null)
			{
				var uploads = Path.Combine(_hostingEnvironment.WebRootPath, uploadDir);
				var _fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
				_fileName = fileName + Path.GetExtension(_fileName);
				System.Console.WriteLine(_fileName);
				using (var fileStream = new FileStream(Path.Combine(uploads, _fileName), FileMode.Create))
				{
					await file.CopyToAsync(fileStream);
					usedFileName = _fileName;
				}
			}
			return usedFileName;
		}

		public void RemoveImageFile(string imageDir, string imgName)
		{
			if (imgName != null)
			{
				var uploads = Path.Combine(_hostingEnvironment.WebRootPath, imageDir);
				var fileDel = Path.Combine(uploads, imgName);
				if (File.Exists(fileDel))
				{
					File.Delete(fileDel);
				}
			}

		}
	}
}
