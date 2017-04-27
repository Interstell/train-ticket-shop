using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TrainTicketShop.Entities {
    public class Carriage
    {
        public string Hash { get; set; }
        public string Number { get; set; }
        public string Price { get; set; }
        public string BookingPrice { get; set; }
        public int FreeSeats { get; set; }
        public Description Type { get; set; }
        public Description Schema { get; set; }
        public List<Description> TransportationTypes { get; set; }
        public int BedPrice { get; set; }

        public List<int> Seats;
        public TrainSuperBriefly Train;

        public Carriage() {

        }

        public Carriage(string json) {
            dynamic result = JsonConvert.DeserializeObject<dynamic>(json);
            this.Hash = result.car.hash;
            this.Number = result.car.number;
            this.Price = result.car.price;
            this.BookingPrice = result.car.bookingPrice;
            this.FreeSeats = result.car.freeSeats;
            this.Type = new Description {
                Id = result.car.type.id,
                Name = result.car.type.name
            };
            this.Schema = new Description {
                Id = result.car.schema.id,
                Name = result.car.schema.name
            };
            this.TransportationTypes = new List<Description>();
            foreach (dynamic type in result.car.transportationTypes) {
                this.TransportationTypes.Add(new Description {
                    Id = type.id,
                    Name = type.name
                });
            }
            this.BedPrice = result.car.bedPrice;

            this.Seats = new List<int>();
            foreach (dynamic seat in result.seats) {
                this.Seats.Add(Int32.Parse((string)seat.number));
            }

            this.Train = new TrainSuperBriefly {
                Number = result.train.number,
                TravelTime = result.train.travelTime,
                IsAbroad = result.train.isAbroad,
                PassengerDepartureDate = result.train.passengerDepartureDate,
                PassengerArrivalDate = result.train.passengerArrivalDate,
                Class_ = new Description {
                    Id = result.train.class_.id,
                    Name = result.train.class_.name
                },
                Category = new Description {
                    Id = result.train.category.id,
                    Name = result.train.category.name
                },
                Speed = new Description {
                    Id = result.train.speed.id,
                    Name = result.train.speed.name
                },
                Model = new Description {
                    Id = result.train.model.id,
                    Name = result.train.model.name
                },
                DepartureStation = new Description {
                    Id = result.train.departureStation.id,
                    Name = result.train.departureStation.name,
                },
                ArrivalStation = new Description {
                    Id = result.train.arrivalStation.id,
                    Name = result.train.arrivalStation.name,
                },
                PassengerDepartureStation = new Description {
                    Id = result.train.passengerDepartureStation.id,
                    Name = result.train.passengerDepartureStation.name,
                },
                PassengerArrivalStation = new Description {
                    Id = result.train.passengerArrivalStation.id,
                    Name = result.train.passengerArrivalStation.name,
                }
            };
        }
    }
}
