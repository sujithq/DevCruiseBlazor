using System.Collections;

namespace DevCruise.Blazor.Shared
{
    public static class EnumerableExtensions
    {
        public static bool Any(this IEnumerable e) => e.GetEnumerator().MoveNext();

        public static T FirstOrDefault<T>(this IEnumerable e)
        {
            var enumerator = e.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return (T)enumerator.Current;
            }
            return default(T);
        }
    }

}
