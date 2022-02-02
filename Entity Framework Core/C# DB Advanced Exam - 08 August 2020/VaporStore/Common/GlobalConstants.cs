using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.Common
{
    public static class GlobalConstants
    {
        //User
        public const int USER_USERNAME_MAX_LENGTH = 20;

        public const int USER_USERNAME_MIN_LENGTH = 3;

        public const int USER_AGE_MIN_VALUE = 3;

        public const int USER_AGE_MAX_VALUE = 103;

        //Game
        public const int GAME_PRICE_MIN_VALUE = 0;

        //Card
        public const int CARD_NUMBER_LENGTH = 19;

        public const int CARD_CVC_LENGTH = 3;

        //Purchase
        public const int PURCHASE_PRODUCTKEY_LENGTH = 14;
    }
}
