using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBot
{
    public static class ChatResponse
    {
        public static readonly string Greeting = "Hi! I can answer your questions about Skyline Hotel. \n\n" +
            "For reservations queries, please contact the hotel directly on +61 2 98742001.";
        public static readonly string SwimmingPool = "Yes, we have a 25-meter indoor pool and a smaller outdoor pool for children.";

        public static readonly string Restaurant =
            "We have 4-star restaurant open for dinner from 5pm. Please make a reservation prior to your stay.";

        public static readonly string Wifi = "Yes, we have complimentary wifi for guests in bedrooms and dining area.";

        public static readonly string Location =
            "We are located on George Street in the city centre, a five minute walk to the Opera House and surrounded by shops, bars, restaurants and other tourist attractions.";

        public static readonly string Farewell = "Thanks for chatting. Goodbye.";

        public static readonly string Default = "Sorry I didn't understand. Can you say that again please?";

        public static readonly string Parking = "We have a carpark for all hotel guests. It is free to use during your stay.";
        public static readonly string Transfer = "To organise a free bus transfer from the airport please let us know in advance. \n\n" + 
            "A taxi will cost $50. Call us on +61 2 98742001 and provide us your flight number.";
        public static readonly string ChangeReservation = "For all changes and cancellations you must contact us at least 48 hours before your stay. Our number is +61 2 98742001.";
        public static readonly string Checkin = "Checkin time is 2pm. We require an identity document such as passport or driving licence. \n\n" + 
            "Where possible we can arrange an early checkin, please call us in advance to arrange. Our number is +61 2 98742001.";
        public static readonly string Checkout = "Checkout time is 10am. On request we can arrange for late checkout for a small fee.";
        public static readonly string Thanks = "Glad I could help.";
    }
}