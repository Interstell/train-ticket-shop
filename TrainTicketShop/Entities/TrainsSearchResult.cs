using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTicketShop.Entities
{
    public class TrainsSearchResult
    {
        List<TrainBriefly> Trains;
        List<StationBriefly> Stations;

        public TrainsSearchResult(string json) {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(json);
            this.Trains = new List<TrainBriefly>();
            foreach(dynamic rawTrain in results.trains) {
                TrainBriefly train = new TrainBriefly {
                    Hash = rawTrain.hash,
                    Number = rawTrain.number,
                    IsAbroad = rawTrain.isAbroad,
                    TravelTime = rawTrain.travelTime,
                    PassengerDepartureDate = rawTrain.passengerDepartureDate,
                    PassengerArrivalDate = rawTrain.passengerArrivalDate,
                    DepartureStationId = rawTrain.departureStationId,
                    ArrivalStationId = rawTrain.arrivalStationId,
                    PassengerDepartureStationId = rawTrain.passengerDepartureStationId,
                    PassengerArrivalStationId = rawTrain.passengerArrivalStationId,
                    IsElectronic = rawTrain.isElectronic,
                    IsRouteExists = rawTrain.isRouteExists,
                    Class_ = new Description {
                        Id = rawTrain.class_.id,
                        Name = rawTrain.class_.name
                    },
                    Category = new Description {
                        Id = rawTrain.category.id,
                        Name = rawTrain.category.name
                    },
                    Speed = new Description {
                        Id = rawTrain.speed.id,
                        Name = rawTrain.speed.name
                    },
                    Model = new Description {
                        Id = rawTrain.model.id,
                        Name = rawTrain.model.name
                    }
                };
                train.CarTypes = new List<CarType>();
                foreach(dynamic rawCarType in rawTrain.carTypes) {
                    train.CarTypes.Add(
                            new CarType {
                                Id = rawCarType.id,
                                Name = rawCarType.name,
                                FreeSeats = rawCarType.freeSeats,
                                EstimatedTax = rawCarType.estimatedTax
                            }
                        );
                }
                Trains.Add(train);
            }
            Stations = new List<StationBriefly>();
            foreach(dynamic station in results.stations) {
                Stations.Add(
                        new StationBriefly {
                            Id = station.id,
                            Name = station.name
                        }
                    );
            }
        }
    }

    public class TrainBriefly {
        public string Hash { get; set; }
        public string Number { get; set; }
        public bool IsAbroad { get; set; }
        public int TravelTime { get; set; }
        public string PassengerDepartureDate { get; set; }
        public string PassengerArrivalDate { get; set; }
        public int DepartureStationId { get; set; }
        public int ArrivalStationId { get; set; }
        public int PassengerDepartureStationId { get; set; }
        public int PassengerArrivalStationId { get; set; }
        public bool IsElectronic { get; set; }
        public bool IsRouteExists { get; set; }

        public Description Class_ { get; set; }
        public Description Category { get; set; }
        public Description Speed { get; set; }
        public Description Model { get; set; }

        public List<CarType> CarTypes { get; set; }
    }
    public class Description {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CarType {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FreeSeats { get; set; }
        public string EstimatedTax { get; set; }
    }
    public class StationBriefly : Description { }
}
