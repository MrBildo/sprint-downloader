using System.Text.Json;
using System.Text.Json.Serialization;

namespace MrBildo.SprintDownloader.Services
{
    public enum WiiURegions
    {
        Japan = 0x01,
        USA = 0x02,
        Europe = 0x04,
        USA_Europe = USA | Europe,
        Unknown = 0x07,
        China = 0x10,
        Korea = 0x20,
        Taiwan = 0x40
    }

    public enum WiiUCategories
    {
        Game = 0x00050000,
        Demo = 0x00050002,
        SystemApp = 0x00050010,
        SystemData = 0x0005001B,
        SystemApplet = 0x00050030,
        VwiiIOS = 0x00000007,
        VwiiSystemApp = 0x00070002,
        VwiiSystem = 0x00070008,
        DLC = 0x0005000C,
        Update = 0x0005000E
    }

    public class WiiUTitle
    {
        public WiiUTitle(ulong id, string name, WiiURegions region, WiiUCategories category)
        {
            Id = id.ToString("X16");
            Name = name;
            Category = category;
            Region = region;
        }

        [JsonConstructor]
        public WiiUTitle(string id, string name, WiiURegions region, WiiUCategories category)
        {
            Id = id;
            Name = name;
            Category = category;
            Region = region;
        }
        public string Id { get; }

        public string Name { get; }

        public WiiUCategories Category { get; }

        public WiiURegions Region { get; }
    }

    public interface IWiiUTitleLoader
    {
        IAsyncEnumerable<WiiUTitle> LoadTitlesAsync(string pathFilename);
    }

    public class WiiUTitleLoader : IWiiUTitleLoader
    {
        public async IAsyncEnumerable<WiiUTitle> LoadTitlesAsync(string pathFilename)
        {
            using var stream = new FileStream(pathFilename, FileMode.Open, FileAccess.Read, FileShare.Read);

            await foreach (var title in JsonSerializer.DeserializeAsyncEnumerable<WiiUTitle>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IncludeFields = true }))
            {
                if (title is not null)
                {
                    yield return title;
                }
            }
        }
    }
}

/*
            var file = @"C:\Users\mrbil\OneDrive\Desktop\titles.txt";

            var data = File.ReadAllText(file);

            var entries = data.Split("},", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            var titles = new List<WiiUTitle>();

            foreach (var entry in entries)
            {
                var properties = entry.Split(",.", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                var name = properties[0].ValueBetween("\"", "\"")?.Trim();
                var id = Convert.ToUInt64(properties[1].Replace("tid=0x", "").Replace(",", "").Trim(), 16);
                var region = Convert.ToInt32(properties[2].Replace("region=", "").Replace(",", "").Trim());
                var key = Convert.ToInt32(properties[3].Replace("key=", "").Trim());

                titles.Add(new WiiUTitle(id, name ?? string.Empty, (WiiURegions)region, (WiiUCategories)(int)(id >> 32)));
            }

            // write everything to JSON
            var json = JsonSerializer.Serialize(titles, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(@"C:\Users\mrbil\OneDrive\Desktop\titles.json", json); 
 */
