using System.IO;
using BasketballGame.Core.DTO;

namespace BasketballGame.Core.Persistence
{
    public class SaveService
    {
        private readonly string _path;
        public SaveService(string path) { _path = path; }

        public void Save(CareerSnapshot snapshot)
        {
            var json = JsonUtil.ToJson(snapshot);
            File.WriteAllText(_path, json);
        }

        public CareerSnapshot? Load()
        {
            if (!File.Exists(_path)) return null;
            var json = File.ReadAllText(_path);
            return JsonUtil.FromJson<CareerSnapshot>(json);
        }
    }
}
