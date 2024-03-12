using CsvHelper;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using ReadFile.Models.Dto;
using ReadFile.Services.IServices;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ReadFile.Services
{
    public class FileService : IFileService
    {
        public ResponseDto _responseDto;
        private FileDto _fileExcel;
        private FileDto _fileCSV;
        private string[] _headerNV ;

        public FileService()
        {
            _responseDto = new ResponseDto();
            _headerNV = new string[] { "STT", "Chức vụ", "Khu vực", "Họ tên", "Email", "SĐT", "QL Trực tiếp", "Trạng thái", "Nhà phân phối được quản lý trực tiếp" };

            _fileExcel = new FileDto(null, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "", "xlsx");
            _fileCSV = new FileDto(null, "text/csv", "", "csv");
        }

        public async Task<FileDto> DownloadFileNV(TypeFileDto.typeFile typeFile)
        {
            string[] headers = _headerNV;
            FileDto file;
            var stream = new MemoryStream();

            switch (typeFile)
            {
                case TypeFileDto.typeFile.xlsx:
                    stream = await CreateFileExcel(headers);
                    file = _fileExcel;
                    break;
                case TypeFileDto.typeFile.csv:
                    stream = await CreateFileCSV(headers);
                    file = _fileCSV;
                    break;
                default:
                    _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "lỗi không có file này trong hệ thống",
                        Result = null
                    };
                    return null;
            }

            

            file.fileName = "file_nhanvien";
            file.Stream = stream;

            _responseDto = new()
            {
                IsSuccess = true,
                Message = "File " + file.fileName + " đang được tạo",
                Result = null
            };

            return file;
        }

        public async Task<ResponseDto> ReadFileExcelNV(string filePath)
        {
            string fileExtension = GetFileExtension(filePath);

            try
            {
                List<DataNV> excelDataList = new List<DataNV>();

                var link = new FileInfo(filePath);

                using (var package = new ExcelPackage(link))
                {
                    var workbook = package.Workbook;
                    if (workbook != null)
                    {
                        var worksheet = workbook.Worksheets.FirstOrDefault();
                        if (worksheet != null)
                        {
                            // Đọc dữ liệu từ worksheet, bắt đầu từ dòng thứ 2
                            int rowCount = worksheet.Dimension.Rows;
                            for (int row = 2; row <= rowCount; row++)
                            {
                                DataNV excelData = new DataNV
                                {
                                    stt = int.Parse(worksheet.Cells[row, 1].Value?.ToString()),
                                    Chucvu = worksheet.Cells[row, 2].Value?.ToString(),
                                    Khuvuc = worksheet.Cells[row, 3].Value?.ToString(),
                                    Hoten = worksheet.Cells[row, 4].Value?.ToString(),
                                    Email = worksheet.Cells[row, 5].Value?.ToString(),
                                    Sdt = worksheet.Cells[row, 6].Value?.ToString(),
                                    QLTrucTiep = worksheet.Cells[row, 7].Value?.ToString(),
                                    Trangthai = worksheet.Cells[row, 8].Value?.ToString(),
                                    NhaphanphoiTT = worksheet.Cells[row, 9].Value?.ToString()
                                };

                                excelDataList.Add(excelData);
                            }
                        }
                    }
                }

                _responseDto.IsSuccess = true;
                _responseDto.Message = "Lấy dữ liệu thành công";
                _responseDto.Result = excelDataList;
            }
            catch (Exception ex)
            {
                _responseDto = new ResponseDto
                {
                    IsSuccess = false,
                    Message = ex != null ? ex.Message : "An error occurred.",
                    Result = null
                };
            }
            return _responseDto;
        }

        public async Task<ResponseDto> ReadFileCSVNV(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = new List<DataNV>();
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var record = new DataNV
                        {
                            stt = csv.GetField<int>(_headerNV[0]),
                            Chucvu = csv.GetField(_headerNV[1]),
                            Khuvuc = csv.GetField(_headerNV[2]),
                            Hoten = csv.GetField(_headerNV[3]),
                            Email = csv.GetField(_headerNV[4]),
                            Sdt = csv.GetField(_headerNV[5]),
                            QLTrucTiep = csv.GetField(_headerNV[6]),
                            Trangthai = csv.GetField(_headerNV[7]),
                            NhaphanphoiTT = csv.GetField(_headerNV[8])
                        };
                        records.Add(record);


                    }
                    // Set the records to the response
                    _responseDto.Result = records;
                    _responseDto.IsSuccess = true;
                    _responseDto.Message = "CSV file read successfully.";
                }

            }
            catch (Exception ex)
            {
                _responseDto.Result = null;
                _responseDto.IsSuccess = true;
                _responseDto.Message = ex.ToString();
                throw;
            }
            return _responseDto;
        }

        private async Task<MemoryStream> CreateFileExcel(string[] headers)
        {
            MemoryStream stream = new MemoryStream();
            try
            {
                // Tạo một tệp Excel mới
                using (var package = new ExcelPackage())
                {
                    var workbook = package.Workbook;
                    var worksheet = workbook.Worksheets.Add("Sheet1");


                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = headers[i];
                    }

                    // Ghi tệp Excel vào một MemoryStream

                    package.SaveAs(stream);

                    // Đặt con trỏ luồng về đầu
                    stream.Seek(0, SeekOrigin.Begin);

                    _responseDto = new()
                    {
                        IsSuccess = true,
                        Message = "Download file thành công",
                        Result = null
                    };
                }
            }
            catch (Exception ex)
            {
                _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "download file không thành công",
                    Result = null
                };
            }

            return stream;
        }

        private async Task<MemoryStream> CreateFileCSV(string[] headers)
        {
            MemoryStream stream = new MemoryStream();
            try
            {
                // Kiểm tra null cho headers
                if (headers == null || headers.Length == 0)
                {
                    throw new ArgumentException("Header array cannot be null or empty.");
                }

                using (var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true))
                {
                    // Ghi header vào tệp CSV
                    await writer.WriteLineAsync(string.Join(",", headers));

                    // Flush để đảm bảo dữ liệu được ghi vào MemoryStream
                    await writer.FlushAsync();

                    // Đặt con trỏ về đầu của MemoryStream
                    stream.Seek(0, SeekOrigin.Begin);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ ở đây (ví dụ: ghi log)
                Console.WriteLine($"An error occurred while creating CSV file: {ex}");
                // Ném ngoại lệ để thông báo cho lớp gọi xử lý
                throw;
            }
            return stream;
        }
        private string GetFileExtension(string filePath)
        {
            return Path.GetExtension(filePath)?.TrimStart('.');
        }
    }
}