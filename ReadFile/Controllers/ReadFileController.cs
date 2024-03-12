using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadFile.Services.IServices;
using ReadFile.Models.Dto;
using System.Runtime.CompilerServices;
using OfficeOpenXml.Table;
using OfficeOpenXml;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace ReadFile.Controllers
{
    [Route("api/readFile")]
    [ApiController]
    public class ReadFileController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private IFileService _fileService;
        private ResponseDto _responseDto;
        public ReadFileController(IFileService fileService, IAuthorizationService authorizationService)
        {
            _fileService = fileService;
            _responseDto = new ResponseDto();
            _authorizationService = authorizationService;
        }

        [HttpGet("downloadFileNV_Excel")]
        public async Task<IActionResult> DownloadFileEX()
        {
            var file = await _fileService.DownloadFileNV(TypeFileDto.typeFile.xlsx);

            if (file.fileName == "")
            {
                return BadRequest();
            }
            else
            {
                return File(file.Stream, file.contentType, file.fileName);
            }
        }

        [HttpGet("downloadFileNV_CSV")]
        public async Task<IActionResult> DownloadFileCSVNV()
        {
            var file = await _fileService.DownloadFileNV(TypeFileDto.typeFile.csv);


            if (file.fileName == "")
            {
                return BadRequest();
            }
            else
            {
                return File(file.Stream, file.contentType, file.fileName);
            }
        }

        [HttpGet("ReadFile/{fileName}")]
        public async Task<IActionResult> ReadFileNV(string fileName)
        {
            string filePath = fileName;
            // lấy dữ liệu file
            ResponseDto? excelDataNVs = await _fileService.ReadFileExcelNV(filePath);
            _responseDto = excelDataNVs;
            return Ok(_responseDto);
        }

        [HttpGet("ReadFile/CSV/{fileName}")]
        public async Task<IActionResult> ReadFileNVCSV(string fileName)
        {
            string filePath = fileName;
            // lấy dữ liệu file
            ResponseDto? excelDataNVs = await _fileService.ReadFileCSVNV(filePath);
            _responseDto = excelDataNVs;
            return Ok(_responseDto);
        }
    }
}
