namespace CachingSystem.Storage
{
    public interface IStorage<Key, Value>
    {
        public void Add(Key key, Value value);

        public void Remove(Key key);

        public Value Get(Key key);
    }
}