using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HybridiProjekti.Models
{
    internal class ItemsDatabase
    {
        // Fetches items from the data.json file, creates and empty list if the file does not exist
        public async static Task<IEnumerable<Item>> GetItems()
        {
            
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "data.json");

            try
            {
               
                if (!File.Exists(filePath))

                {   // Create an empty list and save it as the default content
                    var defaultItems = new List<Item>(); 
                    JsonSerializerOptions writeOptions = new JsonSerializerOptions

                    {
                        WriteIndented = true
                    };

                    string defaultJson = JsonSerializer.Serialize(defaultItems, writeOptions);
                    await File.WriteAllTextAsync(filePath, defaultJson);
                    return [];
                }
                else
                {
                    //Read the file and deserialize its content
                    using FileStream stream = File.OpenRead(filePath);
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true 
                    };

                    // Deserialize the JSON stream directly to a result of type IEnumerable<Item>
                    IEnumerable<Item>? result = await JsonSerializer.DeserializeAsync<IEnumerable<Item>>(stream, options);
                    Console.WriteLine(filePath + ": file read successfully");

                    // Return the result or an empty collection if the result is null
                    return result ?? Enumerable.Empty<Item>();
                }

            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"A read error occurred:  {ex.Message}");
                return [];
            }


        }
        // Writes the items to the data.json file
        public async static Task WriteItems(ObservableCollection<ViewModels.ItemViewModel> items)
        {

            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            // Serialize the items received as a parameter to JSON string
            string json = System.Text.Json.JsonSerializer.Serialize(items, options);

            
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "data.json");

            try
            {
                
                using StreamWriter writer = new StreamWriter(filePath);
                await writer.WriteAsync(json);
            }
            catch (IOException ioEx)
            {
                
                Console.WriteLine($"I/O error occurred:  {ioEx.Message}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                
                Console.WriteLine($"Permission error:  {uaEx.Message}");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred:  {ex.Message}");
            }
        }
    }
}
