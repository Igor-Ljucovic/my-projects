using static System.Math;

namespace QualityCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static double Quality(int wantedQualityLevel, int maxQualityLevel, double qualityChancePercent, double recyclerReturnPercent, double upcycleMultiplierPercent)
        {
            if (maxQualityLevel <= 1)
                throw new ArgumentException("Maximum quality level must be higher than 1.");
            if (wantedQualityLevel <= 1)
                throw new ArgumentException("Wanted quality level must be higher than 1.");
            if (qualityChancePercent < 1 || qualityChancePercent >= 100)
                throw new ArgumentException("Quality chance must be between 1 and 100");
            if (wantedQualityLevel > maxQualityLevel)
                throw new ArgumentException("Wanted quality level must be the same or lower than maximum quality level");

            double qualityChance = qualityChancePercent / 100;
            double recyclerReturn = recyclerReturnPercent / 100;
            double upcycleMultiplier = upcycleMultiplierPercent / 100;

            double uncommonChance = 1 - Enumerable.Range(0, maxQualityLevel - 1).Sum(i => Pow(upcycleMultiplier, i) * qualityChance);

            double maximumQualityChance = Quality(1, qualityChance * (1 + recyclerReturn * uncommonChance));

            return maximumQualityChance;

            double Quality(int currentQualityIncrement, double maxQualityLevelChanceInPercentages) => 
                currentQualityIncrement == wantedQualityLevel - 1
                ? maxQualityLevelChanceInPercentages
                : Quality(currentQualityIncrement + 1, maxQualityLevelChanceInPercentages * (recyclerReturn * qualityChance + upcycleMultiplier));
        }

        private void calculateQualityButton_Click(object sender, EventArgs e)
        {
            try
            {
                int maxQualityLevel = int.Parse(maximumQualityTextbox.Text);
                int wantedQualityLevel = int.Parse(wantedQualityTextbox.Text);
                double qualityChancePercent = double.Parse(totalQualityTextbox.Text);
                double recyclerReturnPercent = double.Parse(recyclerReturnTextbox.Text);
                double upcycleMultiplierPercent = double.Parse(upcycleTextbox.Text);

                double wantedQualityChance = Quality(wantedQualityLevel, maxQualityLevel, qualityChancePercent, recyclerReturnPercent, upcycleMultiplierPercent);

                CalculateQualityLabel.Text = 100 * wantedQualityChance + " %";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
