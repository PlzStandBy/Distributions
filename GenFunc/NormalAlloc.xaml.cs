using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;


namespace GenFunc
{

    class RandomGenerator
    {
        Random randomizer = new Random();
        
        public double Randomizer
        {
            get
            {
                return randomizer.NextDouble();
            }
        }
    }
    class RandomlyNormalAllocatedValue
    {
        private double value;
        private double expectedValue = 0.5;
        private double dispersion = 0.08334;
        public double Value
        {
            get
            {
                return value;
            }
        }

        private int noCorrelatedValuesAmount = 200;
        public RandomlyNormalAllocatedValue(RandomGenerator random)
        {
            List<double> noCorrelatedValues = new List<double>();
            for(int i = 0; i < noCorrelatedValuesAmount; i++)
            {
                noCorrelatedValues.Add(random.Randomizer);
            }
            double averageValue = noCorrelatedValues.Average();
            noCorrelatedValues.Clear();
            this.value = ( (averageValue - expectedValue)/ Math.Sqrt(dispersion) ) * Math.Sqrt(noCorrelatedValuesAmount);
        }
        public double GetProbabilityDensity()
        {
            return ( ( 1/ Math.Sqrt(2 * Math.PI)) ) * (Math.Exp((-1)*( Math.Pow((value-expectedValue),2) / 2))  );
        }

    }
    

    public partial class NormalAlloc : Page
    {
        public NormalAlloc()
        {
            InitializeComponent();
            ChartInitialize();
            GenerateAndOutputNormalValues();

        }
        private void GenerateAndOutputNormalValues()
        {
            chartDensity.Series["Density"].Points.Clear();
            RandomGenerator randomGenerator = new RandomGenerator();
            RandomlyNormalAllocatedValue normalAllocValue;

            for (int i=0;i<10000;i++)
            {
                normalAllocValue = new RandomlyNormalAllocatedValue(randomGenerator);
                chartDensity.Series["Density"].Points.AddXY(normalAllocValue.Value, normalAllocValue.GetProbabilityDensity());
            }
        }
        private void ChartInitialize()
        {
            chartDensity.ChartAreas.Add(new ChartArea("Default"));
            chartDensity.Series.Add(new Series("Density"));
            chartDensity.Series["Density"].ChartArea = "Default";
            chartDensity.Series["Density"].ChartType = SeriesChartType.Point;
            chartDensity.Titles.Add("ПЛОТНОСТЬ ВЕРОЯТНОСТИ"); ;
        }
    }
}
