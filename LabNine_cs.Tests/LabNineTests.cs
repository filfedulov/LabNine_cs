using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Classes.Time
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void Min60_returnedTimeHours1Min0()
        {
            //arrange
            int minutes = 60;
            int excpected = 1;
            int excpected_ = 0;
            //act
            Time time = new Time();
            time.Minutes = minutes;
            int actual = time.hours;
            //assert
            Assert.AreEqual(excpected, actual);
            actual = time.minutes;
            Assert.AreEqual(excpected_, actual);
        }

        [TestMethod]
        public void Min61_returnedTimeHour1Min1()
        {
            //arrange
            int minutes = 61;
            int excpected = 1;
            //act
            Time time = new Time();
            time.Minutes = minutes;
            int actual = time.hours;
            //assert
            Assert.AreEqual(excpected, actual);
            actual = time.minutes;
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void MinLessNull_returnedNull()
        {
            //arrange
            int minutes = -1;
            int excpected = 0;
            //act
            Time time = new Time(minutes, 0);
            int actual = time.minutes + time.hours;
            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void OperatorMinusResultMinLessNull_returnedUpchangedObject()
        {
            //arrange
            Time timeFrom = new Time(10, 1);
            Time timeWhat = new Time(20, 1);
            int excpected = 10;
            int excpected_ = 1;
            //act
            timeFrom -= timeWhat;
            int actual = timeFrom.minutes;
            int actual_ = timeFrom.hours;
            //assert
            Assert.AreEqual(excpected, actual);
            Assert.AreEqual(excpected_, actual_);
        }

        [TestMethod]
        public void _OperatorMinusResultMinLessNull_returnedUpchangedObject()
        {
            //arrange
            Time timeFrom = new Time(10, 1);
            Time timeWhat = new Time(0, 2);
            int excpected = 10;
            int excpected_ = 1;
            //act
            timeFrom -= timeWhat;
            int actual = timeFrom.minutes;
            int actual_ = timeFrom.hours;
            //assert
            Assert.AreEqual(excpected, actual);
            Assert.AreEqual(excpected_, actual_);
        }

        [TestMethod]
        public void OperatorMinusResultHoursLessNull_returnedUpchangedObject()
        {
            //arrange
            Time timeFrom = new Time(0, 1);
            Time timeWhat = new Time(0, 2);
            int excpected = 0;
            int excpected_ = 1;
            //act
            timeFrom -= timeWhat;
            int actual = timeFrom.minutes;
            int actual_ = timeFrom.hours;
            //assert
            Assert.AreEqual(excpected, actual);
            Assert.AreEqual(excpected_, actual_);
        }

        [TestMethod]
        public void BoolImlicit_IfMinutesNullAndHoursNull_ReturnedFalse()
        {
            //arrange
            Time timeFrom = new Time();
            bool excpected = false;
            //act
            bool actual = timeFrom;
            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void _BoolImlicit_IfMinutesNotNullAndHoursNotNull_ReturnedTrue()
        {
            //arrange
            Time timeFrom = new Time(1, 1);
            bool excpected = true;
            //act
            bool actual = timeFrom;
            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void ExplicitInt_ReturnedHours()
        {
            //arrange
            Time timeFrom = new Time(50, 1);
            int excpected = 1;
            //act
            int actual = (int)timeFrom;
            //assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void AverageArithmeticHours12_Minutes15_Returned4And5()
        {
            //arrange
            TimeArray timeArray = new TimeArray();
            timeArray.arr = new Time[3];
            for (int i = 0; i < timeArray.arr.Length; i++)
            {
                timeArray.arr[i] = new Time();
                timeArray.arr[i].Hours = 4;
                timeArray.arr[i].Minutes = 5;
            }
            int excpected = 4;
            int excpected_ = 5;
            //act
            TimeArray.AverageArithmetic(timeArray);
            int actual = TimeArray.avgArithmHours;
            int actual_ = TimeArray.avgArithmMinutes;
            //assert
            Assert.AreEqual(excpected, actual);
            Assert.AreEqual(excpected_, actual_);
        }
    }
}
