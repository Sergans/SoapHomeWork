using LibraryService.Web.Models;
using LibraryServiceReference;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryService.Web.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILogger<LibraryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(SearchType searchType, string searchString)
        {
            LibraryWebServiceSoapClient libraryWebServiceSoapClient = new
                LibraryWebServiceSoapClient(LibraryWebServiceSoapClient.EndpointConfiguration.LibraryWebServiceSoap12);

            var bookCategoryViewModel = new BookCategoryViewModel
            {
                Books = new Book[] { }
            };

            if (!string.IsNullOrEmpty(searchString) && searchString.Length >= 3)
            {
                switch (searchType)
                {
                    case SearchType.Title:
                        bookCategoryViewModel.Books = libraryWebServiceSoapClient.GetBooksByTitle(searchString);
                        break;
                    case SearchType.Category:
                        bookCategoryViewModel.Books = libraryWebServiceSoapClient.GetBooksByCategory(searchString);
                        break;
                    case SearchType.Author:
                        bookCategoryViewModel.Books = libraryWebServiceSoapClient.GetBooksByAuthor(searchString);
                        break;
                }
            }

            return View(bookCategoryViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}