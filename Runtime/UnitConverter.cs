namespace mgrosser3
{
    public static class UnitConverter
    {
        /// <summary>
        /// Converts a value in inches to a value in centimetres.
        /// </summary>
        /// <param name="value"></param>
        public static float InchesToCentimeters(float value)
        {
            return value * 2.54f;
        }

        /// <summary>
        /// Converts a value in inches to a value in centimetres.
        /// </summary>
        /// <param name="value"></param>
        public static float CentimetersToInches(float value)
        {
            return value / 2.54f;
        }
    }
}