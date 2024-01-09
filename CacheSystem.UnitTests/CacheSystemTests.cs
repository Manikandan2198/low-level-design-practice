using CachingSystem;
using CachingSystem.Factory;
using NUnit.Framework;

namespace CacheSystem.UnitTest
{
    [TestFixture]
    public class CacheSystemTests
    {
        private Cache<int, string> cache;
        [SetUp]
        public void SetUp()
        {
            cache = new CacheFactory().DefaultCache<int, string>(3);
        }

        [Test]
        public void Put_PutAKeyToCache_KeyFound()
        {
            cache.Put(1, "One");
            var result = cache.Get(1);
            Assert.AreEqual(result, "One");
        }

        [Test]
        public void Get_GetAExistingKey_KeyFound()
        {
            cache.Put(1, "One");
            var result = cache.Get(1);
            Assert.AreEqual(result, "One");
        }

        [Test]
        public void Get_GetANonExistingKey_KeyNotFound()
        {
            var result = cache.Get(2);
            Assert.IsNull(result);
        }

        [Test]
        public void Get_EvictLRU_ReturnsNull()
        {
            cache.Put(1, "One");
            cache.Put(2, "Two");
            cache.Put(3, "Three");
            cache.Get(1);
            cache.Get(2);
            cache.Put(4, "Four");
            var result = cache.Get(3);
            Assert.IsNull(result);
        }

        [Test]
        public void Get_NotEvictNotLRU_ReturnsNonNull()
        {
            cache.Put(1, "One");
            cache.Put(2, "Two");
            cache.Put(3, "Three");
            cache.Get(1);
            cache.Get(2);
            cache.Put(4, "Four");
            var result = cache.Get(2);
            Assert.AreEqual(result, "Two");
        }

    }
}