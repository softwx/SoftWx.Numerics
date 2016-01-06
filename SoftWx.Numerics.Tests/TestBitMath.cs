// Copyright ©2015 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett
using NUnit.Framework;

namespace SoftWx.Numerics.Tests {
    /// <summary></summary>
    [TestFixture]
    public class TestBitMath {

        [Test]
        public void LowBit0ShouldReturn0() {
            Assert.AreEqual(0, BitMath.LowBit((byte)0), "byte");
            Assert.AreEqual(0, BitMath.LowBit((sbyte)0), "sbyte");
            Assert.AreEqual(0, BitMath.LowBit((ushort)0), "ushort");
            Assert.AreEqual(0, BitMath.LowBit((short)0), "short");
            Assert.AreEqual(0, BitMath.LowBit((uint)0), "uint");
            Assert.AreEqual(0, BitMath.LowBit((int)0), "int");
            Assert.AreEqual(0, BitMath.LowBit((ulong)0), "ulong");
            Assert.AreEqual(0, BitMath.LowBit((long)0), "long");
            Assert.AreEqual(UInt128.Zero, BitMath.LowBit((UInt128)0), "UInt128");
        }

        [Test]
        public void LowBit1ShouldReturn1() {
            Assert.AreEqual(1, BitMath.LowBit((byte)1), "byte");
            Assert.AreEqual(1, BitMath.LowBit((sbyte)1), "sbyte");
            Assert.AreEqual(1, BitMath.LowBit((ushort)1), "ushort");
            Assert.AreEqual(1, BitMath.LowBit((short)1), "short");
            Assert.AreEqual(1, BitMath.LowBit((uint)1), "uint");
            Assert.AreEqual(1, BitMath.LowBit((int)1), "int");
            Assert.AreEqual(1, BitMath.LowBit((ulong)1), "ulong");
            Assert.AreEqual(1, BitMath.LowBit((long)1), "long");
            Assert.AreEqual(UInt128.One, BitMath.LowBit((UInt128)1), "UInt128");
        }

        [Test]
        public void LowBitAllBitsSetShouldReturn1() {
            Assert.AreEqual(1, BitMath.LowBit((byte)0xff), "byte");
            Assert.AreEqual(1, BitMath.LowBit((sbyte)-1), "sbyte");
            Assert.AreEqual(1, BitMath.LowBit((ushort)0xffff), "ushort");
            Assert.AreEqual(1, BitMath.LowBit((short)-1), "short");
            Assert.AreEqual(1, BitMath.LowBit((uint)0xffffffff), "uint");
            Assert.AreEqual(1, BitMath.LowBit((int)-1), "int");
            Assert.AreEqual(1, BitMath.LowBit((ulong)0xffffffffffffffff), "ulong");
            Assert.AreEqual(1, BitMath.LowBit((long)-1), "long");
            Assert.AreEqual(UInt128.One, BitMath.LowBit(UInt128.MaxValue));
        }

        [Test]
        public void LowBitAllBitsMinus1ShouldReturn2() {
            Assert.AreEqual(2, BitMath.LowBit((byte)0xfe), "byte");
            Assert.AreEqual(2, BitMath.LowBit((sbyte)-2), "sbyte");
            Assert.AreEqual(2, BitMath.LowBit((ushort)0xfffe), "ushort");
            Assert.AreEqual(2, BitMath.LowBit((short)-2), "short");
            Assert.AreEqual(2, BitMath.LowBit((uint)0xfffffffe), "uint");
            Assert.AreEqual(2, BitMath.LowBit((int)-2), "int");
            Assert.AreEqual(2, BitMath.LowBit((ulong)0xfffffffffffffffe), "ulong");
            Assert.AreEqual(2, BitMath.LowBit((long)-2), "long");
            Assert.AreEqual((UInt128)2, BitMath.LowBit(new UInt128(0xffffffffffffffff, 0xfffffffffffffffe)), "UInt128");
        }

        [Test]
        public void LowBitByteShouldMatchWider() {
            byte v = byte.MinValue;
            while(true) {
                byte expected = BitMath.LowBit(v);
                Assert.AreEqual((sbyte)expected, BitMath.LowBit((sbyte)v), "sbyte");
                Assert.AreEqual((ushort)expected, BitMath.LowBit((ushort)v), "ushort");
                Assert.AreEqual((short)expected, BitMath.LowBit((short)v), "short");
                Assert.AreEqual((uint)expected, BitMath.LowBit((uint)v), "uint");
                Assert.AreEqual((int)expected, BitMath.LowBit((int)v), "int");
                Assert.AreEqual((ulong)expected, BitMath.LowBit((ulong)v), "ulong");
                Assert.AreEqual((long)expected, BitMath.LowBit((long)v), "long");
                Assert.AreEqual((UInt128)expected, BitMath.LowBit((UInt128)v), "UInt128");
                if (v == byte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void HighBit0ShouldReturn0() {
            Assert.AreEqual(0, BitMath.HighBit((byte)0), "byte");
            Assert.AreEqual(0, BitMath.HighBit((sbyte)0), "sbyte");
            Assert.AreEqual(0, BitMath.HighBit((ushort)0), "ushort");
            Assert.AreEqual(0, BitMath.HighBit((short)0), "short");
            Assert.AreEqual(0, BitMath.HighBit((uint)0), "uint");
            Assert.AreEqual(0, BitMath.HighBit((int)0), "int");
            Assert.AreEqual(0, BitMath.HighBit((ulong)0), "ulong");
            Assert.AreEqual(0, BitMath.HighBit((long)0), "long");
            Assert.AreEqual(UInt128.Zero, BitMath.HighBit((UInt128)0), "UInt128");
        }

        [Test]
        public void HighBit1ShouldReturn1() {
            Assert.AreEqual(1, BitMath.HighBit((byte)1), "byte");
            Assert.AreEqual(1, BitMath.HighBit((sbyte)1), "sbyte");
            Assert.AreEqual(1, BitMath.HighBit((ushort)1), "ushort");
            Assert.AreEqual(1, BitMath.HighBit((short)1), "short");
            Assert.AreEqual(1, BitMath.HighBit((uint)1), "uint");
            Assert.AreEqual(1, BitMath.HighBit((int)1), "int");
            Assert.AreEqual(1, BitMath.HighBit((ulong)1), "ulong");
            Assert.AreEqual(1, BitMath.HighBit((long)1), "long");
            Assert.AreEqual(UInt128.One, BitMath.HighBit((UInt128)1), "UInt128");
        }

        [Test]
        public void HighBitAllBitsSetShouldReturnMsb() {
            Assert.AreEqual(0x80, BitMath.HighBit((byte)0xff), "byte");
            Assert.AreEqual(sbyte.MinValue, BitMath.HighBit((sbyte)-1), "sbyte");
            Assert.AreEqual(0x8000, BitMath.HighBit((ushort)0xffff), "ushort");
            Assert.AreEqual(short.MinValue, BitMath.HighBit((short)-1), "short");
            Assert.AreEqual(0x80000000, BitMath.HighBit((uint)0xffffffff), "uint");
            Assert.AreEqual(int.MinValue, BitMath.HighBit((int)-1), "int");
            Assert.AreEqual(0x8000000000000000, BitMath.HighBit((ulong)0xffffffffffffffff), "ulong");
            Assert.AreEqual(long.MinValue, BitMath.HighBit((long)-1), "long");
            Assert.AreEqual(new UInt128(0x8000000000000000, 0), BitMath.HighBit(UInt128.MaxValue));
        }

        [Test]
        public void HighBitByteShouldMatchWider() {
            byte v = byte.MinValue;
            while (true) {
                byte expected = BitMath.HighBit(v);
                Assert.AreEqual((sbyte)expected, BitMath.HighBit((sbyte)v), "sbyte");
                Assert.AreEqual((ushort)expected, BitMath.HighBit((ushort)v), "ushort");
                Assert.AreEqual((short)expected, BitMath.HighBit((short)v), "short");
                Assert.AreEqual((uint)expected, BitMath.HighBit((uint)v), "uint");
                Assert.AreEqual((int)expected, BitMath.HighBit((int)v), "int");
                Assert.AreEqual((ulong)expected, BitMath.HighBit((ulong)v), "ulong");
                Assert.AreEqual((long)expected, BitMath.HighBit((long)v), "long");
                Assert.AreEqual((UInt128)expected, BitMath.HighBit((UInt128)v), "UInt128");
                if (v == byte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void LowBitPosition0ShouldReturnNeg1() {
            Assert.AreEqual(-1, BitMath.LowBitPosition((byte)0), "byte");
            Assert.AreEqual(-1, BitMath.LowBitPosition((sbyte)0), "sbyte");
            Assert.AreEqual(-1, BitMath.LowBitPosition((ushort)0), "ushort");
            Assert.AreEqual(-1, BitMath.LowBitPosition((short)0), "short");
            Assert.AreEqual(-1, BitMath.LowBitPosition((uint)0), "uint");
            Assert.AreEqual(-1, BitMath.LowBitPosition((int)0), "int");
            Assert.AreEqual(-1, BitMath.LowBitPosition((ulong)0), "ulong");
            Assert.AreEqual(-1, BitMath.LowBitPosition((long)0), "long");
            Assert.AreEqual(-1, BitMath.LowBitPosition((UInt128)0), "UInt128");
        }

        [Test]
        public void LowBitPosition1ShouldReturn0() {
            Assert.AreEqual(0, BitMath.LowBitPosition((byte)1), "byte");
            Assert.AreEqual(0, BitMath.LowBitPosition((sbyte)1), "sbyte");
            Assert.AreEqual(0, BitMath.LowBitPosition((ushort)1), "ushort");
            Assert.AreEqual(0, BitMath.LowBitPosition((short)1), "short");
            Assert.AreEqual(0, BitMath.LowBitPosition((uint)1), "uint");
            Assert.AreEqual(0, BitMath.LowBitPosition((int)1), "int");
            Assert.AreEqual(0, BitMath.LowBitPosition((ulong)1), "ulong");
            Assert.AreEqual(0, BitMath.LowBitPosition((long)1), "long");
            Assert.AreEqual(0, BitMath.LowBitPosition((UInt128)1), "UInt128");
        }

        [Test]
        public void LowBitPositionAllBitsSetShouldReturn0() {
            Assert.AreEqual(0, BitMath.LowBitPosition((byte)0xff), "byte");
            Assert.AreEqual(0, BitMath.LowBitPosition((sbyte)-1), "sbyte");
            Assert.AreEqual(0, BitMath.LowBitPosition((ushort)0xffff), "ushort");
            Assert.AreEqual(0, BitMath.LowBitPosition((short)-1), "short");
            Assert.AreEqual(0, BitMath.LowBitPosition((uint)0xffffffff), "uint");
            Assert.AreEqual(0, BitMath.LowBitPosition((int)-1), "int");
            Assert.AreEqual(0, BitMath.LowBitPosition((ulong)0xffffffffffffffff), "ulong");
            Assert.AreEqual(0, BitMath.LowBitPosition((long)-1), "long");
            Assert.AreEqual(0, BitMath.LowBitPosition(UInt128.MaxValue));
        }

        [Test]
        public void LowBitPositionAllBitsMinus11ShouldReturn1() {
            Assert.AreEqual(1, BitMath.LowBitPosition((byte)0xfe), "byte");
            Assert.AreEqual(1, BitMath.LowBitPosition((sbyte)-2), "sbyte");
            Assert.AreEqual(1, BitMath.LowBitPosition((ushort)0xfffe), "ushort");
            Assert.AreEqual(1, BitMath.LowBitPosition((short)-2), "short");
            Assert.AreEqual(1, BitMath.LowBitPosition((uint)0xfffffffe), "uint");
            Assert.AreEqual(1, BitMath.LowBitPosition((int)-2), "int");
            Assert.AreEqual(1, BitMath.LowBitPosition((ulong)0xfffffffffffffffe), "ulong");
            Assert.AreEqual(1, BitMath.LowBitPosition((long)-2), "long");
            Assert.AreEqual(1, BitMath.LowBitPosition(new UInt128(0xffffffffffffffff, 0xfffffffffffffffe)), "UInt128");
        }

        [Test]
        public void LowBitPositionByteShouldMatchWider() {
            byte v = byte.MinValue;
            while (true) {
                int expected = BitMath.LowBitPosition(v);
                Assert.AreEqual(expected, BitMath.LowBitPosition((sbyte)v), "sbyte");
                Assert.AreEqual(expected, BitMath.LowBitPosition((ushort)v), "short");
                Assert.AreEqual(expected, BitMath.LowBitPosition((short)v), "short");
                Assert.AreEqual(expected, BitMath.LowBitPosition((uint)v), "uint");
                Assert.AreEqual(expected, BitMath.LowBitPosition((int)v), "int");
                Assert.AreEqual(expected, BitMath.LowBitPosition((ulong)v), "ulong");
                Assert.AreEqual(expected, BitMath.LowBitPosition((long)v), "long");
                Assert.AreEqual(expected, BitMath.LowBitPosition((UInt128)v), "UInt128");
                if (v == byte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void HighBitPosition0ShouldReturnNeg1() {
            Assert.AreEqual(-1, BitMath.HighBitPosition((byte)0), "byte");
            Assert.AreEqual(-1, BitMath.HighBitPosition((sbyte)0), "sbyte");
            Assert.AreEqual(-1, BitMath.HighBitPosition((ushort)0), "ushort");
            Assert.AreEqual(-1, BitMath.HighBitPosition((short)0), "short");
            Assert.AreEqual(-1, BitMath.HighBitPosition((uint)0), "uint");
            Assert.AreEqual(-1, BitMath.HighBitPosition((int)0), "int");
            Assert.AreEqual(-1, BitMath.HighBitPosition((ulong)0), "ulong");
            Assert.AreEqual(-1, BitMath.HighBitPosition((long)0), "long");
            Assert.AreEqual(-1, BitMath.HighBitPosition((UInt128)0), "UInt128");
        }

        [Test]
        public void HighBitPosition1ShouldReturn0() {
            Assert.AreEqual(0, BitMath.HighBitPosition((byte)1), "byte");
            Assert.AreEqual(0, BitMath.HighBitPosition((sbyte)1), "sbyte");
            Assert.AreEqual(0, BitMath.HighBitPosition((ushort)1), "ushort");
            Assert.AreEqual(0, BitMath.HighBitPosition((short)1), "short");
            Assert.AreEqual(0, BitMath.HighBitPosition((uint)1), "uint");
            Assert.AreEqual(0, BitMath.HighBitPosition((int)1), "int");
            Assert.AreEqual(0, BitMath.HighBitPosition((ulong)1), "ulong");
            Assert.AreEqual(0, BitMath.HighBitPosition((long)1), "long");
            Assert.AreEqual(0, BitMath.HighBitPosition((UInt128)1), "UInt128");
        }

        [Test]
        public void HighBitPositionAllBitsSetShouldReturnMsbPos() {
            Assert.AreEqual(7, BitMath.HighBitPosition((byte)0xff), "byte");
            Assert.AreEqual(7, BitMath.HighBitPosition((sbyte)-1), "sbyte");
            Assert.AreEqual(15, BitMath.HighBitPosition((ushort)0xffff), "ushort");
            Assert.AreEqual(15, BitMath.HighBitPosition((short)-1), "short");
            Assert.AreEqual(31, BitMath.HighBitPosition((uint)0xffffffff), "uint");
            Assert.AreEqual(31, BitMath.HighBitPosition((int)-1), "int");
            Assert.AreEqual(63, BitMath.HighBitPosition((ulong)0xffffffffffffffff), "ulong");
            Assert.AreEqual(63, BitMath.HighBitPosition((long)-1), "long");
            Assert.AreEqual(127, BitMath.HighBitPosition(new UInt128(0xffffffffffffffff, 0xffffffffffffffff)), "UInt128");
        }

        [Test]
        public void HighBitPositionByteShouldMatchWider() {
            byte v = byte.MinValue;
            while (true) {
                int expected = BitMath.HighBitPosition(v);
                Assert.AreEqual(expected, BitMath.HighBitPosition((sbyte)v), "sbyte");
                Assert.AreEqual(expected, BitMath.HighBitPosition((ushort)v), "ushort");
                Assert.AreEqual(expected, BitMath.HighBitPosition((short)v), "short");
                Assert.AreEqual(expected, BitMath.HighBitPosition((uint)v), "uint");
                Assert.AreEqual(expected, BitMath.HighBitPosition((int)v), "int");
                Assert.AreEqual(expected, BitMath.HighBitPosition((ulong)v), "ulong");
                Assert.AreEqual(expected, BitMath.HighBitPosition((long)v), "long");
                Assert.AreEqual(expected, BitMath.HighBitPosition((UInt128)v), "UInt128");
                if (v == byte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void TrailingZeroBits0ShouldReturnBitWidth() {
            Assert.AreEqual(8, BitMath.TrailingZeroBits((byte)0), "byte");
            Assert.AreEqual(8, BitMath.TrailingZeroBits((sbyte)0), "sbyte");
            Assert.AreEqual(16, BitMath.TrailingZeroBits((ushort)0), "ushort");
            Assert.AreEqual(16, BitMath.TrailingZeroBits((short)0), "short");
            Assert.AreEqual(32, BitMath.TrailingZeroBits((uint)0), "uint");
            Assert.AreEqual(32, BitMath.TrailingZeroBits((int)0), "int");
            Assert.AreEqual(64, BitMath.TrailingZeroBits((ulong)0), "ulong");
            Assert.AreEqual(64, BitMath.TrailingZeroBits((long)0), "long");
            Assert.AreEqual(128, BitMath.TrailingZeroBits((UInt128)0), "UInt128");
        }

        [Test]
        public void TrailingZeroBits1ShouldReturn0() {
            Assert.AreEqual(0, BitMath.TrailingZeroBits((byte)1), "byte");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((sbyte)1), "sbyte");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((ushort)1), "ushort");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((short)1), "short");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((uint)1), "uint");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((int)1), "int");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((ulong)1), "ulong");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((long)1), "long");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((UInt128)1), "UInt128");
        }

        [Test]
        public void TrailingZeroBitsAllBitsSetShouldReturn0() {
            Assert.AreEqual(0, BitMath.TrailingZeroBits((byte)0xff), "byte");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((sbyte)-1), "sbyte");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((ushort)0xffff), "ushort");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((short)-1), "short");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((uint)0xffffffff), "uint");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((int)-1), "int");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((ulong)0xffffffffffffffff), "ulong");
            Assert.AreEqual(0, BitMath.TrailingZeroBits((long)-1), "long");
            Assert.AreEqual(0, BitMath.TrailingZeroBits(new UInt128(0xffffffffffffffff, 0xffffffffffffffff)), "UInt128");
        }

        [Test]
        public void TrailingZeroBitsAllBitsMinus1ShouldReturn1() {
            Assert.AreEqual(1, BitMath.TrailingZeroBits((byte)0xfe), "byte");
            Assert.AreEqual(1, BitMath.TrailingZeroBits((sbyte)-2), "sbyte");
            Assert.AreEqual(1, BitMath.TrailingZeroBits((ushort)0xfffe), "ushort");
            Assert.AreEqual(1, BitMath.TrailingZeroBits((short)-2), "short");
            Assert.AreEqual(1, BitMath.TrailingZeroBits((uint)0xfffffffe), "uint");
            Assert.AreEqual(1, BitMath.TrailingZeroBits((int)-2), "int");
            Assert.AreEqual(1, BitMath.TrailingZeroBits((ulong)0xfffffffffffffffe), "ulong");
            Assert.AreEqual(1, BitMath.TrailingZeroBits((long)-2), "long");
            Assert.AreEqual(1, BitMath.TrailingZeroBits(new UInt128(0xffffffffffffffff, 0xfffffffffffffffe)), "UInt128");
        }

        [Test]
        public void TrailingZeroBitsByteShouldMatchWider() {
            byte v = byte.MinValue;
            while (true) {
                Assert.AreEqual(BitMath.TrailingZeroBits(v), BitMath.TrailingZeroBits((sbyte)v), "sbyte");
                if (v == 0) {
                    v++;
                    continue; // the result for 0 is type dependant
                }
                Assert.AreEqual(BitMath.TrailingZeroBits(v), BitMath.TrailingZeroBits((ushort)v), "short");
                Assert.AreEqual(BitMath.TrailingZeroBits(v), BitMath.TrailingZeroBits((short)v), "short");
                Assert.AreEqual(BitMath.TrailingZeroBits(v), BitMath.TrailingZeroBits((uint)v), "uint");
                Assert.AreEqual(BitMath.TrailingZeroBits(v), BitMath.TrailingZeroBits((int)v), "int");
                Assert.AreEqual(BitMath.TrailingZeroBits(v), BitMath.TrailingZeroBits((ulong)v), "ulong");
                Assert.AreEqual(BitMath.TrailingZeroBits(v), BitMath.TrailingZeroBits((long)v), "long");
                Assert.AreEqual(BitMath.TrailingZeroBits(v), BitMath.TrailingZeroBits((UInt128)v), "UInt128");
                if (v == byte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void LeadingZeroBits0ShouldReturnBitWidth() {
            Assert.AreEqual(8, BitMath.LeadingZeroBits((byte)0), "byte");
            Assert.AreEqual(8, BitMath.LeadingZeroBits((sbyte)0), "sbyte");
            Assert.AreEqual(16, BitMath.LeadingZeroBits((ushort)0), "ushort");
            Assert.AreEqual(16, BitMath.LeadingZeroBits((short)0), "short");
            Assert.AreEqual(32, BitMath.LeadingZeroBits((uint)0), "uint");
            Assert.AreEqual(32, BitMath.LeadingZeroBits((int)0), "int");
            Assert.AreEqual(64, BitMath.LeadingZeroBits((ulong)0), "ulong");
            Assert.AreEqual(64, BitMath.LeadingZeroBits((long)0), "long");
            Assert.AreEqual(128, BitMath.LeadingZeroBits((UInt128)0), "UInt128");
        }

        [Test]
        public void LeadingZeroBits1ShouldReturnBitWidthLessOne() {
            Assert.AreEqual(7, BitMath.LeadingZeroBits((byte)1), "byte");
            Assert.AreEqual(7, BitMath.LeadingZeroBits((sbyte)1), "sbyte");
            Assert.AreEqual(15, BitMath.LeadingZeroBits((ushort)1), "ushort");
            Assert.AreEqual(15, BitMath.LeadingZeroBits((short)1), "short");
            Assert.AreEqual(31, BitMath.LeadingZeroBits((uint)1), "uint");
            Assert.AreEqual(31, BitMath.LeadingZeroBits((int)1), "int");
            Assert.AreEqual(63, BitMath.LeadingZeroBits((ulong)1), "ulong");
            Assert.AreEqual(63, BitMath.LeadingZeroBits((long)1), "long");
            Assert.AreEqual(127, BitMath.LeadingZeroBits((UInt128)1), "UInt128");
        }

        [Test]
        public void LeadingZeroBitsAllBitsSetShouldReturn0() {
            Assert.AreEqual(0, BitMath.LeadingZeroBits((byte)0xff), "byte");
            Assert.AreEqual(0, BitMath.LeadingZeroBits((sbyte)-1), "sbyte");
            Assert.AreEqual(0, BitMath.LeadingZeroBits((ushort)0xffff), "ushort");
            Assert.AreEqual(0, BitMath.LeadingZeroBits((short)-1), "short");
            Assert.AreEqual(0, BitMath.LeadingZeroBits((uint)0xffffffff), "uint");
            Assert.AreEqual(0, BitMath.LeadingZeroBits((int)-1), "int");
            Assert.AreEqual(0, BitMath.LeadingZeroBits((ulong)0xffffffffffffffff), "ulong");
            Assert.AreEqual(0, BitMath.LeadingZeroBits((long)-1), "long");
            Assert.AreEqual(0, BitMath.LeadingZeroBits(new UInt128(0xffffffffffffffff, 0xffffffffffffffff)), "UInt128");
        }

        [Test]
        public void SignificantBits0ShouldReturn0() {
            Assert.AreEqual(0, BitMath.SignificantBits((byte)0), "byte");
            Assert.AreEqual(0, BitMath.SignificantBits((sbyte)0), "sbyte");
            Assert.AreEqual(0, BitMath.SignificantBits((ushort)0), "ushort");
            Assert.AreEqual(0, BitMath.SignificantBits((short)0), "short");
            Assert.AreEqual(0, BitMath.SignificantBits((uint)0), "uint");
            Assert.AreEqual(0, BitMath.SignificantBits((int)0), "int");
            Assert.AreEqual(0, BitMath.SignificantBits((ulong)0), "ulong");
            Assert.AreEqual(0, BitMath.SignificantBits((long)0), "long");
            Assert.AreEqual(0, BitMath.SignificantBits((UInt128)0), "UInt128");
        }

        [Test]
        public void SignificantBits1ShouldReturn1() {
            Assert.AreEqual(1, BitMath.SignificantBits((byte)1), "byte");
            Assert.AreEqual(1, BitMath.SignificantBits((sbyte)1), "sbyte");
            Assert.AreEqual(1, BitMath.SignificantBits((ushort)1), "ushort");
            Assert.AreEqual(1, BitMath.SignificantBits((short)1), "short");
            Assert.AreEqual(1, BitMath.SignificantBits((uint)1), "uint");
            Assert.AreEqual(1, BitMath.SignificantBits((int)1), "int");
            Assert.AreEqual(1, BitMath.SignificantBits((ulong)1), "ulong");
            Assert.AreEqual(1, BitMath.SignificantBits((long)1), "long");
            Assert.AreEqual(1, BitMath.SignificantBits((UInt128)1), "UInt128");
        }

        [Test]
        public void SignificantBitsAllBitsSetShouldReturnBitWidth() {
            Assert.AreEqual(8, BitMath.SignificantBits((byte)0xff), "byte");
            Assert.AreEqual(8, BitMath.SignificantBits((sbyte)-1), "sbyte");
            Assert.AreEqual(16, BitMath.SignificantBits((ushort)0xffff), "ushort");
            Assert.AreEqual(16, BitMath.SignificantBits((short)-1), "short");
            Assert.AreEqual(32, BitMath.SignificantBits((uint)0xffffffff), "uint");
            Assert.AreEqual(32, BitMath.SignificantBits((int)-1), "int");
            Assert.AreEqual(64, BitMath.SignificantBits((ulong)0xffffffffffffffff), "ulong");
            Assert.AreEqual(64, BitMath.SignificantBits((long)-1), "long");
            Assert.AreEqual(128, BitMath.SignificantBits(new UInt128(0xffffffffffffffff, 0xffffffffffffffff)), "UInt128");
        }

        [Test]
        public void SignificantBitsByteShouldMatchWider() {
            byte v = byte.MinValue;
            while (true) {
                int expected = BitMath.SignificantBits(v);
                Assert.AreEqual(expected, BitMath.SignificantBits((sbyte)v), "sbyte");
                Assert.AreEqual(expected, BitMath.SignificantBits((ushort)v), "ushort");
                Assert.AreEqual(expected, BitMath.SignificantBits((short)v), "short");
                Assert.AreEqual(expected, BitMath.SignificantBits((uint)v), "uint");
                Assert.AreEqual(expected, BitMath.SignificantBits((int)v), "int");
                Assert.AreEqual(expected, BitMath.SignificantBits((ulong)v), "ulong");
                Assert.AreEqual(expected, BitMath.SignificantBits((long)v), "long");
                Assert.AreEqual(expected, BitMath.SignificantBits((UInt128)v), "UInt128");
                if (v == byte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void BitCount0ShouldReturn0() {
            Assert.AreEqual(0, BitMath.BitCount((byte)0), "byte");
            Assert.AreEqual(0, BitMath.BitCount((sbyte)0), "sbyte");
            Assert.AreEqual(0, BitMath.BitCount((ushort)0), "ushort");
            Assert.AreEqual(0, BitMath.BitCount((short)0), "short");
            Assert.AreEqual(0, BitMath.BitCount((uint)0), "uint");
            Assert.AreEqual(0, BitMath.BitCount((int)0), "int");
            Assert.AreEqual(0, BitMath.BitCount((ulong)0), "ulong");
            Assert.AreEqual(0, BitMath.BitCount((long)0), "long");
            Assert.AreEqual(0, BitMath.BitCount((UInt128)0), "UInt128");
        }

        [Test]
        public void BitCount1ShouldReturn1() {
            Assert.AreEqual(1, BitMath.BitCount((byte)1), "byte");
            Assert.AreEqual(1, BitMath.BitCount((sbyte)1), "sbyte");
            Assert.AreEqual(1, BitMath.BitCount((ushort)1), "ushort");
            Assert.AreEqual(1, BitMath.BitCount((short)1), "short");
            Assert.AreEqual(1, BitMath.BitCount((uint)1), "uint");
            Assert.AreEqual(1, BitMath.BitCount((int)1), "int");
            Assert.AreEqual(1, BitMath.BitCount((ulong)1), "ulong");
            Assert.AreEqual(1, BitMath.BitCount((long)1), "long");
            Assert.AreEqual(1, BitMath.BitCount((UInt128)1), "UInt128");
        }

        [Test]
        public void BitCountAllBitsSetShouldReturnBitWidth() {
            Assert.AreEqual(8, BitMath.BitCount((byte)0xff), "byte");
            Assert.AreEqual(8, BitMath.BitCount((sbyte)-1), "sbyte");
            Assert.AreEqual(16, BitMath.BitCount((ushort)0xffff), "ushort");
            Assert.AreEqual(16, BitMath.BitCount((short)-1), "short");
            Assert.AreEqual(32, BitMath.BitCount((uint)0xffffffff), "uint");
            Assert.AreEqual(32, BitMath.BitCount((int)-1), "int");
            Assert.AreEqual(64, BitMath.BitCount((ulong)0xffffffffffffffff), "ulong");
            Assert.AreEqual(64, BitMath.BitCount((long)-1), "long");
            Assert.AreEqual(128, BitMath.BitCount(new UInt128(0xffffffffffffffff, 0xffffffffffffffff)), "UInt128");
        }

        [Test]
        public void BitCountMsbSetShouldReturn1() {
            Assert.AreEqual(1, BitMath.BitCount((byte)0x80), "byte");
            Assert.AreEqual(1, BitMath.BitCount(sbyte.MinValue), "sbyte");
            Assert.AreEqual(1, BitMath.BitCount((ushort)0x8000), "ushort");
            Assert.AreEqual(1, BitMath.BitCount(short.MinValue), "short");
            Assert.AreEqual(1, BitMath.BitCount((uint)0x80000000), "uint");
            Assert.AreEqual(1, BitMath.BitCount(int.MinValue), "int");
            Assert.AreEqual(1, BitMath.BitCount((ulong)0x8000000000000000), "ulong");
            Assert.AreEqual(1, BitMath.BitCount(long.MinValue), "long");
            Assert.AreEqual(1, BitMath.BitCount(new UInt128(0x8000000000000000, 0)), "UInt128");
        }

        [Test]
        public void BitCountByteShouldMatchWider() {
            byte v = byte.MinValue;
            while (true) {
                Assert.AreEqual(BitMath.BitCount(v), BitMath.BitCount((sbyte)v), "sbyte");
                Assert.AreEqual(BitMath.BitCount(v), BitMath.BitCount((ushort)v), "ushort");
                Assert.AreEqual(BitMath.BitCount(v), BitMath.BitCount((short)v), "short");
                Assert.AreEqual(BitMath.BitCount(v), BitMath.BitCount((uint)v), "uint");
                Assert.AreEqual(BitMath.BitCount(v), BitMath.BitCount((int)v), "int");
                Assert.AreEqual(BitMath.BitCount(v), BitMath.BitCount((ulong)v), "ulong");
                Assert.AreEqual(BitMath.BitCount(v), BitMath.BitCount((long)v), "long");
                Assert.AreEqual(BitMath.BitCount(v), BitMath.BitCount((UInt128)v), "UInt128");
                if (v == byte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void ReverseBits0ShouldReturn0() {
            Assert.AreEqual(0, BitMath.ReverseBits((byte)0), "byte");
            Assert.AreEqual(0, BitMath.ReverseBits((sbyte)0), "sbyte");
            Assert.AreEqual(0, BitMath.ReverseBits((ushort)0), "ushort");
            Assert.AreEqual(0, BitMath.ReverseBits((short)0), "short");
            Assert.AreEqual(0, BitMath.ReverseBits((uint)0), "uint");
            Assert.AreEqual(0, BitMath.ReverseBits((int)0), "int");
            Assert.AreEqual(0, BitMath.ReverseBits((ulong)0), "ulong");
            Assert.AreEqual(0, BitMath.ReverseBits((long)0), "long");
            Assert.AreEqual(UInt128.Zero, BitMath.ReverseBits((UInt128)0), "UInt128");
        }

        [Test]
        public void ReverseBits1ShouldReturnMsb() {
            Assert.AreEqual(0x80, BitMath.ReverseBits((byte)1), "byte");
            Assert.AreEqual(sbyte.MinValue, BitMath.ReverseBits((sbyte)1), "sbyte");
            Assert.AreEqual(0x8000, BitMath.ReverseBits((ushort)1), "ushort");
            Assert.AreEqual(short.MinValue, BitMath.ReverseBits((short)1), "short");
            Assert.AreEqual(0x80000000, BitMath.ReverseBits((uint)1), "uint");
            Assert.AreEqual(int.MinValue, BitMath.ReverseBits((int)1), "int");
            Assert.AreEqual(0x8000000000000000, BitMath.ReverseBits((ulong)1), "ulong");
            Assert.AreEqual(long.MinValue, BitMath.ReverseBits((long)1), "long");
            Assert.AreEqual(new UInt128(0x8000000000000000, 0), BitMath.ReverseBits((UInt128)1), "UInt128");
        }

        [Test]
        public void ReverseBitsAllBitsSetShouldReturnAllBitsSet() {
            Assert.AreEqual(0xff, BitMath.ReverseBits((byte)0xff), "byte");
            Assert.AreEqual(-1, BitMath.ReverseBits((sbyte)-1), "sbyte");
            Assert.AreEqual(0xffff, BitMath.ReverseBits((ushort)0xffff), "ushort");
            Assert.AreEqual(-1, BitMath.ReverseBits((short)-1), "short");
            Assert.AreEqual(0xffffffff, BitMath.ReverseBits((uint)0xffffffff), "uint");
            Assert.AreEqual(-1, BitMath.ReverseBits((int)-1), "int");
            Assert.AreEqual(0xffffffffffffffff, BitMath.ReverseBits((ulong)0xffffffffffffffff), "ulong");
            Assert.AreEqual(-1, BitMath.ReverseBits((long)-1), "long");
            Assert.AreEqual(new UInt128(0xffffffffffffffff, 0xffffffffffffffff), BitMath.ReverseBits(new UInt128(0xffffffffffffffff, 0xffffffffffffffff)), "UInt128");
        }

        [Test]
        public void ReverseBitsMsbSetShouldReturn1() {
            Assert.AreEqual(1, BitMath.ReverseBits((byte)0x80), "byte");
            Assert.AreEqual(1, BitMath.ReverseBits(sbyte.MinValue), "sbyte");
            Assert.AreEqual(1, BitMath.ReverseBits((ushort)0x8000), "ushort");
            Assert.AreEqual(1, BitMath.ReverseBits(short.MinValue), "short");
            Assert.AreEqual(1, BitMath.ReverseBits((uint)0x80000000), "uint");
            Assert.AreEqual(1, BitMath.ReverseBits(int.MinValue), "int");
            Assert.AreEqual(1, BitMath.ReverseBits((ulong)0x8000000000000000), "ulong");
            Assert.AreEqual(1, BitMath.ReverseBits(long.MinValue), "long");
            Assert.AreEqual(UInt128.One, BitMath.ReverseBits(new UInt128(0x8000000000000000,0)), "UInt128");
        }

        [Test]
        public void ReverseBitsByteTwiceShouldReturnOriginal() {
            byte v = byte.MinValue;
            while (true) {
                Assert.AreEqual(v, (byte)BitMath.ReverseBits(BitMath.ReverseBits((byte)v)), "sbyte");
                if (v == byte.MaxValue) break;
                v++;
            }
        }
    }
}