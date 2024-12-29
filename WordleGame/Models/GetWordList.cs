using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WordleGame
{
    public class GetWordList
    {
            private readonly string fileName = "words.txt";
            private readonly HttpClient httpClient;

            public GetWordList()
            {
                httpClient = new HttpClient();
            }

            
            //Ensures the word list is available locally by downloading it if necessary.
            
            public async Task EnsureWordListExistsAsync()
            {
                string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                if (!File.Exists(filePath))
                {
                    await DownloadAndSaveWordsAsync(filePath);
                }
            }

            
            //Download the word list from the specified URL and saves it to a local file
            private async Task DownloadAndSaveWordsAsync(string filePath)
            {
                try
                {
                    string url = "https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt";

                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();

                    // Save to local file
                    await File.WriteAllTextAsync(filePath, content);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Failed to download or save the word list.", ex);
                }
            }

            
            /// Reads the words from the local file.
            public async Task<List<string>> LoadWordsAsync()
            {
                string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                if (File.Exists(filePath))
                {
                    string content = await File.ReadAllTextAsync(filePath);
                    return new List<string>(
                        content.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                               .Select(word => word.Trim()));
                }
                else
                {
                    throw new FileNotFoundException("Word list file not found.");
                }
            }
        }
    }

   
