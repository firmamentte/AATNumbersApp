using AATNumbersApp.Data.Entities;
using System.Text.Json;
using System.Xml.Serialization;

namespace AATNumbersApp.BLL.BLLClasses
{
    public class DownloadBLL
    {
        private readonly NumberBLL NumberBLL;

        public DownloadBLL()
        {
            NumberBLL = new NumberBLL();
        }

        public async Task<byte[]> CreateXMLFile()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "wwwroot", "xmlFiles", $"{Guid.NewGuid()}.xml");

            using (var writer = new StreamWriter(path))
            {
                new XmlSerializer(typeof(List<Number>)).Serialize(writer, await NumberBLL.GetNumbers());
            }

            return await File.ReadAllBytesAsync(path);
        }

        public async Task<byte[]> CreateBinFile()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "wwwroot", "binFiles", $"{Guid.NewGuid()}.bin");

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, await NumberBLL.GetNumbers());
            }

            return await File.ReadAllBytesAsync(path);
        }
    }
}
