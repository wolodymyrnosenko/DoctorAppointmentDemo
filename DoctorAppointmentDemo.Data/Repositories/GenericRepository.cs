using System.Xml.Serialization;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;

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
        
        public GenericRepository() { }//....

        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            var sources = GetAll().Append(source).ToList();

            SerializationService.Serialize(Path, sources);

            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;

            SerializationService.Serialize(Path, GetAll().Where(x => x.Id != id));

            //List<TSource> getAll = SerializationService.Deserialize<List<TSource>>(Path);
            //List<TSource> allWithoutDeleted = new List<TSource>();
            //foreach (TSource source in getAll)
            //{
            //    if (source.Id != id)
            //        allWithoutDeleted.Add(source);
            //}
            //SerializationService.Serialize(Path, allWithoutDeleted);

            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            //return SerializationService.Deserialize<List<TSource>>(Path) ?? new List<TSource>();
            //return JsonConvert.DeserializeObject<List<TSource>>(json)!;

            return SerializationService.Deserialize<List<TSource>>(Path);//....
            //return SerializationService.Deserialize<IEnumerable<TSource>>(Path);
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;
            SerializationService.Serialize(Path, GetAll().Select(x => x.Id == id ? source : x));
            return source;
        }
        
        public abstract void ShowInfo(TSource source);

        protected abstract void SaveLastId();

        protected Repository ReadFromAppSettings()
        {
            return SerializationService.Deserialize<Repository>(AppSettings);
        }
        
        public int GetLastId() => LastId;
    }
}
