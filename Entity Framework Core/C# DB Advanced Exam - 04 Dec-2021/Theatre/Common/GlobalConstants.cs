using System;
using System.Collections.Generic;
using System.Text;

namespace Theatre.Common
{
    public class GlobalConstants
    {
        //Theatre
        public const int THEATRE_NAME_MAX_LENGTH = 30;

        public const int THEATRE_NAME_MIN_LENGTH = 4;

        public const sbyte THEATRE_NUMBEROFHALLS_MAX_VALUE = 10;

        public const sbyte THEATRE_NUMBEROFHALLS_MIN_VALUE = 1;

        public const int THEATRE_DIRECTOR_MAX_LENGTH = 30;

        public const int THEATRE_DIRECTOR_MIN_LENGTH = 4;

        //Play
        public const int PLAY_TITLE_MAX_LENGTH = 50;

        public const int PLAY_TITLE_MIN_LENGTH = 4;

        public const int PLAY_DURATION_MIN_LENGTH = 1;

        public const float PLAY_RATING_MAX_VALUE = 10.00F;

        public const float PLAY_RATING_MIN_VALUE = 0.00F;

        public const int PLAY_DESCRIPTION_MAX_LENGTH = 700;

        public const int PLAY_SCREENWRITER_MAX_LENGTH = 30;

        public const int PLAY_SCREENWRITER_MIN_LENGTH = 4;

        //Cast
        public const int CAST_FULLNAME_MAX_LENGTH = 30;

        public const int CAST_FULLNAME_MIN_LENGTH = 4;

        public const int CAST_PHONENUMBER_LENGTH = 15;

        //Ticket
        public const double TICKET_PRICE_MAX_VALUE = 100.00;

        public const double TICKET_PRICE_MIN_VALUE = 1.00;

        public const sbyte TICKET_ROWNUMBER_MAX_VALUE = 10;

        public const sbyte TICKET_ROWNUMBER_MIN_VALUE = 1;
    }
}
