using System;
using WolleWinkel.CrossCutting.Interfaces;

namespace WolleWinkel.Infrastructure
{
    public class DateTime:IDateTime
    {
        public DateTimeOffset DtoNow => DateTimeOffset.Now;
        public System.DateTime DtNow => System.DateTime.Now;
    }
}