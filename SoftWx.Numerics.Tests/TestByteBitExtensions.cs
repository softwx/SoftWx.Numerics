// Copyright ©2015 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// 11/19/2015
// <authors> Steve Hatchett

using NUnit.Framework;

namespace SoftWx.Numerics.Tests {
    /// <summary>
    /// Description of TestByteBitExtensions.
    /// </summary>
    [TestFixture]
    public class TestByteBitExtensions {
        [Test]
        public void Log2ShouldReturn0For0() {
            Assert.AreEqual(0, ByteBitExtensions.Log2(0));
        }
        [Test]
        public void Log2ShouldWorkForAllPositiveValues() {
            int maxLog = ByteBitExtensions.Log2(byte.MaxValue);
            Assert.AreEqual(ByteBitExtensions.Log2(byte.MaxValue - 1), maxLog);
            for (byte i = 1; i < byte.MaxValue; i++) {
                byte a = ByteBitExtensions.Log2(i);
                if ((i < 1 << a) || ((a < maxLog) && (a >= 1 << (a + 1)))) {
                    Assert.Fail("Log2 returned " + a + " for " + i);
                }
            }
        }
        [Test]
        public void Log2ShouldHandleExactPowersOf2() {
            Assert.AreEqual(4, ByteBitExtensions.Log2(1 << 4));
        }
        [Test]
        public void Log2ShouldHandlePowersOf2Plus1() {
            Assert.AreEqual(4, ByteBitExtensions.Log2((1 << 4) + 1));
        }
        [Test]
        public void Log2ShouldHandlePowersOf2Minus1() {
            Assert.AreEqual(3, ByteBitExtensions.Log2((1 << 4) - 1));
        }
        [Test]
        public void Log2ShouldReturn7ForMaxValue() {
            // max is (2^8)-1, so 7 is correct answer
            Assert.AreEqual(7, ByteBitExtensions.Log2(byte.MaxValue));
        }
        [Test]
        public void IsPowerOf2ShouldReturnFalseFor0() {
            Assert.AreEqual(false, ByteBitExtensions.IsPowerOf2(0));
        }
        [Test]
        public void IsPowerOf2ShouldReturnTrueFor1() {
            Assert.AreEqual(true, ByteBitExtensions.IsPowerOf2(1));
        }
        [Test]
        public void IsPowerOf2ShouldReturnFalseForMaxValue() {
            Assert.AreEqual(false, ByteBitExtensions.IsPowerOf2(byte.MaxValue));
        }
        [Test]
        public void PowerOf2FloorShouldReturn0For0() {
            Assert.AreEqual(0, ByteBitExtensions.PowerOf2Floor(0));
        }
        [Test]
        public void PowerOf2FloorShouldReturn1For1() {
            Assert.AreEqual(1, ByteBitExtensions.PowerOf2Floor(1));
        }
        [Test]
        public void PowerOf2FloorShouldReturnSameForExactPowersOf2() {
            Assert.AreEqual((1 << 4), ByteBitExtensions.PowerOf2Floor(1 << 4));
        }
        [Test]
        public void PowerOf2FloorShouldHandlePowersOf2Plus1() {
            Assert.AreEqual((1 << 4), ByteBitExtensions.PowerOf2Floor((1 << 4) + 1));
        }
        [Test]
        public void PowerOf2FloorShouldHandlePowersOf2Minus1() {
            Assert.AreEqual((1 << 3), ByteBitExtensions.PowerOf2Floor((1 << 4) - 1));
        }
        [Test]
        public void PowerOf2FloorShouldReturn1LSHFT7ForMaxValue() {
            Assert.AreEqual(1 << 7, ByteBitExtensions.PowerOf2Floor(byte.MaxValue));
        }
        [Test]
        public void PowerOf2CeilingShouldReturn1For0() {
            Assert.AreEqual(1, ByteBitExtensions.PowerOf2Ceiling(0));
        }
        [Test]
        public void PowerOf2CeilingShouldReturn1For1() {
            Assert.AreEqual(1, ByteBitExtensions.PowerOf2Ceiling(0));
        }
        [Test]
        public void PowerOf2CeilingShouldReturnSameForExactPowersOf2() {
            Assert.AreEqual((1 << 4), ByteBitExtensions.PowerOf2Ceiling(1 << 4));
        }
        [Test]
        public void PowerOf2CeilingShouldHandlePowersOf2Plus1() {
            Assert.AreEqual((1 << 5), ByteBitExtensions.PowerOf2Ceiling((1 << 4) + 1));
        }
        [Test]
        public void PowerOf2CeilingShouldHandlePowersOf2Minus1() {
            Assert.AreEqual((1 << 4), ByteBitExtensions.PowerOf2Ceiling((1 << 4) - 1));
        }
        [Test]
        public void PowerOf2CeilingShouldReturn0ForMaxValue() {
            Assert.AreEqual(0, ByteBitExtensions.PowerOf2Ceiling(byte.MaxValue));
        }
        [Test]
        public void HighBitShouldReturn0For0() {
            Assert.AreEqual(0, ByteBitExtensions.HighBit(0));
        }
        [Test]
        public void HighBitShouldReturn1For1() {
            Assert.AreEqual(1, ByteBitExtensions.HighBit(1));
        }
        [Test]
        public void HighBitShouldReturn1LSHFT7ForMaxValue() {
            Assert.AreEqual(1 << 7, ByteBitExtensions.HighBit(byte.MaxValue));
        }
        [Test]
        public void LowBitShouldReturn0For0() {
            Assert.AreEqual(0, ByteBitExtensions.LowBit(0));
        }
        [Test]
        public void LowBitShouldReturn1For1() {
            Assert.AreEqual(1, ByteBitExtensions.LowBit(1));
        }
        [Test]
        public void LowBitShouldReturn2ForMaxValueMinus1() {
            Assert.AreEqual(2, ByteBitExtensions.LowBit(byte.MaxValue - 1));
        }
        [Test]
        public void LowBitShouldReturn1ForMaxValue() {
            Assert.AreEqual(1, ByteBitExtensions.LowBit(byte.MaxValue));
        }
        [Test]
        public void HighBitPositionShouldReturn8For0() {
            Assert.AreEqual(8, ByteBitExtensions.HighBitPosition(0));
        }
        [Test]
        public void HighBitPositionShouldReturn0For1() {
            Assert.AreEqual(0, ByteBitExtensions.HighBitPosition(1));
        }
        [Test]
        public void HighBitPositionShouldReturn7ForMaxValue() {
            Assert.AreEqual(7, ByteBitExtensions.HighBitPosition(byte.MaxValue));
        }
        [Test]
        public void LowBitPositionShouldReturn8For0() {
            Assert.AreEqual(8, ByteBitExtensions.LowBitPosition(0));
        }
        [Test]
        public void LowBitPositionShouldReturn0For1() {
            Assert.AreEqual(0, ByteBitExtensions.LowBitPosition(1));
        }
        [Test]
        public void LowBitPositionShouldReturn1ForMaxValueMinus1() {
            Assert.AreEqual(1, ByteBitExtensions.LowBitPosition(byte.MaxValue - 1));
        }
        [Test]
        public void LowBitPositionShouldReturn0ForMaxValue() {
            Assert.AreEqual(0, ByteBitExtensions.LowBitPosition(byte.MaxValue));
        }
        [Test]
        public void LeadingZeroBitsShouldReturn8For0() {
            Assert.AreEqual(8, ByteBitExtensions.LeadingZeroBits(0));
        }
        [Test]
        public void LeadingZeroBitsShouldReturn7For1() {
            Assert.AreEqual(7, ByteBitExtensions.LeadingZeroBits(1));
        }
        [Test]
        public void LeadingZeroBitsShouldReturn0ForMaxValueMinus1() {
            Assert.AreEqual(0, ByteBitExtensions.LeadingZeroBits(byte.MaxValue - 1));
        }
        [Test]
        public void LeadingZeroBitsShouldReturn0ForMaxValue() {
            Assert.AreEqual(0, ByteBitExtensions.LeadingZeroBits(byte.MaxValue));
        }
        [Test]
        public void TrailingZeroBitsShouldReturn8For0() {
            Assert.AreEqual(8, ByteBitExtensions.TrailingZeroBits(0));
        }
        [Test]
        public void TrailingZeroBitsShouldReturn0For1() {
            Assert.AreEqual(0, ByteBitExtensions.TrailingZeroBits(1));
        }
        [Test]
        public void TrailingZeroBitsShouldReturn1ForMaxValueMinus1() {
            Assert.AreEqual(1, ByteBitExtensions.TrailingZeroBits(byte.MaxValue - 1));
        }
        [Test]
        public void TrailingZeroBitsShouldReturn0ForMaxValue() {
            Assert.AreEqual(0, ByteBitExtensions.TrailingZeroBits(byte.MaxValue));
        }
        [Test]
        public void BitCountShouldReturn0For0() {
            Assert.AreEqual(0, ByteBitExtensions.BitCount(0));
        }
        [Test]
        public void BitCountShouldReturn1For1() {
            Assert.AreEqual(1, ByteBitExtensions.BitCount(1));
        }
        [Test]
        public void BitCountShouldReturn7ForMaxValueMinus1() {
            Assert.AreEqual(7, ByteBitExtensions.BitCount(byte.MaxValue - 1));
        }
        [Test]
        public void BitCountShouldReturn8ForMaxValue() {
            Assert.AreEqual(8, ByteBitExtensions.BitCount(byte.MaxValue));
        }
        [Test]
        public void ReverseBitsShouldReturn0For0() {
            Assert.AreEqual(0, ByteBitExtensions.ReverseBits(0));
        }
        [Test]
        public void ReverseBitsShouldReturn128For1() {
            Assert.AreEqual(128, ByteBitExtensions.ReverseBits(1));
        }
        [Test]
        public void ReverseBitsShouldReturn127ForMaxValueMinus1() {
            Assert.AreEqual(127, ByteBitExtensions.ReverseBits(byte.MaxValue - 1));
        }
        [Test]
        public void ReverseBitsShouldReturnMaxValueForMaxValue() {
            Assert.AreEqual(byte.MaxValue, ByteBitExtensions.ReverseBits(byte.MaxValue));
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
