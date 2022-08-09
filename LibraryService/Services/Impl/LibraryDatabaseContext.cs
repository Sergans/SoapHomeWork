using LibraryService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Web;


namespace LibraryService.Services.Impl
{
    public class LibraryDatabaseContext : ILibraryDatabaseContextService
    {
        private IList<Book> _libraryDatabase;

        public IList<Book> Books => _libraryDatabase;

        public LibraryDatabaseContext()
        {
            Initialize();
        }

        private void Initialize()
        {

            _libraryDatabase =
                JsonConvert.DeserializeObject<List<Book>>(Encoding.UTF8.GetString(Properties.Resources.books));
        }
        public void WriteJson(List<Book> book)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string json = System.Text.Json.JsonSerializer.Serialize(book, options);
            string filePath = @"C:\Users\GANS\Desktop\SOAPHomeWork\LibraryService\Books.json";
            using (StreamWriter fileStream = new StreamWriter(filePath))
            {
                fileStream.Write(json);
            }
        
        }
    }
}