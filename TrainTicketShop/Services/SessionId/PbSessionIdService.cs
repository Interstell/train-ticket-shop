using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Logging;

namespace TrainTicketShop.Services.SessionId {

    public interface ISessionIdService {
        string GetSessionId();
    }


    public class PbSessionIdService : ISessionIdService {
        private SessionData _sessionData; //todo make DI singleton and update by Cron
        private ILogger _logger;

        public PbSessionIdService(ILogger<PbSessionIdService> logger) {
            _logger = logger;
            updateSessionDataFromFile();
        }

        private void updateSessionDataFromFile() {
            try {
                using (StreamReader reader = File.OpenText("./Services/SessionId/pb_session_id.json")) {
                    string json = reader.ReadToEnd();
                    _sessionData = JsonConvert.DeserializeObject<SessionData>(json);
                }
            }
            catch (Exception e) {
                _logger.LogCritical(e.Message);
            }
        }

        public string GetSessionId() {
            return _sessionData.sessionId;
        }

    }

    internal class SessionData {
        public string sessionId { get; set; }
        public long activeSince { get; set; }
        public long activeUntil { get; set; }
        public string activeSinceStr { get; set; }
    }
}
