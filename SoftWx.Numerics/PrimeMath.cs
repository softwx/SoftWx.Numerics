// Copyright ©2012-2016 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett
namespace SoftWx.Numerics {
    /// <summary>
    /// Numeric extension methods for math operations related to prime numbers
    /// for integer numeric types. 
    /// </summary>
    /// <remarks>Methods for byte, sbyte, ushort and short are not included,
    /// as there is little or no advantage that can be gained by their smaller
    /// size, and implementations would merely be wrappers that upcast to uint
    /// and int. Callers can do that themselves, and it will even be slightly
    /// faster too. Examples:
    /// byte b1, b2, br; b1 = 100; b2 = 101;
    /// br = (byte)PrimeMath.Gcd(b1, b2); //will implicitly upcast to uint
    /// or
    /// br = (byte)((uint)b1).Gcd(b2)</remarks>
    public static class PrimeMath {
        /// <summary>Computes the greatest common divisor of two values.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The other value.</param>
        /// <returns>The greatest common divisor of the two values.</returns>
        public static uint Gcd(this uint value1, uint value2) {
            uint t;
            if (value1 > value2) {
                t = value1;
                value1 = value2;
                value2 = t;
            }
            while (value1 > 1) {
                t = value2;
                value2 = value1;
                value1 = t % value1;
            }
            if (value1 == 0) return value2;
            return 1u;
        }

        /// <summary>Computes the greatest common divisor of two values.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The other value.</param>
        /// <returns>The greatest common divisor of the two values.</returns>
        public static int Gcd(this int value1, int value2) {
            if ((value1 | value2) < 0) return (int)Gcd(value1.AbsU(), value2.AbsU());
            return (int)Gcd((uint)value1, (uint)value2);
        }

        /// <summary>Computes the greatest common divisor of two values.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The other value.</param>
        /// <returns>The greatest common divisor of the two values.</returns>
        public static ulong Gcd(this ulong value1, ulong value2) {
            ulong t = value1 | value2;
            if ((uint)t == t) return Gcd((uint)value1, (uint)value2);
            if (value1 > value2) {
                t = value1;
                value1 = value2;
                value2 = t;
            }
            while (value1 > 1) {
                t = value1;
                if ((value2 >> 3) < t) {
                    while ((value2 -= t) > t) ;
                    value1 = value2;
                    value2 = t;
                } else {
                    if ((uint)value2 == value2) return Gcd((uint)value1, (uint)value2);
                    value1 = value2 % t;
                    value2 = t;
                }
            }
            if (value1 == 0) return value2;
            return 1;
        }

        /// <summary>Computes the greatest common divisor of two values.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The other value.</param>
        /// <returns>The greatest common divisor of the two values.</returns>
        public static long Gcd(this long value1, long value2) {
            if ((value1 | value2) < 0) return (long)Gcd(value1.AbsU(), value2.AbsU());
            return (long)Gcd((ulong)value1, (ulong)value2);
        }

        /// <summary>Computes the greatest common divisor of two values.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The other value.</param>
        /// <returns>The greatest common divisor of the two values.</returns>
        public static UInt128 Gcd(this UInt128 value1, UInt128 value2) {
            if ((value1.High | value2.High) == 0UL) return Gcd(value1.Low, value2.Low);
            UInt128 t;
            if (value1 > value2) {
                t = value1;
                value1 = value2;
                value2 = t;
            }
            while (value1 > 1) {
                t = value1;
                value1 = value2 - t;
                if (value1 >= t) {
                    value1 -= t;
                    if (value1 >= t) {
                        value1 -= t;
                        if (value1 >= t) {
                            if (value1.High != 0) value1 %= t;
                            else return Gcd((ulong)t, (ulong)value1);
                        }
                    }
                }
                value2 = t;
            }
            if (value1 == 0) return value2;
            return UInt128.One;
        }

        /// <summary>Determines if the specified values are coprime to each other.</summary>
        /// <param name="value1">The value to be tested.</param>
        /// <param name="value2">The other value to be tested.</param>
        /// <returns>True if the values are coprime to each other, otherwise, false.</returns>
        public static bool IsCoprime(this uint value1, uint value2) {
            // 25% of possible pairings are even num to even num so handle them
            // with a bit twiddle that's much faster than GCD function. If they
            // are both even, then they can't be coprime (2 is common divisor).
            // This works for 0 as well since only 1 and -1 are coprime to 0.
            return ((((value1 | value2) & 1) != 0)
                    && (Gcd(value1, value2) == 1));
        }

        /// <summary>Determines if the specified values are coprime to each other.</summary>
        /// <param name="value1">The value to be tested.</param>
        /// <param name="value2">The other value to be tested.</param>
        /// <returns>True if the values are coprime to each other, otherwise, false.</returns>
        public static bool IsCoprime(this int value1, int value2) {
            // 25% of possible pairings are even num to even num so handle them
            // with a bit twiddle that's much faster than GCD function. If they
            // are both even, then they can't be coprime (2 is common divisor).
            // This works for 0 as well since only 1 and -1 are coprime to 0.
            return ((((value1 | value2) & 1) != 0)
                    && (Gcd(value1, value2) == 1));
        }

        /// <summary>Determines if the specified values are coprime to each other.</summary>
        /// <param name="value1">The value to be tested.</param>
        /// <param name="value2">The other value to be tested.</param>
        /// <returns>True if the values are coprime to each other, otherwise, false.</returns>
        public static bool IsCoprime(this ulong value1, ulong value2) {
            // 25% of possible pairings are even num to even num so handle them
            // with a bit twiddle that's much faster than GCD function. If they
            // are both even, then they can't be coprime (2 is common divisor).
            // This works for 0 as well since only 1 and -1 are coprime to 0.
            return ((((value1 | value2) & 1) != 0)
                    && (Gcd(value1, value2) == 1));
        }

        /// <summary>Determines if the specified values are coprime to each other.</summary>
        /// <param name="value1">The value to be tested.</param>
        /// <param name="value2">The other value to be tested.</param>
        /// <returns>True if the values are coprime to each other, otherwise, false.</returns>
        public static bool IsCoprime(this long value1, long value2) {
            // 25% of possible pairings are even num to even num so handle them
            // with a bit twiddle that's much faster than GCD function. If they
            // are both even, then they can't be coprime (2 is common divisor).
            // This works for 0 as well since only 1 and -1 are coprime to 0.
            return ((((value1 | value2) & 1) != 0)
                    && (Gcd(value1, value2) == 1));
        }

        /// <summary>Determines if the specified values are coprime to each other.</summary>
        /// <param name="value1">The value to be tested.</param>
        /// <param name="value2">The other value to be tested.</param>
        /// <returns>True if the values are coprime to each other, otherwise, false.</returns>
        public static bool IsCoprime(this UInt128 value1, UInt128 value2) {
            // 25% of possible pairings are even num to even num so handle them
            // with a bit twiddle that's much faster than GCD function. If they
            // are both even, then they can't be coprime (2 is common divisor).
            // This works for 0 as well since only 1 and -1 are coprime to 0.
            return ((((value1.Low | value2.Low) & 1) != 0)
                    && (Gcd(value1, value2) == UInt128.One));
        }

        /// <summary>Computes the nearest number less than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range MinValue to start.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static uint NearestCoprimeFloor(this uint start, uint value2) {
            if (start == 0) return 0;
            if (value2 == 0) return 1;
            while (!IsCoprime(start, value2)) start--;
            return start;
        }

        /// <summary>Computes the nearest number less than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range MinValue to start.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static int NearestCoprimeFloor(this int start, int value2) {
            uint v1, v2;
            v2 = (value2 >= 0) ? (uint)value2 : value2.AbsU();
            if (start > 0) return (int)NearestCoprimeFloor((uint)start, v2);
            if ((value2 == 0) && (start < -1)) return 0;
            for (v1 = start.AbsU(); v1 <= (uint)(-(int.MinValue + 1)) + 1; v1++) {
                if (v1.IsCoprime(v2)) return -(int)v1;
            }
            return 0;
        }

        /// <summary>Computes the nearest number less than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range MinValue to start.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static ulong NearestCoprimeFloor(this ulong start, ulong value2) {
            if (start == 0) return 0;
            if (value2 == 0) return 1;
            while (!IsCoprime(start, value2)) start--;
            return start;
        }

        /// <summary>Computes the nearest number less than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range MinValue to start.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static long NearestCoprimeFloor(this long start, long value2) {
            ulong v1, v2;
            v2 = (value2 >= 0) ? (ulong)value2 : value2.AbsU();
            if (start > 0) return (long)NearestCoprimeFloor((ulong)start, v2);
            if ((v2 == 0) && (start < -1)) return 0;
            for (v1 = start.AbsU(); v1 <= (ulong)(-(long.MinValue + 1)) + 1; v1++) {
                if (v1.IsCoprime(v2)) return -(long)v1;
            }
            return 0;
        }

        /// <summary>Computes the nearest number less than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range MinValue to start.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static UInt128 NearestCoprimeFloor(this UInt128 start, UInt128 value2) {
            if (start == UInt128.Zero) return UInt128.Zero;
            if (value2 == UInt128.Zero) return UInt128.One;
            while (!IsCoprime(start, value2)) start--;
            return start;
        }

        /// <summary>Computes the nearest number greater than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range start to MaxValue.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static uint NearestCoprimeCeiling(this uint start, uint value2) {
            if ((value2 == 0) && (start > 1)) return 0;
            while (!IsCoprime(start, value2)) {
                if (start == uint.MaxValue) return 0;
                start++;
            }
            return start;
        }

        /// <summary>Computes the nearest number greater than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range start to MaxValue.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static int NearestCoprimeCeiling(this int start, int value2) {
            uint v1, v2;
            v2 = (value2 >= 0) ? (uint)value2 : value2.AbsU();
            if ((value2 == 0) && (start <= -1)) return -1;
            if ((start == int.MaxValue) || ((value2 == 0) && (start > 1))) return 0;
            v1 = start.AbsU();
            if (start >= 0) {
                while (!IsCoprime(v1, v2)) {
                    if (v1 == int.MaxValue) return 0;
                    v1++;
                }
                return (int)v1;
            } else {
                while (!IsCoprime(v1, v2)) v1--;
                return -(int)v1;
            }
        }

        /// <summary>Computes the nearest number greater than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range start to MaxValue.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static ulong NearestCoprimeCeiling(this ulong start, ulong value2) {
            if ((value2 == 0) && (start > 1)) return 0;
            while (!IsCoprime(start, value2)) {
                if (start == ulong.MaxValue) return 0;
                start++;
            }
            return start;
        }

        /// <summary>Computes the nearest number greater than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range start to MaxValue.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static long NearestCoprimeCeiling(this long start, long value2) {
            ulong v1, v2;
            v2 = (value2 >= 0) ? (ulong)value2 : value2.AbsU();
            if ((value2 == 0) && (start <= -1)) return -1;
            if ((start == int.MaxValue) || ((value2 == 0) && (start > 1))) return 0;
            v1 = start.AbsU();
            if (start >= 0) {
                while (!IsCoprime(v1, v2)) {
                    if (v1 == long.MaxValue) return 0;
                    v1++;
                }
                return (long)v1;
            } else {
                while (!IsCoprime(v1, v2)) v1--;
                return -(long)v1;
            }
        }

        /// <summary>Computes the nearest number greater than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range start to MaxValue.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static UInt128 NearestCoprimeCeiling(this UInt128 start, UInt128 value2) {
            if ((value2 == 0) && (start > 1)) return UInt128.Zero;
            while (!IsCoprime(start, value2)) {
                if (start == ulong.MaxValue) return UInt128.Zero;
                start++;
            }
            return start;
        }

        /// <summary>Determines if the specified value is a prime number.</summary>
        /// <remarks>This method chooses the best algorithm to use based on
        /// the magnitude of the specified value. For smaller values, a
        /// simple trial division algorithm is used. For larger values, a 
        /// deterministic version of the Miller-Rabin algorithm is used.</remarks>
        /// <param name="value">The value to be tested for primality.</param>
        /// <returns>True if the value is prime, otherwise, false.</returns>
        public static bool IsPrime(this uint value) {
            // take care of the simple cases of small primes and the
            // common composites having those primes as factors
            if ((value & 1) == 0) return value == 2;
            if ((value % 3) == 0) return value == 3;
            if ((value % 5) == 0) return value == 5;
            if ((value % 7) == 0) return value == 7;
            if (value == 1) return false;
            if (value < 1000000) {
                // for small values, faster to determine prime by trial division at this point
                for (uint i = 11, skip = 2; (i <= ushort.MaxValue) && (i * i <= value); i += skip, skip = 6 - skip) {
                    if (value % i == 0) return false;
                }
                return true;
            };
            // handle rest of small primes (checking more than this gives negligible benefit, on average)
            if (((value % 11) == 0) || ((value % 13) == 0) || ((value % 17) == 0) 
                || ((value % 19) == 0) || ((value % 23) == 0) || ((value % 29) == 0) 
                || ((value % 31) == 0) || ((value % 37) == 0) || ((value % 41) == 0) 
                || ((value % 43) == 0) || ((value % 47) == 0) || ((value % 53) == 0) 
                || ((value % 59) == 0) || ((value % 61) == 0) || ((value % 67) == 0) 
                || ((value % 71) == 0) || ((value % 73) == 0) || ((value % 79) == 0) 
                || ((value % 83) == 0) || ((value % 89) == 0) || ((value % 97) == 0) 
                ){
                return (value <= 97);
            }
            // for larger values, use deterministic Miller-Rabin with most efficient witness array for the value being tested
            return InternalMillerRabin(value, witnessSets[WitnessIndex(value)]);
        }

        /// <summary>Determines if the specified value is a prime number.</summary>
        /// <remarks>This method chooses the best algorithm to use based on
        /// the magnitude of the specified value. For smaller values, a
        /// simple trial division algorithm is used. For larger values, a 
        /// deterministic version of the Miller-Rabin algorithm is used.</remarks>
        /// <param name="value">The value to be tested for primality.</param>
        /// <returns>True if the value is prime, otherwise, false.</returns>
        public static bool IsPrime(this int value) {
            if (value <= 1) return false;
            return ((uint)value).IsPrime();
        }

        /// <summary>Determines if the specified value is a prime number.</summary>
        /// <remarks>This method chooses the best algorithm to use based on
        /// the magnitude of the specified value. For smaller values, a
        /// simple trial division algorithm is used. For larger values, a 
        /// deterministic version of the Miller-Rabin algorithm is used.</remarks>
        /// <param name="value">The value to be tested for primality.</param>
        /// <returns>True if the value is prime, otherwise, false.</returns>
        public static bool IsPrime(this ulong value) {
            // quick return for even numbers
            if ((value & 1) == 0) return value == 2;

            // for values in uint range, quicker to let that method handle them
            if (value == (uint)value) return ((uint)value).IsPrime();

            // take care of the simple cases of small primes and the
            // common composites having those primes as factors
            // (checking more than this gives negligible benefit, on average)
            if (((value % 3) == 0) || ((value % 5) == 0) || ((value % 7) == 0)
                || ((value % 11) == 0) || ((value % 13) == 0) || ((value % 17) == 0)
                || ((value % 19) == 0) || ((value % 23) == 0) || ((value % 29) == 0)
                || ((value % 31) == 0) || ((value % 37) == 0) || ((value % 41) == 0)
                || ((value % 43) == 0) || ((value % 47) == 0) || ((value % 53) == 0)
                || ((value % 59) == 0) || ((value % 61) == 0) || ((value % 67) == 0)) return false;
            if (((value % 71) == 0) || ((value % 73) == 0) || ((value % 79) == 0)
                || ((value % 83) == 0) || ((value % 89) == 0) || ((value % 97) == 0)
                || ((value % 101) == 0) || ((value % 103) == 0) || ((value % 107) == 0)
                || ((value % 109) == 0) || ((value % 113) == 0) || ((value % 127) == 0)
                || ((value % 131) == 0) || ((value % 137) == 0) || ((value % 139) == 0)
                || ((value % 149) == 0)) return false;

            // use deterministic Miller-Rabin with most efficient witness array for the value being tested
            return InternalMillerRabin(value, witnessSets[WitnessIndex(value)]);
        }

        /// <summary>Determines if the specified value is a prime number.</summary>
        /// <remarks>This method chooses the best algorithm to use based on
        /// the magnitude of the specified value. For smaller values, a
        /// simple trial division algorithm is used. For larger values, a 
        /// deterministic version of the Miller-Rabin algorithm is used.</remarks>
        /// <param name="value">The value to be tested for primality.</param>
        /// <returns>True if the value is prime, otherwise, false.</returns>
        public static bool IsPrime(this long value) {
            if (value <= 1) return false;
            return ((ulong)value).IsPrime();
        }

        /// <summary>Computes the prime number nearest, but not greater than the specified start value.
        /// Returns zero if the start value is less than 2.</summary>
        /// <param name="value">The largest value that is a prime number, and is less than
        /// or equal to the start value.</param>
        /// <returns>The nearest prime number that is less than or equal to the initial value.</returns>
        public static uint NearestPrimeFloor(this uint value) {
            switch (value) {
                case 0:
                case 1: return 0;
                case 2: return 2;
            }
            value = (value - 1) | 1; // all primes must be odd numbers, so start with odd number
            while (!IsPrime(value)) value -= 2;
            return value;
        }

        /// <summary>Computes the prime number nearest, but not greater than the specified start value.
        /// Returns zero if the start value is less than 2.</summary>
        /// <param name="value">The largest value that is a prime number, and is less than
        /// or equal to the start value.</param>
        /// <returns>The nearest prime number that is less than or equal to the initial value.</returns>
        public static int NearestPrimeFloor(this int value) {
            if (value < 2) return 0;
            return (int)(((uint)value).NearestPrimeFloor());
        }

        /// <summary>Computes the prime number nearest, but not greater than the specified start value.
        /// Returns zero if the start value is less than 2.</summary>
        /// <param name="value">The largest value that is a prime number, and is less than
        /// or equal to the start value.</param>
        /// <returns>The nearest prime number that is less than or equal to the initial value.</returns>
        public static ulong NearestPrimeFloor(this ulong value) {
            switch (value) {
                case 0:
                case 1: return 0;
                case 2: return 2;
            }
            if (value == (uint)value) return ((uint)value).NearestPrimeFloor();
            value = (value - 1) | 1; // all primes must be odd numbers, so start with odd number
            while (!IsPrime(value)) value -= 2;
            return value;
        }

        /// <summary>Computes the prime number nearest, but not greater than the specified start value.
        /// Returns zero if the start value is less than 2.</summary>
        /// <param name="value">The largest value that is a prime number, and is less than
        /// or equal to the start value.</param>
        /// <returns>The nearest prime number that is less than or equal to the initial value.</returns>
        public static long NearestPrimeFloor(this long value) {
            if (value < 2) return 0;
            return (long)(((ulong)value).NearestPrimeFloor());
        }

        /// <summary>Computes the prime number nearest, but not smaller than the specified start value.
        /// Returns zero if no solutions are in the range of start value to uint.MaxValue.</summary>
        /// <param name="value">The start value.</param>
        /// <returns>The nearest prime number that is greater than or equal to the initial value.</returns>
        public static uint NearestPrimeCeiling(this uint value) {
           const uint maxPrime = 4294967291;
           if (value <= 2) return 2;
            if (value > maxPrime) return 0;
            value |= 1; // all primes must be odd numbers, so start with odd number
            while (!IsPrime(value)) value += 2;
            return value;
        }

        /// <summary>Computes the prime number nearest, but not smaller than the specified start value.
        /// Because int.MaxValue is a prime number, all inputs will produced a valid prime.</summary>
        /// <param name="value">The start value.</param>
        /// <returns>The nearest prime number that is greater than or equal to the initial value.</returns>
        public static int NearestPrimeCeiling(this int value) {
            if (value <= 2) return 2;
            uint res = ((uint)value).NearestPrimeCeiling();
            return (res <= int.MaxValue) ? (int)res : 0;
        }

        /// <summary>Computes the prime number nearest, but not smaller than the specified start value.
        /// Returns zero if no solutions are in the range of start value to ulong.MaxValue.</summary>
        /// <param name="value">The start value.</param>
        /// <returns>The nearest prime number that is greater than or equal to the initial value.</returns>
        public static ulong NearestPrimeCeiling(this ulong value) {
            const ulong maxPrime = 18446744073709551557;
            if (value <= 2) return 2;
            if (value > maxPrime) return 0;
            value |= 1; // all primes must be odd numbers
            while (!IsPrime(value)) value += 2;
            return value;
        }

        /// <summary>Computes the prime number nearest, but not smaller than the specified start value.
        /// Returns zero if no solutions are in the range of start value to long.MaxValue.</summary>
        /// <param name="value">The start value.</param>
        /// <returns>The nearest prime number that is greater than or equal to the initial value.</returns>
        public static long NearestPrimeCeiling(this long value) {
            if (value <= 2) return 2;
            ulong res = ((ulong)value).NearestPrimeCeiling();
            return (res <= long.MaxValue) ? (long)res : 0;
        }

        /// <summary>
        // precomputed witnesses and the maximum value up to which they guarantee primality
        private static readonly ulong[] witnessMaxes = new ulong[] {
            341531, 1050535501, 350269456337, 55245642489451, 7999252175582851, 585226005592931977, ulong.MaxValue};
        private static readonly ulong[][] witnessSets = new ulong[][] {
            new ulong[] { 9345883071009581737 }, //341531
            new ulong[] { 336781006125, 9639812373923155 }, //1050535501
            new ulong[] { 4230279247111683200, 14694767155120705706, 16641139526367750375 }, //350269456337
            new ulong[] { 2, 141889084524735, 1199124725622454117, 11096072698276303650 }, //55245642489451
            new ulong[] { 2, 4130806001517, 149795463772692060, 186635894390467037, 3967304179347715805 }, //7999252175582851
            new ulong[] { 2, 123635709730000, 9233062284813009, 43835965440333360, 761179012939631437, 1263739024124850375 }, // 585226005592931977
            new ulong[] { 2, 325, 9375, 28178, 450775, 9780504, 1795265022 } //18446744073709551615 (ulong.MaxValue)
        };
        private static int WitnessIndex(uint value) {
            if (value > witnessMaxes[1]) return 2;
            return (value > witnessMaxes[0]) ? 1 : 0;
        }
        private static int WitnessIndex(ulong value) {
            if (value == (uint)value) return WitnessIndex((uint)value);
            int i = witnessMaxes.Length-1;
            while (value <= witnessMaxes[i]) i--;
            return i + 1;
        }

        /// <summary>Determines if the specified odd value, >= 3 value is a prime number, using the
        /// Miller-Rabin algorithm.</summary>
        /// <param name="value">The uint value (which must be odd and >=3) to be tested for primality.</param>
        /// <param name="witnesses">The witnesses to be used.</param>
        /// <returns>True if the value is prime, otherwise, false.</returns>
        private static bool InternalMillerRabin(uint value, ulong[] witnesses) {
            // compute n − 1 as (2^s)·d (where d is odd)
            uint valLessOne = value - 1;
            uint d = valLessOne / 2; // we know that value is odd and valLessOne is even, so unroll 1st iter of loop
            int s = 0;
            if ((d % 1) == 0) {
                s = d.TrailingZeroBits();
                d >>= s;
            }
            // test value against each witness
            for (int i = 0; i < witnesses.Length; i++) {
                uint a;
                ulong aL = witnesses[i];
                if (aL >= value) {
                    aL %= value;
                    if (aL < 2) continue;
                }
                a = (uint)aL; // safe to ignore upper 4 bytes, because we ensured a < the uint value
                if (a == valLessOne) continue;
                uint x = a.ModPow(d, value); // overflow safe version of x = Math.Pow(a, d) % value
                if (x == 1) continue;
                for (int r = 0; (x != valLessOne) && (r < s); r++) {
                    x = (uint)((x * (ulong)x) % value); // overflow safe version of x = (x * x) % value
                    if (x == 1) return false;
                }
                if (x != valLessOne) return false;
            }
            // witnesses confirm value is prime
            return true;
        }
        /// <summary>Determines if the specified odd value, >= 3 is a prime number, using the
        /// Miller-Rabin algorithm.</summary>
        /// <param name="value">The uint value (which must be odd and >=3) to be tested for primality.</param>
        /// <param name="witnesses">The witnesses to be used.</param>
        /// <returns>True if the value is prime, otherwise, false.</returns>
        private static bool InternalMillerRabin(ulong value, ulong[] witnesses) {
            // compute n − 1 as (2^s)·d (where d is odd)
            ulong valLessOne = value - 1;
            ulong d = valLessOne / 2; // we know that value is odd and valLessOne is even, so unroll 1st iter of loop
            int s = 0;
            if ((d % 1) == 0) {
                s = d.TrailingZeroBits();
                d >>= s;
            }
            // test value against each witness
            for (int i = 0; i < witnesses.Length; i++) {
                ulong a = witnesses[i];
                if (a >= value) {
                    a %= value;
                    if (a < 2) continue;
                }
                if (a == valLessOne) continue;
                ulong x = a.ModPow(d, value); // overflow safe version of x = Math.Pow(a, d) % value
                if (x == 1) continue;
                for (int r = 0; (x != valLessOne) && (r < s); r++) {
                    x = UInt128.Square(x).Mod(value);
                    if (x == 1) return false;
                }
                if (x != valLessOne) return false;
            }
            // witnesses confirm value is prime
            return true;
        }
    }
}
/*
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
