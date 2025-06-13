using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;
using Newtonsoft.Json;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public string AppSettings { get; private set; }

        public ISerializationService SerializationService { get; private set; }

        public abstract string Path { get; set; }

        public abstract int LastId { get; set; }

        public GenericRepository(string appSettings, ISerializationService serializationService)
        {
            AppSettings = appSettings;
            SerializationService = serializationService;
        }
        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Append(source), Formatting.Indented));
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Where(x => x.Id != id), Formatting.Indented));
            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            ////if (!File.Exists(Path))
            ////{
            ////    File.WriteAllText(Path, "[]");
            ////}

            ////var json = File.ReadAllText(Path);

            ////if (string.IsNullOrWhiteSpace(json))
            ////{
            ////    File.WriteAllText(Path, "[]");
            ////    json = "[]";
            ////}

            ////return JsonConvert.DeserializeObject<List<TSource>>(json)!;
            
            //..
            
            //if (!File.Exists(Path))
            //{
            //    return new List<TSource>();
            //}

            //if (!File.Exists(Path))
            //{
            //    File.WriteAllText(Path, "[]");
            //}

            //var file = File.ReadAllText(Path);

            //if (string.IsNullOrWhiteSpace(file))
            //{
            //    File.WriteAllText(Path, "[]");
            //    file = "[]";
            //}

            //return serializationService.Deserialize<List<TSource>>(Path) ?? new List<TSource>();

            //return JsonConvert.DeserializeObject<List<TSource>>(json)!;

            return SerializationService.Deserialize<IEnumerable<TSource>>(Path);
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Select(x => x.Id == id ? source : x), Formatting.Indented));

            return source;
        }
        
        public abstract void ShowInfo(TSource source);

        protected abstract void SaveLastId();

        //protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath))!;

        protected Repository ReadFromAppSettings()
        //{
        //    //Rewrite json file using constants pathes
        //    string json = File.ReadAllText(Constants.AppSettingsPath);
        //    dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        //    jsonObj["Database"]["Doctors"]["Path"] = Constants.DoctorsPath;
        //    jsonObj["Database"]["Patients"]["Path"] = Constants.PatientsPath;
        //    jsonObj["Database"]["Appointments"]["Path"] = Constants.AppointmentsPath;
        //    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        //    File.WriteAllText(Constants.AppSettingsPath, output);

        //    return JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath))!;
        //}
        {
            return SerializationService.Deserialize<Repository>(AppSettings);
        }
        
        public int GetLastId() => LastId;
    }
}
