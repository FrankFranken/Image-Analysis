using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Image_Analysis
{
    public class MicrosoftEmotionApi
    {
        public async Task<HttpResponseMessage> CallMicrosoftEmotionApi(int id)
        {
            char[] file = null;
            using (ImagesUploadEntities dc = new ImagesUploadEntities())
            {
                if (dc.ImageGalleries != null)
                {
                    foreach (var image in dc.ImageGalleries)
                    {
                        if (image.ImageID == id)
                        {
                            file = Encoding.UTF8.GetString(image.ImageData).ToCharArray();
                        }
                    }
                }
            }
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "74106f204fd0492e9b7d93aba5b3e022");

            var uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?" + queryString;

            HttpResponseMessage response;
            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(file);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                return response;
            }
        }
        
    }
}