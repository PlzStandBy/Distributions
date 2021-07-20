using System;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;

namespace GenFunc
{
    class RandomlyExpoAllocatedValue
    {
        private double value;
        private double lambda = 1;

        public double Value
        {
            get
            {
                return value;
            }
        }

        public RandomlyExpoAllocatedValue(RandomGenerator random)
        {
            value = Math.Abs(Math.Log(random.Randomizer));
        }

        public double GetProbabilityDensity()
        {
            return Math.Exp((-lambda) * Value);
        }

    }


    public partial class ExponentialAlloc : Page
    {
        public ExponentialAlloc()
        {
            InitializeComponent();
            ChartInitialize();
            GenerateAndOutputNormalValues();
        }
        private void GenerateAndOutputNormalValues()
        {
            chartExpDensity.Series["DensityExp"].Points.Clear();
            RandomGenerator randomGenerator = new RandomGenerator();
            RandomlyExpoAllocatedValue exponentialAllocValue;

            for (int i = 0; i < 10000; i++)
            {
                exponentialAllocValue = new RandomlyExpoAllocatedValue(randomGenerator);
                chartExpDensity.Series["DensityExp"].Points.AddXY(exponentialAllocValue.Value, exponentialAllocValue.GetProbabilityDensity());
            }

        }
        private void ChartInitialize()
        {
            chartExpDensity.ChartAreas.Add(new ChartArea("Default"));
            chartExpDensity.Series.Add(new Series("DensityExp"));
            chartExpDensity.Series["DensityExp"].ChartArea = "Default";
            chartExpDensity.Series["DensityExp"].ChartType = SeriesChartType.Point;
            chartExpDensity.Titles.Add("ПЛОТНОСТЬ ВЕРОЯТНОСТИ"); ;
        }
    }
}
