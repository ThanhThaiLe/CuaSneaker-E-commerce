using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using software.common.BaseClass;
using software.common.Common;
using software.common.Model;
using software.common.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace software.common.ControllerBase
{
    [ServiceFilter(typeof(SoftwareAuthorize))]
    [ApiController]
    [Route("[controller].ctr/[action]")]
    public abstract class BaseAuthenticationController : Controller
    {
        public readonly IUserService _userService;
        public BaseAuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        public string getUserId()
        {
            return User.Identity.Name;
        }
        public JsonResult generateError()
        {
            Response.StatusCode = 400;
            var error = ModelState.Where(a => a.Value != null).ToList()
                .Where(d => d.Value.Errors.Count > 0)
                .Select(q => new
                {
                    key = q.Key,
                    value = q.Value.Errors.Select(e => e.ErrorMessage).ToArray(),
                    //str=str
                }).ToList();
            return Json(error);
        }
        public JsonResult generateSuscess()
        {
            Response.StatusCode = 200;

            return Json(new { result = "" });
        }
        public string get_path_file(string name, string error, string currentpath)
        {
            var tick = DateTime.Now.Ticks;
            var path = Path.Combine(currentpath, "file_upload", name, "Error");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var pathSave = Path.Combine(path, tick + ".txt");
            using (Stream stream = new FileStream(pathSave, FileMode.Create))
            {
                stream.CopyTo(stream);
            }
            System.IO.File.WriteAllText(path, error.Replace("<br/>", Environment.NewLine));
            return pathSave;
        }
        [NonAction]
        public async Task<FileStreamResult> exportFileExcel(AppSetting _appsetting, string[] header, string[] listKey, object dataList, string name)
        {
            var excel = new ExcelHelper(_appsetting);
            string file = "";
            try
            {
                file = excel.exportExcel(dataList, null, new List<string[]> { header }, listKey, new List<NPOI.SS.Util.CellRangeAddress>(), name, true);
            }
            catch (System.Exception)
            {

                throw;
            }
            if (!string.IsNullOrEmpty(file))
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(file, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                return File(memory, excel.GetContentType(file), Path.GetFileName(file));
            }
            return null;
        }
        public List<row> handleImportExcel(IFormFile file)
        {
            string folderName = "import_excel";

            var currentpath = Directory.GetCurrentDirectory();

            string newPath = Path.Combine(currentpath, "file_upload", folderName);
            var tick = Guid.NewGuid();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            var list_cell = new List<cell>();
            var list_row = new List<row>();
            string sFileExtension = Path.GetExtension(file.FileName).ToLower();
            ISheet sheet;
            string fullPath = Path.Combine(newPath, tick + "." + file.FileName.Split(".").Last());
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);

                stream.Position = 0;

                if (sFileExtension == ".xls")

                {

                    HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  

                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  

                }

                else

                {

                    XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  

                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   

                }

                IRow headerRow = sheet.GetRow(0); //Get Header Row

                int cellCount = headerRow.LastCellNum;


                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File

                {

                    IRow row = sheet.GetRow(i);

                    if (row == null) continue;

                    if (row.Cells.All(d => d.CellType == NPOI.SS.UserModel.CellType.Blank)) continue;

                    for (int j = row.FirstCellNum; j < cellCount; j++)

                    {

                        if (row.GetCell(j) != null)
                        {
                            var cell = new cell();

                            var value = row.GetCell(j).ToString();


                            cell.value = value;
                            list_cell.Add(cell);
                        }

                    }

                    var data_row = new row();


                    data_row.key = i.ToString();
                    data_row.list_cell = list_cell;
                    list_cell = new List<cell>();
                    list_row.Add(data_row);
                }


            }
            return list_row;
        }

        public List<row> handleImportExcelName(IFormFile file, string name)
        {
            string folderName = name;

            var currentpath = Directory.GetCurrentDirectory();

            string newPath = Path.Combine(currentpath, "file_upload", folderName);
            var tick = Guid.NewGuid();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            var list_cell = new List<cell>();
            var list_row = new List<row>();
            string sFileExtension = Path.GetExtension(file.FileName).ToLower();
            ISheet sheet;
            string fullPath = Path.Combine(newPath, tick + "." + file.FileName.Split(".").Last());
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);

                stream.Position = 0;

                if (sFileExtension == ".xls")

                {

                    HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  

                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  

                }

                else

                {

                    XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  

                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   

                }

                IRow headerRow = sheet.GetRow(0); //Get Header Row

                int cellCount = headerRow.LastCellNum;


                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File

                {

                    IRow row = sheet.GetRow(i);

                    if (row == null) continue;

                    if (row.Cells.All(d => d.CellType == NPOI.SS.UserModel.CellType.Blank)) continue;

                    for (int j = row.FirstCellNum; j < cellCount; j++)

                    {

                        if (row.GetCell(j) != null)
                        {
                            var cell = new cell();

                            var value = row.GetCell(j).ToString();


                            cell.value = value;
                            list_cell.Add(cell);
                        }

                    }

                    var data_row = new row();


                    data_row.key = i.ToString();
                    data_row.list_cell = list_cell;
                    list_cell = new List<cell>();
                    list_row.Add(data_row);
                }


            }
            return list_row;
        }


    }
}

