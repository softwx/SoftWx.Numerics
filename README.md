# SoftWx.Numerics
##### C# library of math extensions to .Net numeric types
NuGet package at https://www.nuget.org/packages/SoftWx.Numerics/

Currently contains bit fiddling, base 2 math, general math, and prime number math methods for the 8 built-in integer types (byte, sbyte, ushort, short, uint, int, ulong, and long), and the SoftWx.Numerics.UInt128 type. The library originally started with some blog posts (http://blog.softwx.net/2013/05/miller-rabin-primality-test-in-c.html) on deterministic Miller Rabin prime testing.
This github library is meant to replace and improve the code that went with those blog posts. To run the Profile project included in this repository's solution, you'll need to bring in the NuGet package SoftWx.Diagnostics.

This is currently a work in progress. Still to do: add unit tests for prime related methods.

Classes:
* BitMath - optimized bit fiddling methods for integer types
  * LowBit - Returns the least significant set bit
  * HighBit - Returns the most significant set bit
  * LowBitPosition - Returns the least significant set bit position
  * HighBitPosition - Returns the most significant set bit position
  * TrailingZeroBits - Returns the count of trailing zero bits
  * LeadingZeroBits - Returns the count of leading zero bits
  * SignificantBits - Returns the number of bit positions up to and including the most significant set bit
  * BitCount - Returns the count of set bits
  * ReverseBits - Returns the specified value with all bits reversed
* Base2Math - optimized log and power of 2 methods for integer types 
  * Log2 - Returns the integer logarithm base 2 (Floor(Log2(value)))
  * IsPowerOf2 - Determines if the specified value is a power of 2
  * PowerOf2Floor - Returns the nearest power of 2 that's equal or less than the specified value
  * PowerOf2Ceiling - Returns the nearest power of 2 that's equal or greater than the specified value
* Math - optimized general math methods, similar to those in .Net's Math class
  * AbsU - Returns the absolute value of the specified signed value as a corresponding unsigned type, without overflow
  * MulMod - Returns the product of two values, modulus a third value
  * ModPow - Returns a value raised to a specified value, modulus a third value
* PrimeMath - optimized methods related to prime numbers
  * Gcd - Computes the greatest common divisor of two values
  * IsCoprime - Determines if the specified values are coprime to each other
  * NearestCoprimeFloor - Computes the nearest number less than or equal to the specified start value that is coprime to another specified value
  * NearestCoprimeCeiling - Computes the nearest number greater than or equal to the specified start value that is coprime to another specified value
  * IsPrime - Determines if the specified value is a prime number
  * NearestPrimeFloor - Computes the prime number nearest, but not greater than the specified start value
  * NearestPrimeCeiling - Computes the prime number nearest, but not smaller than the specified start value
* UInt128 - Represents 128 bit unsigned integers.
  * Multiply(ulong,ulong) - Computes the 128 bit product of two 64 bit unsigned integers
  * Square(ulong,ulong) - Computes the 128 bit product of squaring a 64 bit unsigned integer
  * IsULong - Determines if the UInt128 value is less than or equal to UInt64.MaxValue
  * Low - Returns the lower 64 bits of the UInt128 value
  * High - Returns the upper 64 bits of the UInt128 value
  * Equals - Returns a value indicating whether this instance is equal to a specified object
  * GetHashCode - Returns the hash code for this instance
  * ToString - Simple ToString implementation
  * implicit cast - ulong to UInt128
  * explicit cast - UInt128 to ulong
  * operators - equality(==), inequality(!=), greater than(>), less than(<), greater than or equal(>=), less than or equal(<=), bitwise complement(~), bitwise and(&), bitwise or(|), left shift(<<), right shift(>>), addition(+), subtraction(-), increment(++), decrement(--), multiplication(*), division(/), modulus(%)
  