

/*

#### Synchronous Program Execution

    ** Program is executed line by line, one at a time
    **When a function is called, program execution has to wait until the function returns before it continues to the next line
    
#### Asynchronous Program Execution

    ** When a function is called, program excution continues to the next line, without waiting for the function to complete


So what's the difference?

    ** Asynchronous programming improves responsivness of your application


Task-based Asynchronous Model.
*/
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApp
{


    public class AsyncAwait
    {

        public void DownloadHtml(string url)
        {

            var webClient = new WebClient();
            var html = webClient.DownloadString("url");

            using (var streamWriter = new StreamWriter(@"c:\projects"))
            {
                streamWriter.Write(html);
            }
        }


        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync("url");

            using (var streamWriter = new StreamWriter(@"c:\projects"))
            {
                await streamWriter.WriteAsync(html);
            }
        }
    }
}