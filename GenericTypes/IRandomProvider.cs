// ---- C# II (Dor Ben Dor) ----
//         Amit Breiman
// -----------------------------

namespace GenericTypes
{
    interface IRandomProvider<T> where T : IComparable<T>
    {
        public T GetRandom();

    }
}
