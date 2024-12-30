using System.IO;
using UnityEngine;

namespace PdUtils.Dao.Impls
{
    public abstract class ALocalStorageJsonDao<T> : IDao<T>
    {
        private readonly FileInfo _fileInfo;

        public ALocalStorageJsonDao(string fileName)
        {
            _fileInfo = new FileInfo(Path.Combine(Application.persistentDataPath, fileName));
        }

        public bool Exist() => _fileInfo.Exists;

        public void Save(T obj)
        {
            if (!_fileInfo.Exists)
                _fileInfo.Directory.Create();

            var json = JsonUtility.ToJson(obj);
            File.WriteAllText(_fileInfo.FullName, json);
        }

        public T Load()
        {
            var json = File.ReadAllText(_fileInfo.FullName);
            return JsonUtility.FromJson<T>(json);
        }
    }
}