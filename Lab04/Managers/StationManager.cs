using Lab04.Tools.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04.Managers
{
    internal static class StationManager
    {
        private static IPersonStorage _personStorage;
        private static IPersonStorage _cachedStorage;
        internal static IPersonStorage PersonStorage
        {
            get { return _personStorage; }
        }

        internal static IPersonStorage CachedStorage
        {
            get { return _cachedStorage; }
        }

        internal static void Initialize(IPersonStorage personStorage)
        {
            _personStorage = personStorage;
        }

        internal static void InitializeCache(IPersonStorage personStorage)
        {
            _cachedStorage = personStorage;
        }

    }
}
