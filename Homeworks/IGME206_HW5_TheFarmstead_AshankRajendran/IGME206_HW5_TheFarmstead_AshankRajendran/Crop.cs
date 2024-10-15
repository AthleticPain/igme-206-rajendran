namespace IGME206_HW5_TheFarmstead_AshankRajendran
{
    class Crop
    {
        //****************************
        //All variables here
        //****************************

        private string cropName;
        private double cost;
        private int growthTime;
        private int daysLeft;

        //****************************
        //Properties
        //****************************

        public bool CanHarvest
        {
            get
            {
                if (daysLeft == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public double SellingPrice
        {
            get
            {
                return cost * growthTime;
            }
        }

        public string CropName
        {
            get
            {
                return cropName;
            }
            set
            {
                cropName = value;
            }
        }

        public double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }

        public int GrowthTime
        {
            get
            {
                return growthTime;
            }
            set
            {
                growthTime = value;
            }
        }

        public int DaysLeft
        {
            get
            {
                return daysLeft;
            }
            set
            {
                daysLeft = value;
            }
        }

        //****************************
        //Constructors
        //****************************

        //Parameterized Constructor
        /// <summary>
        /// Initializes a new instance of the Crop class
        /// </summary>
        /// <param name="name">Name of the crop</param>
        /// <param name="cost">Cost of planting the crop</param>
        /// <param name="growthTime">Number of time in days it takes for 
        /// crop to be ready for harvest</param>
        public Crop(string name, double cost, int growthTime)
        {
            this.cropName = name;
            this.cost = cost;
            this.growthTime = growthTime;
            daysLeft = growthTime;
        }

        //Copy Constructor
        /// <summary>
        /// Initializes a new instance of the Crop class as a copy of another crop.
        /// </summary>
        /// <param name="other">The crop to copy.</param>
        public Crop(Crop other)
            :   this(other.cropName, other.cost, other.growthTime)
        {
            // No code here!
        }

        //****************************
        //Methods
        //****************************

        /// <summary>
        /// Decrements the days left till crop is ready for harvest
        /// </summary>
        public void DayPassed()
        {
            if (daysLeft > 0)
            {
                daysLeft--;
            }
        }
        /// <summary>
        /// Displays a summary of the crop status
        /// </summary>
        /// <returns>string of selling price if ready to harvest or 
        /// string with days left if not ready to harvest</returns>
        public override string ToString()
        {
            if(CanHarvest)
            {
                return string.Format("{0} is ready to harvest for {1:c}.", 
                    cropName, SellingPrice);
            }
            else
            {
                return string.Format("{0} has {1} days left to harvest.", 
                    cropName, daysLeft);
            }
        }

    }
}
