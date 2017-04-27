using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTicketShop.Services.Railway
{
    public interface IRailwayService : ICarriageInfoService, ISearchTrainService, ISearchHintsService, ITrainInfoService { }

    // #PATTERN FACADE
    public class RailwayService : IRailwayService
    {
        private ICarriageInfoService _carriageInfoService;
        private ISearchTrainService _searchTrainService;
        private ISearchHintsService _searchHintsService;
        private ITrainInfoService _trainInfoService;

        public RailwayService(ICarriageInfoService carriageInfoService, 
            ISearchHintsService searchHintsService,
            ISearchTrainService searchTrainService,
            ITrainInfoService trainInfoService) {
            _carriageInfoService = carriageInfoService;
            _searchTrainService = searchTrainService;
            _searchHintsService = searchHintsService;
            _trainInfoService = trainInfoService;
        }

        public string GetCarriageInfo(string carriageHash) {
            return _carriageInfoService.GetCarriageInfo(carriageHash);
        }

        public string GetHints(string input) {
            return _searchHintsService.GetHints(input);
        }

        public string GetTrainInfo(string trainHash) {
            return _trainInfoService.GetTrainInfo(trainHash);
        }

        public string GetTrainsFromWeb(int from, int to, string date) {
            return _searchTrainService.GetTrainsFromWeb(from, to, date);
        }
    }
}
