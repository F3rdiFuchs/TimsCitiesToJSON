using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace worldcities4Tim
{
    class ReadThread
    {
        CityList list = new CityList();
        public void openFile()
        {
            if (File.Exists(@"c:\worldcitiespop.txt"))
            {
                City city = new City();
                int counter = 0;
                int citycount = 0;
                string text;
                int roundcount = 0;
                var fileStream = new FileStream("c:\\worldcitiespop.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }
                Console.WriteLine("Datei wurde gefunden");
                string word = "";
                foreach (char s in text)
                {
                    
                    if(s != 44)
                    {
                        word = word + s;
                    }
                    else
                    {
                        if(counter ==0)
                        {
                            city.country = word;
                            counter++;
                        }
                        else if (counter == 1)
                        {
                            city.city = word;
                            counter++;
                        }
                        else if (counter == 2)
                        {
                            city.accentCity = word;
                            counter++;
                        }
                        else if (counter ==3)
                        {

                            counter++;
                        }
                        else if (counter == 4)
                        {
                            Match match = Regex.Match(word, @"(?:\d*\.)?\d+", RegexOptions.IgnoreCase);
                            if (match.Success)
                            {
                                string newString = match.Value;
                                float parsedvalue = float.Parse(newString, CultureInfo.InvariantCulture);
                                city.latitude = parsedvalue;
                            }
                            else
                            {
                                throw new Exception();
                            }
                            counter++;
                        }
                        else if (counter == 5)
                        {
                            Match match = Regex.Match(word, @"(?:\d*\.)?\d+", RegexOptions.IgnoreCase);
                            if (match.Success)
                            {
                                string newString = match.Value;
                                float parsedvalue = float.Parse(newString, CultureInfo.InvariantCulture);
                                city.longitude = parsedvalue;
                            }
                            else
                            {
                                throw new Exception();
                            }
                            counter++;
                        }
                        if (counter == 6)
                        {
                            counter = 0;
                            

                            list.addCity(new City(city.country, city.city, city.accentCity, city.latitude, city.longitude));
                            citycount++;
                            Console.WriteLine(citycount);
                            city.country = "";
                            city.city = "";
                            city.accentCity = "";
                            city.latitude = 0.0f;
                            city.longitude = 0.0f;

                            if(citycount == 100000)
                            {
                                saveJson(roundcount);
                                Console.WriteLine("Datei "+ roundcount + "wurden angelegt");
                                roundcount++;
                                citycount = 0;
                            }
                        }
                        word = "";
                    }       
                }
            }
            else
            {
                Console.WriteLine("Datei wurde nicht gefunden");
                Console.ReadLine();
            }
        }

        public void saveJson(int count)
        {
            string json = JsonConvert.SerializeObject(list);
            StreamWriter writer = new StreamWriter("C:\\log" + count + ".json", true);
            writer.Write(json);
            list.clearList();
        }
    }
}
