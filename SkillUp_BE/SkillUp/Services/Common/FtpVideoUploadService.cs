using Microsoft.AspNetCore.Http;

namespace SkillUp.Services.Common
{
    public class FtpVideoUploadService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly string _baseUrl;

        public FtpVideoUploadService(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
            _baseUrl = _configuration["VideoSettings:BaseUrl"] ?? "";
        }

        public async Task<string> UploadVideoAsync(IFormFile file, string? subfolder = null)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Video file không được để trống!");

            var allowedExtensions = new[] { ".mp4", ".avi", ".mov", ".wmv", ".webm", ".mkv" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
                throw new ArgumentException($"Định dạng video không hợp lệ! Chỉ chấp nhận: {string.Join(", ", allowedExtensions)}");

            var maxSizeInBytes = _configuration.GetValue<int>("VideoSettings:MaxSizeInMB", 500) * 1024 * 1024;
            if (file.Length > maxSizeInBytes)
                throw new ArgumentException($"Kích thước video không được vượt quá {maxSizeInBytes / 1024 / 1024}MB!");

            var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";

            // Save to wwwroot/videos/{subfolder}/
            var relativePath = string.IsNullOrEmpty(subfolder) ? "videos" : $"videos/{subfolder}";
            var savePath = Path.Combine(_env.WebRootPath, relativePath);
            Directory.CreateDirectory(savePath);

            var filePath = Path.Combine(savePath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // ponytail: BaseUrl dùng cho production; local thì để trống hoặc set http://localhost:5120
            var videoUrl = string.IsNullOrEmpty(_baseUrl)
                ? $"/{relativePath}/{uniqueFileName}"
                : $"{_baseUrl}/{relativePath}/{uniqueFileName}";

            return videoUrl;
        }

        public Task<bool> DeleteVideoAsync(string videoUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(videoUrl)) return Task.FromResult(false);

                // Lấy relative path từ URL
                var uri = new Uri(videoUrl, UriKind.RelativeOrAbsolute);
                var relativePart = uri.IsAbsoluteUri ? uri.AbsolutePath : videoUrl;

                var filePath = Path.Combine(_env.WebRootPath, relativePart.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(filePath))
                    File.Delete(filePath);

                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> TestConnectionAsync() => Task.FromResult(true);

        public Task<(bool success, string message, string details)> TestConnectionDetailedAsync()
            => Task.FromResult((true, "Local storage mode", $"WebRoot: {_env.WebRootPath}"));
    }
}
