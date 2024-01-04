

namespace SaveSystem.Abstract
{
    public interface ISaveSystem
    {
        void Save(SaveData saveData);
        SaveData Load();
    }
}
