using System.Data.Common;
using firstapi.Models;

namespace firstapi.Repository{

    public class FlightRepo : IFlight<VsFlight>
    {   
        private readonly Ace52024Context _context;
        public FlightRepo (){}
        public FlightRepo(Ace52024Context context){
            _context = context;
        }
        public void AddFlight(VsFlight f)
        {
            _context.VsFlights.Add(f);
            _context.SaveChanges();
        }

        public void DeleteFlight(int id)
        {
            var bookingRowDel = _context.VsBookingDetails.Where(x=>x.FlightId == id).ToList();
            if(bookingRowDel != null){
                _context.VsBookingDetails.RemoveRange(bookingRowDel);
            }
            VsFlight f = _context.VsFlights.Find(id);
            _context.VsFlights.Remove(f);
            _context.SaveChanges();
        }

        public List<VsFlight> GetAllFlights()
        {
            return _context.VsFlights.ToList();
        }

        public VsFlight GetFlightById(int id)
        {
            return _context.VsFlights.Find(id);
        }

        public List<VsFlight> GetFlightsBySrcDest(string s)
        {
            string src = s.Split("-")[0];
            string dest = s.Split("-")[1];
            
            var vsFlight =  _context.VsFlights.Where(x=> x.Src == src && x.Dest == dest).Select(x=>x).ToList();

            return vsFlight;
        }

        public void UpdateFlight(int id, VsFlight f)
        {
            _context.VsFlights.Update(f);
            _context.SaveChanges();
        }

        public List<string> GetSources(){
            var sources =  _context.VsFlights.Select(x=> x.Src).Distinct().ToList();
            return sources;
        }

        public List<string> GetDestinations(){
            var destinations =  _context.VsFlights.Select(x=> x.Dest).Distinct().ToList();
            return destinations;
        }
    }
}