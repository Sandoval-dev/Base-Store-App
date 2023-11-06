using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/books")]
    public class BooksV2Controller:ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksV2Controller(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpHead]
        public async Task<IActionResult> GetAllBoksAsync()
        {
            var books = await _manager.BookService.GetAllBooksAsync(false);
            return Ok(books);



        }
    }
}
