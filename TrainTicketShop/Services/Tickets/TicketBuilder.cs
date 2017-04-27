﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;
using TrainTicketShop.ViewModels;

namespace TrainTicketShop.Services.Tickets
{
    interface ITicketBuilder {
        void ChooseStrategy();
        void FillPassengerInfo();
        void FillTrainInfo();
        void FillCarriageInfo();

        Ticket Ticket { get; }
    }

    public class TicketBuilder : ITicketBuilder {
        private TicketViewModel _ticketVM;
        private Carriage _carriage;
        private TicketBuildingStrategy _ticketBuildingStrategy;
        
        public Ticket Ticket { get; private set; }

        public TicketBuilder(TicketViewModel ticketVM, Carriage carriage, string email ) {
            _ticketVM = ticketVM;
            _carriage = carriage;
            Ticket = new Ticket() { Email = email };
        }

        public void ChooseStrategy() {
            switch (_ticketVM.PassengerType) {
                case PassengerType.Adult:
                    _ticketBuildingStrategy = new AdultStrategy(Ticket, _ticketVM);
                    break;
                case PassengerType.Kid:
                    _ticketBuildingStrategy = new KidStrategy(Ticket, _ticketVM);
                    break;
                case PassengerType.Student:
                    _ticketBuildingStrategy = new StudentStrategy(Ticket, _ticketVM);
                    break;
            }
        }

        public void FillPassengerInfo() {
            Ticket.SeatNumber = _ticketVM.SeatNumber;
            _ticketBuildingStrategy.FillTicketWithData();
        }

        public void FillTrainInfo() {
            Ticket.TrainNumber = _carriage.Train.Number;
            Ticket.TrainTravelTime = _carriage.Train.TravelTime;
            Ticket.TrainPassengerDepartureDate = _carriage.Train.PassengerDepartureDate;
            Ticket.TrainPassengerArrivalDate = _carriage.Train.PassengerArrivalDate;
            Ticket.TrainClass = _carriage.Train.Class_.Name;
            Ticket.TrainCategory = _carriage.Train.Category.Name;
            Ticket.TrainModel = _carriage.Train.Model.Name;
            Ticket.TrainDepartureStation = _carriage.Train.DepartureStation.Name;
            Ticket.TrainDepartureStationId = _carriage.Train.DepartureStation.Id;
            Ticket.TrainArrivalStation = _carriage.Train.ArrivalStation.Name;
            Ticket.TrainArrivalStationId = _carriage.Train.ArrivalStation.Id;
            Ticket.TrainPassengerDepartureStation = _carriage.Train.PassengerDepartureStation.Name;
            Ticket.TrainPassengerDepartureStationId = _carriage.Train.PassengerDepartureStation.Id;
            Ticket.TrainPassengerArrivalStation = _carriage.Train.PassengerArrivalStation.Name;
            Ticket.TrainPassengerArrivalStationId = _carriage.Train.PassengerArrivalStation.Id;
        }

        public void FillCarriageInfo() {
            Ticket.CarriageNumber = _carriage.Number;
            Ticket.CarriageType = _carriage.Type.Name;
            Ticket.Price = _carriage.Price;
        }


    }
}