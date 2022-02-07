using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Text.Json;
using System.Threading.Tasks;
using HelloSerialization.HAlliHAllo;

namespace HelloSerialization
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Person person = new Person()
            {
                Vorname = "Max",
                Nachname = "Mustermann",
                Alter = 33,
                Kontostand = 1_000_000,
                KreditLimit = 5_000_000
            };

            #region CSV Serializer mit Erweiterungsmethoden (Extention-Methods)


            person.Speichern("Person.csv");

            person = new Person();
            person.Laden("Person.csv");

            #endregion




            Stream stream = null;

            //using System.Text.Json;
            //string jsonString1 = System.Text.Json.JsonSerializer.Serialize(person);

            //person.Speichern("Person.csv");

            #region JSON 
            //using Newtonsoft.Json;
            string jsonString2 = JsonConvert.SerializeObject(person);
            await File.WriteAllTextAsync("Person.json",jsonString2);

            jsonString2 = string.Empty;
            jsonString2 = await File.ReadAllTextAsync("Person.json");
            Person geladenePerson3 = JsonConvert.DeserializeObject<Person>(jsonString2);
            #endregion

            #region XML
            //Schreiben
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, person);
            stream.Close();

            //Lesen
            stream = File.OpenRead("Person.xml");
            Person gelandePerson2 = (Person)xmlSerializer.Deserialize(stream);
            stream.Close();
            #endregion

            #region Binary
            ////Schreiben
            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //stream = File.OpenWrite("Person.bin");
            //binaryFormatter.Serialize(stream, person);
            //stream.Close();

            ////Lesen
            //stream = File.OpenRead("Person.bin");
            //Person geladenePerson = (Person)binaryFormatter.Deserialize(stream);
            //stream.Close();





            //Schreiben
            try
            {
                BinaryFormatter binaryFormatter1 = new BinaryFormatter();
                stream = File.OpenWrite("Person.bin"); //Öffne oder Erstelle Datei zum schreiben und binde den Stream an 
                binaryFormatter1.Serialize(stream, person); //Schreiben die Instanz 'person' in Person.bin
            }
            catch (SerializationException ex)
            {
                Debug.WriteLine(ex.ToString()); //Message + StackTrace
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally //Im Normal oder im Fehlerfall (Exception->CatchBlock)  -> Finally wird immer ausgeführt und stellt sicher, dass der Stream den FileHanler von Person.bin nimmt
            {
                stream.Close();
            }

            //Lesen
            if (!File.Exists("Person.bin"))
                throw new FileNotFoundException();



            try
            {
                stream = null;
                stream = File.OpenRead("Person.bin");

                BinaryFormatter binaryFormatter2 = new BinaryFormatter();
                Person person1 = (Person)binaryFormatter2.Deserialize(stream);
            }
            catch (SerializationException ex)
            {
                Debug.WriteLine(ex.ToString()); //Message + StackTrace
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            #endregion
        }
    }

    //[Serializable] //Serialization für BinaryFormatter -> Person ist wegschreibbar 
    public class Person
    {
        
        public string Vorname { get; set; } = string.Empty;
        public string Nachname { get; set; } = string.Empty;
        public int Alter { get; set; }

        //Bei Properties -> [field: NonSerialized]
        //[field: NonSerialized] -> in Verwendung des Binary Formatters
        [XmlIgnore]


        [JsonIgnore]
        public decimal Kontostand { get; set; }


        //Bei public Variablen ->  [NonSerialized]
        //[NonSerialized]
        [XmlIgnore]
        [JsonIgnore]
        public decimal KreditLimit;


        //private int wohnort;

        //public int Wohnort
        //{
        //    get { return wohnort; }
        //    set { wohnort = value; }    
        //}
    }
}
