using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBot
{
    public static class ChatResponse
    {
        public static readonly string Greeting = "Hi! I can answer your questions about Skyline Hotel. For reservations queries, please contact the hotel directly on + 61 2 98742001.";
        public static readonly string SwimmingPool = "Yes, we have a 25-meter indoor pool and a smaller outdoor pool for children.";

        public static readonly string Restaurant =
            "We have 4-star restaurant open for dinner from 5pm. Please make a reservation prior to your stay.";

        public static readonly string Wifi = "Yes, we have complimentary wifi for guests in bedrooms and dining area.";

        public static readonly string Location =
            "We are located on George Street in the city centre, a five minute walk to the Opera House and surrounded by shops, bars, restaurants and other tourist attractions.";

        public static readonly string Farewell = "Thanks for chatting. Goodbye.";

        public static readonly string Default = "Sorry I didn't understand. Can you say that again please?";
    }
}