using firstapi.Models;
using firstapi.Repository;

namespace firstapi.Service
{

    public class FlightServ : IFlightServ<VsFlight>
    {   
        private readonly IFlight<VsFlight> fl;
        public FlightServ(){}
        public FlightServ(IFlight<VsFlight> _fl){
            fl = _fl;
        }

        public void AddFlight(VsFlight f)
        {
            fl.AddFlight(f);
        }

        public void DeleteFlight(int id)
        {
            fl.DeleteFlight(id);
        }

        public List<VsFlight> GetAllFlights()
        {
            return fl.GetAllFlights();
        }

        public VsFlight GetFlightById(int id)
        {
            return fl.GetFlightById(id);
        }

        public List<VsFlight> GetFlightsBySrcDest(string s)
        {
            return fl.GetFlightsBySrcDest(s);
        }

        public void UpdateFlight(int id, VsFlight f)
        {
            fl.UpdateFlight(id, f);
        }
    }
}