﻿using System.Numerics;

namespace KozzionMathematics.Algebra
{
    // Symbolic algebras are symetric and infinitly precise
    public interface IAlgebraField<DomainType>
    {
        DomainType AddIdentity { get; }

        DomainType MultiplyIdentity { get; }

        DomainType Add(DomainType value_0, DomainType value_1);

        DomainType Subtract(DomainType value_0, DomainType value_1);

        DomainType Multiply(DomainType value_0, DomainType value_1);

        DomainType Divide(DomainType value_0, DomainType value_1);

        DomainType ToDomain(int value);

        DomainType ToDomain(BigInteger value);

        int ToInt32(DomainType value);

        BigInteger ToBigInteger(DomainType value);
    }
}
