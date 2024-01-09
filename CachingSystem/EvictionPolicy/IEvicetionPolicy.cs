namespace CachingSystem.EvictionPolicy
{
    public interface IEvicetionPolicy<Key>
    {
        public Key Evict();
        public void KeyAccessed(Key key);
    }
}