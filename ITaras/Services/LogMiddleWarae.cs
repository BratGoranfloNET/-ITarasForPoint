using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ITaras.Services
{
    public class LogMiddleWarae
    {
        private readonly RequestDelegate _next; 
        
        public LogMiddleWarae(RequestDelegate next)
        {
                _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestBodyStream = new MemoryStream();
            var originalRequestBody = context.Request.Body;

            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var url = UriHelper.GetDisplayUrl(context.Request);
            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
            string text = $"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()} , REQUEST METHOD: {context.Request.Method}, REQUEST BODY: {requestBodyText}, REQUEST URL: {url}";

            string fileToWrite = @"C:\LOGTEST\log.txt";
          
            using (FileStream fstream = new FileStream(fileToWrite, File.Exists(fileToWrite) ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write))
            {
               byte[] array = System.Text.Encoding.Default.GetBytes(text + "\n");
               fstream.Write(array, 0, array.Length);
               fstream.Close();
            }
            
            await _next(context);
        }
    }
}
