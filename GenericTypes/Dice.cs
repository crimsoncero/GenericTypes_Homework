// ---- C# II (Dor Ben Dor) ----
//         Amit Breiman
// -----------------------------

namespace GenericTypes
{
    class Dice<T> : IRandomProvider<T> where T : IComparable<T>
    {
        public List<T> Base { get; private set; }

        public Dice(List<T> @base)
        {
            Base = @base;
        }

        public virtual T GetRandom()
        {
            return Base[Random.Shared.Next(0, Base.Count)];
        }
    }

    class Dice : Dice<int>
    {
        public uint Scalar { get; private set; }
        public int Modifier { get; private set; }

        public Dice(List<int> @base, uint scalar, int modifier) : base(@base)
        {
            Scalar = scalar;
            Modifier = modifier;
        }

        public Dice(uint @base, uint scalar, int modifier) : base(Enumerable.Range(1, (int)@base).ToList())
        {
            Scalar = scalar;
            Modifier = modifier;
        }

        public override int GetRandom()
        {
            int sum = Modifier;

            for (int i = 0; i < Scalar; i++)
            {
                sum += Base[Random.Shared.Next(0, Base.Count)];
            }

            return sum;
        }


    }

}
