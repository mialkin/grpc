namespace Grpc.Api.Protos;

public partial class Money
{
    public Money(long whole, int fraction)
    {
        Whole = whole;
        Fraction = fraction;
    }

    private const decimal FractionFactor = 100;

    public static implicit operator decimal(Money amount)
        => amount.Whole + amount.Fraction / FractionFactor;

    public static implicit operator Money(decimal value)
    {
        var whole = decimal.ToInt64(value);
        var fraction = decimal.ToInt32((value - whole) * FractionFactor);
        return new Money(whole, fraction);
    }
}
