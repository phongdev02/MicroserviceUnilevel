namespace UserService.Service.SetFunc
{
    public class NPPJson
    {
        private string path;
        public NPPJson() {
            path = GetAbsolutePath("File/");

        }

        public bool IsFileExists(string filePath)
        {
            // Kiểm tra xem tệp có tồn tại không
            return File.Exists(filePath);
        }

        private string GetAbsolutePath(string relativePath)
        {
            // Lấy đường dẫn thư mục gốc của dự án
            string rootPath = Directory.GetCurrentDirectory();

            // Kết hợp đường dẫn tương đối với đường dẫn thư mục gốc để tạo đường dẫn tuyệt đối
            string absolutePath = Path.Combine(rootPath, relativePath);

            return absolutePath;
        }
    }
}
