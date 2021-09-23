using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Model.ClassesModel.Entity;
using Model.ClassesModel.IService;
using Model.HistoryDownloadingModel.Entity;
using Model.HistoryDownloadingModel.IService;
using Model.MaterialModel.DTO;
using Model.MaterialModel.Entity;
using Model.MaterialModel.IService;
using Model.UserModel.Entity;
using Model.UserModel.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : Controller
    {
        private IMaterialService materialService;
        private IClassesService classesService;
        private IUserService useresService;
        private IHistoryDownloadingService historyDownloadingService;

        public FileController(
            IMaterialService materialService,
            IClassesService classesService,
            IUserService useresService,
            IHistoryDownloadingService historyDownloadingService
            )
        {
            this.materialService = materialService;
            this.classesService = classesService;
            this.useresService = useresService;
            this.historyDownloadingService = historyDownloadingService;
        }

        [HttpPost("file/{id}/{name}/{data}"), DisableRequestSizeLimit]
        public IActionResult Upload(Guid id, string name, string data)
        {
            Guid newG = Guid.NewGuid();
            Classes classes = classesService.Get(id);

            var file = Request.Form.Files[0];
            string extension = Path.GetExtension(file.FileName);

            var folderName = Path.Combine("Resources", "File", String.Concat( newG.ToString(), extension));
            
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            using (var stream = new FileStream(pathToSave, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (name == "null")
            {
                name = null;
            }

            bool active = false;
            if (data == "null")
            {
                data = null;
            }
            else
            {
                active = true;
            }

            if (name != null)
            {

                    Material material = new Material(
                        newG,
                        classes,
                        pathToSave,
                        String.Concat(name, extension),
                        active,
                        data,
                        new AuditData("system", DateTime.Now)
                    );
                    materialService.AddNew(material);

            }
            else
            {
                    Material material = new Material(
                        newG,
                        classes,
                        pathToSave,
                        file.FileName,
                        active,
                        data,
                        new AuditData("system", DateTime.Now)
                    );
                    materialService.AddNew(material);
            }
            return Ok();
        }

        [HttpGet("{id}"), DisableRequestSizeLimit]
        public IActionResult Download(Guid id)
        {
            MaterialDTO material = materialService.Get(id);

            var file = new FileStream(material.Localization, FileMode.Open, FileAccess.Read);
            return Ok(file);

        }

        [HttpGet("DownloadTask/{id}"), DisableRequestSizeLimit]
        public async Task<ActionResult> DownloadFile(Guid id)
        {
            MaterialDTO material = materialService.Get(id);

            var memory = new MemoryStream();
            await using (var stream = new FileStream(material.Localization, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(material.Localization), material.Name);
        }

        [HttpGet("DownloadTaskStudent/{userId}/{id}"), DisableRequestSizeLimit]
        public async Task<ActionResult> DownloadFileStudent(Guid id,Guid userId)
        {
            MaterialDTO material = materialService.Get(id);

            historyDownloadingService.AddNewHistory(userId, material.Id);

            var memory = new MemoryStream();
            await using (var stream = new FileStream(material.Localization, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(material.Localization), material.Name);
        }

        private string GetContentType(string localization)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (!provider.TryGetContentType(localization, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}
