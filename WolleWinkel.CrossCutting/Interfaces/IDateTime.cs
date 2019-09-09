using System;

namespace WolleWinkel.CrossCutting.Interfaces
{
    public interface IDateTime
    {
        DateTimeOffset DtoNow { get; }
        DateTime DtNow { get; }
    }
}