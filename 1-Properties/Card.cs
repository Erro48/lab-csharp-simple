using System.Collections.Generic;

namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        public string Seed { get; }
        public string Name { get; }
        public int Ordinal { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordinal)
        {
            Name = name;
            Ordinal = ordinal;
            Seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple) : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
            Name = tuple.Item1;
            Seed = tuple.Item2;
            Ordinal = tuple.Item3;
        }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            // TODO understand string interpolation
            return $"{this.GetType().Name}(Name={Name}, Seed={Seed}, Ordinal={Ordinal})";
        }

        // TODO generate Equals(object obj)

        // TODO generate GetHashCode()
        private sealed class SeedNameEqualityComparer : IEqualityComparer<Card>
        {
            public bool Equals(Card x, Card y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Seed == y.Seed && x.Name == y.Name;
            }

            public int GetHashCode(Card obj)
            {
                return HashCode.Combine(obj.Seed, obj.Name);
            }
        }

        public static IEqualityComparer<Card> SeedNameComparer { get; } = new SeedNameEqualityComparer();
    }
}
