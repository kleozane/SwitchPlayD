namespace SwitchPlayD.Services.Abstract
{
	public interface IFileHandleService
	{
		Task<List<string>> UploadAsync(IFormFileCollection files, string uploadDir);
		Task<string> UploadAndRenameFileAsync(IFormFile file, string uploadDir, string fileName);
		void RemoveImageFile(string imageDir, string imgName);
	}
}
