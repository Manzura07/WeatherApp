class Program
{
    const string KEY = "3fe3618da3f5d90fb993d05aa32c0afc";

    static async Task Main()
    // -> Main metodi async Task Main() ko‘rinishida o‘zgartirildi, bu esa await ni ishlatishga imkon beradi.
    {
        Console.Write("Davlat nomini kiriting: ");
        string country = Console.ReadLine()!;

        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={country}&appid={KEY}&units=metric";
                // -> units=metric parametri qo‘shilgan celsiy bo‘yicha harorat chiqadi.
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption: {ex.Message}");
            }
        }
    }
}
