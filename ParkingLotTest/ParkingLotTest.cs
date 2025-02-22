﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLotPractice;
using System.Threading.Tasks.Dataflow;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_by_ticket()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            string expectedResult = "car";
            // When
            string result = parkingLot.Fetch(ticket);
            // Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_by_corresponding_ticket()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");
            string expectedResult1 = "car1";
            string expectedResult2 = "car2";
            // When
            string result1 = parkingLot.Fetch(ticket1);
            string result2 = parkingLot.Fetch(ticket2);
            // Then
            Assert.Equal(expectedResult1, result1);
            Assert.Equal(expectedResult2, result2);
        }

        [Fact]
        public void Should_return_WrongTicketException_when_ticket_is_wrong()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = "T-car2";

            // When// Then
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket2));
        }

        [Fact]
        public void Should_get_no_car_when_ticket_is_empty()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            // When
            string result = parkingLot.Fetch();
            // Then
            Assert.Null(result);
        }

        [Fact]
        public void Should_return_WrongTicketException_when_ticket_is_used_before()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            string car = parkingLot.Fetch(ticket);

            // When// Then
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket));
        }

        [Fact]
        public void Should_return_NoPositionException_when_capacity_is_full()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot(1);
            parkingLot.Park("car1");
            // When// Then
            NoPositionException noPositionException = Assert.Throws<NoPositionException>(() => parkingLot.Park("car"));
        }
    }
}