using System;

namespace Generators;

public enum AverageBehavior : byte
{
    ReturnAverageOfAvailableNumbers = 0,
    ThrowException,
    ReturnNaN,
}
