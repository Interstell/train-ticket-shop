using Newtonsoft.Json;
using System.Collections.Generic;

namespace TrainTicketShop.Entities {
    public class CarBriefly {
        public string Hash { get; set; }
        public string Number { get; set; }
        public string Price { get; set; }
        public string BookingPrice { get; set; }
        public int TypeId { get; set; }
        public int FreeSeats { get; set; }
        public int LowerSeats { get; set; }
        public int UpperSeats { get; set; }
        public int SideLowerSeats { get; set; }
        public int SideUpperSeats { get; set; }
        public int BedPrice { get; set; }
    }

    public class TrainSuperBriefly {
        public string Number { get; set; }
        public int TravelTime { get; set; }
        public bool IsAbroad { get; set; }
        public string PassengerDepartureDate { get; set; }
        public string PassengerArrivalDate { get; set; }
        public Description Class_ { get; set; }
        public Description Category { get; set; }
        public Description Speed { get; set; }
        public Description Model { get; set; }
        public Description DepartureStation { get; set; }
        public Description ArrivalStation { get; set; }
        public Description PassengerDepartureStation { get; set; }
        public Description PassengerArrivalStation { get; set; }
    }

    public class Train {
        List<CarBriefly> Cars;
        List<Description> CarTypes;

        public string Number { get; set; }
        public int TravelTime { get; set; }
        public bool IsAbroad { get; set; }
        public string PassengerDepartureDate { get; set; }
        public string PassengerArrivalDate { get; set; }
        public Description Class_ { get; set; }
        public Description Category { get; set; }
        public Description Speed { get; set; }
        public Description Model { get; set; }
        public Description DepartureStation { get; set; }
        public Description ArrivalStation { get; set; }
        public Description PassengerDepartureStation { get; set; }
        public Description PassengerArrivalStation { get; set; }

        public Train(string json) {
            dynamic result = JsonConvert.DeserializeObject<dynamic>(json);
            Cars = new List<CarBriefly>();
            foreach (dynamic rawCar in result.cars) {
                Cars.Add(new CarBriefly {
                    Hash = rawCar.hash,
                    Number = rawCar.number,
                    Price = rawCar.price,
                    BookingPrice = rawCar.bookingPrice,
                    TypeId = rawCar.typeId,
                    FreeSeats = rawCar.freeSeats,
                    LowerSeats = rawCar.lowerSeats,
                    UpperSeats = rawCar.upperSeats,
                    SideLowerSeats = rawCar.sideLowerSeats,
                    SideUpperSeats = rawCar.sideUpperSeats,
                    BedPrice = rawCar.bedPrice
                });
            }
            CarTypes = new List<Description>();
            foreach (dynamic rawCarType in result.carTypes) {
                CarTypes.Add(
                    new Description {
                        Id = rawCarType.id,
                        Name = rawCarType.name
                    }
                    );
            }

            this.Number = result.train.number;
            this.TravelTime = result.train.travelTime;
            this.IsAbroad = result.train.isAbroad;
            this.PassengerDepartureDate = result.train.passengerDepartureDate;
            this.PassengerArrivalDate = result.train.passengerArrivalDate;
            this.Class_ = new Description {
                Id = result.train.class_.id,
                Name = result.train.class_.name
            };
            this.Category = new Description {
                Id = result.train.category.id,
                Name = result.train.category.name
            };
            this.Speed = new Description {
                Id = result.train.speed.id,
                Name = result.train.speed.name
            };
            this.Model = new Description {
                Id = result.train.model.id,
                Name = result.train.model.name
            };
            this.DepartureStation = new Description {
                Id = result.train.departureStation.id,
                Name = result.train.departureStation.name,
            };
            this.ArrivalStation = new Description {
                Id = result.train.arrivalStation.id,
                Name = result.train.arrivalStation.name,
            };
            this.PassengerDepartureStation = new Description {
                Id = result.train.passengerDepartureStation.id,
                Name = result.train.passengerDepartureStation.name,
            };
            this.PassengerArrivalStation = new Description {
                Id = result.train.passengerArrivalStation.id,
                Name = result.train.passengerArrivalStation.name,
            };
        }
    }
}
