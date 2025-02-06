using System;
using System.Diagnostics;

namespace VirtualWallet.Domain.Helpers;

public static class DateTimeHelper
{
    [DebuggerStepThrough]
    public static DateTime NewDateTime()
    {
        return DateTimeOffset.Now.UtcDateTime;
    }

    [DebuggerStepThrough]
    public static DateTime NewDate()
    {
        return DateTimeOffset.Now.Date;
    }
}